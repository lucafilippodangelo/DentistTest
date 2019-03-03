using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class TreatmentType
    {
        [Key]
        public Guid treatmentTypeId { get; set; }

        public string description { get; set; }
    }
}
