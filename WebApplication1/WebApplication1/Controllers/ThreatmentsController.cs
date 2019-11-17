using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DentistCore2._2.Data;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class ThreatmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThreatmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Threatments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Threatment.ToListAsync());
        }

        // GET: Threatments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threatment = await _context.Threatment
                .FirstOrDefaultAsync(m => m.ThreatmentId == id);
            if (threatment == null)
            {
                return NotFound();
            }

            return View(threatment);
        }

        // GET: Threatments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Threatments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Duration,Description,IsActive")] Threatment threatment)
        {
            if (ModelState.IsValid)
            {
                threatment.ThreatmentId = Guid.NewGuid();
                _context.Add(threatment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(threatment);
        }

        // GET: Threatments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threatment = await _context.Threatment.FindAsync(id);
            if (threatment == null)
            {
                return NotFound();
            }
            return View(threatment);
        }

        // POST: Threatments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Duration,Description,IsActive")] Threatment threatment)
        {
            if (id != threatment.ThreatmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(threatment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThreatmentExists(threatment.ThreatmentId))
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
            return View(threatment);
        }

        // GET: Threatments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threatment = await _context.Threatment
                .FirstOrDefaultAsync(m => m.ThreatmentId == id);
            if (threatment == null)
            {
                return NotFound();
            }

            return View(threatment);
        }

        // POST: Threatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var threatment = await _context.Threatment.FindAsync(id);
            _context.Threatment.Remove(threatment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThreatmentExists(Guid id)
        {
            return _context.Threatment.Any(e => e.ThreatmentId == id);
        }
    }
}
