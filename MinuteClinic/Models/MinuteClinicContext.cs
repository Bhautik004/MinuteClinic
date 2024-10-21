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
                      new Clinics() { ClinicId = 1, ClinicName = "NY Clinic", Location = "1234 Elm St", City = "Anytown", State = "NY", ZipCode = 12345 },
                      new Clinics() { ClinicId = 2, ClinicName = "IL Clinic", Location = "5678 Oak St", City = "Othertown", State = "IL", ZipCode = 45678 },
                      new Clinics() { ClinicId = 3, ClinicName = "MI Clinic", Location = "91011 Pine St", City = "Thirdtown", State = "MI", ZipCode = 90012 }
                      );
            modelBuilder.Entity<Provider>().HasData(
                     new Provider() { ProviderId = 1, Name = "Moderna", Address = "NY"},
                     new Provider() { ProviderId = 2, Name = "AstraZeneca", Address = "PL" },
                     new Provider() { ProviderId = 3, Name = "Pfizer", Address = "IL" }
                     );

        }

        

    }
}
