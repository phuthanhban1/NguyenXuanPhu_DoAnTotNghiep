using Application.Dtos.AnswerDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageFileController : ControllerBase
    {
        private readonly IImageFileService _imageFileService;
        public ImageFileController(IImageFileService imageFileService)
        {
            _imageFileService = imageFileService;
        }

        [HttpPost]
        public async Task<ActionResult> Upload(IFormFile image)
        {
            await _imageFileService.AddAsync(image);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> DownLoad(Guid id)
        {
            var fileDto = await _imageFileService.GetByIdAsync(id);
            if (fileDto == null)
            {
                return NotFound();
            }
            return File(fileDto.FileData, fileDto.ContentType, fileDto.FileName);
        }
    }
}
