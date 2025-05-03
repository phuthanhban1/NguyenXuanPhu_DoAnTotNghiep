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
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuestionTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(QuestionLevelCreateDto questionLevelCreateDto)
        {
            var questionLevel = _mapper.Map<QuestionType>(questionLevelCreateDto);
            await _unitOfWork.QuestionTypes.AddAsync(questionLevel);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var questionLevel = await _unitOfWork.QuestionTypes.GetByIdAsync(id);
            if (questionLevel == null)
            {
                throw new NotFoundException("Không tìm thấy loại câu hỏi");
            }
            await _unitOfWork.QuestionTypes.DeleteAsync(questionLevel);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<QuestionLevelUpdateDto>> GetAllAsync(Guid skillId)
        {
            var questionLevels = await _unitOfWork.QuestionTypes.GetAllAsync();
            var questionLevelSkill = questionLevels.Where(x => x.SkillId == skillId).ToList();
            var questionLevelDtos = _mapper.Map<List<QuestionLevelUpdateDto>>(questionLevelSkill);
            return questionLevelDtos;
        }

        public async Task<QuestionLevelUpdateDto> GetByIdAsync(Guid id)
        {
            var questionLevel = await _unitOfWork.QuestionTypes.GetByIdAsync(id);
            if (questionLevel == null)
            {
                throw new NotFoundException("Không tìm thấy loại câu hỏi");
            }
            var questionLevelDto = _mapper.Map<QuestionLevelUpdateDto>(questionLevel);
            return questionLevelDto;
        }

        public async Task UpdateAsync(QuestionLevelUpdateDto questionLevelUpdateDto)
        {
            var questionLevel = await _unitOfWork.QuestionTypes.GetByIdAsync(questionLevelUpdateDto.Id);
            if (questionLevel == null)
            {
                throw new NotFoundException("Không tìm thấy loại câu hỏi");
            }
            questionLevel.Name = questionLevelUpdateDto.Name;
            questionLevel.Level = questionLevelUpdateDto.Level;
            await _unitOfWork.QuestionTypes.UpdateAsync(questionLevel);
            await _unitOfWork.SaveChangeAsync();

        }
    }
}
