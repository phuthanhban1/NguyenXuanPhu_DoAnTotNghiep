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
        public async Task<IActionResult> GetAll()
        {
            var questionLevels = await _questionTypeService.GetAllAsync();
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

        [HttpPost("update")]
        public async Task<IActionResult> Update(QuestionTypeUpdateDto questionTypeUpdateDto)
        {
            
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
        [HttpPut]
        public async Task<IActionResult> GetsBySkillIde()
        {
            //var list = await _questionTypeService.GetsBySkillId(skillId);
            return Ok();
        }

        [HttpGet("count/{skillId}")]
        public async Task<IActionResult> CountQuestionType(Guid skillId)
        {
            var list = await _questionTypeService.CountQuestionType(skillId);
            return Ok(list);
        }

        [HttpGet("count-question-type/{skillId}/{structId}")]
        public async Task<IActionResult> CountQuestionTypeById(Guid skillId, Guid structId)
        {
            var list = await _questionTypeService.CountQuestionType2(skillId, structId);
            return Ok(list);
        }
    }
}
