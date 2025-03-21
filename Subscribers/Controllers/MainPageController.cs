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
            return View();
        }
    }
}
