using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class Person
    {
        [Key]
        public Guid giudId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string surname { get; set; }

        [Phone]
        public string phone { get; set; }

        [StringLength(1000)]
        public string notes { get; set; }

        [EmailAddress]
        public string mail { get; set; }
    }
}
