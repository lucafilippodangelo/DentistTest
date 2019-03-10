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

        //LD to 1 relationships
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public AppointmentDuration aptScheduledDuration { get; set; }

        public TreatmentType aptTreatmentType { get; set; }

        public Patient aptPatient { get; set; } //an appointment is for one patient

        public Practise practise { get; set; }

        //LD n to n
        //public virtual ICollection<Staff> staff { get; set; } //defining virtual for NtoN
        public ICollection<AppointmentStaff> appointmentStaff { get; } = new List<AppointmentStaff>();

        // Forwarding Status
        //private IAppointmentStatus aptStatus = new Normal();  //start as normal health

    }
}
