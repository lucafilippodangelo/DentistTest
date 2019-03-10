using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class Patient : Person
    {
        [StringLength(1000)]
        public string patientNote { get; set; }

        public Guid giudAptId { get; set; } //LD FK
        public Appointment AppointmentNavigation { get; set; } //LD navigation Key
    }
}
