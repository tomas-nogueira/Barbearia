using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Barbearia.Models;

namespace Barbearia.Controllers
{
    public class TypeUserController : Controller
    {
        private readonly Contexto _context;

        public TypeUserController(Contexto context)
        {
            _context = context;
        }

        // GET: TypeUser
        public async Task<IActionResult> Index()
        {
              return _context.TypeUser != null ? 
                          View(await _context.TypeUser.ToListAsync()) :
                          Problem("Entity set 'Contexto.TypeUser'  is null.");
        }

        // GET: TypeUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeUser == null)
            {
                return NotFound();
            }

            var typeUser = await _context.TypeUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeUser == null)
            {
                return NotFound();
            }

            return View(typeUser);
        }

        // GET: TypeUser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeNameUser")] TypeUser typeUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeUser);
        }

        // GET: TypeUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeUser == null)
            {
                return NotFound();
            }

            var typeUser = await _context.TypeUser.FindAsync(id);
            if (typeUser == null)
            {
                return NotFound();
            }
            return View(typeUser);
        }

        // POST: TypeUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeNameUser")] TypeUser typeUser)
        {
            if (id != typeUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeUserExists(typeUser.Id))
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
            return View(typeUser);
        }

        // GET: TypeUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeUser == null)
            {
                return NotFound();
            }

            var typeUser = await _context.TypeUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeUser == null)
            {
                return NotFound();
            }

            return View(typeUser);
        }

        // POST: TypeUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeUser == null)
            {
                return Problem("Entity set 'Contexto.TypeUser'  is null.");
            }
            var typeUser = await _context.TypeUser.FindAsync(id);
            if (typeUser != null)
            {
                _context.TypeUser.Remove(typeUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeUserExists(int id)
        {
          return (_context.TypeUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
