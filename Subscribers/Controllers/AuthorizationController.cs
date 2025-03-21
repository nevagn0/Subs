using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Subscribers.Models;

namespace Subscribers.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly Spo2Context _context;
        public AuthorizationController(Spo2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View("Authorization");
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(User user)
        {
            var auth = _context.Users.FirstOrDefault(u => u.PhoneNumber == user.PhoneNumber && u.Password == user.Password);
            if (auth != null)
            {
                return RedirectToAction("Index", "MainPage");
            }
            else
            {
                ModelState.AddModelError("PhoneNumber", "Пользователь с такими данными не найден");
                ModelState.AddModelError("Password", "Пользователь с такими данными не найден");
                return View("Authorization", user);
            }
        }
        public IActionResult Reset()
        {
            return RedirectToAction("Index", "ResetPassword");
        }
    }
}
