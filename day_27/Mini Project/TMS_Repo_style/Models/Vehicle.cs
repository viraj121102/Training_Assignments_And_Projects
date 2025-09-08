using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }

        [Required, StringLength(255)]
        public required string Model { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Capacity { get; set; }

        [Required, StringLength(50)]
        public required string Type { get; set; } // Truck, Van, Bus

        [Required, StringLength(50)]
        public required string Status { get; set; } // Available, On Trip, Maintenance

        // 🔗 Navigation: A vehicle can have many trips
        public ICollection<Trip>? Trips { get; set; }
    }
}
