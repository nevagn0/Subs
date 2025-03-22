using Microsoft.AspNetCore.Mvc;
using Subscribers.Models;

namespace Subscribers.Controllers
{
    public class AddSubcribeController : Controller
    {
        private readonly Spo2Context _context;
        public AddSubcribeController(Spo2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Subcrib sub,User user)
        {
            if (HttpContext.Session.GetInt32("UserId") is int userId)
            {
                sub.Iduser = userId;
                _context.Subcribs.Add(sub);
                await _context.SaveChangesAsync();
                return View();
            }
            return RedirectToAction("Index", "MainPage"); 
        }
    }
}
