using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pr_pin.Data;
using pr_pin.Models;

namespace pr_pin.Controllers
{
    public class ReviewPredavanjaaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReviewPredavanjaaController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }


        public async Task<IActionResult> Index()
        {

            var innerJoinQuery =
    (from sp in _context.speakers
     join pr in _context.predavanja on sp.SpeakerId equals pr.SpeakerId
    select new ReviewPredavanja
    { ime = sp.Ime,
         profilnaSlika= sp.Slika, 
        NaslovTeme = pr.NaslovTeme,
        datumPredavanja=  pr.datumPredavanja });

            
            return View(innerJoinQuery.ToList());
        }
       

        // GET: ReviewPredavanjaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReviewPredavanjaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReviewPredavanjaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReviewPredavanjaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReviewPredavanjaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReviewPredavanjaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReviewPredavanjaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
