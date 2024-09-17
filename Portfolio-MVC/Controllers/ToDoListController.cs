using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio_MVC.Models;

namespace Portfolio_MVC.Controllers
{
	[Authorize]
	public class ToDoListController : Controller
    {
        private readonly MyPortfolioContext _context;

        public ToDoListController(MyPortfolioContext context)
        {
            _context = context;
        }
		public IActionResult Index()
		{
			ViewData["ToDoListCount"] = _context.ToDoList.Count(t => !t.Status);
			var tasks = _context.ToDoList.ToList();
			return View(tasks);
		}
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDoList toDo)
        {
            if (ModelState.IsValid)
            {
                _context.ToDoList.Add(toDo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }
        public IActionResult Update(int id)
        {
            var toDo = _context.ToDoList.Find(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(toDo);
        }

        [HttpPost]
        public IActionResult Update(int id, ToDoList toDo)
        {
            if (id != toDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(toDo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var toDo = _context.ToDoList.Find(id);
            if (toDo == null)
            {
                return NotFound();
            }
            _context.ToDoList.Remove(toDo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ChangeToDoListStatusToTrue(int id) 
        {
            var value = _context.ToDoList.Find(id);
            value.Status = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ChangeToDoListStatusToFalse(int id)
        {
            var value = _context.ToDoList.Find(id);
            value.Status = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
