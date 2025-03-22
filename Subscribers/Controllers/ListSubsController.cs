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
            if (HttpContext.Session.GetInt32("UserId") is int userId)
            {
                var userSubs = _context.Subcribs.Where(u => u.Iduser == userId).ToList();
                return View(userSubs);  
            }
            return View(new List<Subcrib>());
        }
    }
}
