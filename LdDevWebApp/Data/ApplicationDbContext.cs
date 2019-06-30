
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


        public DbSet<Person> Persons { get; set; }
        public DbSet<StaffRole> StaffRoles { get; set; }
        public DbSet<Practise> Practises { get; set; }
        public DbSet<Staff> Staff { get; set; } //LDNtoN
        
        //public DbSet<AppointmentTreatmentType> TreatmentTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<AppointmentStaff>().HasKey(t => new { t.giudAptId, t.giudPersonId }); //LDNtoN


            mb.Entity<Practise>().HasData(
                new { Id = new System.Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"), Name = "Practise One", Note = "Practse One Note" },
                new { Id = new System.Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"), Name = "Practise Two", Note = "Practse Two Note" }
                );


        }



    }
}
/*
 modelBuilder.Entity<Post>().HasData(
    new { BlogId = 1, PostId = 2, Title = "Second post", Content = "Test 2" });
     */

//HOW TO SEED RELATED INSTANCES: https://wildermuth.com/2018/08/12/Seeding-Related-Entities-in-EF-Core-2-1-s-HasData()
// https://msdn.microsoft.com/en-us/magazine/mt829703