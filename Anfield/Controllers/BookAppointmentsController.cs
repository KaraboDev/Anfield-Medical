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
    public class BookAppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookAppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookAppointments
        public async Task<IActionResult> Index()
        {
              return _context.BookAppointment != null ? 
                          View(await _context.BookAppointment.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BookAppointment'  is null.");
        }

        // GET: BookAppointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookAppointment == null)
            {
                return NotFound();
            }

            var bookAppointment = await _context.BookAppointment
                .FirstOrDefaultAsync(m => m.AppontmentId == id);
            if (bookAppointment == null)
            {
                return NotFound();
            }

            return View(bookAppointment);
        }

        // GET: BookAppointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppontmentId,Name,Surname,Age,PhoneNumber,Email,Service,Date,Time")] BookAppointment bookAppointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookAppointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookAppointment);
        }

        // GET: BookAppointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookAppointment == null)
            {
                return NotFound();
            }

            var bookAppointment = await _context.BookAppointment.FindAsync(id);
            if (bookAppointment == null)
            {
                return NotFound();
            }
            return View(bookAppointment);
        }

        // POST: BookAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppontmentId,Name,Surname,Age,PhoneNumber,Email,Service,Date,Time")] BookAppointment bookAppointment)
        {
            if (id != bookAppointment.AppontmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookAppointmentExists(bookAppointment.AppontmentId))
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
            return View(bookAppointment);
        }

        // GET: BookAppointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookAppointment == null)
            {
                return NotFound();
            }

            var bookAppointment = await _context.BookAppointment
                .FirstOrDefaultAsync(m => m.AppontmentId == id);
            if (bookAppointment == null)
            {
                return NotFound();
            }

            return View(bookAppointment);
        }

        // POST: BookAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookAppointment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BookAppointment'  is null.");
            }
            var bookAppointment = await _context.BookAppointment.FindAsync(id);
            if (bookAppointment != null)
            {
                _context.BookAppointment.Remove(bookAppointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookAppointmentExists(int id)
        {
          return (_context.BookAppointment?.Any(e => e.AppontmentId == id)).GetValueOrDefault();
        }
    }
}
