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
        [StringLength(2000)]
        public string CaptainImage { get; set; }
        [StringLength(70)]
        public string FarePerSeats { get; set; }
        [StringLength(255)]
        public string Passwords { get; set; }
        [StringLength(200)]
        public string CreateionDate { get; set; }
        [StringLength(10)]
        public string Role { get; set; }
    }
}
