using DentistCore2._2.Data;
using DentistCore2._2.SignalR;
using DentistCore2._2.Utilities;
using LdDevWebApp.BehavioralPatterns.AppointmentStatuses;
using LdDevWebApp.Models.Enums;
using MailClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public interface IMailService {
        Task<IActionResult> SendMail(Guid? id);
    }

    public class MailService :IMailService
    {
        private readonly ApplicationDbContext _context;
        private readonly IViewRenderService _viewRenderService;
        private readonly IHubContext<AnHub> _hub;

        public MailService(ApplicationDbContext context, IViewRenderService viewRenderService, IHubContext<AnHub> hubcontext)
        {
            _context = context;
            _viewRenderService = viewRenderService;
            _hub = hubcontext;
        }
        public async Task<IActionResult> SendMail(Guid? id)
        {

            var appointment = await _context.Appointments.Where(a => a.Id == id).SingleOrDefaultAsync();
            if (appointment == null)
            {
                return NotFound();
            }
            else if (appointment.AptStateObject.GetType() == typeof(Initial) || appointment.AptStateObject.GetType() == typeof(MailSendError))
            {
                try
                {
                    //BUILD MAIL START
                    //string urlRoute = Url.RouteUrl("Custom", new { id = id.Value }, "https");

                    string urlRouteConfirm = "";// Url.RouteUrl("Confirm", new { id = id.Value }, "https");
                    string urlRouteCallMeBack = "";//Url.RouteUrl("CallMeBack", new { id = id.Value }, "https");
                    string urlRouteCancel = "";//Url.RouteUrl("Cancel", new { id = id.Value }, "https");

                    var aCustomInfo = new CustomInfo
                    {
                        DateTime = DateTime.Now,
                        ActionEnumerator = 1,
                        AppointmentId = id.Value,
                        InternalKey = "abc",
                        urlRouteConfirm = urlRouteConfirm,
                        urlRouteCallMaBack = urlRouteCallMeBack,
                        urlRouteCancel = urlRouteCancel
                    };

                    var Body = await _viewRenderService.RenderToStringAsync("UserAct/Landing", aCustomInfo);
                    //BUILD MAIL END
                    ProcessMail.SendMail("info@lucadangelo.it", "Subject", Body);

                    appointment.UpdateStatus(AptStatusesEnum.st["MailSent"]);

                    //LINK TO BE CREATED!!
                    await _hub.Clients.All.SendAsync("ReceiveMessage", "<a href='#'class='alert-link'>an example link</a>", "SendMail", "success");
                }
                catch (Exception ex)
                {
                    appointment.UpdateStatus(AptStatusesEnum.st["MailSendError"]);
                    await _hub.Clients.All.SendAsync("ReceiveMessage", "MAIL SENT ERROR", "SendMail", "danger");
                }

                _context.Update(appointment);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        private IActionResult NoContent()
        {
            throw new NotImplementedException();
        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
