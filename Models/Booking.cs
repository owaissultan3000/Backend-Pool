using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace carpool.Models
{
    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        [StringLength(200)]
        public string BookingId { get; set; }
        [StringLength(255)]
        public string CaptainId { get; set; }
        [StringLength(255)]
        public string PassengerId { get; set; }
        [Required]
        [StringLength(255)]
        public string PassengerName { get; set; }
        [Required]
        [StringLength(255)]
        public string PassengerPhoneNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string PassengerDestination { get; set; }

        [ForeignKey(nameof(CaptainId))]
        [InverseProperty("Bookings")]
        public virtual Captain Captain { get; set; }
        [ForeignKey(nameof(PassengerId))]
        [InverseProperty(nameof(User.Bookings))]
        public virtual User Passenger { get; set; }
    }
}
