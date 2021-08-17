using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace carpool.Models
{
    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [StringLength(255)]
        public string AdminId { get; set; }
        [StringLength(255)]
        public string AdminName { get; set; }
        [StringLength(255)]
        public string PhoneNumber { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Passwords { get; set; }
        [StringLength(200)]
        public string CreationDate { get; set; }
        [StringLength(10)]
        public string Role { get; set; }
    }
}
