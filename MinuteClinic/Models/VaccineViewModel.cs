using Microsoft.AspNetCore.Mvc.Rendering;

namespace MinuteClinic.Models
{
    public class VaccineViewModel
    {
        public int? SelectedClinicId { get; set; }
        public int? SelectedProviderId { get; set; }
        public IEnumerable<SelectListItem> Clinics { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Providers { get; set; } = new List<SelectListItem>();
        public IEnumerable<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
    }
}
