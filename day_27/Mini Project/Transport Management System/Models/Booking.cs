using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transport_Management_System.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [ForeignKey("Trip")]
        public int TripID { get; set; }

        [ForeignKey("Passenger")]
        public int PassengerID { get; set; }

        [Required, StringLength(50)]
        public string Status { get; set; } // e.g., Confirmed, Cancelled, Completed

        // 🔗 Navigation Properties
        public Trip? Trip { get; set; }
        public Passenger? Passenger { get; set; }
    }
}
