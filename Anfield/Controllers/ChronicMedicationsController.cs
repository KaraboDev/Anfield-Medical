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
    public class ChronicMedicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChronicMedicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChronicMedications
        public async Task<IActionResult> Index()
        {
              return _context.ChronicMedication != null ? 
                          View(await _context.ChronicMedication.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ChronicMedication'  is null.");
        }

        // GET: ChronicMedications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChronicMedication == null)
            {
                return NotFound();
            }

            var chronicMedication = await _context.ChronicMedication
                .FirstOrDefaultAsync(m => m.MedicationId == id);
            if (chronicMedication == null)
            {
                return NotFound();
            }

            return View(chronicMedication);
        }

        // GET: ChronicMedications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChronicMedications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicationId,MedicationName,Dosage,RouteOfAdministration,StartDate,EndDate,SideEffects")] ChronicMedication chronicMedication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chronicMedication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chronicMedication);
        }

        // GET: ChronicMedications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChronicMedication == null)
            {
                return NotFound();
            }

            var chronicMedication = await _context.ChronicMedication.FindAsync(id);
            if (chronicMedication == null)
            {
                return NotFound();
            }
            return View(chronicMedication);
        }

        // POST: ChronicMedications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicationId,MedicationName,Dosage,RouteOfAdministration,StartDate,EndDate,SideEffects")] ChronicMedication chronicMedication)
        {
            if (id != chronicMedication.MedicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chronicMedication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChronicMedicationExists(chronicMedication.MedicationId))
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
            return View(chronicMedication);
        }

        // GET: ChronicMedications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChronicMedication == null)
            {
                return NotFound();
            }

            var chronicMedication = await _context.ChronicMedication
                .FirstOrDefaultAsync(m => m.MedicationId == id);
            if (chronicMedication == null)
            {
                return NotFound();
            }

            return View(chronicMedication);
        }

        // POST: ChronicMedications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChronicMedication == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ChronicMedication'  is null.");
            }
            var chronicMedication = await _context.ChronicMedication.FindAsync(id);
            if (chronicMedication != null)
            {
                _context.ChronicMedication.Remove(chronicMedication);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChronicMedicationExists(int id)
        {
          return (_context.ChronicMedication?.Any(e => e.MedicationId == id)).GetValueOrDefault();
        }
    }
}
