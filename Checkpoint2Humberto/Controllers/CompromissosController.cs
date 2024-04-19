using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Checkpoint2Humberto.Models;

namespace Checkpoint2Humberto.Controllers
{
    public class CompromissosController : Controller
    {
        private readonly AgendaContexto _context;

        public CompromissosController(AgendaContexto context)
        {
            _context = context;
        }

        // GET: Compromissos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Compromissos.ToListAsync());
        }

        // GET: Compromissos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromissos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compromisso == null)
            {
                return NotFound();
            }

            return View(compromisso);
        }

        // GET: Compromissos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Compromissos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Local,Data")] Compromisso compromisso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compromisso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compromisso);
        }

        // GET: Compromissos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromissos.FindAsync(id);
            if (compromisso == null)
            {
                return NotFound();
            }
            return View(compromisso);
        }

        // POST: Compromissos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Local,Data")] Compromisso compromisso)
        {
            if (id != compromisso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compromisso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompromissoExists(compromisso.Id))
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
            return View(compromisso);
        }

        // GET: Compromissos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromissos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compromisso == null)
            {
                return NotFound();
            }

            return View(compromisso);
        }

        // POST: Compromissos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compromisso = await _context.Compromissos.FindAsync(id);
            if (compromisso != null)
            {
                _context.Compromissos.Remove(compromisso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompromissoExists(int id)
        {
            return _context.Compromissos.Any(e => e.Id == id);
        }
    }
}
