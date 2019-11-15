using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Entities;

namespace LdDevWebApp.Models.Entities
{
    //LD join table
    public class AppointmentThreatment
    {
        public Guid AppointmentId { get; set; } //naming by convention
        public Appointment Appointment { get; set; } //Navigation property


        //If not using Fluent API I have to add -> [ForeignKey("Treatment")] //once I'm not using conventions I need to specify that this is the FK for the navogation property "Treatment"
        public Guid ThreatmentId { get; set; } //naming by convention
        public Threatment Threatment { get; set; } //Navigation property
    }
}
