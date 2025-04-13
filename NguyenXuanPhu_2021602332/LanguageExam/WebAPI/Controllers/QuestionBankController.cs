using Application.Dtos.QuestionBankDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionBankController : ControllerBase
    {
        private readonly IQuestionBankService _questionBankService;
        public QuestionBankController(IQuestionBankService questionBankService)
        {
            _questionBankService = questionBankService;
        }
        [HttpPost]
        public async Task<ActionResult> Add(QuestionBankCreateDto questionBankCreateDto)
        {
            await _questionBankService.AddAsync(questionBankCreateDto);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update(QuestionBankUpdateDto questionBankUpdateDto)
        {
            await _questionBankService.UpdateAsync(questionBankUpdateDto);
            return Ok();
        }
    }
}
