using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carpool.Models
{
    public class UserModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "User Name Required!")]
        [MaxLength (50,ErrorMessage ="Too Long Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0][\d]{3}[\d]{7}$", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender {get;set;}
        
        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(17, ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[Kk]{1}[0-9]{6}@nu.edu.pk$", ErrorMessage = "Provide your NU Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Too Short Password", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Too Short Password", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }

    }
}