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
    public class TypeServiceController : Controller
    {
        private readonly Contexto _context;

        public TypeServiceController(Contexto context)
        {
            _context = context;
        }

        // GET: TypeService
        public async Task<IActionResult> Index()
        {
              return _context.TypeService != null ? 
                          View(await _context.TypeService.ToListAsync()) :
                          Problem("Entity set 'Contexto.TypeService'  is null.");
        }

        // GET: TypeService/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeService == null)
            {
                return NotFound();
            }

            var typeService = await _context.TypeService
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeService == null)
            {
                return NotFound();
            }

            return View(typeService);
        }

        // GET: TypeService/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameService,TimeService")] TypeService typeService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeService);
        }

        // GET: TypeService/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeService == null)
            {
                return NotFound();
            }

            var typeService = await _context.TypeService.FindAsync(id);
            if (typeService == null)
            {
                return NotFound();
            }
            return View(typeService);
        }

        // POST: TypeService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameService,TimeService")] TypeService typeService)
        {
            if (id != typeService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeServiceExists(typeService.Id))
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
            return View(typeService);
        }

        // GET: TypeService/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeService == null)
            {
                return NotFound();
            }

            var typeService = await _context.TypeService
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeService == null)
            {
                return NotFound();
            }

            return View(typeService);
        }

        // POST: TypeService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeService == null)
            {
                return Problem("Entity set 'Contexto.TypeService'  is null.");
            }
            var typeService = await _context.TypeService.FindAsync(id);
            if (typeService != null)
            {
                _context.TypeService.Remove(typeService);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeServiceExists(int id)
        {
          return (_context.TypeService?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
