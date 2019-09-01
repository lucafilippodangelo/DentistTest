using System.Threading.Tasks;
using DentistCore2._2.Data;
using DentistCore2._2.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

        
        //[Authorize]
        [Route("", Name = "Confirm")]
        public async Task<IActionResult> ConfirmAction()
        {
            await _hub.Clients.All.SendAsync("ReceiveMessage", "primo", "secondo", "danger");
            return View( "test");
        }

        
        [Authorize]
        [Route("", Name = "CallMeBack")]
        public async Task<IActionResult> CallMeBackAction()
        {
            await _hub.Clients.All.SendAsync("ReceiveMessage", "primo", "secondo", "danger");
            return View("test");
        }

        [Authorize]
        [Route("", Name = "Cancel")]
        public async Task<IActionResult> CancelAction()
        {
            ////the input will be encripted

            ////retrieve appointment USING INPUT PARM
            //var anAptId = Guid.Parse("644f17b2-6e34-4cad-bab5-8bba425270a4");

            //var appointment = await _context.Appointments.FindAsync(anAptId);

            //appointment.UpdateStatus(AptStatusesEnum.st["Canceled"]);

            //_context.Update(appointment);
            //await _context.SaveChangesAsync();

            await _hub.Clients.All.SendAsync("ReceiveMessage", "primo", "secondo", "danger");
            return View("test");
        }

    }
}
