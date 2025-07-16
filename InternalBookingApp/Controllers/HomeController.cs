using Microsoft.AspNetCore.Mvc;

namespace InternalBookingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
