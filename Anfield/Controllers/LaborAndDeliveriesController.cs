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
    public class LaborAndDeliveriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LaborAndDeliveriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LaborAndDeliveries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LaborAndDeliveries.Include(l => l.Patient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LaborAndDeliveries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LaborAndDeliveries == null)
            {
                return NotFound();
            }

            var laborAndDelivery = await _context.LaborAndDeliveries
                .Include(l => l.Patient)
                .FirstOrDefaultAsync(m => m.LaborAndDeliveryId == id);
            if (laborAndDelivery == null)
            {
                return NotFound();
            }

            return View(laborAndDelivery);
        }

        // GET: LaborAndDeliveries/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "ContactNumber");
            return View();
        }

        // POST: LaborAndDeliveries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LaborAndDeliveryId,PatientId,LaborStartDate,DeliveryDate,DeliveryMethod")] LaborAndDelivery laborAndDelivery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laborAndDelivery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "ContactNumber", laborAndDelivery.PatientId);
            return View(laborAndDelivery);
        }

        // GET: LaborAndDeliveries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LaborAndDeliveries == null)
            {
                return NotFound();
            }

            var laborAndDelivery = await _context.LaborAndDeliveries.FindAsync(id);
            if (laborAndDelivery == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "ContactNumber", laborAndDelivery.PatientId);
            return View(laborAndDelivery);
        }

        // POST: LaborAndDeliveries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LaborAndDeliveryId,PatientId,LaborStartDate,DeliveryDate,DeliveryMethod")] LaborAndDelivery laborAndDelivery)
        {
            if (id != laborAndDelivery.LaborAndDeliveryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laborAndDelivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaborAndDeliveryExists(laborAndDelivery.LaborAndDeliveryId))
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
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "ContactNumber", laborAndDelivery.PatientId);
            return View(laborAndDelivery);
        }

        // GET: LaborAndDeliveries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LaborAndDeliveries == null)
            {
                return NotFound();
            }

            var laborAndDelivery = await _context.LaborAndDeliveries
                .Include(l => l.Patient)
                .FirstOrDefaultAsync(m => m.LaborAndDeliveryId == id);
            if (laborAndDelivery == null)
            {
                return NotFound();
            }

            return View(laborAndDelivery);
        }

        // POST: LaborAndDeliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LaborAndDeliveries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LaborAndDeliveries'  is null.");
            }
            var laborAndDelivery = await _context.LaborAndDeliveries.FindAsync(id);
            if (laborAndDelivery != null)
            {
                _context.LaborAndDeliveries.Remove(laborAndDelivery);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaborAndDeliveryExists(int id)
        {
          return (_context.LaborAndDeliveries?.Any(e => e.LaborAndDeliveryId == id)).GetValueOrDefault();
        }
    }
}
