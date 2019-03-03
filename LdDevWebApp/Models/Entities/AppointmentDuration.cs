using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class AppointmentDuration
    {
        [Key]
        public Guid appointmentDurationId { get; set; }

        [Required]
        public DateTime timeDuration { get; set; }

        public String timeDurationDescription { get; set; }
    }
}
