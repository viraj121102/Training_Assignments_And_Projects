using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
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
