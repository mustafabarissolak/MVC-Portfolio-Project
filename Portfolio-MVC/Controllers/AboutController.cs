using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio_MVC.Models;

namespace Portfolio_MVC.ViewComponents
{
    [Authorize]
    public class AboutController : Controller
    {
        private readonly MyPortfolioContext _context;

        public AboutController(MyPortfolioContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var About = _context.About.ToList();
            return View(About);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(About about)
        {
            if (ModelState.IsValid)
            {
                _context.About.Add(about);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }
        public IActionResult Edit(int id)
        {
            var about = _context.About.Find(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        [HttpPost]
        public IActionResult Edit(int id, About about)
        {
            if (id != about.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(about);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }
        public IActionResult Delete(int id)
        {
            var about = _context.About.Find(id);
            if (about == null)
            {
                return NotFound();
            }
            _context.About.Remove(about);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
