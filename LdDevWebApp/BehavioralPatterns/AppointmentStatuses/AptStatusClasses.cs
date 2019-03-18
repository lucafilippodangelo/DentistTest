using LdDevWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.BehavioralPatterns.AppointmentStatuses
{
    //LD each concrete strategy class implements a status 
    public class AptStatusClasses
    {

        public class Initial : IAptStatus
        {
            void IAptStatus.UpdateStatus(Appointment apt, int? anAptEvent) 
            {
                if (anAptEvent == 1)
                {
                    apt.SaveStatus (new SendError());
                }
                else if (anAptEvent == 2)
                {
                    apt.SaveStatus(new Sent());
                }
                
            }
        }

        public class SendError : IAptStatus
        {
            void IAptStatus.UpdateStatus(Appointment apt, int? anAptEvent)
            {
                apt.SaveStatus(new Initial());
            }
        }

        public class Sent : IAptStatus
        {
            void IAptStatus.UpdateStatus(Appointment apt, int? anAptEvent)
            {
                apt.SaveStatus(new Initial());
            }
        }


    }
}
