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

namespace LdDevWebApp.Controllers
{

    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IViewRenderService _viewRenderService;
        List<Appointment> letsSee;
        private readonly IHubContext<AnHub> _hub;

        public AppointmentsController(ApplicationDbContext context, IViewRenderService viewRenderService, IHubContext<AnHub> hubcontext)
        {
            _context = context;
            _viewRenderService = viewRenderService;
            _hub = hubcontext;
        }

        // GET: Appointments
        
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Appointments.ToListAsync());

            var appointments = _context.Appointments.Include(app => app.Practise)
            .OrderBy(app => app.When)
            .AsNoTracking()
            .ToListAsync()
            ;
            letsSee = await appointments;

            //after retrieving from database then I set not mapped attributes
            letsSee.ForEach(p => p.setAptStateObject());

            //Success("Loading index");
            //if (mailSent == true) await _hub.Clients.All.SendAsync("ReceiveMessage", "primo", "secondo", "danger");

            return View(letsSee);
        }

        // GET: Appointments/Details/5
        //[ActionName("Appointments/Details")]
        [Authorize]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.Include(a => a.AppointmentLogs).Include(a => a.Practise)
                .Where(a => a.Id == id).SingleOrDefaultAsync()
                ;
            if (appointment == null)
            {
                return NotFound();
            }
            else {
                appointment.setAptStateObject();

                //LD NEED TO BE ASYNC
                //Utility.SendMailTest(new List<UserActions>() { new UserActions {  actionId = 1, content = "link to confirm"},
                //new UserActions {  actionId = 2, content = "link to cancel"},
                //new UserActions {  actionId = 3, content = "link to call me back"}}
                //) ;

                //LD START MAIL SENDING
                string urlAction = Url.Action("Details", "Appointments", new { id = id.Value }, "http");
                string test = "Details/" + id.Value.ToString();

                var aCustomInfo = new CustomInfo { DateTime = DateTime.Now, ActionEnumerator = 1, AppointmentId = id.Value, InternalKey = "abc", LandingLink = urlAction };

                //string Body = Rendering.RenderPartialToString("UserAct/Landing", aCustomInfo, this.ControllerContext, _viewEngine);

                try
                {
                    var Body = await _viewRenderService.RenderToStringAsync("UserAct/Landing", aCustomInfo);
                    ProcessMail.SendMail("info@lucadangelo.it", "Subject", Body);//(user.Email, subject, composedMail);
                }
                catch (Exception ex)
                {
                    var luca = "";
                    //CustomLogErrorStoring.storeErrorLog(ex, "User", "AdministrationUserCreateP", true);
                }
                //LD END MAIL SENDING

                return View(appointment);
            }
        }


        /// <summary>
        /// this is a sync method should not be used
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> SendMail(Guid? id)
        {

            //LD NEED TO BE ASYNC
            //Utility.SendMailTest(new List<UserActions>() { new UserActions {  actionId = 1, content = "link to confirm"},
            //new UserActions {  actionId = 2, content = "link to cancel"},
            //new UserActions {  actionId = 3, content = "link to call me back"}}
            //) ;

            var appointment = await _context.Appointments.Where(a => a.Id == id).SingleOrDefaultAsync();
            if (appointment == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    string urlRoute = Url.RouteUrl("Custom", new { id = id.Value }, "http");
                    var aCustomInfo = new CustomInfo { DateTime = DateTime.Now, ActionEnumerator = 1, AppointmentId = id.Value, InternalKey = "abc", LandingLink = urlRoute };
                    var Body = await _viewRenderService.RenderToStringAsync("UserAct/Landing", aCustomInfo);

                    ProcessMail.SendMail("info@lucadangelo.it", "Subject", Body);

                    appointment.UpdateStatus(AptStatusesEnum.st["MailSent"]);
                }
                catch (Exception ex)
                {
                    appointment.UpdateStatus(AptStatusesEnum.st["MailSendError"]);
                }

                _context.Update(appointment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// this endpoint has to be called from ajax so no post to new action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize]
        public async void SendMailAsync(Guid? id)
        {

            //LD NEED TO BE ASYNC
            //Utility.SendMailTest(new List<UserActions>() { new UserActions {  actionId = 1, content = "link to confirm"},
            //new UserActions {  actionId = 2, content = "link to cancel"},
            //new UserActions {  actionId = 3, content = "link to call me back"}}
            //) ;

            var appointment = _context.Appointments.Where(a => a.Id == id).SingleOrDefaultAsync();
            if (appointment != null)
            {
      
                //try
                //{
                //    string urlRoute = Url.RouteUrl("Custom", new { id = id.Value }, "http");
                //    var aCustomInfo = new CustomInfo { DateTime = DateTime.Now, ActionEnumerator = 1, AppointmentId = id.Value, InternalKey = "abc", LandingLink = urlRoute };
                //    var Body =  _viewRenderService.RenderToStringAsync("UserAct/Landing", aCustomInfo);

                //    ProcessMail.SendMail("info@lucadangelo.it", "Subject", Body);

                //    appointment.UpdateStatus(AptStatusesEnum.st["MailSent"]);
                //}
                //catch (Exception ex)
                //{
                //    appointment.UpdateStatus(AptStatusesEnum.st["MailSendError"]);
                //}

                //_context.Update(appointment);
                //_context.SaveChangesAsync();
            }

            await _hub.Clients.All.SendAsync("ReceiveMessage", "primo", "secondo", "danger");
        }



        // GET: Appointments/Create
        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,When,Notes")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.Id = Guid.NewGuid();
                appointment.UpdateStatus (AptStatusesEnum.st["Initial"]);
                _context.Add(appointment);

                AppointmentLog anAptLog = new AppointmentLog { Information = "created app id " + appointment.Id, When = DateTime.UtcNow ,  Appointment = appointment };
                _context.Add(anAptLog);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

                
            }

            return View(appointment);
        }

        // GET: Appointments/Edit/5
        //[Authorize]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);


            if (appointment == null)
            {
                return NotFound();
            }
            else {
                appointment.setAptStateObject();

                var subKeyValue = AptStatusesEnum.st
                                  .Where(d => d.Value == AptStatusesEnum.st["Initial"] || d.Value == AptStatusesEnum.st["Aborted"])
                                  .ToList();
                // 'SelectList' explanation: 
                //parm -> 'inputlist' is 'subKeyValue'
                //parm -> "my DATAVALUE in my dictionary is the 'Value' so the guid. it is what will be returned as 'StatusID' in post edit"
                //parm -> "my DATATEXT in my dictionary is the 'Key' so the text like 'Initial' "
                //parm -> "appointment.StatusID" is the default value that has to match DATAVALUE type
                ViewData["AptStatus"] = new SelectList(subKeyValue, "Value", "Key", appointment.StatusID.ToString ());
                return View(appointment);
            }
           
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,When,Notes,StatusID")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    AppointmentLog anAptLog = new AppointmentLog { Information = "UPDATED app " + appointment.Id, When = DateTime.UtcNow, Appointment = appointment };
                    _context.Add(anAptLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
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

        // POST: Appointments/Delete/5
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
    }
}
