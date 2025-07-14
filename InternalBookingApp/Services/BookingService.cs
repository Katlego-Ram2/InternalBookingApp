using InternalBookingApp.Data;
using InternalBookingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalBookingApp.Services
{
    public class BookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Check for booking conflicts on the same resource/time
        public async Task<bool> IsBookingConflictAsync(int resourceId, DateTime startTime, DateTime endTime, int? bookingId = null)
        {
            return await _context.Bookings
                .Where(b => b.ResourceId == resourceId)
                .Where(b => bookingId == null || b.BookingId != bookingId)
                .AnyAsync(b => startTime < b.EndTime && endTime > b.StartTime);
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Resource)
                .ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Resource)
                .FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task CreateBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
