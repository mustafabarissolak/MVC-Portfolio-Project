using Microsoft.AspNetCore.Mvc;
using Portfolio_MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio_MVC.Controllers
{
    public class SkillsController : Controller
    {
        private readonly MyPortfolioContext _context;

        public SkillsController(MyPortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
			ViewData["SkillsCount"] = _context.Skills.Count();
			var skills = _context.Skills.ToList();
            return View(skills);
        }

		// GET: Skills/Create
		public IActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _context.Skills.Add(skill);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: Skills/Edit/5
        public IActionResult Edit(int id)
        {
            var skill = _context.Skills.Find(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        // POST: Skills/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Skill skill)
        {
            if (id != skill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(skill);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // POST: Skills/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var skill = _context.Skills.Find(id);
            if (skill == null)
            {
                return NotFound();
            }
            _context.Skills.Remove(skill);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
