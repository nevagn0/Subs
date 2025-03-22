using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Subscribers.Models;

namespace Subscribers.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly Spo2Context _context;

        public ExpensesController(Spo2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            var userSubsPrice = _context.Subcribs.Where(x => x.Iduser == userId).ToList();
            decimal totalExpenses = userSubsPrice.Sum(u => u.Price);

            ViewBag.TotalExpenses = totalExpenses;
            ViewBag.Subscriptions = userSubsPrice;

            return View();
        }
    }
}