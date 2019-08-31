using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LdDevWebApp.Models.Entities;
using DentistCore2._2.Data;
using DentistCore2._2.SignalR;

namespace LdDevWebApp.Controllers
{
    public class StaffsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Staffs
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Staff.ToListAsync()); //LD before I was returning a simple list

            var staff = _context.Staff
                .Include(sta => sta.StaffRole)
                .AsNoTracking();

            var xx = await staff.ToListAsync();
            return View(xx);
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.Include(s => s.StaffRole)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            ViewData["StaffRole"] = new SelectList(_context.StaffRoles ,"Id","Role");
            return View();
        }


        //private void PopulateStaffList(object selectedStaffRole = null)
        //{
        //    var staffRoleQuery = from s in _context.StaffRoles 
        //                           orderby s.Role 
        //                           select s;
        //    ViewBag.StaffRoleId = new SelectList(staffRoleQuery.AsNoTracking(), "StaffRoleId", "Role", selectedStaffRole);

        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Phone,Email,Note,StaffRoleID")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                staff.Id = Guid.NewGuid();
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["StaffRole"] = new SelectList(_context.StaffRoles, "Id", "Role", staff.StaffRoleID); //Passing the default value "staff.StaffRoleID"
            return View(staff);
        }

        // POST: Staffs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Surname,Phone,Email,Note,StaffRoleID")] Staff staff)
        {
            if (id != staff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.Id))
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
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var staff = await _context.Staff.FindAsync(id);
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(Guid id)
        {
            return _context.Staff.Any(e => e.Id == id);
        }

        #region Support method
        #endregion
    }
}
