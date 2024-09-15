using Microsoft.AspNetCore.Mvc;

namespace Portfolio_MVC.ViewComponents
{
	public class _AdminSideComponentPartial : ViewComponent
	{
		private readonly MyPortfolioContext _context;

		public _AdminSideComponentPartial (MyPortfolioContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			ViewData["ToDoListCount"] = _context.ToDoList.Count(t => !t.Status);
			var tasks = _context.ToDoList.ToList();
			ViewData["SkillsCount"] = _context.Skills.Count();
			var skills = _context.Skills.ToList();
			ViewData["MessagesCount"] = _context.Contact.Count(c => !c.IsRead);
			var values = _context.Contact.ToList();
			return View();
		}

	}
}
