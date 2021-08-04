using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace carpool.Models
{
    public partial class Ride
    {
        [Key]
        [StringLength(255)]
        public string RideId { get; set; }
        [StringLength(255)]
        public string CaptainId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string VehicleId { get; set; }
        [Required]
        [StringLength(4000)]
        public string JourneyRoute { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DepartureTime { get; set; }
        [StringLength(70)]
        public string FarePerSeats { get; set; }
        public int? AvailableSeats { get; set; }

        [ForeignKey(nameof(CaptainId))]
        [InverseProperty("Rides")]
        public virtual Captain Captain { get; set; }
    }
}
