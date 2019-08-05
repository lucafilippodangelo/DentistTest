using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class AppointmentLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)] //LD save date and time
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime When { get; set; } // Scheduled Date Time

        [Required]
        public string Information { get; set; }

        //LD FK
        public Appointment Appointment { get; set; } //LD navigation to appointment, the FK will be automatically created and named by convention "AppointmentId"

    }
}
