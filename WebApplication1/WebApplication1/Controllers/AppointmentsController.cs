using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LdDevWebApp.Models.Entities;
using LdDevWebApp.BehavioralPatterns.AppointmentStatuses;
using LdDevWebApp.Models.Enums;
using System.Collections;
using DentistCore2._2.Data;
using System.Threading;
using DentistCore2._2.SignalR;
using MailClassLibrary;
using Microsoft.AspNetCore.Authorization;
using DentistCore2._2.Models;
using DentistCore2._2.Utilities;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.SignalR;
using SmartBreadcrumbs.Attributes;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.Helpers;

namespace LdDevWebApp.Controllers
{
    [DefaultBreadcrumb("My Home Page")]
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMailService _mailService;
        List<Appointment> letsSee;

        
        public AppointmentsController(ApplicationDbContext context, IHubContext<AnHub> hubcontext, IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }

        //[Authorize]
        public async Task<IActionResult> Index()
        {
            var appointments = _context.Appointments.AsNoTracking()
                                       .Include(app => app.Practise).AsNoTracking()
                                       .Include(a=>a.Patient).AsNoTracking()
                                       .OrderBy(app => app.When)
                                       .ToListAsync();
            letsSee = await appointments;

            //after retrieving from database then I set not mapped attributes
            letsSee.ForEach(p => p.setAptStateObject());

            return View(letsSee);
        }

