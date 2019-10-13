using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    //LD join table
    public class AppointmentStaff
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }


        //If not using Fluent API I have to add -> [ForeignKey("Appointment")]
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; } //Navigation property


        //If not using Fluent API I have to add -> [ForeignKey("Staff")] //once I'm not using conventions I need to specify that this is the FK for the navogation property "staff"
        public Guid StaffId { get; set; }
        public Staff Staff { get; set; } //Navigation property


        //LD REMEMBER
        // in "OnModelCreating" of the DbContext I need to specify the below property
        // mb.Entity<AppointmentStaff>().HasKey(t => new { t.AppointmentId , t.StaffId });
    }
}
