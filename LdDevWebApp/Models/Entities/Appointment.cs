using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid giudAptId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime aptScheduledDateTime { get; set; }

        public string aptNotes { get; set; } //to be used if "treatmentType" not listed

        //LD FK Keys
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public AppointmentDuration aptScheduledDuration { get; set; }

        [Required]
        public TreatmentType aptTreatmentType { get; set; }

        public virtual Patient aptPatient { get; set; }

        public virtual Practise practise { get; set; }

        //LD n to n
        public virtual ICollection<AppointmentStaff_NtoN> appointmentStaff_NtoN { get; set; }

        // Forwarding Status
        //private IAppointmentStatus aptStatus = new Normal();  //start as normal health

    }
}
