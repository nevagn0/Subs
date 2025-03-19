using Microsoft.AspNetCore.Mvc;

namespace Subscribers.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View("Authorization");
        }
    }
}
