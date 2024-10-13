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
    public class cls_UserController : Controller
    {
        private readonly ApplicetionDbContext _context;

        public cls_UserController(ApplicetionDbContext context)
        {
            _context = context;
        }

        // GET: cls_User
        public async Task<IActionResult> Index()
        {
            var applicetionDbContext = _context.Users.Include(c => c.typeUser);
            return View(await applicetionDbContext.ToListAsync());
        }

        // GET: cls_User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var cls_User = await _context.Users
                .Include(c => c.typeUser)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (cls_User == null)
            {
                return NotFound();
            }

            return View(cls_User);
        }

        // GET: cls_User/Create
        public IActionResult Create()
        {
            ViewData["TypeUserId"] = new SelectList(_context.TypeUsers, "TypeUserId", "TypeUserName");
            return View();
        }

        // POST: cls_User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,UserPassowrd,TypeUserId")] cls_User cls_User)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cls_User);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeUserId"] = new SelectList(_context.TypeUsers, "TypeUserId", "TypeUserName", cls_User.TypeUserId);
            return View(cls_User);
        }

        // GET: cls_User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var cls_User = await _context.Users.FindAsync(id);
            if (cls_User == null)
            {
                return NotFound();
            }
            ViewData["TypeUserId"] = new SelectList(_context.TypeUsers, "TypeUserId", "TypeUserName", cls_User.TypeUserId);
            return View(cls_User);
        }

        // POST: cls_User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,UserPassowrd,TypeUserId")] cls_User cls_User)
        {
            if (id != cls_User.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cls_User);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cls_UserExists(cls_User.UserId))
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
            ViewData["TypeUserId"] = new SelectList(_context.TypeUsers, "TypeUserId", "TypeUserName", cls_User.TypeUserId);
            return View(cls_User);
        }

        // GET: cls_User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var cls_User = await _context.Users
                .Include(c => c.typeUser)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (cls_User == null)
            {
                return NotFound();
            }

            return View(cls_User);
        }

        // POST: cls_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicetionDbContext.Users'  is null.");
            }
            var cls_User = await _context.Users.FindAsync(id);
            if (cls_User != null)
            {
                _context.Users.Remove(cls_User);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cls_UserExists(int id)
        {
          return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
