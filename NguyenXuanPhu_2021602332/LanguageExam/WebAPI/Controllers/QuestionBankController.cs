using Application.Dtos.QuestionBankDtos;
using Application.Services;
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
            var sid = HttpContext.User.FindFirst(ExtensionService.Sid)?.Value;
            if (sid == null)
            {
                return BadRequest("Invalid token");
            }
            await _questionBankService.AddAsync(questionBankCreateDto, new Guid(sid));
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update(QuestionBankUpdateDto questionBankUpdateDto)
        {

            await _questionBankService.UpdateAsync(questionBankUpdateDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _questionBankService.DeleteAsync(id);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<QuestionBankDto>>> GetAll()
        {
            var questionBanks = await _questionBankService.GetAllAsync();
            return Ok(questionBanks);
        }
        [HttpGet("{language}")]
        public async Task<ActionResult<QuestionBankDto>> GetByLanguageManageId(string language)
        {
            var sid = HttpContext.User.FindFirst(ExtensionService.Sid)?.Value;
            if(sid == null)
            {
                return BadRequest("Invalid token");
            }
            var questionBank = await _questionBankService.GetByLanguageManageId(language, new Guid(sid));
            return Ok(questionBank);
        }
    }
}
