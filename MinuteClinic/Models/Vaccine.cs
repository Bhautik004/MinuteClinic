using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinuteClinic.Models
{
    public class Vaccine
    {


        [Key]
        public int VaccineId { get; set; }

        [Required(ErrorMessage = "Vaccine name is required.")]
        [StringLength(100, ErrorMessage = "Vaccine name cannot be longer than 100 characters.")]
        [Display(Name = "Vaccine Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10,000.")]
        [Column(TypeName = "decimal(18, 2)")]  // Specifies the precision of the decimal value in the database
        [Display(Name = "Price (in USD)")]  // Custom display name
        public double Price { get; set; }

        [Display(Name = "Vaccine Image")]
        public string VaccineImage { get; set; }

        [Display(Name = "Clinic")]  // Display name for UI
        public int ClinicId { get; set; }
        public Clinics Clinic { get; set; }

        [Display(Name = "Provider")]
        public int ProviderId { get; set; } 
        public Provider Provider { get; set; }


        [Display(Name = "Available Time Slots")]
        public string AvailableTimeSlots { get; set; } = "10:00 AM,10:30 AM,11:00 AM,11:30 AM,12:00 PM,12:30 PM,1:00 PM,1:30 PM";


    }
}
