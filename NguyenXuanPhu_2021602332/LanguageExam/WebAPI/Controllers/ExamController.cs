using Application.Dtos.ExamDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService = examService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateExam(ExamCreateDto examCreateDto)
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            if (examCreateDto == null)
            {
                return BadRequest("Exam data is null");
            }
            await _examService.AddAsync(Guid.Parse(sid), examCreateDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateExam(ExamUpdateDto examUpdateDto)
        {
            if (examUpdateDto == null)
            {
                return BadRequest("Exam data is null");
            }
            await _examService.UpdateAsync(examUpdateDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid exam ID");
            }
            await _examService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExams()
        {
            var exams = await _examService.GetAllAsync();
            return Ok(exams);
        }

        // get exams by manager id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamByManager(Guid id)
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            var exams = await _examService.GetByManagerIdAsync(Guid.Parse(sid));
            return Ok(exams);
        }
        [HttpGet("exam/{id}")]
        public async Task<IActionResult> GetExamById(Guid id)
        {
            var exam = await _examService.GetById(id);
            return Ok(exam);
        }

        [HttpGet("create-exam")]
        public async Task<IActionResult> GetExamByCreate()
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            var exam = await _examService.GetExamByCreate(Guid.Parse(sid));
            return Ok(exam);
        }

    }
}
