using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace carpool.Models
{
    public partial class Captain
    {
        public Captain()
        {
            Rides = new HashSet<Ride>();
        }

        [Key]
        [StringLength(255)]
        public string CaptainId { get; set; }
        [StringLength(255)]
        public string CaptainName { get; set; }
        [StringLength(255)]
        public string CaptainPhone { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(20)]
        public string VehicleNumber { get; set; }
        [StringLength(100)]
        public string VehicleModel { get; set; }
        [StringLength(20)]
        public string VehicleColor { get; set; }
        [Column(TypeName = "image")]
        public byte[] CaptainImage { get; set; }
        [StringLength(255)]
        public string Passwords { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreateionDate { get; set; }
        [StringLength(10)]
        public string Role { get; set; }

        [InverseProperty(nameof(Ride.Captain))]
        public virtual ICollection<Ride> Rides { get; set; }
    }
}
