using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageFileController : ControllerBase
    {
        private readonly IExamFileService _imageFileService;
        public ImageFileController(IExamFileService imageFileService)
        {
            _imageFileService = imageFileService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var fileDto = await _imageFileService.GetByIdAsync(id);
            return File(fileDto.FileData, fileDto.ContentType, fileDto.FileName);
            
        }
    }
}
