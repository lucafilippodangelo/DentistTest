using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Enums
{
    static public class AptStatusesEnum
    {
        //LD I land in each status because of an action
        static public Dictionary<string, Guid> st = new Dictionary<string, Guid>
        {
            {"Initial", Guid.Parse("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483")}, //(Coming from Creation or From manual secretary action(in case of Aborted or SendError))
            {"MailSendError", Guid.Parse("4fd374c2-9605-4134-844a-5228e7e46189")}, //(Coming from  mail send attempt Action)
            {"MailSent", Guid.Parse("50001690-71c4-4c64-821e-673b66c187a0")}, //(Coming from  mail send attempt Action)
            {"Canceled", Guid.Parse("46374a57-8541-4ddb-ba9a-3fe997a0a8e5")}, //(Coming from Patient Action)
            {"CallMeBack", Guid.Parse("b0c7d136-9c3b-4968-886c-a5d70e241fe3")}, //(Coming from Patient Action)
            {"Confirmed", Guid.Parse("4ac4cfd7-b69c-4710-930c-6d0d489840fa")}, //(Coming from Patient Action)
            {"Aborted", Guid.Parse("1d5649e8-1e0b-46fc-be6d-40bcd1d3c8b9")}, //(Coming from maual Secretary Action)
        };

    }
  
}
