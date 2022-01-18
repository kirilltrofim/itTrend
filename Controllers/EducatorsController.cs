using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using itTrend.Data;
using itTrend.Models;
using System.Net;
using System.Net.Http;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace itTrend.Controllers
{
    public class EducatorsController : Controller
    {
        IWebHostEnvironment _appEnvironment;
        private readonly Context _context;

        public EducatorsController(Context context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
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
        public async Task<IActionResult> Create([Bind("GroupID,ID,LastName,FirstName,Patronomic,Photo,PhoneNumber,SubjectID")] Educator educator, IFormFile uploadedFile)
        {
            
                if (ModelState.IsValid)
                {
                    _context.Add(educator);

                    if (uploadedFile != null)
                    {
                        // путь к папке Files
                        string path = "/Files/" + uploadedFile.FileName;
                        // сохраняем файл в папку Files в каталоге wwwroot
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            uploadedFile.CopyTo(fileStream);
                        }
                        educator.Photo = path;
                    }
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
        public async Task<IActionResult> Edit(int id, [Bind("GroupID,ID,LastName,FirstName,Patronomic,Photo,PhoneNumber,SubjectID")] Educator educator, IFormFile uploadedFile)
        {
            if (id != educator.GroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (uploadedFile != null)
                    {
                        // путь к папке Files
                        string path = "/Files/" + uploadedFile.FileName;
                        // сохраняем файл в папку Files в каталоге wwwroot
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            uploadedFile.CopyTo(fileStream);
                        }
                        educator.Photo = path;
                    }
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
