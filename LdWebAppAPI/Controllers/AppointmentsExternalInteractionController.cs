using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LdDevWebApp.Data;
using LdDevWebApp.Models.Entities;
using LdDevWebApp.Models.Enums;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LdWebAppAPI.Controllers
{
    public class AppointmentsExternalInteractionController : Controller
    {
        // GET: /<controller>/


        private readonly ApplicationDbContext _context;

        public AppointmentsExternalInteractionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SetCanceled()
        {
            //the input will be encripted

            //retrieve appointment USING INPUT PARM
            var anAptId = Guid.Parse("644f17b2-6e34-4cad-bab5-8bba425270a4");

            var appointment = await _context.Appointments.FindAsync(anAptId);

            appointment.UpdateStatus(AptStatusesEnum.st["Canceled"]);

            _context.Update(appointment);
            await _context.SaveChangesAsync();

            // UPDATE LOGS -> "OBJECT XXXX STATUS UPDATED"
        }

        public void SetCallMeBack(Guid Apt)
        {
            //the input will be encripted

            //retrieve appointment

            //just need to call "UpdateStatus" of the retrieved object
        }

        public void SetConfirmed(Guid Apt)
        {
            //the input will be encripted

            //retrieve appointment

            //just need to call "UpdateStatus" of the retrieved object
        }

    }
}
