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
                if (anAptEvent == 1) // SingletonAptEvent -> "mailSendError"
                {
                    apt.SaveStatus (new MailSendError());
                }
                else if (anAptEvent == 2) // SingletonAptEvent -> "mailSent"
                {
                    apt.SaveStatus(new MailSent());
                }
                else if (anAptEvent == 9) // SingletonAptEvent -> "initialToAborted", administration fired event
                {
                    apt.SaveStatus(new MailSent());
                }
            }
        }

        //LD Status: "MailSendError" - this method is useful to make a massive update of all the object in this status
        public class MailSendError : IAptStatus
        {
            void IAptStatus.UpdateStatus(Appointment apt, int? anAptEvent)
            {
                apt.SaveStatus(new Initial());  // [NO anAptEvent NEEDED], administration fired event
            }
        }

        //LD Status: "MailSent" 
        public class MailSent : IAptStatus
        {
            void IAptStatus.UpdateStatus(Appointment apt, int? anAptEvent)
            {
                if (anAptEvent == 3) // SingletonAptEvent -> "cancel"
                {
                    apt.SaveStatus(new Canceled());
                }
                else if (anAptEvent == 4) // SingletonAptEvent -> "callMeBack"
                {
                    apt.SaveStatus(new CallMeBack());
                }
                else if (anAptEvent == 5) // SingletonAptEvent -> "confirm"
                {
                    apt.SaveStatus(new Confirmed());
                }
            }
        }

        //LD Status: "Confirmed" - this is a final status
        public class Confirmed : IAptStatus
        {
            void IAptStatus.UpdateStatus(Appointment apt, int? anAptEvent)
            {
                //this is a final status
                throw new NotImplementedException();
            }
        }

        //LD Status: "Canceled" - this is a final status
        public class Canceled : IAptStatus
        {
            void IAptStatus.UpdateStatus(Appointment apt, int? anAptEvent)
            {
                apt.SaveStatus(new Initial()); // [NO anAptEvent NEEDED], administration fired event
            }
        }

        //LD Status: "CallMeBack"
        public class CallMeBack : IAptStatus
        {
            void IAptStatus.UpdateStatus(Appointment apt, int? anAptEvent)
            {
                 if (anAptEvent == 7) // SingletonAptEvent -> "callMeBackToCanceled"
                {
                     apt.SaveStatus(new Canceled());
                 }
                 else if (anAptEvent == 8) // SingletonAptEvent -> "callMeBackToConfirmed"
                {
                     apt.SaveStatus(new Confirmed());
                 }
            }
        }

    }
}
