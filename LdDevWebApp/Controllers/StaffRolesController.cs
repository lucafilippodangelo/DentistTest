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
    public class StaffRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaffRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffRoles.ToListAsync());
        }

        // GET: StaffRoles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRole = await _context.StaffRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffRole == null)
            {
                return NotFound();
            }

            return View(staffRole);
        }

        // GET: StaffRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Role,Note")] StaffRole staffRole)
        {
            if (ModelState.IsValid)
            {
                staffRole.Id = Guid.NewGuid();
                _context.Add(staffRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffRole);
        }

        // GET: StaffRoles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRole = await _context.StaffRoles.FindAsync(id);
            if (staffRole == null)
            {
                return NotFound();
            }
            return View(staffRole);
        }

        // POST: StaffRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Role,Note")] StaffRole staffRole)
        {
            if (id != staffRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffRoleExists(staffRole.Id))
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
            return View(staffRole);
        }

        // GET: StaffRoles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRole = await _context.StaffRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffRole == null)
            {
                return NotFound();
            }

            return View(staffRole);
        }

        // POST: StaffRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var staffRole = await _context.StaffRoles.FindAsync(id);
            _context.StaffRoles.Remove(staffRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffRoleExists(Guid id)
        {
            return _context.StaffRoles.Any(e => e.Id == id);
        }
    }
}
