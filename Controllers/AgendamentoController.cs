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
    public class AgendamentoController : Controller
    {
        private readonly Contexto _context;

        public AgendamentoController(Contexto context)
        {
            _context = context;
        }

        // GET: Agendamento
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Agendamento.Include(a => a.ServiceSalao);
            return View(await contexto.ToListAsync());
        }

        // GET: Agendamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Agendamento == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamento
                .Include(a => a.ServiceSalao)
                .FirstOrDefaultAsync(m => m.AgendamentoId == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // GET: Agendamento/Create
        public IActionResult Create()
        {
            ViewData["ServiceSalaoId"] = new SelectList(_context.ServiceSalao, "Id", "Id");
            return View();
        }

        // POST: Agendamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgendamentoId,HorarioAgendamento,ServiceSalaoId")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agendamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceSalaoId"] = new SelectList(_context.ServiceSalao, "Id", "Id", agendamento.ServiceSalaoId);
            return View(agendamento);
        }

        // GET: Agendamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Agendamento == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamento.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            ViewData["ServiceSalaoId"] = new SelectList(_context.ServiceSalao, "Id", "Id", agendamento.ServiceSalaoId);
            return View(agendamento);
        }

        // POST: Agendamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgendamentoId,HorarioAgendamento,ServiceSalaoId")] Agendamento agendamento)
        {
            if (id != agendamento.AgendamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoExists(agendamento.AgendamentoId))
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
            ViewData["ServiceSalaoId"] = new SelectList(_context.ServiceSalao, "Id", "Id", agendamento.ServiceSalaoId);
            return View(agendamento);
        }

        // GET: Agendamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Agendamento == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamento
                .Include(a => a.ServiceSalao)
                .FirstOrDefaultAsync(m => m.AgendamentoId == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // POST: Agendamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Agendamento == null)
            {
                return Problem("Entity set 'Contexto.Agendamento'  is null.");
            }
            var agendamento = await _context.Agendamento.FindAsync(id);
            if (agendamento != null)
            {
                _context.Agendamento.Remove(agendamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoExists(int id)
        {
          return (_context.Agendamento?.Any(e => e.AgendamentoId == id)).GetValueOrDefault();
        }
    }
}
