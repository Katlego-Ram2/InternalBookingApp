using System.ComponentModel.DataAnnotations;

namespace InternalBookingApp.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public string Description { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        public int Capacity { get; set; }
    }
}
