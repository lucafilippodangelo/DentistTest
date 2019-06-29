using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class Patient : Person
    {
        public ICollection<Appointment> Appointments { get; set; } //LD navigation Key
    }
}
