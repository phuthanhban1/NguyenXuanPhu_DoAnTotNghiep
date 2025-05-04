using Application.Dtos.QuestionBankDtos;
using Application.Dtos.SkillDtos;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.UnitOfWork;
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
        public async Task AddAsync(SkillCreateDto skillDto)
        {
            var skill = _mapper.Map<Skill>(skillDto);
            skill.Id = Guid.NewGuid();
            await _unitOfWork.Skills.AddAsync(skill);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task ConfirmSkill(SkillConfirmDto skillConfirmDto)
        {
            var skill = await _unitOfWork.Skills.GetByIdAsync(skillConfirmDto.Id);
            if (skill == null)
            {
                throw new NotFoundException($"Không tìm thấy kỹ năng có id {skillConfirmDto.Id}");
            }
            skill.IsConfirm = skillConfirmDto.IsConfirm;
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
    }
}
