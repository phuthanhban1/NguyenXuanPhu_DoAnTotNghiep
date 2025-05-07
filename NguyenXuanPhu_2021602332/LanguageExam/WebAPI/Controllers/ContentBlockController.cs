using Application.Dtos.ContentBlockDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentBlockController : ControllerBase
    {
        private readonly IContentBlockService _contentBlockService;
        public ContentBlockController(IContentBlockService contentBlockService)
        {
            _contentBlockService = contentBlockService;
        }

        [HttpPost("single")]
        public async Task<IActionResult> AddSingle(List<ContentBlockSingleDto> lists)
        {
            if (lists == null)
            {
                return BadRequest("ContentBlockSingleTextDto cannot be null");
            }
            await _contentBlockService.AddSingle(lists);
            return Ok();
        }
    }
}
