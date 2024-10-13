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
    public class cls_tbgadController : Controller
    {
        private readonly ApplicetionDbContext _context;

        public cls_tbgadController(ApplicetionDbContext context)
        {
            _context = context;
        }

        // GET: cls_tbgad
        public async Task<IActionResult> Index()
        {
            var applicetionDbContext = _context.Tbgads.Include(c => c.studenty);
            return View(await applicetionDbContext.ToListAsync());
        }

        // GET: cls_tbgad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tbgads == null)
            {
                return NotFound();
            }

            var cls_tbgad = await _context.Tbgads
                .Include(c => c.studenty)
                .FirstOrDefaultAsync(m => m.TDagrId == id);
            if (cls_tbgad == null)
            {
                return NotFound();
            }

            return View(cls_tbgad);
        }

        // GET: cls_tbgad/Create
        public IActionResult Create()
        {
            ViewData["StuyId"] = new SelectList(_context.cls_Studenty, "StuyId", "StuName");
            return View();
        }

        // POST: cls_tbgad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TDagrId,StuyId,StuHW,MideXame,FinalXame,Total,Etamate")] cls_tbgad cls_tbgad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cls_tbgad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StuyId"] = new SelectList(_context.cls_Studenty, "StuyId", "StuName", cls_tbgad.StuyId);
            return View(cls_tbgad);
        }

        // GET: cls_tbgad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tbgads == null)
            {
                return NotFound();
            }

            var cls_tbgad = await _context.Tbgads.FindAsync(id);
            if (cls_tbgad == null)
            {
                return NotFound();
            }
            ViewData["StuyId"] = new SelectList(_context.cls_Studenty, "StuyId", "StuName", cls_tbgad.StuyId);
            return View(cls_tbgad);
        }

        // POST: cls_tbgad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TDagrId,StuyId,StuHW,MideXame,FinalXame,Total,Etamate")] cls_tbgad cls_tbgad)
        {
            if (id != cls_tbgad.TDagrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cls_tbgad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cls_tbgadExists(cls_tbgad.TDagrId))
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
            ViewData["StuyId"] = new SelectList(_context.cls_Studenty, "StuyId", "StuName", cls_tbgad.StuyId);
            return View(cls_tbgad);
        }

        // GET: cls_tbgad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tbgads == null)
            {
                return NotFound();
            }

            var cls_tbgad = await _context.Tbgads
                .Include(c => c.studenty)
                .FirstOrDefaultAsync(m => m.TDagrId == id);
            if (cls_tbgad == null)
            {
                return NotFound();
            }

            return View(cls_tbgad);
        }

        // POST: cls_tbgad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tbgads == null)
            {
                return Problem("Entity set 'ApplicetionDbContext.Tbgads'  is null.");
            }
            var cls_tbgad = await _context.Tbgads.FindAsync(id);
            if (cls_tbgad != null)
            {
                _context.Tbgads.Remove(cls_tbgad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cls_tbgadExists(int id)
        {
          return (_context.Tbgads?.Any(e => e.TDagrId == id)).GetValueOrDefault();
        }
    }
}
