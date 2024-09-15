using Microsoft.AspNetCore.Mvc;
namespace Portfolio_MVC.ViewComponents
{
    public class _AdminToDoListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
