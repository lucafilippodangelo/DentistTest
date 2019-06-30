using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class AppointmentStaff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AppointmentStaffGiudId { get; set; }

        public Guid giudAptId { get; set; }
        public Appointment appointment { get; set; }

        public Guid giudPersonId { get; set; }
        public Staff staff { get; set; }
    }
}
