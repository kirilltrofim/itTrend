using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using itTrend.Data;
using itTrend.Models;

namespace itTrend.Controllers
{
    public class EducatorsController : Controller
    {
        private readonly Context _context;

        public EducatorsController(Context context)
        {
            _context = context;
        }

        // GET: Educators
        public async Task<IActionResult> Index()
        {
            var context = _context.Educators.Include(e => e.Subjects);
            return View(await context.ToListAsync());
        }

        // GET: Educators/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educator = await _context.Educators
                .Include(e => e.Subjects)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (educator == null)
            {
                return NotFound();
            }

            return View(educator);
        }

        // GET: Educators/Create
        public IActionResult Create()
        {
            ViewData["SubjectsID"] = new SelectList(_context.Subjects, "ID", "ID");
            return View();
        }

        // POST: Educators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SubjectsID,FullName,Photo,Phone")] Educator educator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectsID"] = new SelectList(_context.Subjects, "ID", "ID", educator.SubjectsID);
            return View(educator);
        }

        // GET: Educators/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educator = await _context.Educators.FindAsync(id);
            if (educator == null)
            {
                return NotFound();
            }
            ViewData["SubjectsID"] = new SelectList(_context.Subjects, "ID", "ID", educator.SubjectsID);
            return View(educator);
        }

        // POST: Educators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,SubjectsID,FullName,Photo,Phone")] Educator educator)
        {
            if (id != educator.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducatorExists(educator.ID))
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
            ViewData["SubjectsID"] = new SelectList(_context.Subjects, "ID", "ID", educator.SubjectsID);
            return View(educator);
        }

        // GET: Educators/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educator = await _context.Educators
                .Include(e => e.Subjects)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (educator == null)
            {
                return NotFound();
            }

            return View(educator);
        }

        // POST: Educators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var educator = await _context.Educators.FindAsync(id);
            _context.Educators.Remove(educator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducatorExists(string id)
        {
            return _context.Educators.Any(e => e.ID == id);
        }
    }
}
