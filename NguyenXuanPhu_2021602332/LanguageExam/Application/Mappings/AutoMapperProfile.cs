using Application.Dtos.AnswerDtos;
using Application.Dtos.ContentBlockDtos;
using Application.Dtos.DetailResultDtos;
using Application.Dtos.ExamDtos;
using Application.Dtos.ExamineeDtos;
using Application.Dtos.ExamStruct;
using Application.Dtos.ExamStructDetail;
using Application.Dtos.ImageFileDtos;
using Application.Dtos.QuestionBankDtos;
using Application.Dtos.QuestionDtos;
using Application.Dtos.QuestionTypeDtos;
using Application.Dtos.RoleDtos;
using Application.Dtos.RoomDtos;
using Application.Dtos.SimilarQuestions;
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
            CreateMap<Room, RoomDto>();
            CreateMap<Exam, ExamDto>();
            CreateMap<ExamStructDetailCreateDto, ExamStructDetail>();
            CreateMap<ExamStructDetail, ExamStructDetailDto>().ForMember(esdd => esdd.QuestionTypeName, s => s.MapFrom(s => s.QuestionType.Name));
            CreateMap<ExamStruct, ExamStructDto>();
            CreateMap<Skill, SkillDto>()
                .ForMember(sd => sd.CreatedUserName, s => s.MapFrom(s => s.CreatedUser.FullName))
                .ForMember(sd => sd.ReviewedUserName, s => s.MapFrom(s => s.ReviewedUser.FullName))
                ;
            CreateMap<Role, RoleDto>();
            CreateMap<AnswerCreateDto, Answer>().ReverseMap();
            CreateMap<UserUpdateDto, User>()
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
                .ForMember(ud => ud.ImageFaceBase64, u => u.MapFrom(u => Convert.ToBase64String(u.ImageFace.FileData)))
                .ForMember(ud => ud.ImageIdCardBeforeBase64, u => u.MapFrom(u => Convert.ToBase64String(u.ImageIdCardBefore.FileData)))
                .ForMember(ud => ud.ImageIdCardAfterBase64, u => u.MapFrom(u => Convert.ToBase64String(u.ImageIdCardAfter.FileData)))
                .ForMember(ud => ud.FullAddress, u => u.Ignore());
            CreateMap<Examinee, ExamineeDto>()
                .ForMember(ed => ed.RoomName, e => e.MapFrom(e => e.Room.Name))
                .ForMember(ed => ed.FullName, e => e.MapFrom(e => e.User.FullName))
                .ForMember(ed => ed.Email, e => e.MapFrom(e => e.User.Email))
                ;

            CreateMap<ContentBlock, ContentBlockSimilarDto>();
            

            CreateMap<Examinee, DetailResultDto>()
                .ForMember(ed => ed.FullName, e => e.MapFrom(e => e.User.FullName));
                

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
                .ForMember(cbd => cbd.Questions, cb => cb.MapFrom(cb => cb.Questions))
                .ForMember(cbd => cbd.IsSingle, cb => cb.MapFrom(cb => cb.QuestionType.IsSingle))
                ;
            CreateMap<SimilarQuestion, SimilarQuestionDto>()
                .ForMember(sqd => sqd.Id, s => s.MapFrom(s => s.ContentBlockId1));
            CreateMap<ContentBlock, SimilarQuestionDto>()
                .ForMember(cbd => cbd.AudioBase64, cb => cb.MapFrom(cb => Convert.ToBase64String(cb.AudioFile.FileData)))
                .ForMember(cbd => cbd.ImageBase64, cb => cb.MapFrom(cb => Convert.ToBase64String(cb.ImageFile.FileData)))
                .ForMember(cbd => cbd.Questions, cb => cb.MapFrom(cb => cb.Questions))
                .ForMember(cbd => cbd.Questions, cb => cb.MapFrom(cb => cb.Questions))
                .ForMember(cbd => cbd.IsSingle, cb => cb.MapFrom(cb => cb.QuestionType.IsSingle))
                ;
            // .ForMember(cbd => cbd.Questions.Answers, cb => cb.MapFrom(cb => cb.Questions.Answers));

            CreateMap<Question, QuestionCreateDto>().ReverseMap();
            CreateMap<QuestionType, QuestionTypeCountDto>()
                .ForMember(qtd => qtd.QuestionTypeCounts, u => u.Ignore());
            

            CreateMap<User, GetAllUserDto>()
                .ForMember(g => g.RoleName, u => u.MapFrom(u => u.Role.Name));

            CreateMap<AnswerCreateDto, Answer>();
            CreateMap<QuestionCreateDto, Question>();


        }
    }
}
