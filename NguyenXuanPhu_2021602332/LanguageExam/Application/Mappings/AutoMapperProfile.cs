using Application.Dtos.AnswerDtos;
using Application.Dtos.ContentBlockDtos;
using Application.Dtos.ExamDtos;
using Application.Dtos.ExamineeDtos;
using Application.Dtos.ImageFileDtos;
using Application.Dtos.QuestionBankDtos;
using Application.Dtos.QuestionDtos;
using Application.Dtos.QuestionTypeDtos;
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
            CreateMap<AnswerCreateDto, Answer>().ReverseMap();
            CreateMap<UserCreateDto, User>()
                .ForMember(u => u.ImageFaceId, ucd=> ucd.Ignore())
                .ForMember(u => u.ImageFace, ucd => ucd.Ignore())
                .ForMember(u => u.ImageIdCardAfterId, ucd=> ucd.Ignore())
                .ForMember(u => u.ImageIdCardAfter, ucd=> ucd.Ignore())
                .ForMember(u => u.ImageIdCardBeforeId, ucd=> ucd.Ignore())
                .ForMember(u => u.ImageIdCardBefore, ucd=> ucd.Ignore())
                .ForMember(u => u.IsActive, ucd => ucd.Ignore());
            CreateMap<UserUpdateDto, User>()
                .ForMember(u => u.ImageFaceId, ucd => ucd.Ignore())
                .ForMember(u => u.ImageFace, ucd => ucd.Ignore())
                .ForMember(u => u.ImageIdCardAfterId, ucd => ucd.Ignore())
                .ForMember(u => u.ImageIdCardAfter, ucd => ucd.Ignore())
                .ForMember(u => u.ImageIdCardBeforeId, ucd => ucd.Ignore())
                .ForMember(u => u.ImageIdCardBefore, ucd => ucd.Ignore())
                .ForMember(u => u.IsActive, ucd => ucd.Ignore());

            CreateMap<User, GetAllUserDto>();
            CreateMap<User, UserDto>()
                .ForMember(ud => ud.Address, u => u.Ignore())
                .ForMember(ud => ud.ImageFace, u => u.Ignore())
                .ForMember(ud => ud.ImageIdCardBefore, u => u.Ignore())
                .ForMember(ud => ud.ImageIdCardAfter, u => u.Ignore());

            CreateMap<ExamFile, ImageFileDto>();

            CreateMap<QuestionBankUpdateDto, QuestionBank>();
            CreateMap<QuestionBankCreateDto, QuestionBank>();
            CreateMap<QuestionBank, QuestionBankDto>();
            CreateMap<SkillCreateDto, Skill>();
            CreateMap<SkillUpdateDto, Skill>();

            CreateMap<ExamCreateDto, Exam>();
            CreateMap<ExamUpdateDto, Exam>();
            CreateMap<Exam, ExamDto>();

            CreateMap<ExamineeCreateDto, Examinee>();
            CreateMap<ExamineeUpdateDto, Examinee>();

            CreateMap<QuestionType, QuestionTypeDto>();
            CreateMap<QuestionTypeCreateDto, QuestionType>();

            CreateMap<Skill, SkillDetailDto>()
                
                .ForMember(sd => sd.Language, s => s.MapFrom(s => s.QuestionBank.Language))
                .ForMember(sd => sd.BankName, s => s.MapFrom(s => s.QuestionBank.Name));

            CreateMap<QuestionType, QuestionTypeDto>()
                .ForMember(qtd => qtd.SkillName, qt => qt.MapFrom(qt => qt.Skill.Name));
            CreateMap<QuestionType, QuestionTypeUpdateDto>().ReverseMap();

            CreateMap<ContentBlock, ContentBlockDto>()
                .ForMember(cbd => cbd.AudioBase64, cb => cb.MapFrom(cb => Convert.ToBase64String(cb.AudioFile.FileData)))
                .ForMember(cbd => cbd.ImageBase64, cb => cb.MapFrom(cb => Convert.ToBase64String(cb.ImageFile.FileData)))
                .ForMember(cbd => cbd.Questions, cb => cb.MapFrom(cb => cb.Questions))
                .ForMember(cbd => cbd.IsSingle, cb => cb.MapFrom(cb => cb.QuestionType.IsSingle))
                ;

               // .ForMember(cbd => cbd.Questions.Answers, cb => cb.MapFrom(cb => cb.Questions.Answers));

            CreateMap<Question, QuestionCreateDto>().ReverseMap();
        }
    }
}
