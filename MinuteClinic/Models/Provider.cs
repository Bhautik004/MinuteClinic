using System.ComponentModel.DataAnnotations;

namespace MinuteClinic.Models
{
    public class Provider
    {

        [Key]  // Marks this as the primary key
        public int ProviderId { get; set; }

        [Required(ErrorMessage = "Provider name is required.")]
        [StringLength(100, ErrorMessage = "Provider name cannot be longer than 100 characters.")]
        [Display(Name = "Provider Name")]  // Display name for UI
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        [Display(Name = "Provider Address")]  // Display name for UI
        public string Address { get; set; }



    }
}
