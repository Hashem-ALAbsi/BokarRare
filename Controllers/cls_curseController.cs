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
    public class cls_curseController : Controller
    {
        private readonly ApplicetionDbContext _context;

        public cls_curseController(ApplicetionDbContext context)
        {
            _context = context;
        }

        // GET: cls_curse
        public async Task<IActionResult> Index()
        {
              return _context.Curses != null ? 
                          View(await _context.Curses.ToListAsync()) :
                          Problem("Entity set 'ApplicetionDbContext.Curses'  is null.");
        }

        // GET: cls_curse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Curses == null)
            {
                return NotFound();
            }

            var cls_curse = await _context.Curses
                .FirstOrDefaultAsync(m => m.CurseId == id);
            if (cls_curse == null)
            {
                return NotFound();
            }

            return View(cls_curse);
        }

        // GET: cls_curse/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cls_curse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurseId,CurseName")] cls_curse cls_curse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cls_curse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cls_curse);
        }

        // GET: cls_curse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Curses == null)
            {
                return NotFound();
            }

            var cls_curse = await _context.Curses.FindAsync(id);
            if (cls_curse == null)
            {
                return NotFound();
            }
            return View(cls_curse);
        }

        // POST: cls_curse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurseId,CurseName")] cls_curse cls_curse)
        {
            if (id != cls_curse.CurseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cls_curse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cls_curseExists(cls_curse.CurseId))
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
            return View(cls_curse);
        }

        // GET: cls_curse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Curses == null)
            {
                return NotFound();
            }

            var cls_curse = await _context.Curses
                .FirstOrDefaultAsync(m => m.CurseId == id);
            if (cls_curse == null)
            {
                return NotFound();
            }

            return View(cls_curse);
        }

        // POST: cls_curse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Curses == null)
            {
                return Problem("Entity set 'ApplicetionDbContext.Curses'  is null.");
            }
            var cls_curse = await _context.Curses.FindAsync(id);
            if (cls_curse != null)
            {
                _context.Curses.Remove(cls_curse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cls_curseExists(int id)
        {
          return (_context.Curses?.Any(e => e.CurseId == id)).GetValueOrDefault();
        }
    }
}
