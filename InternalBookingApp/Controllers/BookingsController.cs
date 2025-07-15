using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternalBookingApp.Data;
using InternalBookingApp.Models;
using InternalBookingApp.Services;

namespace InternalBookingApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly BookingService _bookingService;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
            _bookingService = new BookingService(context);
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings.Include(b => b.Resource).ToListAsync();
            return View(bookings);
        }

        public IActionResult Create()
        {
            ViewBag.ResourceId = new SelectList(_context.Resources, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ResourceId = new SelectList(_context.Resources, "Id", "Name", booking.ResourceId);
                return View(booking);
            }

            if (_bookingService.HasConflict(booking))
            {
                ModelState.AddModelError("", "This resource is already booked during the selected time.");
                ViewBag.ResourceId = new SelectList(_context.Resources, "Id", "Name", booking.ResourceId);
                return View(booking);
            }

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
