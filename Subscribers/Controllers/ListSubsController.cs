using Microsoft.AspNetCore.Mvc;
using Subscribers.Models;

namespace Subscribers.Controllers
{
    public class ListSubsController : Controller
    {
        private readonly Spo2Context _context;
        public ListSubsController(Spo2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListUserSubs(Subcrib subcrib)
        {
            if (HttpContext.Session.GetInt32("UserId") is int userId)
            {
                var UserSubs = _context.Subcribs.Where(u => u.Iduser == userId).ToList();
                return View(UserSubs);
            }
            return View();
        }
    }
}
