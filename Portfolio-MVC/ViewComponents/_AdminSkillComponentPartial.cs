using Microsoft.AspNetCore.Mvc;

namespace Portfolio_MVC.ViewComponents
{
    public class _AdminSkillComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
