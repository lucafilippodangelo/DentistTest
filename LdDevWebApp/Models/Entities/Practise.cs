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
        public Guid giudId { get; set; }

        public String LocationName { get; set; }

        public String description { get; set; }

        public ICollection<Appointment> practiseForApts { get; set; } //LD navigation Key
    }
}
