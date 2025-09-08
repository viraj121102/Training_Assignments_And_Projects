using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transport_Management_System.Models
{
    public class Route
    {
        [Key]
        public int RouteID { get; set; }

        [Required, StringLength(255)]
        public string? StartDestination { get; set; }

        [Required, StringLength(255)]
        public string? EndDestination { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double Distance { get; set; }

        // 🔗 Navigation: A route can be used by many trips
        public ICollection<Trip>? Trips { get; set; }
    }
}
