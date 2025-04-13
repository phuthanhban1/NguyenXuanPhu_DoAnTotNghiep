using Application.Dtos.SkillDtos;
using Application.Services.Interfaces;
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
    }
}
