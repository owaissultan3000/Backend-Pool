using System.ComponentModel.DataAnnotations;

namespace carpool.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(17, ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^\w+([-+.']\w+)*@nu.edu.pk$", ErrorMessage = "Provide your NU Email")]
        public string UserEmail { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Too Short Password", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}