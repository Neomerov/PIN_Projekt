using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pr_pin.Data;
using pr_pin.Models;

namespace pr_pin.Controllers
{
    public class PredavanjaaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PredavanjaaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Predavanjaa
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.predavanja.Include(p => p.Speaker);
            return View(await applicationDbContext.ToListAsync());
        }

        

        // GET: Predavanjaa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.predavanja == null)
            {
                return NotFound();
            }

            var predavanja = await _context.predavanja
                .Include(p => p.Speaker)
                .FirstOrDefaultAsync(m => m.PredavanjaId == id);
            if (predavanja == null)
            {
                return NotFound();
            }

            return View(predavanja);
        }

        // GET: Predavanjaa/Create
        public IActionResult Create()
        {
            ViewData["SpeakerId"] = new SelectList(_context.speakers, "SpeakerId", "Ime");
            return View();
        }

        // POST: Predavanjaa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PredavanjaId,NaslovTeme,datumPredavanja,SpeakerId")] Predavanja predavanja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(predavanja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpeakerId"] = new SelectList(_context.speakers, "SpeakerId", "SpeakerId", predavanja.SpeakerId);
            return View(predavanja);
        }

        // GET: Predavanjaa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.predavanja == null)
            {
                return NotFound();
            }

            var predavanja = await _context.predavanja.FindAsync(id);
            if (predavanja == null)
            {
                return NotFound();
            }
            ViewData["SpeakerId"] = new SelectList(_context.speakers, "SpeakerId", "Ime", predavanja.SpeakerId);
            return View(predavanja);
        }

        // POST: Predavanjaa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PredavanjaId,NaslovTeme,datumPredavanja,SpeakerId")] Predavanja predavanja)
        {
            if (id != predavanja.PredavanjaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(predavanja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PredavanjaExists(predavanja.PredavanjaId))
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
            ViewData["SpeakerId"] = new SelectList(_context.speakers, "SpeakerId", "SpeakerId", predavanja.SpeakerId);
            return View(predavanja);
        }

        // GET: Predavanjaa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.predavanja == null)
            {
                return NotFound();
            }

            var predavanja = await _context.predavanja
                .Include(p => p.Speaker)
                .FirstOrDefaultAsync(m => m.PredavanjaId == id);
            if (predavanja == null)
            {
                return NotFound();
            }

            return View(predavanja);
        }

        // POST: Predavanjaa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.predavanja == null)
            {
                return Problem("Entity set 'ApplicationDbContext.predavanja'  is null.");
            }
            var predavanja = await _context.predavanja.FindAsync(id);
            if (predavanja != null)
            {
                _context.predavanja.Remove(predavanja);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PredavanjaExists(int id)
        {
          return _context.predavanja.Any(e => e.PredavanjaId == id);
        }
    }
}
