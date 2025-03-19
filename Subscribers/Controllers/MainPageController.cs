using Microsoft.AspNetCore.Mvc;

namespace Subscribers.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
