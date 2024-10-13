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
    public class cls_TectarController : Controller
    {
        private readonly ApplicetionDbContext _context;

        public cls_TectarController(ApplicetionDbContext context)
        {
            _context = context;
        }

        // GET: cls_Tectar
        public async Task<IActionResult> Index()
        {
            var applicetionDbContext = _context.Tectars.Include(c => c.curse);
            return View(await applicetionDbContext.ToListAsync());
        }

        // GET: cls_Tectar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tectars == null)
            {
                return NotFound();
            }

            var cls_Tectar = await _context.Tectars
                .Include(c => c.curse)
                .FirstOrDefaultAsync(m => m.TechId == id);
            if (cls_Tectar == null)
            {
                return NotFound();
            }

            return View(cls_Tectar);
        }

        // GET: cls_Tectar/Create
        public IActionResult Create()
        {
            ViewData["CurseId"] = new SelectList(_context.Curses, "CurseId", "CurseName");
            return View();
        }

        // POST: cls_Tectar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TechId,TechName,TechPhone,TechAddress,CurseId,TechSal,TechImage")] cls_Tectar cls_Tectar)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var filStrem = new FileStream(Path.Combine(@"wwwroot/", "Images", ImageName), FileMode.Create);
                file[0].CopyTo(filStrem);
                cls_Tectar.TechImage = ImageName;
                //E:\Visual Studio 2022\projects\BokarRare\wwwroot\Images\
            }
            else if (cls_Tectar.TechImage == null && cls_Tectar.TechImage == null)
            {
                cls_Tectar.TechImage = "1.jpg";
            }
            else
            {
                cls_Tectar.TechImage = cls_Tectar.TechImage;
            }
            if (ModelState.IsValid)
            {
                _context.Add(cls_Tectar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurseId"] = new SelectList(_context.Curses, "CurseId", "CurseId", cls_Tectar.CurseId);
            return View(cls_Tectar);
        }

        // GET: cls_Tectar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tectars == null)
            {
                return NotFound();
            }

            var cls_Tectar = await _context.Tectars.FindAsync(id);
            if (cls_Tectar == null)
            {
                return NotFound();
            }
            ViewData["CurseId"] = new SelectList(_context.Curses, "CurseId", "CurseName", cls_Tectar.CurseId);
            return View(cls_Tectar);
        }

        // POST: cls_Tectar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TechId,TechName,TechPhone,TechAddress,CurseId,TechSal,TechImage")] cls_Tectar cls_Tectar)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var filStrem = new FileStream(Path.Combine(@"wwwroot/", "Images", ImageName), FileMode.Create);
                file[0].CopyTo(filStrem);
                cls_Tectar.TechImage = ImageName;
                //E:\Visual Studio 2022\projects\BokarRare\wwwroot\Images\
            }
            else if (cls_Tectar.TechImage == null )
            {
                cls_Tectar.TechImage = "1.jpg";
            }
            else
            {
                cls_Tectar.TechImage = cls_Tectar.TechImage;
            }
            if (id != cls_Tectar.TechId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cls_Tectar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cls_TectarExists(cls_Tectar.TechId))
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
            ViewData["CurseId"] = new SelectList(_context.Curses, "CurseId", "CurseId", cls_Tectar.CurseId);
            return View(cls_Tectar);
        }

        // GET: cls_Tectar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tectars == null)
            {
                return NotFound();
            }

            var cls_Tectar = await _context.Tectars
                .Include(c => c.curse)
                .FirstOrDefaultAsync(m => m.TechId == id);
            if (cls_Tectar == null)
            {
                return NotFound();
            }

            return View(cls_Tectar);
        }

        // POST: cls_Tectar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tectars == null)
            {
                return Problem("Entity set 'ApplicetionDbContext.Tectars'  is null.");
            }
            var cls_Tectar = await _context.Tectars.FindAsync(id);
            if (cls_Tectar != null)
            {
                _context.Tectars.Remove(cls_Tectar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cls_TectarExists(int id)
        {
          return (_context.Tectars?.Any(e => e.TechId == id)).GetValueOrDefault();
        }
    }
}
