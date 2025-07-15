using InternalBookingApp.Data;
using InternalBookingApp.Models;
using System.Linq;

namespace InternalBookingApp.Services
{
    public class BookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool HasConflict(Booking newBooking)
        {
            return _context.Bookings.Any(existing =>
                existing.ResourceId == newBooking.ResourceId &&
                existing.Id != newBooking.Id &&
                newBooking.StartTime < existing.EndTime &&
                newBooking.EndTime > existing.StartTime
            );
        }
    }
}
