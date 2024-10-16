using System.ComponentModel.DataAnnotations;

namespace MinuteClinic.Models
{
    public class Clinics
    {

        [Key]
        public int ClinicId { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(200, ErrorMessage = "Location cannot be longer than 200 characters.")]
        [Display(Name = "Clinic Location")]
        public string Location { get; set; }


        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City cannot be longer than 100 characters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [StringLength(2, ErrorMessage = "State must be a valid 2-letter state code (e.g., NY, CA).")]
        [Display(Name = "State")]
        public string State { get; set; }


        [Required(ErrorMessage = "ZipCode is required.")]
        [Range(00000, 99999, ErrorMessage = "ZipCode must be a 5-digit number.")]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

    }
}
