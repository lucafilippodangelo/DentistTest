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
            return View(await _context.Staff.ToListAsync());
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .FirstOrDefaultAsync(m => m.giudPersonId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("staffNote,giudPersonId,name,surname,phone,personNote,mail")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                staff.giudPersonId = Guid.NewGuid();
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
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("staffNote,giudPersonId,name,surname,phone,personNote,mail")] Staff staff)
        {
            if (id != staff.giudPersonId)
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
                    if (!StaffExists(staff.giudPersonId))
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
                .FirstOrDefaultAsync(m => m.giudPersonId == id);
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
            return _context.Staff.Any(e => e.giudPersonId == id);
        }
    }
}
