using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MinuteClinic.Models
{
    public class Vaccine
    {


        [Key]
        public int VaccineId { get; set; }


        [Required(ErrorMessage = "Vaccine name is required.")]
        [StringLength(100, ErrorMessage = "Vaccine name cannot be longer than 100 characters.")]
        
        public string Name { get; set; }



        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 10000, ErrorMessage = "Price must be between 1 and 10,000.")]
        public int? Price { get; set; }

       
        public string ? VaccineImage { get; set; }


        [Required(ErrorMessage = "Clinic is required.")]
        [ValidateNever]
        public Clinics Clinic { get; set; } = null!;

        [Required(ErrorMessage = "Clinic is required.")]
        public int ?ClinicId { get; set; }


        [Required(ErrorMessage = "Provider is required.")]
        public int? ProviderId { get; set; }

        [Required(ErrorMessage = "Provider is required.")]
        [ValidateNever]
        public Provider Providers { get; set; } = null!;

        [Required(ErrorMessage = "Available Time Slots is required.")]
        public string AvailableTimeSlots { get; set; } = "10:00 AM,10:30 AM,11:00 AM,11:30 AM,12:00 PM,12:30 PM,1:00 PM,1:30 PM";


    }
}
