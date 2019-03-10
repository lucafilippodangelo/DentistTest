using LdDevWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.BehavioralPatterns.AppointmentStatuses
{
    
    public interface IAptStatusSupported //LD useful to define the status supported
    {
        void UpdateAptStatusAction();
    }
}
