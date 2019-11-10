using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class Practise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Notes { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } //LD navigation Key


    }
}
