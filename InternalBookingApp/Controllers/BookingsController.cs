using InternalBookingApp.Models;
using InternalBookingApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternalBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingsController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
                return NotFound();

            return booking;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(Booking booking)
        {
            // Check booking conflicts
            var conflict = await _bookingService.IsBookingConflictAsync(booking.ResourceId, booking.StartTime, booking.EndTime);
            if (conflict)
                return BadRequest("Booking conflict detected for the selected resource and time.");

            await _bookingService.CreateBookingAsync(booking);
            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, booking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, Booking booking)
        {
            if (id != booking.BookingId)
                return BadRequest();

            // Check booking conflicts excluding current booking
            var conflict = await _bookingService.IsBookingConflictAsync(booking.ResourceId, booking.StartTime, booking.EndTime, booking.BookingId);
            if (conflict)
                return BadRequest("Booking conflict detected for the selected resource and time.");

            await _bookingService.UpdateBookingAsync(booking);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return NoContent();
        }
    }
}
