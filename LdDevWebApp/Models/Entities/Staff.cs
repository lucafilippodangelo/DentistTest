﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class Staff : Person
    {
        public Guid StaffRoleID { get; set; } // FK to "StaffRole". I did create it menually by respectiong conventions "table name"+"ID". This FK is useful for binding in controller
        public virtual StaffRole StaffRole { get; set; } // "virtual" to be enabled to lazy loading

        //[NotMapped]
        //public ICollection<AppointmentStaff> appointmentStaff { get; } = new List<AppointmentStaff>();  //LDNtoN <- search for this tag
    }
}


