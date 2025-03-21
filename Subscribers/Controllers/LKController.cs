using Microsoft.AspNetCore.Mvc;

namespace Subscribers.Controllers
{
    public class LKController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
