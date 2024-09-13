using Microsoft.AspNetCore.Mvc;

namespace Portfolio_MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
