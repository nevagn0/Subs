using Microsoft.AspNetCore.Mvc;
using Subscribers.Models;

namespace Subscribers.Controllers
{
    public class UpdateController : Controller
    {
        private readonly Spo2Context _context;
        public UpdateController(Spo2Context context)
        {
            _context = context;
        }
        public IActionResult Update(int id)
        {
            var IdSub = _context.Subcribs.FirstOrDefault(x => x.Id == id);
            return View(IdSub);
        }

        [HttpPost]
        public IActionResult Update(Subcrib sub)
        {
            _context.Subcribs.Update(sub);
            _context.SaveChanges();
            return RedirectToAction("Index", "Listsubs");
        }
    }
}
