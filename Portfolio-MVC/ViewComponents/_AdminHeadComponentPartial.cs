using Microsoft.AspNetCore.Mvc;

namespace Portfolio_MVC.ViewComponents
{
    public class _AdminHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
