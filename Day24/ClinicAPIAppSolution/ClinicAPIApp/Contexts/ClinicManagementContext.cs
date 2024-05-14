using ClinicAPIApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPIApp.Contexts
{
    public class ClinicManagementContext : DbContext
    {

        public ClinicManagementContext(DbContextOptions options) : base(options) {
        
        }

        public DbSet <Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Doctor>().HasData(

                new Doctor() { Id = 1, Name = "Ben Parker", Qualification = "MBBS", Specialization = "Cardiologist", Experience=5 },
                new Doctor() { Id=2, Name="Peter Parker", Qualification="BDS", Specialization="Dentist",Experience=6}
                );
            
        } 



    }
}
