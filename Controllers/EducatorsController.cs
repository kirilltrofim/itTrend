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
            return View(await _context.Educators.ToListAsync());
        }

        // GET: Educators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educator = await _context.Educators
                .FirstOrDefaultAsync(m => m.GroupID == id);
            if (educator == null)
            {
                return NotFound();
            }

            return View(educator);
        }

        // GET: Educators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Educators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupID,ID,LastName,FirstName,Patronomic,Photo,PhoneNumber,SubjectID")] Educator educator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educator);
        }

        // GET: Educators/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            return View(educator);
        }

        // POST: Educators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupID,ID,LastName,FirstName,Patronomic,Photo,PhoneNumber,SubjectID")] Educator educator)
        {
            if (id != educator.GroupID)
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
                    if (!EducatorExists(educator.GroupID))
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
            return View(educator);
        }

        // GET: Educators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educator = await _context.Educators
                .FirstOrDefaultAsync(m => m.GroupID == id);
            if (educator == null)
            {
                return NotFound();
            }

            return View(educator);
        }

        // POST: Educators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educator = await _context.Educators.FindAsync(id);
            _context.Educators.Remove(educator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducatorExists(int id)
        {
            return _context.Educators.Any(e => e.GroupID == id);
        }
    }
}
