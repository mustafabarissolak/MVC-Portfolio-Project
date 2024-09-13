using Microsoft.AspNetCore.Mvc;
using Portfolio_MVC;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _SkillComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _context;

        // Constructor üzerinden DbContext inject ediliyor
        public _SkillComponentPartial(MyPortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }
    }
}
