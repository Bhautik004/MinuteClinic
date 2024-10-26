using Microsoft.EntityFrameworkCore;

namespace MinuteClinic.Models
{
    public class MinuteClinicContext : DbContext
    {
        public MinuteClinicContext(DbContextOptions<MinuteClinicContext> options)
            : base(options)
        {
        }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Clinics> Clinics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vaccine>().ToTable("Vaccine");
            modelBuilder.Entity<Provider>().ToTable("Provider");
            modelBuilder.Entity<Clinics>().ToTable("Clinics");

            modelBuilder.Entity<Clinics>().HasData(
                new Clinics { ClinicId = 1, ClinicName = "NY Clinic", Location = "1234 Elm St", City = "Anytown", State = "NY", ZipCode = 12345 },
                new Clinics { ClinicId = 2, ClinicName = "IL Clinic", Location = "5678 Oak St", City = "Othertown", State = "IL", ZipCode = 45678 },
                new Clinics { ClinicId = 3, ClinicName = "MI Clinic", Location = "91011 Pine St", City = "Thirdtown", State = "MI", ZipCode = 90012 },
                new Clinics { ClinicId = 4, ClinicName = "CA Health Center", Location = "7890 Maple Ave", City = "Los Angeles", State = "CA", ZipCode = 90210 },
                new Clinics { ClinicId = 5, ClinicName = "Downtown Clinic", Location = "321 Cedar St", City = "Chicago", State = "IL", ZipCode = 60601 },
                new Clinics { ClinicId = 6, ClinicName = "Westside Clinic", Location = "654 Spruce St", City = "Denver", State = "CO", ZipCode = 80202 },
                new Clinics { ClinicId = 7, ClinicName = "Bay Area Clinic", Location = "987 Redwood Rd", City = "San Francisco", State = "CA", ZipCode = 94102 },
                new Clinics { ClinicId = 8, ClinicName = "South Beach Clinic", Location = "111 Ocean Dr", City = "Miami", State = "FL", ZipCode = 33139 }
            );


            modelBuilder.Entity<Provider>().HasData(
                new Provider { ProviderId = 1, Name = "Moderna", Address = "NY" },
                new Provider { ProviderId = 2, Name = "AstraZeneca", Address = "UK" },
                new Provider { ProviderId = 3, Name = "Pfizer", Address = "IL" },
                new Provider { ProviderId = 4, Name = "Johnson & Johnson", Address = "NJ" },
                new Provider { ProviderId = 5, Name = "Sinopharm", Address = "China" },
                new Provider { ProviderId = 6, Name = "BioNTech", Address = "Germany" },
                new Provider { ProviderId = 7, Name = "Sanofi", Address = "France" },
                new Provider { ProviderId = 8, Name = "CureVac", Address = "Germany" }
            );


        }



    }
}
