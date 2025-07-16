using InternalBookingApp.Data;
using InternalBookingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InternalBookingApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bookings/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Resources = new SelectList(await _context.Resources.ToListAsync(), "Id", "Name");
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            ViewBag.Resources = new SelectList(await _context.Resources.ToListAsync(), "Id", "Name");

            if (!ModelState.IsValid)
                return View(booking);

            // Booking conflict logic
            bool conflict = await _context.Bookings.AnyAsync(b =>
                b.ResourceId == booking.ResourceId &&
                (
                    (booking.StartTime >= b.StartTime && booking.StartTime < b.EndTime) ||
                    (booking.EndTime > b.StartTime && booking.EndTime <= b.EndTime) ||
                    (booking.StartTime <= b.StartTime && booking.EndTime >= b.EndTime)
                ));

            if (conflict)
            {
                ViewBag.Conflict = "This resource is already booked during the selected time range.";
                return View(booking);
            }

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Booking created successfully!";
            return RedirectToAction("Create");
        }
    }
}
