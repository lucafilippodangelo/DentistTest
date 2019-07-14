using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Enums
{
    static public class AptStatusesEnum
    {

        static public Dictionary<string, Guid> st = new Dictionary<string, Guid>
        {
            {"Initial", Guid.Parse("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483")},
            {"MailSendError", Guid.Parse("4fd374c2-9605-4134-844a-5228e7e46189")}
        };

    }
  
}
