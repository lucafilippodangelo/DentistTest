using LdDevWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.BehavioralPatterns.AppointmentStatuses
{
    
    public interface IAptStatus //LD need to be implemented in each concrete status
    {
        void UpdateStatus(Appointment apt, int? anAptEvent); //LD "anAptEvent" is one of the events in "SingletonAptEvent.cs"
    }
}
