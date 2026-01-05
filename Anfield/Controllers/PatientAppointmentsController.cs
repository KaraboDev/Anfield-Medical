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
    public class PatientAppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientAppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientAppointments
        public async Task<IActionResult> Index()
        {
              return _context.PatientAppointments != null ? 
                          View(await _context.PatientAppointments.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PatientAppointments'  is null.");
        }

        // GET: PatientAppointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PatientAppointments == null)
            {
                return NotFound();
            }

            var patientAppointments = await _context.PatientAppointments
                .FirstOrDefaultAsync(m => m.AppontmentId == id);
            if (patientAppointments == null)
            {
                return NotFound();
            }

            return View(patientAppointments);
        }

        // GET: PatientAppointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppontmentId,Name,Surname,Age,PhoneNumber,Email,Service,Date,Time")] PatientAppointments patientAppointments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientAppointments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientAppointments);
        }

        // GET: PatientAppointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PatientAppointments == null)
            {
                return NotFound();
            }

            var patientAppointments = await _context.PatientAppointments.FindAsync(id);
            if (patientAppointments == null)
            {
                return NotFound();
            }
            return View(patientAppointments);
        }

        // POST: PatientAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppontmentId,Name,Surname,Age,PhoneNumber,Email,Service,Date,Time")] PatientAppointments patientAppointments)
        {
            if (id != patientAppointments.AppontmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientAppointments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientAppointmentsExists(patientAppointments.AppontmentId))
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
            return View(patientAppointments);
        }

        // GET: PatientAppointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PatientAppointments == null)
            {
                return NotFound();
            }

            var patientAppointments = await _context.PatientAppointments
                .FirstOrDefaultAsync(m => m.AppontmentId == id);
            if (patientAppointments == null)
            {
                return NotFound();
            }

            return View(patientAppointments);
        }

        // POST: PatientAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PatientAppointments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PatientAppointments'  is null.");
            }
            var patientAppointments = await _context.PatientAppointments.FindAsync(id);
            if (patientAppointments != null)
            {
                _context.PatientAppointments.Remove(patientAppointments);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientAppointmentsExists(int id)
        {
          return (_context.PatientAppointments?.Any(e => e.AppontmentId == id)).GetValueOrDefault();
        }
    }
}
