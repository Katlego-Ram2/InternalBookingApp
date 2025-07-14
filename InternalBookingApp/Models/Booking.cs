using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalBookingApp.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Resource")]
        public int ResourceId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = "Pending"; // e.g. Pending, Confirmed, Cancelled

        public string Notes { get; set; }

        public User User { get; set; }
        public Resource Resource { get; set; }
    }
}
