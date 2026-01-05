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
    public class PathologiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PathologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pathologies
        public async Task<IActionResult> Index()
        {
              return _context.Pathology != null ? 
                          View(await _context.Pathology.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Pathology'  is null.");
        }

        // GET: Pathologies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pathology == null)
            {
                return NotFound();
            }

            var pathology = await _context.Pathology
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (pathology == null)
            {
                return NotFound();
            }

            return View(pathology);
        }

        // GET: Pathologies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pathologies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,FirstName,LastName,PatientName,PatientLastName,TestDescription,DateTime")] Pathology pathology)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pathology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pathology);
        }

        // GET: Pathologies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pathology == null)
            {
                return NotFound();
            }

            var pathology = await _context.Pathology.FindAsync(id);
            if (pathology == null)
            {
                return NotFound();
            }
            return View(pathology);
        }

        // POST: Pathologies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,FirstName,LastName,PatientName,PatientLastName,TestDescription,DateTime")] Pathology pathology)
        {
            if (id != pathology.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pathology);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PathologyExists(pathology.StaffId))
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
            return View(pathology);
        }

        // GET: Pathologies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pathology == null)
            {
                return NotFound();
            }

            var pathology = await _context.Pathology
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (pathology == null)
            {
                return NotFound();
            }

            return View(pathology);
        }

        // POST: Pathologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pathology == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pathology'  is null.");
            }
            var pathology = await _context.Pathology.FindAsync(id);
            if (pathology != null)
            {
                _context.Pathology.Remove(pathology);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PathologyExists(int id)
        {
          return (_context.Pathology?.Any(e => e.StaffId == id)).GetValueOrDefault();
        }
    }
}
