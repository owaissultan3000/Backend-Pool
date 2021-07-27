using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carpool.Models
{
    public class CaptainModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public  Guid CaptainId { get; set; }

        [Required(ErrorMessage = "User Name Required!")]
        [MaxLength (50,ErrorMessage ="Too Long Name")]
        public string CaptainName { get; set; }
        
        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0][\d]{3}[\d]{7}$", ErrorMessage = "Invalid phone number")]
        public string CaptainPhone { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender {get;set;} 

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(17, ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[Kk]{1}[0-9]{6}@nu.edu.pk$", ErrorMessage = "Provide your NU Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vehicle Number is required.")]
        [MaxLength(8, ErrorMessage = "Invalid Vehicle Number")]
        [RegularExpression(@"^[A-Za-z]{3,4}-?[0-9]{3,4}$", ErrorMessage = "Provide Valid Vehicle Number")]
        public string VehicleNumber { get; set; }

        [Required(ErrorMessage = "Vehicle Model is required.")]
        public string VehicleModel { get; set; }

        [Required(ErrorMessage = "Vehicle Color is required.")]
        public string VehicleColor { get; set; }
        public byte[] CaptainImage { get; set; }

        public int FarePerSeats { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Too Short Password", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Too Short Password", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        public DateTime? date;
        public DateTime Date
        {
            get { return date ?? DateTime.Today; }
            set { date = value; }
        }

        public readonly string Role  = "Captain";

    }
}