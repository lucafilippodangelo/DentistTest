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

        public class InitialStatus : IAptStatusSupported
        {
            void IAptStatusSupported.UpdateAptStatusAction() 
            {
                Console.WriteLine("when from an -Initial Status- we update the status ");
            }
        }

        public class SendErrorStatus : IAptStatusSupported
        {
            void IAptStatusSupported.UpdateAptStatusAction()
            {
                Console.WriteLine("Current: Send Error status");
            }
        }

        public class SentStatus : IAptStatusSupported
        {
            void IAptStatusSupported.UpdateAptStatusAction()
            {
                Console.WriteLine("Current: Sent status");
            }
        }


    }
}
