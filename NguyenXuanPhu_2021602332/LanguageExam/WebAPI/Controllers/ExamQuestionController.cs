using Application.Dtos.ExamQuestionDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamQuestionController : ControllerBase
    {
        private readonly IExamQuestionService _examQuestionService;
        public ExamQuestionController(IExamQuestionService examQuestionService)
        {
            _examQuestionService = examQuestionService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExamQuestionCreateDto examQuestionCreateDto)
        {
            await _examQuestionService.Add(examQuestionCreateDto);
            return Ok();
        }

        [HttpGet("{examId}")]
        public async Task<IActionResult> HasQuestion(Guid examId)
        {
            var check = await _examQuestionService.HasQuestion(examId);
            return Ok(check);
        }
    }
}
