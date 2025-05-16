using Application.Dtos.ExamStruct;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamStructController : ControllerBase
    {
        private readonly IExamStructService _examStructService;
        public ExamStructController(IExamStructService examStructService)
        {
            _examStructService = examStructService;
        }
        [HttpPost]
        public async Task<IActionResult> Add(ExamStructCreateDto examStructCreateDto)
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            await _examStructService.Add(Guid.Parse(sid), examStructCreateDto);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByBankId(Guid id)
        {
            var list = await _examStructService.GetListByBankId(id);
            return Ok(list);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStruct(Guid id)
        {
            await _examStructService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStruct(ExamStructUpdateDto examStructUpdateDto)
        {
            await _examStructService.Update(examStructUpdateDto);
            return Ok();
        }
    }
}
