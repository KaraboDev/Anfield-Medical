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
    public class NewbornsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewbornsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Newborns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Newborns.Include(n => n.Patient);
            return View(await applicationDbContext.ToListAsync());
        }
        public IActionResult Index1()
        {  
            return View();
        }

        // GET: Newborns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Newborns == null)
            {
                return NotFound();
            }

            var newborn = await _context.Newborns
                .Include(n => n.Patient)
                .FirstOrDefaultAsync(m => m.NewbornId == id);
            if (newborn == null)
            {
                return NotFound();
            }

            return View(newborn);
        }

        // GET: Newborns/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "ContactNumber");
            return View();
        }

        // POST: Newborns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewbornId,PatientId,BirthDate,Weight,HealthStatus")] Newborn newborn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newborn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "ContactNumber", newborn.PatientId);
            return View(newborn);
        }

        // GET: Newborns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Newborns == null)
            {
                return NotFound();
            }

            var newborn = await _context.Newborns.FindAsync(id);
            if (newborn == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "ContactNumber", newborn.PatientId);
            return View(newborn);
        }

        // POST: Newborns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewbornId,PatientId,BirthDate,Weight,HealthStatus")] Newborn newborn)
        {
            if (id != newborn.NewbornId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newborn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewbornExists(newborn.NewbornId))
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
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "ContactNumber", newborn.PatientId);
            return View(newborn);
        }

        // GET: Newborns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Newborns == null)
            {
                return NotFound();
            }

            var newborn = await _context.Newborns
                .Include(n => n.Patient)
                .FirstOrDefaultAsync(m => m.NewbornId == id);
            if (newborn == null)
            {
                return NotFound();
            }

            return View(newborn);
        }

        // POST: Newborns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Newborns == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Newborns'  is null.");
            }
            var newborn = await _context.Newborns.FindAsync(id);
            if (newborn != null)
            {
                _context.Newborns.Remove(newborn);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewbornExists(int id)
        {
          return (_context.Newborns?.Any(e => e.NewbornId == id)).GetValueOrDefault();
        }
    }
}
