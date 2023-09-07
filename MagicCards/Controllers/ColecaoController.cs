using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagicCards.Data;
using MagicCards.Models;

namespace MagicCards.Controllers
{
    public class ColecaoController : Controller
    {
        private readonly MagicDbContext _context;

        public ColecaoController(MagicDbContext context)
        {
            _context = context;
        }

        // GET: Colecao
        public async Task<IActionResult> Index()
        {
              return _context.Colecoes != null ? 
                          View(await _context.Colecoes.ToListAsync()) :
                          Problem("Entity set 'MagicDbContext.Colecoes'  is null.");
        }

        // GET: Colecao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Colecoes == null)
            {
                return NotFound();
            }

            var colecao = await _context.Colecoes
                .FirstOrDefaultAsync(m => m.ColecaoId == id);
            if (colecao == null)
            {
                return NotFound();
            }

            return View(colecao);
        }

        // GET: Colecao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult<Colecao>> Create(Colecao colecao)
        {

            if (_context.Colecoes == null)
            {
                return Problem("Entity set 'MagicDbContext.Colecao'  is null.");
            }

            _context.Add(colecao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospede", new { id = colecao.ColecaoId }, colecao);

        }


        // GET: Colecao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colecoes == null)
            {
                return NotFound();
            }

            var colecao = await _context.Colecoes.FindAsync(id);
            if (colecao == null)
            {
                return NotFound();
            }
            return View(colecao);
        }

        // POST: Colecao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Colecao colecao)
        {
            if (id != colecao.ColecaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colecao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColecaoExists(colecao.ColecaoId))
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
            return View(colecao);
        }

        // GET: Colecao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Colecoes == null)
            {
                return NotFound();
            }

            var colecao = await _context.Colecoes
                .FirstOrDefaultAsync(m => m.ColecaoId == id);
            if (colecao == null)
            {
                return NotFound();
            }

            return View(colecao);
        }

        // POST: Colecao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Colecoes == null)
            {
                return Problem("Entity set 'MagicDbContext.Colecoes'  is null.");
            }
            var colecao = await _context.Colecoes.FindAsync(id);
            if (colecao != null)
            {
                _context.Colecoes.Remove(colecao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColecaoExists(int id)
        {
          return (_context.Colecoes?.Any(e => e.ColecaoId == id)).GetValueOrDefault();
        }
    }
}
