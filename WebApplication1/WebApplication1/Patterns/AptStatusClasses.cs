using LdDevWebApp.Models.Entities;
using LdDevWebApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.BehavioralPatterns.AppointmentStatuses
{
    //LD each concrete strategy class implements a status 

    //default status when object initialized and no other statuses already assigned.
    // from this status is possible to move in any allowed status
    public class Default : IAptStatus
    {
        public string AptStateDescription { get => "Default"; }

        public void UpdateStatus(Appointment apt, Guid anAptEvent)
        {
            if (anAptEvent == AptStatusesEnum.st["Initial"]) // "Initial"
            {
                apt.SaveStatus(new Initial(), anAptEvent);
            }
            if (anAptEvent == AptStatusesEnum.st["MailSendError"]) // "mailSendError"
            {
                apt.SaveStatus(new MailSendError(), anAptEvent);
            }
            if (anAptEvent == AptStatusesEnum.st["MailSent"]) // "mailSent"
            {
                apt.SaveStatus(new MailSent(), anAptEvent);
            }
            if (anAptEvent == AptStatusesEnum.st["Aborted"]) // "InitialToAborted"
            {
                apt.SaveStatus(new Aborted(), anAptEvent);
            }
            if (anAptEvent == AptStatusesEnum.st["Canceled"]) // "InitialToAborted"
            {
                apt.SaveStatus(new Canceled(), anAptEvent);
            }
            //NEED TO MANAGE NOT COMPATIBLE NEW STATE AND RETURN A WARNING
        }
    }

    public class Initial : IAptStatus
        {
        public string AptStateDescription { get => "Initial"; }
        void IAptStatus.UpdateStatus(Appointment apt, Guid anAptEvent) 
            {
                if (anAptEvent == AptStatusesEnum.st["MailSendError"]) // "mailSendError"
                {
                    apt.SaveStatus(new MailSendError(), anAptEvent);
                }
                else if (anAptEvent == AptStatusesEnum.st["SendError"]) // "mailSent"
                {
                    apt.SaveStatus(new MailSent(), anAptEvent);
                }
                else if (anAptEvent == AptStatusesEnum.st["Aborted"]) // "InitialToAborted"
                {
                    apt.SaveStatus(new Aborted(), anAptEvent);
                }
                else if (anAptEvent == AptStatusesEnum.st["Confirmed"]) // "InitialToConfirmed"
                {
                    apt.SaveStatus(new Confirmed(), anAptEvent);
                }
        }
        }



        //LD Status: "MailSendError" - this method is useful to make a massive update of all the object in this status
        public class MailSendError : IAptStatus
        {
        public string AptStateDescription { get => "MailSendError"; }
        void IAptStatus.UpdateStatus(Appointment apt, Guid anAptEvent)
            {
                if (anAptEvent == AptStatusesEnum.st["Initial"]) // "Initial"
                {
                    apt.SaveStatus(new Initial(), anAptEvent);
                }
            }
        }

        public class Aborted : IAptStatus
        {
        public string AptStateDescription { get => "Aborted"; }
        void IAptStatus.UpdateStatus(Appointment apt, Guid anAptEvent)
            {
                if (anAptEvent == AptStatusesEnum.st["Initial"]) // "Initial"
                {
                    apt.SaveStatus(new Initial(), anAptEvent);
                }
            }
        }

        //LD Status: "MailSent" 
        public class MailSent : IAptStatus
            {
            public string AptStateDescription { get => "MailSent"; }
                void IAptStatus.UpdateStatus(Appointment apt, Guid anAptEvent)
                {
                    if (anAptEvent == AptStatusesEnum.st["Canceled"]) 
                    {
                        apt.SaveStatus(new Canceled(), anAptEvent);
                    }
                    else if (anAptEvent == AptStatusesEnum.st["CallMeBack"])
                    {
                        apt.SaveStatus(new CallMeBack(), anAptEvent);
                    }
                    else if (anAptEvent == AptStatusesEnum.st["Confirmed"]) 
                    {
                        apt.SaveStatus(new Confirmed(), anAptEvent);
                    }
                }
            }

        //LD Status: "Confirmed" - this is a final status
        public class Confirmed : IAptStatus
        {
        public string AptStateDescription { get => "Confirmed"; }

        void IAptStatus.UpdateStatus(Appointment apt, Guid anAptEvent)
            {
                //this is a final status
                throw new NotImplementedException();
            }
        }

        //LD Status: "Canceled" - this is a final status
        public class Canceled : IAptStatus
        {
        public string AptStateDescription => "Canceled";

        void IAptStatus.UpdateStatus(Appointment apt, Guid anAptEvent)
            {
                //this is a final status
                throw new NotImplementedException();
            }
        }

        //LD Status: "CallMeBack"
        public class CallMeBack : IAptStatus
        {
        public string AptStateDescription => "CallMeBack";
        void IAptStatus.UpdateStatus(Appointment apt, Guid anAptEvent)
            {
                 if (anAptEvent == AptStatusesEnum.st["Canceled"]) // SingletonAptEvent -> "callMeBackToCanceled"
                {
                     apt.SaveStatus(new Canceled(), anAptEvent);
                 }
                 else if (anAptEvent == AptStatusesEnum.st["Confirmed"]) // SingletonAptEvent -> "callMeBackToConfirmed"
                {
                     apt.SaveStatus(new Confirmed(), anAptEvent);
                 }
            }
        }
       
    
}
