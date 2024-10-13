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
    public class cls_TypeController : Controller
    {
        private readonly ApplicetionDbContext _context;

        public cls_TypeController(ApplicetionDbContext context)
        {
            _context = context;
        }

        // GET: cls_Type
        public async Task<IActionResult> Index()
        {
              return _context.Types != null ? 
                          View(await _context.Types.ToListAsync()) :
                          Problem("Entity set 'ApplicetionDbContext.Types'  is null.");
        }

        // GET: cls_Type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Types == null)
            {
                return NotFound();
            }

            var cls_Type = await _context.Types
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (cls_Type == null)
            {
                return NotFound();
            }

            return View(cls_Type);
        }

        // GET: cls_Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cls_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,TypeName")] cls_Type cls_Type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cls_Type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cls_Type);
        }

        // GET: cls_Type/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Types == null)
            {
                return NotFound();
            }

            var cls_Type = await _context.Types.FindAsync(id);
            if (cls_Type == null)
            {
                return NotFound();
            }
            return View(cls_Type);
        }

        // POST: cls_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,TypeName")] cls_Type cls_Type)
        {
            if (id != cls_Type.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cls_Type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cls_TypeExists(cls_Type.TypeId))
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
            return View(cls_Type);
        }

        // GET: cls_Type/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Types == null)
            {
                return NotFound();
            }

            var cls_Type = await _context.Types
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (cls_Type == null)
            {
                return NotFound();
            }

            return View(cls_Type);
        }

        // POST: cls_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Types == null)
            {
                return Problem("Entity set 'ApplicetionDbContext.Types'  is null.");
            }
            var cls_Type = await _context.Types.FindAsync(id);
            if (cls_Type != null)
            {
                _context.Types.Remove(cls_Type);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cls_TypeExists(int id)
        {
          return (_context.Types?.Any(e => e.TypeId == id)).GetValueOrDefault();
        }
    }
}
