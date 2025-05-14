using Application.Dtos.QuestionBankDtos;
using Application.Dtos.SkillDtos;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.UnitOfWork;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SkillService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<string>> GetSkillNamesByBankId(Guid id)
        {
            var list = await _unitOfWork.Skills.GetSkillsByBankId(id);
            return list.Select(s => s.Name).ToList();
        }

        //public Task<List<SkillDetailDto>> GetSkillsByBankId(Guid id)
        //{
        //    var list = _unitOfWork.Skills.GetSkillsByBankId(id);
        //    return list
        //}
        public async Task AddAsync(SkillCreateDto skillDto)
        {
            var listSkill = await _unitOfWork.Skills.GetSkillsByBankId(skillDto.QuestionBankId);
            if(listSkill.Any(x => x.Name == skillDto.Name))
            {
                throw new BadRequestException("Kĩ năng đã tồn tại");
            }
            var skill = _mapper.Map<Skill>(skillDto);
            skill.Id = Guid.NewGuid();
            skill.IsProcess = true;
            skill.IsCreateConfirm = false;
            skill.IsReviewConfirm = false;
            await _unitOfWork.Skills.AddAsync(skill);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task ConfirmSkill(Guid skillId, string role)
        {
            var skill = await _unitOfWork.Skills.GetByIdAsync(skillId);
            if (skill == null)
            {
                throw new NotFoundException($"Không tìm thấy kỹ năng có id {skill.Id}");
            }
            
            if(role == "người tạo câu hỏi")
            {
                skill.IsCreateConfirm = true;
            } else
            {
                skill.IsReviewConfirm = true;
            }
                await _unitOfWork.Skills.ConfirmSkill(skill);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var skill = await _unitOfWork.Skills.GetByIdAsync(id);
            if (skill == null)
            {
                throw new NotFoundException($"Không tìm thấy kỹ năng có id {id}");
            }
            else
            {
                await _unitOfWork.Skills.DeleteAsync(skill);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public async Task<SkillDetailDto> GetByCreate(Guid id)
        {
            var skill = _unitOfWork.Skills.GetByCreate(id);
            if (skill == null)
            {
                throw new NotFoundException($"Không tìm thấy kỹ năng nào cho người tạo câu hỏi có id {id}");
            }
            var skillDto = _mapper.Map<SkillDetailDto>(skill);
            return skillDto;
        }

        public Task<QuestionBankDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SkillDto>> GetByQuestionBankIdAsync(Guid questionBankId)
        {
            var skills = await _unitOfWork.Skills.FindAsync(s => s.QuestionBankId == questionBankId);
            if (skills == null || !skills.Any())
            {
                throw new NotFoundException($"Không tìm thấy kỹ năng nào cho ngân hàng câu hỏi có id {questionBankId}");
            }
            var skillDtos = _mapper.Map<List<SkillDto>>(skills);
            return skillDtos;
        }

        public async Task<SkillDetailDto> GetByReview(Guid id)
        {
            var skill = _unitOfWork.Skills.GetByReview(id);
            if (skill == null)
            {
                throw new NotFoundException($"Không tìm thấy kỹ năng nào cho người đánh giá câu hỏi có id {id}");
            }
            var skillDto = _mapper.Map<SkillDetailDto>(skill);
            return skillDto;
        }

        public async Task<SkillOverViewDto> GetCreateSkill(Guid CreatedUserId)
        {
            var skill = await _unitOfWork.Skills.GetSkillByCreate(CreatedUserId);
            if (skill == null)
            {
                throw new NotFoundException($"Không tìm thấy kỹ năng nào cho người tạo câu hỏi có id {CreatedUserId}");
            }
            var skillOverViewDto = new SkillOverViewDto
            {
                Id = skill.Id,
                Name = skill.Name,
                IsConfirm = skill.IsCreateConfirm,
                QuestionBankName = skill.QuestionBank.Name,
                Language = skill.QuestionBank.Language,
                
                Task = "Tạo câu hỏi"
            };
            if(skill.CreateDue != null)
            {
                skillOverViewDto.DueDate = (DateTime)skill.CreateDue;
            }
            return skillOverViewDto;
        }

        public async Task<SkillOverViewDto> GetReviewSkill(Guid ReviewUserId)
        {
            var skill = await _unitOfWork.Skills.GetSkillByReview(ReviewUserId);
            if (skill == null)
            {
                throw new NotFoundException($"Không tìm thấy kỹ năng nào cho người tạo câu hỏi có id {ReviewUserId}");
            }
            var skillOverViewDto = new SkillOverViewDto
            {
                Id = skill.Id,
                Name = skill.Name,
                IsConfirm = skill.IsReviewConfirm,
                QuestionBankName = skill.QuestionBank.Name,
                Language = skill.QuestionBank.Language,
                Task = "Duyệt câu hỏi"
            };
            if(skill.ReviewDue != null)
            {
                skillOverViewDto.DueDate = (DateTime)skill.ReviewDue;
            }
            return skillOverViewDto;
        }

        public async Task UpdateAsync(SkillUpdateDto skillDto)
        {
            var skill = await _unitOfWork.Skills.GetByIdAsync(skillDto.Id);
            if (skill == null)
            {
                throw new NotFoundException($"Không tìm thấy kỹ năng có id {skillDto.Id}");
            }
            else
            {
                _mapper.Map(skillDto, skill);
                await _unitOfWork.Skills.UpdateAsync(skill);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public Task<List<string>> GetSkillByBankId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
