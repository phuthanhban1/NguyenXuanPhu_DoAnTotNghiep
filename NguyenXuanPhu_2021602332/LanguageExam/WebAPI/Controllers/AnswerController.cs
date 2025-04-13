using Application.Dtos.AnswerDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(AnswerCreateDto answerCreateDto)
        {
            Guid questionId = Guid.NewGuid();
            await _answerService.AddAsync(answerCreateDto, questionId);
            return Ok();
        }
    }
}
