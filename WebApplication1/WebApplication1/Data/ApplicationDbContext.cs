using System;
using System.Collections.Generic;
using System.Text;
using LdDevWebApp.Models.Entities;
using LdDevWebApp.Models.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DentistCore2._2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Appointment> Appointments { get; set; } 
        public DbSet<Person> Persons { get; set; }
        public DbSet<StaffRole> StaffRoles { get; set; }
        public DbSet<Practise> Practises { get; set; }
        public DbSet<Staff> Staff { get; set; } //LD NtoN
        public DbSet<AppointmentLog> AppointmentLogs { get; set; } //LD 1toN

        public DbSet<LdDevWebApp.Models.Entities.Patient> Patient { get; set; }



        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<StaffRole>().HasData(
            new { Id = new System.Guid("1a637f30-a003-48af-8f46-21328531e9c8"), Role = "Seeded staffRole one", Note = "Seeded staffRole one NOTE" },
            new { Id = new System.Guid("a24a0521-52e2-438b-a1d5-1db1f75c836b"), Role = "Seeded staffRole two", Note = "Seeded staffRole two NOTE"}
            );

            mb.Entity<Staff>().HasData(
            new { Id = new System.Guid("1eb6bee1-e634-4b1e-9caf-5ce80b45604c"), Name = "Seeded staff one NAME", Surname = "Seeded staff one Surname", Email = "sviluppo.dangelo@gmail.com", Notes = "Seeded staff one NOTES", StaffRoleID = new System.Guid("1a637f30-a003-48af-8f46-21328531e9c8") },
            new { Id = new System.Guid("ee243d91-ddf1-48f6-827d-0bfa6616bae1"), Name = "Seeded staff two NAME", Surname = "Seeded staff two Surname", Email = "info@lucadangelo.it", Notes = "Seeded staff two NOTES", StaffRoleID = new System.Guid("a24a0521-52e2-438b-a1d5-1db1f75c836b") }
            );

            mb.Entity<AppointmentStaff>().HasKey(t => new { t.giudAptId, t.giudPersonId }); //LDNtoN

            mb.Entity<Practise>().HasData(
                new { Id = new System.Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"), Name = "Practise One", Notes = "Seeded Practise Note One" },
                new { Id = new System.Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"), Name = "Practise Two", Notes = "Seeded Practise Note Two" }
                );

            mb.Entity<Patient>().HasData(
            new { Id = new System.Guid("5b6c0ab6-c947-4279-9e35-53e2fa3cc1ff"), Name = "Patient one NAME", Surname = "Patient one Surname", Email = "sviluppo.dangelo@gmail.com", Notes = "Patient one NOTES" }, 
            new { Id = new System.Guid("99b48598-b815-4d08-aa20-9492f41738ea"), Name = "Patient two NAME", Surname = "Patient two Surname", Email = "info@lucadangelo.it", Notes = "Patient two NOTES" }
            );

            mb.Entity<Appointment>().HasData(
            new { Id = new System.Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"), PatientID = new System.Guid("5b6c0ab6-c947-4279-9e35-53e2fa3cc1ff"), When = new DateTime(2019, 5, 1, 8, 30, 52), Notes = "Seeded Appointment One", PractiseId = new System.Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"), StatusID = AptStatusesEnum.st["Initial"] }, //01 May 2019 h8:30:52
            new { Id = new System.Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"), PatientID= new System.Guid("99b48598-b815-4d08-aa20-9492f41738ea"), When = new DateTime(2019, 6, 1, 14, 30, 00), Notes = "Seeded Appointment Two", PractiseId = new System.Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"), StatusID = AptStatusesEnum.st["Initial"] } //01 Jun 2019 h14:30:00
            );

            mb.Entity<AppointmentLog>().HasData(
            new { Id = new System.Guid("1d2f7b60-6236-4598-a28b-a03d03eb1b94"), When = new DateTime(2019, 5, 1, 8, 30, 52), Information = "Seeded Log One for Appointment One", AppointmentId = new System.Guid("644f17b2-6e34-4cad-bab5-8bba425270a4") },
            new { Id = new System.Guid("253d32ba-ba51-4f51-b151-caa02eb54f23"), When = new DateTime(2019, 5, 2, 14, 30, 00), Information = "Seeded Log Two for Appointment One", AppointmentId = new System.Guid("644f17b2-6e34-4cad-bab5-8bba425270a4") },
            new { Id = new System.Guid("3b3d41f9-ed3b-45b6-89d5-a878b007b32a"), When = new DateTime(2019, 6, 3, 4, 30, 00), Information = "Seeded Log Three for Appointment One", AppointmentId = new System.Guid("644f17b2-6e34-4cad-bab5-8bba425270a4") },
            new { Id = new System.Guid("4e80d553-b1fd-4aed-9020-2206e2aa23cf"), When = new DateTime(2019, 6, 4, 5, 30, 00), Information = "Seeded Log One for Appointment Two", AppointmentId = new System.Guid("9022622f-7adf-44ed-9efa-d362d937b5b8") }
            );

        }

    }
}
