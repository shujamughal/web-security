using lec1WebSecurity.Models;
using Microsoft.AspNetCore.Mvc;

namespace lec1WebSecurity.Controllers
{
    public class UserController : Controller
    {
        private readonly ISanitizationService _sanitizationService;

        public UserController(ISanitizationService sanitizationService) {
            _sanitizationService = sanitizationService;

        }


        public IActionResult Register()
        {
            return View();
        }
            [HttpPost]
        public IActionResult Register(UserInputModel model)
        {
            if (ModelState.IsValid)
            {
                var sanitizedComment = _sanitizationService.SanitizeInput(model.Comment);
                // Process the sanitized comment

                // Process the valid input
                return RedirectToAction("Success");
            }

            // Return the view with validation errors
            return View(model);
        }
    }

}
