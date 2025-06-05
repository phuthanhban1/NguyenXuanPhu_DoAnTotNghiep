using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailResultController : ControllerBase
    {
        private readonly IDetailResultService _detailResultService;
        public DetailResultController(IDetailResultService detailResultService)
        {
            _detailResultService = detailResultService;
        }

        // add reading answer
        [HttpPost("{examId}/{skillName}")]
        public async Task<IActionResult> CreateDetailResult(Guid examId, string skillName, List<Guid> listResults)
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            var skill = "listening";
            if (skillName == "reading") skill = "reading";
            else if (skillName == "writing") skill = "writing";
            else if (skillName == "speaking") skill = "speaking";
            await _detailResultService.CreateDetailResult(examId, Guid.Parse(sid), listResults, skill);
            return Ok();
        }

        // admin get result
        [HttpGet("admin/{examId}")]
        public async Task<IActionResult> GetAllResult(Guid examId)
        {
            var result = await _detailResultService.GetAllResult(examId);
            return Ok(result);
        }
    }
}
