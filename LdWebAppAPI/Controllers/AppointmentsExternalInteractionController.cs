using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LdWebAppAPI.Controllers
{
    public class AppointmentsExternalInteractionController : Controller
    {
        // GET: /<controller>/

        public void SetCanceled(Guid Apt)
        {
            //retrieve appointment

            //just need to call "UpdateStatus" of the retrieved object
        }

        public void SetCallMeBack(Guid Apt)
        {
            //retrieve appointment

            //just need to call "UpdateStatus" of the retrieved object
        }

        public void SetConfirmed(Guid Apt)
        {
            //retrieve appointment

            //just need to call "UpdateStatus" of the retrieved object
        }

    }
}
