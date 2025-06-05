using Application.Dtos.QuestionDtos;
using Microsoft.AspNetCore.Http;


namespace Application.Dtos.ContentBlockDtos
{
    public class ContentBlockCreateDto
    {
        public string? Content { get; set; }

        // foreign key audio file
        public IFormFile? AudioFile { get; set; }

        // foreign key image file
        public IFormFile? ImageFile { get; set; }

        // foreign key question level
        public Guid QuestionTypeId { get; set; }

        public List<QuestionCreateDto> Questions { get; set; }
    }
}
