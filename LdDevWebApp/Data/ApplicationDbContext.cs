using System;
using System.Collections.Generic;
using System.Text;
using LdDevWebApp.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LdDevWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Practise> Practises { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentDuration> AppointmentDurations { get; set; }
        public DbSet<StaffRole> StaffRoles { get; set; }
        public DbSet<TreatmentType> TreatmentTypes { get; set; }

    }
}
