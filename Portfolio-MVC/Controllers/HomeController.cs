using Microsoft.AspNetCore.Mvc;
using Portfolio_MVC.Models;
using System.Diagnostics;

namespace Portfolio_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
