
using LdDevWebApp.BehavioralPatterns.AppointmentStatuses;
using LdDevWebApp.Models.Entities;
using LdDevWebApp.Models.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

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
        public DbSet<Staff> Staff { get; set; } //LD NtoN
        public DbSet<AppointmentLog> AppointmentLogs { get; set; } //LD 1toN





        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<AppointmentStaff>().HasKey(t => new { t.giudAptId, t.giudPersonId }); //LDNtoN

            mb.Entity<Practise>().HasData(
                new { Id = new System.Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"), Name = "Practise One", Notes = "Seeded Practise Note One" },
                new { Id = new System.Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"), Name = "Practise Two", Notes = "Seeded Practise Note Two" }
                );

            mb.Entity<Appointment>().HasData(
            new { Id = new System.Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"), When = new DateTime(2019, 5, 1, 8, 30, 52), Notes = "Seeded Appointment One", PractiseId = new System.Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e") , StatusID = AptStatusesEnum.st["Initial"] }, //01 May 2019 h8:30:52
            new { Id = new System.Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"), When = new DateTime(2019, 6, 1, 14, 30, 00), Notes = "Seeded Appointment Two", PractiseId = new System.Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"), StatusID = AptStatusesEnum.st["Initial"] } //01 Jun 2019 h14:30:00
            );

            mb.Entity<AppointmentLog>().HasData(
            new { Id = new System.Guid("1d2f7b60-6236-4598-a28b-a03d03eb1b94"), When = new DateTime(2019, 5, 1, 8, 30, 52), Information = "Seeded Log One for Appointment One", AppointmentId = new System.Guid("644f17b2-6e34-4cad-bab5-8bba425270a4") },
            new { Id = new System.Guid("253d32ba-ba51-4f51-b151-caa02eb54f23"), When = new DateTime(2019, 5, 2, 14, 30, 00), Information = "Seeded Log Two for Appointment One", AppointmentId = new System.Guid("644f17b2-6e34-4cad-bab5-8bba425270a4") },
            new { Id = new System.Guid("3b3d41f9-ed3b-45b6-89d5-a878b007b32a"), When = new DateTime(2019, 6, 3, 4, 30, 00), Information = "Seeded Log Three for Appointment One", AppointmentId = new System.Guid("644f17b2-6e34-4cad-bab5-8bba425270a4") },
            new { Id = new System.Guid("4e80d553-b1fd-4aed-9020-2206e2aa23cf"), When = new DateTime(2019, 6, 4, 5, 30, 00), Information = "Seeded Log One for Appointment Two", AppointmentId = new System.Guid("9022622f-7adf-44ed-9efa-d362d937b5b8") }
            );

        }
        
        //public DbSet<AppointmentTreatmentType> TreatmentTypes { get; set; }


    }
}

//HOW TO SEED RELATED INSTANCES: https://wildermuth.com/2018/08/12/Seeding-Related-Entities-in-EF-Core-2-1-s-HasData()
// https://msdn.microsoft.com/en-us/magazine/mt829703