using Microsoft.AspNetCore.Mvc;

namespace Portfolio_MVC.ViewComponents
{
	public class _AdminNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}

	}
}
