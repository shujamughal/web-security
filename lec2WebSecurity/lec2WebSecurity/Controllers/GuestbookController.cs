using lec2WebSecurity.Models;
using Microsoft.AspNetCore.Mvc;

namespace lec2WebSecurity.Controllers
{
    public class GuestbookController : Controller
    {
        private static List<GuestbookEntry> _entries = new List<GuestbookEntry>();

        public IActionResult Index()
        {
            return View(_entries);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GuestbookEntry entry)
        {
            if (ModelState.IsValid)
            {
                // Simulate database insertion
                entry.Id = _entries.Count + 1;
                entry.DatePosted = DateTime.Now;

                // XSS Vulnerability: No sanitization of Message field
                _entries.Add(entry);

                return RedirectToAction("Index");
            }

            return View(entry);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }


}
