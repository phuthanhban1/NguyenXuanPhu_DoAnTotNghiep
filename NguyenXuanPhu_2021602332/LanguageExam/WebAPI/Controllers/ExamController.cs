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
        public async Task<IActionResult> CreateExam([FromBody] ExamCreateDto examCreateDto)
        {
            if (examCreateDto == null)
            {
                return BadRequest("Exam data is null");
            }
            await _examService.AddAsync(examCreateDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateExam([FromBody] ExamUpdateDto examUpdateDto)
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
        public async Task<IActionResult> GetAllExam()
        {
            var exams = await _examService.GetAllAsync();
            return Ok(exams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamByManager(Guid id)
        {
            var exams = await _examService.GetByManagerIdAsync(id);
            return Ok(exams);
        }
    }
}
