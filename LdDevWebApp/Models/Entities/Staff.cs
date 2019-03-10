using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class Staff : Person
    {

        [StringLength(1000)]
        public string staffNote { get; set; }

        public StaffRole staffRole { get; set; }
        //LD n to n
        //public virtual List<AppointmentStaff_NtoN> appointmentStaff_NtoN { get; set; }
        //public virtual ICollection<Appointment> appointment { get; set; }
        public ICollection<AppointmentStaff> appointmentStaff { get; } = new List<AppointmentStaff>();


    }
}
