using Application.Dtos.AnswerDtos;
using Application.Dtos.ExamDtos;
using Application.Dtos.ExamineeDtos;
using Application.Dtos.QuestionBankDtos;
using Application.Dtos.SkillDtos;
using Application.Dtos.UserDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AnswerCreateDto, Answer>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<QuestionBankUpdateDto, QuestionBank>();
            CreateMap<QuestionBankCreateDto, QuestionBank>();
            CreateMap<SkillCreateDto, Skill>();
            CreateMap<SkillUpdateDto, Skill>();
            CreateMap<ExamCreateDto, Exam>();
            CreateMap<ExamUpdateDto, Exam>();
            CreateMap<ExamineeCreateDto, Examinee>();
            CreateMap<ExamineeUpdateDto, Examinee>();
        }
    }
}
