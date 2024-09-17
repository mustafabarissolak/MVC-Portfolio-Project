using Microsoft.AspNetCore.Mvc;

namespace Portfolio_MVC.ViewComponents
{
    public class _AdminAboutConponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
