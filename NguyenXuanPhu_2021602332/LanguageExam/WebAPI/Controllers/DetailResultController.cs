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

        [HttpPost("reading/{examId}")]
        public async Task<IActionResult> CreateDetailResult(Guid examId, List<Guid> listResults)
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            await _detailResultService.CreateDetailResult(examId, Guid.Parse(sid), listResults, "đọc");
            return Ok();
        }

        [HttpPost("listening/{examId}")]
        public async Task<IActionResult> CreateDetailResultListen(Guid examId, List<Guid> listResults)
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            await _detailResultService.CreateDetailResult(examId, Guid.Parse(sid), listResults, "nghe");
            return Ok();
        }
        [HttpGet("{examId}/{userId}")]
        public async Task<IActionResult> GetResultsByExamUser(Guid examId, Guid userId)
        {
            var result = await _detailResultService.GetResultsByExamUser(examId, userId);
            return Ok(result);
        }
    }
}
