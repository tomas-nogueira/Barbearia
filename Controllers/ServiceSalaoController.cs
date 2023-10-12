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
    public class ServiceSalaoController : Controller
    {
        private readonly Contexto _context;

        public ServiceSalaoController(Contexto context)
        {
            _context = context;
        }

        // GET: ServiceSalao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.ServiceSalao.Include(s => s.Salao);
            return View(await contexto.ToListAsync());
        }

        // GET: ServiceSalao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceSalao == null)
            {
                return NotFound();
            }

            var serviceSalao = await _context.ServiceSalao
                .Include(s => s.Salao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceSalao == null)
            {
                return NotFound();
            }

            return View(serviceSalao);
        }

        // GET: ServiceSalao/Create
        public IActionResult Create()
        {
            ViewData["SalaoId"] = new SelectList(_context.Salao, "Id", "NameSalao");
            return View();
        }

        // POST: ServiceSalao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SalaoId,ServiceId")] ServiceSalao serviceSalao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceSalao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalaoId"] = new SelectList(_context.Salao, "Id", "NameSalao", serviceSalao.SalaoId);
            return View(serviceSalao);
        }

        // GET: ServiceSalao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceSalao == null)
            {
                return NotFound();
            }

            var serviceSalao = await _context.ServiceSalao.FindAsync(id);
            if (serviceSalao == null)
            {
                return NotFound();
            }
            ViewData["SalaoId"] = new SelectList(_context.Salao, "Id", "NameSalao", serviceSalao.SalaoId);
            return View(serviceSalao);
        }

        // POST: ServiceSalao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SalaoId,ServiceId")] ServiceSalao serviceSalao)
        {
            if (id != serviceSalao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceSalao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceSalaoExists(serviceSalao.Id))
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
            ViewData["SalaoId"] = new SelectList(_context.Salao, "Id", "NameSalao", serviceSalao.SalaoId);
            return View(serviceSalao);
        }

        // GET: ServiceSalao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceSalao == null)
            {
                return NotFound();
            }

            var serviceSalao = await _context.ServiceSalao
                .Include(s => s.Salao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceSalao == null)
            {
                return NotFound();
            }

            return View(serviceSalao);
        }

        // POST: ServiceSalao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceSalao == null)
            {
                return Problem("Entity set 'Contexto.ServiceSalao'  is null.");
            }
            var serviceSalao = await _context.ServiceSalao.FindAsync(id);
            if (serviceSalao != null)
            {
                _context.ServiceSalao.Remove(serviceSalao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceSalaoExists(int id)
        {
          return (_context.ServiceSalao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
