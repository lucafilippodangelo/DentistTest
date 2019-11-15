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
        public Guid StaffRoleID { get; set; } // FK to "StaffRole". I did create it manually by respecting conventions "table name"+"ID". This FK is useful for binding in controller
        public virtual StaffRole StaffRole { get; set; }
        public virtual ICollection<AppointmentStaff> AppointmentStaff { get; set; } //to join table
    }
}


