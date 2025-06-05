using Application.Dtos.ExamStructDetail;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamStructDetailController : ControllerBase
    {
        private readonly IExamStructDetailService _examStructDetailService;
        public ExamStructDetailController(IExamStructDetailService examStructDetailService)
        {
            _examStructDetailService = examStructDetailService;
        }

        [HttpGet("{structId}/{skill}")]
        public async Task<IActionResult> GetStructDetail(Guid structId, string skill)
        {
            var list = await _examStructDetailService.GetStruct(structId, skill);
            if (list == null)
            {
                return BadRequest("ExamStructDetail is null");
            }
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Add(List<ExamStructDetailCreateDto> list)
        {
            await _examStructDetailService.Add(list);
            return Ok();
        }
        
        
    }
}
