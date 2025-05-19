using Application.Dtos.ExamineeDtos;
using Application.Dtos.RoomDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamineeController : ControllerBase
    {
        private readonly IExamineeService _examineeService;
        public ExamineeController(IExamineeService examineeService)
        {
            _examineeService = examineeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExaminee(ExamineeCreateDto examineeCreateDto)
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            await _examineeService.AddAsync(examineeCreateDto.ExamId, Guid.Parse(sid));
            return Ok();
        }

        [HttpGet("is-regist/{examId}")]
        public async Task<IActionResult> IsRegist(Guid examId)
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            var check = await _examineeService.GetExaminee(examId, Guid.Parse(sid));
            if (check != null) return Ok(true);
            return Ok(false);
        }

        [HttpGet("count/{examId}")]
        public async Task<IActionResult> CountExaminee(Guid examId)
        {
            var examinees = await _examineeService.GetByExamIdAsync(examId);
            return Ok(examinees.Count);
        }
        [HttpGet("examinees/{examId}")]
        public async Task<IActionResult> GetExaminees(Guid examId)
        {
            var examinees = await _examineeService.GetUserByExamId(examId);
            return Ok(examinees);
        }

        [HttpGet("exam-number/{examId}")]
        public async Task<IActionResult> CreateExamNumber(Guid examId)
        {
            await _examineeService.CreateExamNumber(examId);
            return Ok();
        }
        [HttpPost("create-room/{examId}")]
        public async Task<IActionResult> CreateRoom(Guid examId, List<RoomExamDto> list)
        {
            await _examineeService.CreateRoom(examId, list);
            return Ok();
        }
    }
}
