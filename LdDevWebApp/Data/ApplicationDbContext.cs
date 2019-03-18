
using LdDevWebApp.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace LdDevWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public DbSet<Appointment> Appointments { get; set; } //LDNtoN
        public DbSet<Staff> Staff { get; set; } //LDNtoN

        public DbSet<Person> Persons { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Practise> Practises { get; set; }
        public DbSet<AppointmentDuration> AppointmentDurations { get; set; }
        public DbSet<StaffRole> StaffRoles { get; set; }
        public DbSet<TreatmentType> TreatmentTypes { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppointmentStaff>().HasKey(t => new { t.giudAptId, t.giudPersonId }); //LDNtoN
        }



    }
}
