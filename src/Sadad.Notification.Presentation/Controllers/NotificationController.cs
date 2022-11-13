using Microsoft.AspNetCore.Mvc;
using Sadad.Notification.Application.Commands;

namespace Sadad.Notification.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NotificationController : ApiControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageCommand command)
        {
            await Mediator.Send(command);
            return Ok("Your message was sent.");
        }
    }
}
