using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    /// <summary>
    /// "[ForeignKey("Staff")]" 
    /// The ForeignKey Attribute can be applied to the dependent class to establish the relationship.
    /// In this case I'm not doing that because it's not mandatory each "StaffRole" is tied with a "Staff"
    /// </summary>
    public class StaffRole
    {
        [Key]
        //[ForeignKey("Staff")] // The ForeignKey Attribute can be applied to the dependent class to establish the relationship.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Role { get; set; }

        public string Note { get; set; }

        public virtual ICollection<Staff> StaffRoleOfStaff { get; set; } // it's the handle to "Staff" table. 1toN relationship.
    }
}

