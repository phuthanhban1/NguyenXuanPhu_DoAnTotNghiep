using Application.Dtos.QuestionLevelDtos;
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
    public class QuestionLevelService : IQuestionLevelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuestionLevelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(QuestionLevelCreateDto questionLevelCreateDto)
        {
            var questionLevel = _mapper.Map<QuestionType>(questionLevelCreateDto);
            await _unitOfWork.QuestionLevels.AddAsync(questionLevel);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var questionLevel = await _unitOfWork.QuestionLevels.GetByIdAsync(id);
            if (questionLevel == null)
            {
                throw new NotFoundException("Không tìm thấy loại câu hỏi");
            }
            await _unitOfWork.QuestionLevels.DeleteAsync(questionLevel);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<QuestionLevelUpdateDto>> GetAllAsync(Guid skillId)
        {
            var questionLevels = await _unitOfWork.QuestionLevels.GetAllAsync();
            var questionLevelSkill = questionLevels.Where(x => x.SkillId == skillId).ToList();
            var questionLevelDtos = _mapper.Map<List<QuestionLevelUpdateDto>>(questionLevelSkill);
            return questionLevelDtos;
        }

        public async Task<QuestionLevelUpdateDto> GetByIdAsync(Guid id)
        {
            var questionLevel = await _unitOfWork.QuestionLevels.GetByIdAsync(id);
            if (questionLevel == null)
            {
                throw new NotFoundException("Không tìm thấy loại câu hỏi");
            }
            var questionLevelDto = _mapper.Map<QuestionLevelUpdateDto>(questionLevel);
            return questionLevelDto;
        }

        public async Task UpdateAsync(QuestionLevelUpdateDto questionLevelUpdateDto)
        {
            var questionLevel = await _unitOfWork.QuestionLevels.GetByIdAsync(questionLevelUpdateDto.Id);
            if (questionLevel == null)
            {
                throw new NotFoundException("Không tìm thấy loại câu hỏi");
            }
            questionLevel.Name = questionLevelUpdateDto.Name;
            questionLevel.Level = questionLevelUpdateDto.Level;
            await _unitOfWork.QuestionLevels.UpdateAsync(questionLevel);
            await _unitOfWork.SaveChangeAsync();

        }
    }
}
