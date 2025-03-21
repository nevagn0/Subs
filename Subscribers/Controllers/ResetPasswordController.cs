using Microsoft.AspNetCore.Mvc;

namespace Subscribers.Controllers
{
    public class ResetPasswordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
