using Microsoft.AspNetCore.Mvc;

namespace InternalBookingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string role)
        {
            // Fake login logic — in real app you'd check a database

            if (role == "Admin")
                return RedirectToAction("Index", "Resources");

            if (role == "User")
                return RedirectToAction("Index", "Bookings");

            return View(); // fallback
        }
    }
}
