using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class Staff : Person
    {
        public virtual StaffRole StaffRole { get; set; } // "virtual" to be enabled to lazy loading

        //[NotMapped]
        //public ICollection<AppointmentStaff> appointmentStaff { get; } = new List<AppointmentStaff>();  //LDNtoN <- search for this tag
    }
}


