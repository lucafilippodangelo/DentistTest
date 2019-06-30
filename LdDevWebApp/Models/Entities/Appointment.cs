using LdDevWebApp.BehavioralPatterns.AppointmentStatuses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static LdDevWebApp.BehavioralPatterns.AppointmentStatuses.AptStatusClasses;

namespace LdDevWebApp.Models.Entities
{
    public class Appointment
    {
        // =========================== Appointment fields ===========================
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)] //LD save date and time
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime When { get; set; } // Scheduled Date Time

        public string Notes { get; set; } //to be used if "treatmentType" not listed




        // =========================== Appointment fields ===========================
        
        public virtual Patient Patient { get; set; } //an appointment is for one patient. "virtual" to be enabled to lazy loading

        public virtual Practise Practise { get; set; }

        public virtual ICollection<AppointmentStaff> StaffList { get; } = new List<AppointmentStaff>();  //LDNtoN
         
        [NotMapped]
        public virtual ICollection<AppointmentTreatmentType> TreatmentTypes { get; set; }

        // =========================== Appointment status ===========================

        //LD STATUS PATTERN - Property
        private IAptStatus Status { get; set; } //private IAptStatus currentAptStatus = new Initial();

        //LD CONSTRUCTOR
        public Appointment(){
            if (Status == null)
            Status = new Initial(); //initial status when object initialized, this is the default status
        }

        #region Status Patern

        //LD STATUS PATTERN - at any time is possible to update the object status. Do necessarely need to care about the current status
        public void UpdateStatus(int AptEventCode)
        {
            Status.UpdateStatus(this, AptEventCode);
            //UPDATE DB + UPDATE LOGS
        }

        //LD STATUS PATTERN - PART THREE - method called from concrete status classes
        public void SaveStatus(IAptStatus AnAptStatus)
        {
            this.Status = AnAptStatus;
            //UPDATE DB + UPDATE LOGS
        }

        //LD STATUS PATTERN - PART FOUR - possibility to query on current status
        public IAptStatus GetCurrentStatus()
        {
            Console.WriteLine("Current Status: " + Status.GetType().ToString());
            return Status;
        }

        #endregion




    }
}
