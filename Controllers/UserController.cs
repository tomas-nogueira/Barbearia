﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Barbearia.Models;

namespace Barbearia.Controllers
{
    public class UserController : Controller
    {
        private readonly Contexto _context;

        public UserController(Contexto context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var contexto = _context.User.Include(u => u.TipoDocumento).Include(u => u.TypeUser);
            return View(await contexto.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.TipoDocumento)
                .Include(u => u.TypeUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "Id", "TipodeDocumento");
            ViewData["TypeUserId"] = new SelectList(_context.TypeUser, "Id", "TypeNameUser");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameUser,TelUser,EmailUser,DocumentoUser,TipoDocumentoId,TypeUserId,SenhaUser")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "Id", "TipodeDocumento", user.TipoDocumentoId);
            ViewData["TypeUserId"] = new SelectList(_context.TypeUser, "Id", "TypeNameUser", user.TypeUserId);
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "Id", "TipodeDocumento", user.TipoDocumentoId);
            ViewData["TypeUserId"] = new SelectList(_context.TypeUser, "Id", "TypeNameUser", user.TypeUserId);
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameUser,TelUser,EmailUser,DocumentoUser,TipoDocumentoId,TypeUserId,SenhaUser")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "Id", "TipodeDocumento", user.TipoDocumentoId);
            ViewData["TypeUserId"] = new SelectList(_context.TypeUser, "Id", "TypeNameUser", user.TypeUserId);
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.TipoDocumento)
                .Include(u => u.TypeUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'Contexto.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
