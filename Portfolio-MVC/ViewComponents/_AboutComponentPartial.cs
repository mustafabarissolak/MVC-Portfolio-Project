using Microsoft.AspNetCore.Mvc;
using Portfolio_MVC;


namespace MyPortfolioUdemy.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
