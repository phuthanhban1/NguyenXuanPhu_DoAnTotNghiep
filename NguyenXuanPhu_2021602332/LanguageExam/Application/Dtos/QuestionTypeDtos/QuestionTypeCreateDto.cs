using Domain.Enums;

namespace Application.Dtos.QuestionTypeDtos
{
    public class QuestionTypeCreateDto : QuestionTypeBase
    {    
        // foreign key: skill
        public Guid SkillId { get; set; }
    }
}
