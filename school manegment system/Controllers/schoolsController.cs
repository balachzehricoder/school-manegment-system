using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_manegment_system.Models;
using school_manegment_system.datacontext;

namespace school_manegment_system.Controllers
{
    public class schoolsController : Controller
    {
        private readonly database _context;

        public schoolsController(database context)
        {
            _context = context;
        }

        // GET: schools
        public async Task<IActionResult> Index()
        {
              return _context.school != null ? 
                          View(await _context.school.ToListAsync()) :
                          Problem("Entity set 'database.school'  is null.");
        }

        // GET: schools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.school == null)
            {
                return NotFound();
            }

            var school = await _context.school
                .FirstOrDefaultAsync(m => m.Id == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // GET: schools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: schools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,parent_name,classs,progress,section,class_teachname,roll_no,studentpasskey")] school school)
        {
            if (ModelState.IsValid)
            {
                _context.Add(school);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(school);
        }

        // GET: schools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.school == null)
            {
                return NotFound();
            }

            var school = await _context.school.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }

        // POST: schools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,class_teachname,parent_name,classs,progress,section,roll_no,studentpasskey")] school school)
        {
            if (id != school.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(school);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!schoolExists(school.Id))
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
            return View(school);
        }

        // GET: schools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.school == null)
            {
                return NotFound();
            }

            var school = await _context.school
                .FirstOrDefaultAsync(m => m.Id == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // POST: schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.school == null)
            {
                return Problem("Entity set 'database.school'  is null.");
            }
            var school = await _context.school.FindAsync(id);
            if (school != null)
            {
                _context.school.Remove(school);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool schoolExists(int id)
        {
          return (_context.school?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
