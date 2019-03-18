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

        public ICollection<AppointmentStaff> appointmentStaff { get; } = new List<AppointmentStaff>();  //LDNtoN


        //LD STATUS PATTERN - PART ONE - initial status when object initialized, this is the default status
        private IAptStatus currentAptStatus = new Initial(); 

        //LD STATUS PATTERN - PART TWO - at any time is possible to update the object status. Do necessarely need to care about the current status
        public void UpdateStatus()
        {
            currentAptStatus.UpdateStatus(this, new int());  
        }

        //LD STATUS PATTERN - PART THREE - method called from concrete status classes
        public void SaveStatus(IAptStatus AnAptStatus) 
        {
            this.currentAptStatus = AnAptStatus;
            //UPDATE DB
        }

        //LD STATUS PATTERN - PART FOUR - possibility to query on current status
        public void GetCurrentStatus()
        {
            //READ FROM DB
            Console.WriteLine("Current Status: " + currentAptStatus.GetType().ToString());
        }



    }
}
