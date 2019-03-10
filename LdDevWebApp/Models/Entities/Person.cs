using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid giudPersonId { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string surname { get; set; }

        [Phone]
        public string phone { get; set; }

        [StringLength(1000)]
        public string personNote { get; set; }

        [EmailAddress]
        [Required]
        public string mail { get; set; }
    }
}
