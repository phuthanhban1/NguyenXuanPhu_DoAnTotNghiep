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

        [HttpPost("single-text")]
        public async Task<IActionResult> AddSingleText(ContentBlockSingleTextDto contentBlockSingleTextDto)
        {
            if (contentBlockSingleTextDto == null)
            {
                return BadRequest("ContentBlockSingleTextDto cannot be null");
            }
            await _contentBlockService.AddSingleText(contentBlockSingleTextDto);
            return Ok();
        }

        [HttpPost("single")]
        public async Task<IActionResult> AddSingle(List<ContentBlockSingleFileDto> lists)
        {
            if (lists == null)
            {
                return BadRequest("ContentBlockSingleTextDto cannot be null");
            }
            lists.ForEach(async x => await _contentBlockService.AddSingle(x));
            return Ok();
        }
    }
}
