using Microsoft.AspNetCore.Mvc;
using Portfolio_MVC.Models;
using Portfolio_MVC;

namespace MyPortfolioMVCProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly MyPortfolioContext _context;

        public ContactController(MyPortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Submit(Contact model)
        {
            if (ModelState.IsValid)
            {
                _context.Contact.Add(model);
                _context.SaveChanges();

                return Json(new { success = true, message = "Mesajınız başarıyla gönderildi." });
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                string errorMessage = string.Join(" ", errors);

                return Json(new { success = false, message = errorMessage });
            }
        }

    }
}
