using Microsoft.AspNetCore.Mvc;

namespace Portfolio_MVC.ViewComponents
{
    public class _AdminContactConponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
