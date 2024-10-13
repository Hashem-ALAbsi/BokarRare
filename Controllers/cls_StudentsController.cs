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
    public class cls_StudentsController : Controller
    {
        private readonly ApplicetionDbContext _context;

        public cls_StudentsController(ApplicetionDbContext context)
        {
            _context = context;
        }

        // GET: cls_Students
        public async Task<IActionResult> Index()
        {
            var applicetionDbContext = _context.cls_Students.Include(c => c.curse).Include(c => c.type);
            return View(await applicetionDbContext.ToListAsync());
        }

        // GET: cls_Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cls_Students == null)
            {
                return NotFound();
            }

            var cls_Students = await _context.cls_Students
                .Include(c => c.curse)
                .Include(c => c.type)
                .FirstOrDefaultAsync(m => m.StId == id);
            if (cls_Students == null)
            {
                return NotFound();
            }

            return View(cls_Students);
        }

        // GET: cls_Students/Create
        public IActionResult Create()
        {
            ViewData["CurseId"] = new SelectList(_context.Curses, "CurseId", "CurseId");
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeId");
            return View();
        }

        // POST: cls_Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StId,StName,StPhone,StAddress,CurseId,TypeId,TechImage")] cls_Students cls_Students)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cls_Students);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurseId"] = new SelectList(_context.Curses, "CurseId", "CurseId", cls_Students.CurseId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeId", cls_Students.TypeId);
            return View(cls_Students);
        }

        // GET: cls_Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cls_Students == null)
            {
                return NotFound();
            }

            var cls_Students = await _context.cls_Students.FindAsync(id);
            if (cls_Students == null)
            {
                return NotFound();
            }
            ViewData["CurseId"] = new SelectList(_context.Curses, "CurseId", "CurseId", cls_Students.CurseId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeId", cls_Students.TypeId);
            return View(cls_Students);
        }

        // POST: cls_Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StId,StName,StPhone,StAddress,CurseId,TypeId,TechImage")] cls_Students cls_Students)
        {
            if (id != cls_Students.StId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cls_Students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cls_StudentsExists(cls_Students.StId))
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
            ViewData["CurseId"] = new SelectList(_context.Curses, "CurseId", "CurseId", cls_Students.CurseId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeId", cls_Students.TypeId);
            return View(cls_Students);
        }

        // GET: cls_Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cls_Students == null)
            {
                return NotFound();
            }

            var cls_Students = await _context.cls_Students
                .Include(c => c.curse)
                .Include(c => c.type)
                .FirstOrDefaultAsync(m => m.StId == id);
            if (cls_Students == null)
            {
                return NotFound();
            }

            return View(cls_Students);
        }

        // POST: cls_Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cls_Students == null)
            {
                return Problem("Entity set 'ApplicetionDbContext.cls_Students'  is null.");
            }
            var cls_Students = await _context.cls_Students.FindAsync(id);
            if (cls_Students != null)
            {
                _context.cls_Students.Remove(cls_Students);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cls_StudentsExists(int id)
        {
          return (_context.cls_Students?.Any(e => e.StId == id)).GetValueOrDefault();
        }
    }
}
