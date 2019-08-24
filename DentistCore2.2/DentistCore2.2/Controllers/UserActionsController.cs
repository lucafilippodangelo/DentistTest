using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon.OpsWorks.Model;
using DentistCore2._2.Data;
using DentistCore2._2.SignalR;
using LdDevWebApp.Models.Enums;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace WebApplication1.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class UserActionsController : Controller
    {


        private readonly IHubContext<AnHub> _hub;
        private readonly ApplicationDbContext _context;

        public UserActionsController(ApplicationDbContext context, IHubContext<AnHub> hubcontext)
        {
            _context = context;
            _hub = hubcontext;
        }

        // GET: Appointments/Create
        //[Authorize]
        public IActionResult Landing()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> LandingConfirm(int aNumber)//([Bind("Id,When,Notes")] Appointment appointment)
        //{

        //    return View();
        //}

        [HttpGet]
        public async Task SetCanceled()
        {
            ////the input will be encripted

            ////retrieve appointment USING INPUT PARM
            //var anAptId = Guid.Parse("644f17b2-6e34-4cad-bab5-8bba425270a4");

            //var appointment = await _context.Appointments.FindAsync(anAptId);

            //appointment.UpdateStatus(AptStatusesEnum.st["Canceled"]);

            //_context.Update(appointment);
            //await _context.SaveChangesAsync();




            await _hub.Clients.All.SendAsync("ReceiveMessage", "primo", "secondo", "danger");

            // UPDATE LOGS -> "OBJECT XXXX STATUS UPDATED"
        }

        //public void SetCallMeBack(Guid Apt)
        //{
        //    //the input will be encripted

        //    //retrieve appointment

        //    //just need to call "UpdateStatus" of the retrieved object
        //}

        //public void SetConfirmed(Guid Apt)
        //{
        //    //the input will be encripted

        //    //retrieve appointment

        //    //just need to call "UpdateStatus" of the retrieved object
        //}

    }
}
