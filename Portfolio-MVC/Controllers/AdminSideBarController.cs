using Microsoft.AspNetCore.Mvc;

namespace Portfolio_MVC.Controllers
{
    public class AdminSideBarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
