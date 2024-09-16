using Microsoft.AspNetCore.Mvc;
using Portfolio_MVC.Models;
using Portfolio_MVC;
using Microsoft.AspNetCore.Authorization;

namespace MyPortfolioMVCProject.Controllers
{
	[Authorize]
	public class ContactController : Controller
	{
		private readonly MyPortfolioContext _context;

		public ContactController(MyPortfolioContext context)
		{
			_context = context;
		}
		[HttpGet]
		public JsonResult GetUnreadMessagesCount()
		{
			var unreadMessagesCount = _context.Contact.Count(c => !c.IsRead);
			return Json(new { count = unreadMessagesCount });
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
		public IActionResult Index()
		{
			// Unread message count
			ViewData["MessagesCount"] = _context.Contact.Count(c => !c.IsRead);
			var values = _context.Contact.ToList();
			return View(values);
		}
		public IActionResult ChangeIsReadToTrue(int id)
		{
			var value = _context.Contact.Find(id);
			if (value == null)
			{
				return NotFound(); // 404 hatası döndür
			}
			value.IsRead = true;
			_context.SaveChanges();
			return RedirectToAction("Inbox");
		}
		public IActionResult ChangeIsReadToFalse(int id)
		{
			var value = _context.Contact.Find(id);
			value.IsRead = false;
			_context.SaveChanges();
			return RedirectToAction("Inbox");
		}

		public IActionResult DeleteMessage(int id)
		{
			var value = _context.Contact.Find(id);
			_context.Contact.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("Inbox");
		}
		public IActionResult MessageDetail(int id)
		{
			var value = _context.Contact.Find(id);
			return View(value);
		}
	}
}
