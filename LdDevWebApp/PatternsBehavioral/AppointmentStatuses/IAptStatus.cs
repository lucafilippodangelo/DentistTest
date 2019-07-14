using LdDevWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.BehavioralPatterns.AppointmentStatuses
{
    /// <summary>
    /// This interface needs to be implemented in each interface implementing "Appointment Status Class".
    /// The parm "Appointment" is the current appointment for which I want to update the status
    /// "int? anAptEvent" is the event happened for current Appointment in current status that causes the change of status.
    /// </summary>
    public interface IAptStatus 
    {
        void UpdateStatus(Appointment apt, int? anAptEvent);
    }


    ////Abstract class must be imlemented
    //[NotMapped]
    //public class AptStatus: IAptStatus
    //{
    //    //[Key]
    //    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    //public Guid Id { get; set; }
    //    //
    //    public virtual void UpdateStatus(Appointment apt, int? anAptEvent) { }

    //}

}
