using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioUdemy.ViewComponents;
using Portfolio_MVC;
namespace MyPortfolioUdemy.ViewComponents
{
    public class _ExperienceComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _context;

        public _ExperienceComponentPartial(MyPortfolioContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Experience.ToList();
            return View(values);
        }
    }
}

