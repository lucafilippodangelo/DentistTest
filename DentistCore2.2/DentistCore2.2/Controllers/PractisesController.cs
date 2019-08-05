using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LdDevWebApp.Models.Entities;
using DentistCore2._2.Data;

namespace LdDevWebApp.Controllers
{
    public class PractisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PractisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Practises
        public async Task<IActionResult> Index()
        {
            return View(await _context.Practises.ToListAsync());
        }

        // GET: Practises/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practise = await _context.Practises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (practise == null)
            {
                return NotFound();
            }

            return View(practise);
        }

        // GET: Practises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Practises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Note")] Practise practise)
        {
            if (ModelState.IsValid)
            {
                practise.Id = Guid.NewGuid();
                _context.Add(practise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(practise);
        }

        // GET: Practises/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practise = await _context.Practises.FindAsync(id);
            if (practise == null)
            {
                return NotFound();
            }
            return View(practise);
        }

        // POST: Practises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Note")] Practise practise)
        {
            if (id != practise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(practise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PractiseExists(practise.Id))
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
            return View(practise);
        }

        // GET: Practises/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practise = await _context.Practises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (practise == null)
            {
                return NotFound();
            }

            return View(practise);
        }

        // POST: Practises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var practise = await _context.Practises.FindAsync(id);
            _context.Practises.Remove(practise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PractiseExists(Guid id)
        {
            return _context.Practises.Any(e => e.Id == id);
        }
    }
}
