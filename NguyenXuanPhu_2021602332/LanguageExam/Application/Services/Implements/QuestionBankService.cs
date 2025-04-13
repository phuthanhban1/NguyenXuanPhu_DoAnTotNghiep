using Application.Dtos.QuestionBankDtos;
using Application.Dtos.UserDtos;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class QuestionBankService : IQuestionBankService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuestionBankService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(QuestionBankCreateDto userCreateDto)
        {
            var questionBank = _mapper.Map<QuestionBank>(userCreateDto);    
            questionBank.Id = Guid.NewGuid();
            questionBank.CreatedAt = DateTime.UtcNow;
            await _unitOfWork.QuestionBanks.AddAsync(questionBank);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var questionBank = await _unitOfWork.QuestionBanks.GetByIdAsync(id);
            if (questionBank == null)
            {
                throw new NotFoundException($"Không tìm thấy ngân hàng câu hỏi có id {id}");
            }
            else
            {
                await _unitOfWork.QuestionBanks.DeleteAsync(questionBank);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public Task<List<QuestionBankDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<QuestionBankDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(QuestionBankUpdateDto questionBankUpdateDto)
        {
            var questionBank = await _unitOfWork.QuestionBanks.GetByIdAsync(questionBankUpdateDto.Id);
            if (questionBank == null)
            {
                throw new NotFoundException($"Không tìm thấy ngân hàng câu hỏi có id: {questionBankUpdateDto.Id}");
            }
            else
            {
                _mapper.Map(questionBankUpdateDto, questionBank);
                await _unitOfWork.QuestionBanks.UpdateAsync(questionBank);
                await _unitOfWork.SaveChangeAsync();
            }
        }
    }
}
