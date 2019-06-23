using LdDevWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.BehavioralPatterns.AppointmentStatuses
{
    /// <summary>
    /// This interface needs to be implemented in each concrete status
    /// "Appointment" is the current appointment for which I want to update the status
    /// "int? anAptEvent" is the event happened for current Appointment in current status
    /// </summary>
    public interface IAptStatus 
    {
        void UpdateStatus(Appointment apt, int? anAptEvent);
    }
}
