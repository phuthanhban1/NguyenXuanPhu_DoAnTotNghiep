using Application.Dtos.ExamineeDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamineeController : ControllerBase
    {
        private readonly IExamineeService _examineeService;
        public ExamineeController(IExamineeService examineeService)
        {
            _examineeService = examineeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExaminee([FromBody] ExamineeCreateDto examineeCreateDto)
        {
            if (examineeCreateDto == null)
            {
                return BadRequest("Examinee data is null");
            }
            await _examineeService.AddAsync(examineeCreateDto);
            return Ok("Examinee created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExaminee([FromBody] ExamineeUpdateDto examineeUpdateDto)
        {
            if (examineeUpdateDto == null)
            {
                return BadRequest("Examinee data is null");
            }
            await _examineeService.UpdateAsync(examineeUpdateDto);
            return Ok("Examinee updated successfully");
        }

    }
}
