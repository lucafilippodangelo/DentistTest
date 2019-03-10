using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class TreatmentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid giudId { get; set; }

        public string description { get; set; }

        public Guid giudAptId { get; set; } //LD FK
        public Appointment AppointmentNavigation { get; set; } //LD navigation Key
    }
}
