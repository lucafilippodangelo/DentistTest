using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using LdDevWebApp.Models.Entities;
using DentistCore2._2.Data;
using SmartBreadcrumbs.Attributes;

namespace LdDevWebApp.Controllers
{
    public class StaffRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Breadcrumb("Staff Roles")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffRoles.ToListAsync());
        }

        [Breadcrumb("Details", FromAction = "Index")]
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

        [Breadcrumb("Create", FromAction = "Index")]
        public IActionResult Create()
        {
            return View();
        }

        [Breadcrumb("Create", FromAction = "Index")]
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

        [Breadcrumb("Edit", FromAction = "Index")]
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

        [Breadcrumb("Edit", FromAction = "Index")]
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

        [Breadcrumb("Delete", FromAction = "Index")]
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

        [Breadcrumb("Delete", FromAction = "Index")]
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
