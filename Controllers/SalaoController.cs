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
    public class SalaoController : Controller
    {
        private readonly Contexto _context;

        public SalaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Salao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Salao.Include(s => s.User);
            return View(await contexto.ToListAsync());
        }

        // GET: Salao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salao == null)
            {
                return NotFound();
            }

            var salao = await _context.Salao
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salao == null)
            {
                return NotFound();
            }

            return View(salao);
        }

        // GET: Salao/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User.Where(x => x.TypeUser.Id == 1), "Id", "NameUser");
            return View();
        }

        // POST: Salao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameSalao,CidadeSalao,RuaSalao,BairroSalao,CepSalao,NumeroSalao,UserId")] Salao salao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User.Where(x=> x.TypeUser.Id == 1), "Id", "NameUser", salao.UserId);
            return View(salao);
        }

        // GET: Salao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salao == null)
            {
                return NotFound();
            }

            var salao = await _context.Salao.FindAsync(id);
            if (salao == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User.Where(x => x.TypeUser.Id == 1), "Id", "NameUser", salao.UserId);
            return View(salao);
        }

        // POST: Salao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameSalao,CidadeSalao,RuaSalao,BairroSalao,CepSalao,NumeroSalao,UserId")] Salao salao)
        {
            if (id != salao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaoExists(salao.Id))
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
            ViewData["UserId"] = new SelectList(_context.User.Where(x => x.TypeUser.Id == 1), "Id", "NameUser", salao.UserId);
            return View(salao);
        }

        // GET: Salao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salao == null)
            {
                return NotFound();
            }

            var salao = await _context.Salao
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salao == null)
            {
                return NotFound();
            }

            return View(salao);
        }

        // POST: Salao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salao == null)
            {
                return Problem("Entity set 'Contexto.Salao'  is null.");
            }
            var salao = await _context.Salao.FindAsync(id);
            if (salao != null)
            {
                _context.Salao.Remove(salao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaoExists(int id)
        {
          return (_context.Salao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
