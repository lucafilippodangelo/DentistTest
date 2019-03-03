using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class Patient
    {
        [Key]
        public Guid giudId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }
}
