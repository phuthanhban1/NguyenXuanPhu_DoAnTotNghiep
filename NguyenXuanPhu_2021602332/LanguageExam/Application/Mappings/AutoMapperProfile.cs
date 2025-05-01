using Application.Dtos.AnswerDtos;
using Application.Dtos.ExamDtos;
using Application.Dtos.ExamineeDtos;
using Application.Dtos.ImageFileDtos;
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

            CreateMap<Domain.Entities.ExamFile, ImageFileDto>();

            CreateMap<QuestionBankUpdateDto, QuestionBank>();
            CreateMap<QuestionBankCreateDto, QuestionBank>();
            CreateMap<SkillCreateDto, Skill>();
            CreateMap<SkillUpdateDto, Skill>();

            CreateMap<ExamCreateDto, Exam>();
            CreateMap<ExamUpdateDto, Exam>();
            CreateMap<Exam, ExamDto>();

            CreateMap<ExamineeCreateDto, Examinee>();
            CreateMap<ExamineeUpdateDto, Examinee>();

            //CreateMap<ImageFileUpdateDto, ImageFile>();
        }
    }
}
