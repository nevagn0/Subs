using System.Data;
using Microsoft.AspNetCore.Mvc;
using Subscribers.Models;

namespace Subscribers.Controllers
{
    public class MainPageController : Controller
    {
        private readonly Spo2Context _context;
        public MainPageController(Spo2Context spo2Context)
        {
            _context = spo2Context;
        }
        public IActionResult Index()
        {
            if (TempData["UserId"] is int userId)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    return View(user);
                }
            }
            return RedirectToAction("Index", "Authorization");
        }
    }
}
