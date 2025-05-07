using Application.Dtos.SkillDtos;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPost("confirm/{skillId}")]
        public async Task<IActionResult> ConfirmTask(Guid skillId)
        {
            var role = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            await _skillService.ConfirmSkill(skillId, role);
            return Ok();
        }
        [HttpGet("skill")]
        public async Task<IActionResult> GetCreateSkill()
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            var role = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            var skill = new SkillOverViewDto();
           if(role == ExtensionService.RoleCreate)
            {
                skill = await _skillService.GetCreateSkill(Guid.Parse(sid));
            } else
            {
                skill = await _skillService.GetReviewSkill(Guid.Parse(sid));
            }
            return Ok(skill);
        }
    }
}
