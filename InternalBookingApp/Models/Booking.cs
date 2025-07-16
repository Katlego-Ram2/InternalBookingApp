using System;
using System.ComponentModel.DataAnnotations;

namespace InternalBookingApp.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public string BookedBy { get; set; } = string.Empty;

        [Required]
        public string Purpose { get; set; } = string.Empty;

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string? Notes { get; set; }

        // Relationships
        public int ResourceId { get; set; }

        public Resource? Resource { get; set; }

        public string? User { get; set; }
    }
}
