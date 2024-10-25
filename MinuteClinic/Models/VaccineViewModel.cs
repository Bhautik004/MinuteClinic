namespace MinuteClinic.Models
{
    public class VaccineViewModel
    {
        public List<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
        public List<Clinics> Clinics { get; set; } = new List<Clinics>();
        public List<Provider> Providers { get; set; } = new List<Provider>();
        public string[] AvailableTimeSlots { get; set; } = new string[0];

        public int? SelectedClinicId { get; set; }
        public int? SelectedProviderId { get; set; }
    }
}
