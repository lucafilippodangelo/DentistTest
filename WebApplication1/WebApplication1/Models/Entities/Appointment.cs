using LdDevWebApp.BehavioralPatterns.AppointmentStatuses;
using LdDevWebApp.Models.Enums;
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

        // =========================== Appointment Constructor ===========================
        public Appointment()
        {
            AptStateObject = new Default(); //LD default initialization for all the objects
        }

        // =========================== Appointment fields ===========================
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)] //LD save date and time
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}")]
        public DateTime When { get; set; } // Scheduled Date Time

        public string Notes { get; set; } //to be used if "treatmentType" not listed

        // =========================== Appointment Status Pattern fields ===========================

        public Guid StatusID { get; set; } //I use it to save the status, when the object is created I initialize the property "AptStatus"
        [NotMapped ]
        public virtual IAptStatus AptStateObject { get; set; }

        // =========================== Appointment FK fields ===========================

        public Guid PatientID { get; set; } // FK to "Patient". I did create it manually by respecting conventions "table name"+"ID". This FK is useful for binding in controller
        public virtual Patient Patient { get; set; } //LD Appointment is for one specific patient. "virtual" to be enabled to lazy loading

        public virtual Practise Practise { get; set; } //LD Appointment happens in a specific Practise. EF will set by default convention the FK "PractiseId" in table. Use "PractiseId" when seeding 

        public virtual ICollection<AppointmentLog> AppointmentLogs { get; set; } //LD 1toN - need of a setter "set;" to seed data in "AppointmentLog" seeding 

        public virtual ICollection<AppointmentStaff> StaffList { get; } //= new List<AppointmentStaff>();  //LD Appointment can have a list od staff
         
        [NotMapped]
        public virtual ICollection<AppointmentTreatment> AppointmentTreatments { get; set; } //LD Appointment can have a list of treatments

        // =========================== Appointment status ===========================


        #region Status Patern

        //LD STATUS PATTERN - at any time is possible to update the object status. Do necessarely need to care about the current status
        public void UpdateStatus(Guid AptEventCode)
        {
            AptStateObject.UpdateStatus(this, AptEventCode);
            
        }

        //LD STATUS PATTERN - PART THREE - method called from concrete status classes
        public void SaveStatus(IAptStatus AnAptStatusObject, Guid AnAptStatusGuid)
        {
            //LD setup current object status
            AptStateObject = AnAptStatusObject;
            //LD setup Guid to be saved in database
            StatusID = AnAptStatusGuid;

            //UPDATE LOGS -> object status saved
        }

        //LD STATUS PATTERN - PART FOUR - possibility to query on current status
        public IAptStatus GetCurrentStatus()
        {
            Console.WriteLine("Current Status: " + AptStateObject.GetType().ToString());
            return AptStateObject;
        }

        //LD set the status of the object. For internal use
        public void setAptStateObject() {
         
            if ((this.StatusID == null) || (this.StatusID == Guid.Empty))
            {
                AptStateObject = new Default();
            }
            else if (StatusID == AptStatusesEnum.st["Initial"])
            {
                AptStateObject = new Initial();
            }
            else if (StatusID == AptStatusesEnum.st["Aborted"])
            {
                AptStateObject = new Aborted();
            }
            else if (StatusID == AptStatusesEnum.st["Canceled"])
            {
                AptStateObject = new Canceled();
            }
            else if (StatusID == AptStatusesEnum.st["MailSent"])
            {
                AptStateObject = new MailSent();
            }
            else if (StatusID == AptStatusesEnum.st["MailSendError"])
            {
                AptStateObject = new MailSendError();
            }
        }
        #endregion




    }
}
