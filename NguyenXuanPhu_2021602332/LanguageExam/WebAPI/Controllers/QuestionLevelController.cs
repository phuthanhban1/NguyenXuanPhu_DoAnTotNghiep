using Application.Dtos.QuestionLevelDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionLevelController : ControllerBase
    {
        private readonly IQuestionLevelService _questionLevelService;

        
        public QuestionLevelController(IQuestionLevelService questionLevelService)
        {
            _questionLevelService = questionLevelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid skillId)
        {
            var questionLevels = await _questionLevelService.GetAllAsync(skillId);
            return Ok(questionLevels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var questionLevel = await _questionLevelService.GetByIdAsync(id);
            if (questionLevel == null)
            {
                return NotFound();
            }
            return Ok(questionLevel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionLevelCreateDto questionLevelCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _questionLevelService.AddAsync(questionLevelCreateDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] QuestionLevelUpdateDto questionLevelUpdateDto)
        {
            if (id != questionLevelUpdateDto.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _questionLevelService.UpdateAsync(questionLevelUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _questionLevelService.DeleteAsync(id);
            return Ok();
        }
    }
}