        //[Authorize]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                                            .Include(a => a.AppointmentLogs)
                                            .Include(a => a.Practise)
                                            .Where(a => a.Id == id)
                                            .SingleOrDefaultAsync();
            if (appointment == null)
            {
                return NotFound();
            }
            else {
                appointment.setAptStateObject();
                return View(appointment);
            }
        }


        /// <summary>
        /// This method to send email for the specific appointment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize]
        public async Task<IActionResult> SendMail(Guid? id)
        {
            return await _mailService.SendMail(id);
        }


        //[Authorize]
        public IActionResult Create()
        {
            // add informations to select staff
            ViewBag.Staff = new MultiSelectList(_context.Staff, "Id", "DisplayName", new[] { Guid.Parse ("ee243d91-ddf1-48f6-827d-0bfa6616bae1") }); //sourse, Key, Value, Default array list

            var luca = _context.Threatment;
            ViewBag.Threatment = new MultiSelectList(luca, "ThreatmentId", "Name"); 

            // add info to select "IsActive" patients
            ViewData["Patients"] = new SelectList(_context.Patient.Where(p => p.IsActive == true), "Id", "DisplayName");

            // add info to select "IsActive" patients
            ViewData["Practises"] = new SelectList(_context.Practises.Where(p => p.IsActive == true), "Id", "Name");

            return View();
        }

        [HttpPost]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,When,Notes,Patient,Practise")] Appointment aptBind, Guid[] Id, Guid[] ThreatmentId)
        {
            //Got rid of model validations for "Patient", once just the Id is returned and I do not need to run any check at this stage
            ModelState.Remove("Patient.Name");
            ModelState.Remove("Patient.Email");
            ModelState.Remove("Patient.Surname");
            if (ModelState.IsValid)
            {
                aptBind.Id = Guid.NewGuid();

                // map staff for appointment
                IList<Guid> aptStaffList = new List<Guid>(Id);
                List<AppointmentStaff> anList = new List<AppointmentStaff>();
                foreach (Guid aGuidInList in aptStaffList)
                {
                    anList.Add(new AppointmentStaff
                    {
                        AppointmentId = aptBind.Id,
                        StaffId = aGuidInList
                    }) ;
                }
                aptBind.AppointmentStaff = anList;

                // map Threatments for an appointment 
                IList<Guid> aptThreatmentList = new List<Guid>(ThreatmentId);
                List<AppointmentThreatment> aList = new List<AppointmentThreatment>();
                foreach (Guid aGuidInList in aptThreatmentList)
                {
                    aList.Add(new AppointmentThreatment
                    {
                        AppointmentId = aptBind.Id,
                        ThreatmentId = aGuidInList
                    });
                }
                aptBind.AppointmentThreatment = aList;

                aptBind.Patient = _context.Patient.FirstOrDefault(p => p.Id == aptBind.Patient.Id);

                aptBind.Practise = _context.Practises .FirstOrDefault(p => p.Id == aptBind.Practise.Id);

                aptBind.UpdateStatus (AptStatusesEnum.st["Initial"]);

                _context.Add(aptBind);

                //LD Update Logs
                AppointmentLog anAptLog = new AppointmentLog { Information = "created app id " + aptBind.Id, When = DateTime.UtcNow ,  Appointment = aptBind };
                _context.Add(anAptLog);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            return View(aptBind);
        }


        //[Authorize]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //LD getting appointment by "Id" and related staff
            //var appointment = _context.Appointments.Include(x => x.AppointmentStaff).Where (w => w.Id == id).Single();
            var appointment = await _context.Appointments
                                            .Include(x => x.AppointmentStaff)
                                            .Include (pa => pa.Patient).AsNoTracking() //LD to avoid Key conflict when updating related entity in post
                                            .Include(pr => pr.Practise).AsNoTracking() //LD to avoid Key conflict when updating related entity in post
                                            .FirstOrDefaultAsync(w => w.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }
            else {
                appointment.setAptStateObject();//appointment.setAptStateObject();

                //LD managing the state of the appointment
                var subKeyValue = AptStatusesEnum.st
                                  .Where(d => d.Value == AptStatusesEnum.st["Initial"] || d.Value == AptStatusesEnum.st["Aborted"])
                                  .ToList();
                // 'SelectList' explanation: 
                //parm -> 'inputlist' is 'subKeyValue'
                //parm -> "my DATAVALUE in my dictionary is the 'Value' so the guid. it is what will be returned as 'StatusID' in post edit"
                //parm -> "my DATATEXT in my dictionary is the 'Key' so the text like 'Initial' "
                //parm -> "appointment.StatusID" is the default value that has to match DATAVALUE type
                ViewData["AptStatus"] = new SelectList(subKeyValue, "Value", "Key", appointment.StatusID.ToString ());

                // managing patients for appointment with default
                ViewData["Patients"] = new SelectList(_context.Patient.AsNoTracking ().Where(p => p.IsActive == true), "Id", "DisplayName", appointment.Patient.Id);

                // add info to select "IsActive" patients
                ViewData["Practises"] = new SelectList(_context.Practises.Where(p => p.IsActive == true), "Id", "Name", appointment.Practise.Id);

                //LD managing the staff for the appointment
                var listSelectedStaffIds = appointment.AppointmentStaff.Select(s => s.StaffId).ToList();
                ViewBag.Staff = new MultiSelectList(_context.Staff, "Id", "DisplayName", listSelectedStaffIds); //source, Key, Value, Default 

                return View(appointment);
            }
            
        }

        [HttpPost]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,When,Notes,StatusID,Patient,Practise")] Appointment aptBind, Guid[] staffSelectedAptBind)
        {
            //Got rid of model validations for "Patient", once just the Id is returned and I do not need to run any check at this stage
            ModelState.Remove("Patient.Name");
            ModelState.Remove("Patient.Email");
            ModelState.Remove("Patient.Surname");

            if (id != aptBind.Id)
            {
                return NotFound();
            }

            // Business-Logic, need to check if state is not initial that: patient,practise,aptStaff,Threatments,when -> are not changed 
            // In case a model error is added
            updatingNotAllowedFieldsForSelectedState(aptBind, staffSelectedAptBind);
           
            if (ModelState.IsValid)
            {
                try
                {
                    UpdateAppointment(staffSelectedAptBind, aptBind);

                    AppointmentLog anAptLog = new AppointmentLog { Information = "UPDATED app " + aptBind.Id, When = DateTime.UtcNow, Appointment = aptBind };
                    _context.Add(anAptLog);

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    if (!AppointmentExists(aptBind.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. ");
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            //In the case the model is not valid, I need to reload the edit page with the submitted values
            var subKeyValue = AptStatusesEnum.st
                  .Where(d => d.Value == AptStatusesEnum.st["Initial"] || d.Value == AptStatusesEnum.st["Aborted"])
                  .ToList();
            ViewData["AptStatus"] = new SelectList(subKeyValue, "Value", "Key", aptBind.StatusID.ToString());

            // managing patients for appointment with default
            ViewData["Patients"] = new SelectList(_context.Patient.Where(p => p.IsActive == true), "Id", "DisplayName", aptBind.Patient.Id.ToString());

            // add info to select "IsActive" practises
            ViewData["Practises"] = new SelectList(_context.Practises.Where(p => p.IsActive == true), "Id", "Name", aptBind.Practise.Id.ToString());

            //LD managing the staff for the appointment
            ViewBag.Staff = new MultiSelectList(_context.Staff, "Id", "DisplayName", staffSelectedAptBind); //source, Key, Value, Default 

            return View(aptBind);
        }

        //[Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        //[Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool AppointmentExists(Guid id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }

        //========================================================================================================================

        /// <summary>
        /// This method updates the appointment related "Staff" Entity
        /// 
        /// https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/update-related-data?view=aspnetcore-2.2
        /// </summary>
        /// <param name="SelectedAptStaff"></param>
        /// <param name="aptToUpdate"></param>
        private void UpdateAppointment(Guid[] staffSelectedAptBind, Appointment aptBind)
        {
            // ------------------------------------------------------------------------------------------------------------------------------------
            //LD the query below is useful only to retrieve the currently staff saved in database for the appointment in context 
            var currentDbApt = _context.Appointments
                .Include(pa => pa.Patient)
                .Include(pr => pr.Practise)
                .Include(x => x.AppointmentStaff)
                        .ThenInclude(x => x.Staff)
                        .FirstOrDefault(w => w.Id == aptBind.Id);

            //LD just binding what received in input on the main "Appointment" Object
            currentDbApt.When = aptBind.When;
            currentDbApt.Notes = aptBind.Notes;
            currentDbApt.StatusID = aptBind.StatusID;

            currentDbApt.PatientId = aptBind.Patient.Id;
            currentDbApt.PractiseId = aptBind.Practise.Id;

            // ------------------------------------------------------------------------------------------------------------------------------------
            // LD need to update NtoN "AppointmentStaff". The idea is to remove from the apt in context the existing staff list and replace with the currently replaced one.
            if (staffSelectedAptBind == null)
            {
                aptBind.AppointmentStaff = new List<AppointmentStaff>();
                return;
            }

            var staffSelectedAptBindHS = new HashSet<Guid>(staffSelectedAptBind); //the selected staff in edit
            var currentDbAptStaffHS = new HashSet<Guid>(currentDbApt.AppointmentStaff.Select(c => c.Staff.Id )); //list of staff for the appointment

            foreach (var aStaff in _context.Staff)
            {
                if (staffSelectedAptBindHS.Contains(aStaff.Id))
                {
                    if (!currentDbAptStaffHS.Contains(aStaff.Id))
                        //then add in the appointment
                        currentDbApt.AppointmentStaff.Add(new AppointmentStaff { AppointmentId = aptBind.Id, StaffId = aStaff.Id });
                }
                else 
                if (currentDbAptStaffHS.Contains(aStaff.Id))
                {
                    //need to REMOVE FROM THE CONTEXT what not selected anymore 
                    AppointmentStaff appointmentStaffToRemove = currentDbApt.AppointmentStaff.FirstOrDefault(i => i.StaffId == aStaff.Id);
                    
                    _context.Remove(appointmentStaffToRemove); // it was possible even to do -> //aptBind.AppointmentStaff.Remove(appointmentStaffToRemove);
                }
            }

            _context.Update(currentDbApt);

        }

        /// <summary>
        /// This method checks when state is "not initial" that: patient,practise,aptStaff,Threatments,when -> are not changed 
        /// add modelState errors if some fields are changed when selecting "Aborted" 
        /// </summary>
        /// <param name="aptBind"></param>
        /// <param name="staffSelectedAptBind"></param>
        /// <returns></returns>
        private bool updatingNotAllowedFieldsForSelectedState(Appointment aptBind, Guid[] staffSelectedAptBind)
        {
            //LD current appointment and related info
            var currentDbApt = _context.Appointments.AsNoTracking()
                        .Include(p => p.Patient).AsNoTracking()
                        .Include(pr => pr.Practise).AsNoTracking()
                        .Include(x => x.AppointmentStaff)
                        .ThenInclude(x => x.Staff)
                        .FirstOrDefault(w => w.Id == aptBind.Id);

            var staffSelectedAptBindHS = new HashSet<Guid>(staffSelectedAptBind); //the selected staff in edit
            var currentDbAptStaffHS = new HashSet<Guid>(currentDbApt.AppointmentStaff.Select(c => c.Staff.Id)); //list of staff for the appointment

                var dirty = false;
            if (aptBind.StatusID != AptStatusesEnum.st["Initial"])
            {
                if (!staffSelectedAptBindHS.Overlaps (currentDbAptStaffHS)) //if the two hashsets does not share the same content
                {
                    dirty = true;
                    ModelState.AddModelError("", "Impossible to update Staff Appointment when State is not Initial");
                }
                if (aptBind.Patient.Id != currentDbApt.Patient.Id)
                {
                    dirty = true;
                    ModelState.AddModelError("", "Impossible to update Patient when State is not Initial");
                }
                if (aptBind.When != currentDbApt.When)
                {
                    dirty = true;
                    ModelState.AddModelError("", "Impossible to update Date Time when State is not Initial");
                }
            }
            return dirty;

        }

    }
}
