using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio_MVC.Models;

namespace Portfolio_MVC.ViewComponents
{
    [Authorize]
    public class ExperienceController : Controller
    {
        private readonly MyPortfolioContext _context;

        public ExperienceController(MyPortfolioContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var experience = _context.Experience.ToList();
            return View(experience);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Experience experience)
        {
            if (ModelState.IsValid)
            {
                _context.Experience.Add(experience);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(experience);
        }
        public IActionResult Edit(int id)
        {
            var experience = _context.Experience.Find(id);
            if (experience == null)
            {
                return NotFound();
            }
            return View(experience);
        }

        [HttpPost]
        public IActionResult Edit(int id, Experience experience)
        {
            if (id != experience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(experience);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(experience);
        }
        public IActionResult Delete(int id)
        {
            var experience = _context.Experience.Find(id);
            if (experience == null)
            {
                return NotFound();
            }
            _context.Experience.Remove(experience);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
