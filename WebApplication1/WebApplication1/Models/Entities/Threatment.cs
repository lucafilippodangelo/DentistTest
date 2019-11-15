using LdDevWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
    public class Threatment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; } //average duration, basically is the standard duration
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AppointmentThreatment> AppointmentThreatment{ get; set; }
    }
}
