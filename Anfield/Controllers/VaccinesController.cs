using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Anfield.Data;
using Anfield.Models;

namespace Anfield.Controllers
{
    public class VaccinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VaccinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vaccines
        public async Task<IActionResult> Index()
        {
              return _context.Vaccine != null ? 
                          View(await _context.Vaccine.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Vaccine'  is null.");
        }

        // GET: Vaccines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vaccine == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccine
                .FirstOrDefaultAsync(m => m.VaccineId == id);
            if (vaccine == null)
            {
                return NotFound();
            }

            return View(vaccine);
        }

        // GET: Vaccines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vaccines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VaccineId,VaccineName,VaccineType,VaccineDescription")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaccine);
        }

        // GET: Vaccines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vaccine == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccine.FindAsync(id);
            if (vaccine == null)
            {
                return NotFound();
            }
            return View(vaccine);
        }

        // POST: Vaccines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VaccineId,VaccineName,VaccineType,VaccineDescription")] Vaccine vaccine)
        {
            if (id != vaccine.VaccineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccineExists(vaccine.VaccineId))
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
            return View(vaccine);
        }

        // GET: Vaccines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vaccine == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccine
                .FirstOrDefaultAsync(m => m.VaccineId == id);
            if (vaccine == null)
            {
                return NotFound();
            }

            return View(vaccine);
        }

        // POST: Vaccines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vaccine == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vaccine'  is null.");
            }
            var vaccine = await _context.Vaccine.FindAsync(id);
            if (vaccine != null)
            {
                _context.Vaccine.Remove(vaccine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccineExists(int id)
        {
          return (_context.Vaccine?.Any(e => e.VaccineId == id)).GetValueOrDefault();
        }
    }
}
