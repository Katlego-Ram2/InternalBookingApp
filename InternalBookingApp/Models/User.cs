using System.ComponentModel.DataAnnotations;

namespace InternalBookingApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [MaxLength(20)]
        public string CellphoneNumber { get; set; }

        [MaxLength(50)]
        public string Role { get; set; }  // e.g. Admin, Staff, User

        [MaxLength(200)]
        public string Address { get; set; }
    }
}

