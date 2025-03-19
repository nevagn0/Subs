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
            if (user.Firstname == null || user.Firstname.Length > 50)
            {
                ModelState.AddModelError("Firstname", "Имя не может быть пустым или больше 50 символов");
            }

            if (user.Secondname == null || user.Secondname.Length > 50)
            {
                ModelState.AddModelError("Secondname", "Фамилия не может быть пустой или больше 50 символов");
            }

            if (user.PhoneNumber == null)
            {
                string phonePattern = @"^(\+7|8)\d{10}$";
                if (!Regex.IsMatch(user.PhoneNumber, phonePattern))
                {
                    ModelState.AddModelError("PhoneNumber", "Телефон должен быть в формате 89999999999 или +79999999999");
                }
            }
            else
            {
                ModelState.AddModelError("PhoneNumber", "Телефон обязателен для заполнения");
            }

            if (user.Password == null || user.Password.Length < 8)
            {
                ModelState.AddModelError("Password", "Пароль не может быть пустым или быть меньше 8 символов");
            }

            if (!ModelState.IsValid)
            {
                return View("Authorization", user);
            }
            var aut = _context.Users.FirstOrDefault(u => u.PhoneNumber ==  user.PhoneNumber && u.Password == user.Password);
            if (aut == null)
            {
                ModelState.AddModelError(string.Empty, "Пользоаветь с такими данными не найден");
            }
            return RedirectToAction("Index", "Home");
            
        }
    }
}
