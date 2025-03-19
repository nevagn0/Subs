using Microsoft.AspNetCore.Mvc;
using Subscribers.Models;

namespace Subscribers.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly Spo2Context _context;
        public RegistrationController(Spo2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View("Registration");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Firstname != null && user.Firstname.Length > 50)
                {
                    ModelState.AddModelError("Firstname", "Имя Не может быть пустым или больше 50 символов");
                }
                if(user.Secondname != null && user.Secondname.Length > 50)
                {
                    ModelState.AddModelError("Secondname", "Фамилия не может быть пыстым или больше 50 символов");
                }
            }
            /*if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Registration", user);
            }
            }*/
        }
}
