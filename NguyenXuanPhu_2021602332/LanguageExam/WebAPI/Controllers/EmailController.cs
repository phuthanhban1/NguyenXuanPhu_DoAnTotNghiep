using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpGet]
        public async Task SendEmail(string toEmail, string subject, string body)
        {
            await ExtensionService.SendEmailAsync("phuthanhban3@gmail.com", "PhuNX", toEmail, subject, body);
        }
    }
}
