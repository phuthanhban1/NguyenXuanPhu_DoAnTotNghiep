using Application.Dtos.ExamQuestionDetailDtos;
using Application.Services.Implements;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamQuestionDetailController : ControllerBase
    {
        private readonly IExamQuestionDetailService _examQuestionDetailService;
        public ExamQuestionDetailController(IExamQuestionDetailService examQuestionDetailService)
        {
            _examQuestionDetailService = examQuestionDetailService;
        }

        [HttpPost]
        public async Task<IActionResult> GenExam(ExamQuestionDetailCreateDto examQuestionDetailCreateDto)
        {
            await _examQuestionDetailService.GenExam(examQuestionDetailCreateDto);
            return Ok();
        }
    }
}
