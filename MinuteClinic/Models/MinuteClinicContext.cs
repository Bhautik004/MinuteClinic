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

        }
        

    }
}
