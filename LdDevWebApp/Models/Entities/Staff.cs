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

        //LD n to n
        public virtual ICollection<AppointmentStaff_NtoN> appointmentStaff_NtoN { get; set; }

    }
}
