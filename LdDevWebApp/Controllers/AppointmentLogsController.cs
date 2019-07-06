using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LdDevWebApp.Data;
using LdDevWebApp.Models.Entities;

namespace LdDevWebApp.Controllers
{
    public class AppointmentLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppointmentLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppointmentLogs.ToListAsync());
        }

        // GET: AppointmentLogs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentLog = await _context.AppointmentLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentLog == null)
            {
                return NotFound();
            }

            return View(appointmentLog);
        }

        // GET: AppointmentLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppointmentLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,When,Information")] AppointmentLog appointmentLog)
        {
            if (ModelState.IsValid)
            {
                appointmentLog.Id = Guid.NewGuid();
                _context.Add(appointmentLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appointmentLog);
        }

        // GET: AppointmentLogs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentLog = await _context.AppointmentLogs.FindAsync(id);
            if (appointmentLog == null)
            {
                return NotFound();
            }
            return View(appointmentLog);
        }

        // POST: AppointmentLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,When,Information")] AppointmentLog appointmentLog)
        {
            if (id != appointmentLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentLogExists(appointmentLog.Id))
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
            return View(appointmentLog);
        }

        // GET: AppointmentLogs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentLog = await _context.AppointmentLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentLog == null)
            {
                return NotFound();
            }

            return View(appointmentLog);
        }

        // POST: AppointmentLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var appointmentLog = await _context.AppointmentLogs.FindAsync(id);
            _context.AppointmentLogs.Remove(appointmentLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentLogExists(Guid id)
        {
            return _context.AppointmentLogs.Any(e => e.Id == id);
        }
    }
}
