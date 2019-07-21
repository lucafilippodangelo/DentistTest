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
            if (anAptEvent == Guid.Parse("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483")) // "Initial"
            {
                apt.SaveStatus(new Initial(), anAptEvent);
            }
            if (anAptEvent == Guid.Parse("4fd374c2-9605-4134-844a-5228e7e46189")) // "mailSendError"
            {
                apt.SaveStatus(new MailSendError(), anAptEvent);
            }
            else if (anAptEvent == Guid.Parse("50001690-71c4-4c64-821e-673b66c187a0")) // "mailSent"
            {
                apt.SaveStatus(new MailSent(), anAptEvent);
            }
            else if (anAptEvent == Guid.Parse("1d5649e8-1e0b-46fc-be6d-40bcd1d3c8b9")) // "InitialToAborted"
            {
                apt.SaveStatus(new Aborted(), anAptEvent);
            }
        }
    }

    public class Initial : IAptStatus
        {
        public string AptStateDescription { get => "Initial"; }
        void IAptStatus.UpdateStatus(Appointment apt, Guid anAptEvent) 
            {
                if (anAptEvent == Guid.Parse("4fd374c2-9605-4134-844a-5228e7e46189")) // "mailSendError"
                {
                    apt.SaveStatus(new MailSendError(), anAptEvent);
                }
                else if (anAptEvent == Guid.Parse("50001690-71c4-4c64-821e-673b66c187a0")) // "mailSent"
                {
                    apt.SaveStatus(new MailSent(), anAptEvent);
                }
                else if (anAptEvent == Guid.Parse("1d5649e8-1e0b-46fc-be6d-40bcd1d3c8b9")) // "InitialToAborted"
                {
                    apt.SaveStatus(new Aborted(), anAptEvent);
                }
            }
        }



        //LD Status: "MailSendError" - this method is useful to make a massive update of all the object in this status
        public class MailSendError : IAptStatus
        {
        public string AptStateDescription { get => "MailSendError"; }
        void IAptStatus.UpdateStatus(Appointment apt, Guid anAptEvent)
            {
                if (anAptEvent == Guid.Parse("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483")) // "Initial"
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
                if (anAptEvent == Guid.Parse("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483")) // "Initial"
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
                //if (anAptEvent == 3) // SingletonAptEvent -> "cancel"
                //{
                //    apt.SaveStatus(new Canceled());
                //}
                //else if (anAptEvent == 4) // SingletonAptEvent -> "callMeBack"
                //{
                //    apt.SaveStatus(new CallMeBack());
                //}
                //else if (anAptEvent == 5) // SingletonAptEvent -> "confirm"
                //{
                //    apt.SaveStatus(new Confirmed());
                //}
            }
        }
/*
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
        */
    
}
