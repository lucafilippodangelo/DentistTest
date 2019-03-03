using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class Appointment
    {
        [Key]
        public Guid appointmentId { get; set; }

        [Required]
        public DateTime aptScheduledDateTime { get; set; }

        [Required]
        public AppointmentDuration aptDuration { get; set; }

        [Required]
        public TreatmentType treatmentType { get; set; }

        public String notes { get; set; } //to be used if "treatmentType" not listed

        // Forwarding Status


    }
}
