using Microsoft.AspNetCore.Mvc;

namespace Portfolio_MVC.ViewComponents
{
	public class _AdminScriptsComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
