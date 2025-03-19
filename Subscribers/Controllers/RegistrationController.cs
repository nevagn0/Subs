using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Subscribers.Models;
using System.Threading.Tasks;

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
                return View("Registration", user);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}