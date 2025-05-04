using Application.Dtos.SkillDtos;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        public readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SkillCreateDto skillCreateDto)
        {
            await _skillService.AddAsync(skillCreateDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SkillUpdateDto skillUpdateDto)
        {
            await _skillService.UpdateAsync(skillUpdateDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _skillService.DeleteAsync(id);
            return Ok();
        }
        [Authorize(Roles = "người tạo câu hỏi, người đánh giá câu hỏi")]
        [HttpGet]
        public async Task<IActionResult> GetSkill()
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (User.IsInRole("người tạo câu hỏi"))
            {
                Console.WriteLine(ExtensionService.Sid);
                var skill = await _skillService.GetByCreate(Guid.Parse(sid));
                return Ok(skill);
            }
            else
            {
                var skill = await _skillService.GetByReview(Guid.Parse(sid));
                return Ok(skill);
            }
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmTask(SkillConfirmDto skillConfirmDto)
        {
            await _skillService.ConfirmSkill(skillConfirmDto);
            return Ok();
        }
    }
}
