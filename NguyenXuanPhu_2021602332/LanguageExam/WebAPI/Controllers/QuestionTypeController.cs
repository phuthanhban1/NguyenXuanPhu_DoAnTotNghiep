using Application.Dtos.QuestionTypeDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {
        private readonly IQuestionTypeService _questionTypeService;

        
        public QuestionTypeController(IQuestionTypeService questionLevelService)
        {
            _questionTypeService = questionLevelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid skillId)
        {
            var questionLevels = await _questionTypeService.GetAllAsync(skillId);
            return Ok(questionLevels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var questionLevel = await _questionTypeService.GetByIdAsync(id);
            if (questionLevel == null)
            {
                return NotFound();
            }
            return Ok(questionLevel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionTypeCreateDto questionTypeCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _questionTypeService.AddAsync(questionTypeCreateDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] QuestionTypeUpdateDto questionTypeUpdateDto)
        {
            if (id != questionTypeUpdateDto.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _questionTypeService.UpdateAsync(questionTypeUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _questionTypeService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("skill/{skillId}")]
        public async Task<IActionResult> GetsBySkillId(Guid skillId)
        {
            var list = await _questionTypeService.GetsBySkillId(skillId);
            return Ok(list);
        }
    }
}
