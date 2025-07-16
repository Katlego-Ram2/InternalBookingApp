using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalBookingApp.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [NotMapped]
        public int Id => ResourceId; // ✅ optional alias

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [MaxLength(100)]
        public string? Location { get; set; }

        public int Capacity { get; set; }

        public bool IsAvailable { get; set; } = true;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
