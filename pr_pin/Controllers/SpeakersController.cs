using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using pr_pin.Data;
using pr_pin.Models;


namespace pr_pin.Controllers
{
   
        public class SpeakersController : Controller
    {
        private readonly ApplicationDbContext _context;
            private readonly IWebHostEnvironment _webHostEnvironment;

            public SpeakersController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
                _webHostEnvironment = hostEnvironment;
            }

        // GET: Speakers
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return View(await _context.speakers.ToListAsync());
        }

        // GET: Speakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.speakers == null)
            {
                return NotFound();
            }

            var speaker = await _context.speakers
                .FirstOrDefaultAsync(m => m.SpeakerId == id);
            if (speaker == null)
            {
                return NotFound();
            }

            return View(speaker);
        }

        // GET: Speakers/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Speakers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpeakerViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Speaker speaker = new Speaker
                {
                    Ime = model.ime,
                    Tema = model.tema,
                    Spol = model.spol,
                    Slika = uniqueFileName,
                };
                _context.Add(speaker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        private string UploadedFile(SpeakerViewModel model)
        {
            string uniqueFileName = null;

            if (model.profilnaSlika != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.profilnaSlika.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.profilnaSlika.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

            // GET: Speakers/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.speakers == null)
            {
                return NotFound();
            }

            var speaker = await _context.speakers.FindAsync(id);
            if (speaker == null)
            {
                return NotFound();
            }
            return View(speaker);
        }

        // POST: Speakers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpeakerViewModel model)
        {
            var speaker = await _context.speakers.FindAsync(id);
            if (id != speaker.SpeakerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                speaker.Ime = model.ime;
                speaker.Tema= model.tema;
                speaker.Spol = model.spol;

                if (model.profilnaSlika != null)
                {
                    //if (model.profilnaSlika != null)
                    //{
                    //    string filePath = Path.Combine(_environment.WebRootPath, "images", model.ExistingImage);
                    //    System.IO.File.Delete(filePath);
                    //}

                    speaker.Slika = UploadedFile(model);
                }


                try
                {
                    _context.Update(speaker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeakerExists(speaker.SpeakerId))
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
            return View(speaker);
        }

        // GET: Speakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.speakers == null)
            {
                return NotFound();
            }

            var speaker = await _context.speakers
                .FirstOrDefaultAsync(m => m.SpeakerId == id);
            if (speaker == null)
            {
                return NotFound();
            }

            return View(speaker);
        }

        // POST: Speakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.speakers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.speakers'  is null.");
            }
            var speaker = await _context.speakers.FindAsync(id);
            if (speaker != null)
            {
                _context.speakers.Remove(speaker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeakerExists(int id)
        {
          return _context.speakers.Any(e => e.SpeakerId == id);
        }
    }
}
