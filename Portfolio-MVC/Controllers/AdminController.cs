using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Portfolio_MVC.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyPortfolioContext _context;
        private readonly PasswordHasher<Admin> _passwordHasher;

        public AdminController(MyPortfolioContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Admin>();
        }
        // GET: /Admin/Index
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Admin/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Admin/Login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Kullanıcı adı ile admini veritabanından bul
            var admin = await _context.Admin.SingleOrDefaultAsync(a => a.UserName == username);

            // Kullanıcı adı bulunamadı veya şifre eşleşmiyor
            if (admin == null || admin.Password != password)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View();
            }

            // Şifre doğrulandıysa kimlik doğrulaması yap
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, username)
    };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Admin");
        }


        // GET: /Admin/Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}