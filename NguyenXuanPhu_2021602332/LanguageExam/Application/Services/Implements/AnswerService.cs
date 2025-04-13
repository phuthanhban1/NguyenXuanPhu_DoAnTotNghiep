using Application.Dtos.AnswerDtos;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.UnitOfWork;

namespace Application.Services.Implements
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AnswerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(AnswerCreateDto answerCreateDto, Guid questionId)
        {
            var answer = _mapper.Map<Answer>(answerCreateDto);
            answer.QuestionId = questionId;
            answer.Id = Guid.NewGuid();
            await _unitOfWork.Answers.AddAsync(answer);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var answer = await _unitOfWork.Answers.GetByIdAsync(id);
            if(answer == null)
            {
                throw new NotFoundException($"Không tìm thấy đáp án có id: {id}");
            } else
            {
                await _unitOfWork.Answers.DeleteAsync(answer);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public IEnumerable<Answer> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Answer> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.Answers.GetByIdAsync(id);
        }

        public async Task UpdateAsync(AnswerDto answerDto)
        {
            var answer = await GetByIdAsync(answerDto.Id);
            answer = _mapper.Map<Answer>(answerDto);
            await _unitOfWork.Answers.UpdateAsync(answer);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
