using System.ComponentModel.DataAnnotations;

namespace Transport_Management_System.Models
{
    public class Passenger
    {
        [Key]
        public int PassengerID { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(10)]
        public string Gender { get; set; }

        public int Age { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        // 🔗 Navigation: A passenger can have many bookings
        public ICollection<Booking>? Bookings { get; set; }
    }
}
