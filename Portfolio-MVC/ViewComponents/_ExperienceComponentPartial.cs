using Microsoft.AspNetCore.Mvc;
using Portfolio_MVC;
namespace MyPortfolioUdemy.ViewComponents
{
    public class _ExperienceComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
