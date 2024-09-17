using Microsoft.AspNetCore.Mvc;
using Portfolio_MVC;


namespace MyPortfolioUdemy.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _context;
        public _AboutComponentPartial(MyPortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.About.ToList();
            return View(values);
        }
    }
}
