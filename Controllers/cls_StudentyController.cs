using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BokarRare.Data;
using BokarRare.Models;

namespace BokarRare.Controllers
{
    public class cls_StudentyController : Controller
    {
        private readonly ApplicetionDbContext _context;

        public cls_StudentyController(ApplicetionDbContext context)
        {
            _context = context;
        }

        // GET: cls_Studenty
        public async Task<IActionResult> Index()
        {
            var applicetionDbContext = _context.cls_Studenty.Include(c => c.curse).Include(c => c.type);
            return View(await applicetionDbContext.ToListAsync());
        }

        // GET: cls_Studenty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cls_Studenty == null)
            {
                return NotFound();
            }

            var cls_Studenty = await _context.cls_Studenty
                .Include(c => c.curse)
                .Include(c => c.type)
                .FirstOrDefaultAsync(m => m.StuyId == id);
            if (cls_Studenty == null)
            {
                return NotFound();
            }

            return View(cls_Studenty);
        }

        // GET: cls_Studenty/Create
        public IActionResult Create()
        {
            ViewData["CurseId"] = new SelectList(_context.Curses, "CurseId", "CurseName");
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeName");
            return View();
        }

        // POST: cls_Studenty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StuyId,StuName,StuPhone,StuAddress,CurseId,TypeId,StuImage")] cls_Studenty cls_Studenty)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var filStrem = new FileStream(Path.Combine(@"wwwroot/", "Images", ImageName), FileMode.Create);
                file[0].CopyTo(filStrem);
                cls_Studenty.StuImage = ImageName;
                //E:\Visual Studio 2022\projects\BokarRare\wwwroot\Images\
            }
            else if (cls_Studenty.StuImage == null && cls_Studenty.StuyId == null)
            {
                cls_Studenty.StuImage = "1.jpg";
            }
            else
            {
                cls_Studenty.StuImage = cls_Studenty.StuImage;
            }
            if (ModelState.IsValid)
            {
                _context.Add(cls_Studenty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurseId"] = new SelectList(_context.Curses, "CurseId", "CurseName", cls_Studenty.CurseId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeName", cls_Studenty.TypeId);
            return View(cls_Studenty);
        }

        // GET: cls_Studenty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cls_Studenty == null)
            {
                return NotFound();
            }

            var cls_Studenty = await _context.cls_Studenty.FindAsync(id);
            if (cls_Studenty == null)
            {
                return NotFound();
            }
            ViewData["CurseId"] = new SelectList(_context.Curses, "CurseId", "CurseName", cls_Studenty.CurseId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeName", cls_Studenty.TypeId);
            return View(cls_Studenty);
        }

        // POST: cls_Studenty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StuyId,StuName,StuPhone,StuAddress,CurseId,TypeId,StuImage")] cls_Studenty cls_Studenty)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var filStrem = new FileStream(Path.Combine(@"wwwroot/", "Images", ImageName), FileMode.Create);
                file[0].CopyTo(filStrem);
                cls_Studenty.StuImage = ImageName;
                //E:\Visual Studio 2022\projects\BokarRare\wwwroot\Images\
            }
            else if (cls_Studenty.StuImage == null)
            {
                cls_Studenty.StuImage = "1.jpg";
            }
            else
            {
                cls_Studenty.StuImage = cls_Studenty.StuImage;
            }
            if (id != cls_Studenty.StuyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cls_Studenty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cls_StudentyExists(cls_Studenty.StuyId))
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
            ViewData["CurseId"] = new SelectList(_context.Curses, "CurseId", "CurseName", cls_Studenty.CurseId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeName", cls_Studenty.TypeId);
            return View(cls_Studenty);
        }

        // GET: cls_Studenty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cls_Studenty == null)
            {
                return NotFound();
            }

            var cls_Studenty = await _context.cls_Studenty
                .Include(c => c.curse)
                .Include(c => c.type)
                .FirstOrDefaultAsync(m => m.StuyId == id);
            if (cls_Studenty == null)
            {
                return NotFound();
            }

            return View(cls_Studenty);
        }

        // POST: cls_Studenty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cls_Studenty == null)
            {
                return Problem("Entity set 'ApplicetionDbContext.cls_Studenty'  is null.");
            }
            var cls_Studenty = await _context.cls_Studenty.FindAsync(id);
            if (cls_Studenty != null)
            {
                _context.cls_Studenty.Remove(cls_Studenty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cls_StudentyExists(int id)
        {
          return (_context.cls_Studenty?.Any(e => e.StuyId == id)).GetValueOrDefault();
        }
    }
}
