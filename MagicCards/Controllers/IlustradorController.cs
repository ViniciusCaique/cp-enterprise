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
    public class IlustradorController : Controller
    {
        private readonly MagicDbContext _context;

        public IlustradorController(MagicDbContext context)
        {
            _context = context;
        }

        // GET: Ilustrador
        public async Task<IActionResult> Index()
        {
            return _context.Ilustradores != null ?
                        View(await _context.Ilustradores.ToListAsync()) :
                        Problem("Entity set 'MagicDbContext.Ilustradores'  is null.");
        }

        // GET: Ilustrador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ilustradores == null)
            {
                return NotFound();
            }

            var ilustrador = await _context.Ilustradores
                .FirstOrDefaultAsync(m => m.IlustradorId == id);
            if (ilustrador == null)
            {
                return NotFound();
            }

            return View(ilustrador);
        }

        // GET: Ilustrador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult<Ilustrador>> Create(Ilustrador ilustrador)
        {

            if (_context.Ilustradores == null)
            {
                return Problem("Entity set 'MagicDbContext.Ilustrador'  is null.");
            }

            _context.Add(ilustrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospede", new { id = ilustrador.IlustradorId }, ilustrador);

        }



        // GET: Ilustrador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ilustradores == null)
            {
                return NotFound();
            }

            var ilustrador = await _context.Ilustradores.FindAsync(id);
            if (ilustrador == null)
            {
                return NotFound();
            }
            return View(ilustrador);
        }

        // POST: Ilustrador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IlustradorId,Nome")] Ilustrador ilustrador)
        {
            if (id != ilustrador.IlustradorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ilustrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IlustradorExists(ilustrador.IlustradorId))
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
            return View(ilustrador);
        }

        // GET: Ilustrador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ilustradores == null)
            {
                return NotFound();
            }

            var ilustrador = await _context.Ilustradores
                .FirstOrDefaultAsync(m => m.IlustradorId == id);
            if (ilustrador == null)
            {
                return NotFound();
            }

            return View(ilustrador);
        }

        // POST: Ilustrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ilustradores == null)
            {
                return Problem("Entity set 'MagicDbContext.Ilustradores' is null.");
            }
            var ilustrador = await _context.Ilustradores.FindAsync(id);
            if (ilustrador != null)
            {
                _context.Ilustradores.Remove(ilustrador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IlustradorExists(int id)
        {
          return (_context.Ilustradores?.Any(e => e.IlustradorId == id)).GetValueOrDefault();
        }
    }
}
