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

        public async Task AddAsync(QuestionBankCreateDto userCreateDto, Guid managerId)
        {
            var questionBank = _mapper.Map<QuestionBank>(userCreateDto);    
            questionBank.Id = Guid.NewGuid();
            questionBank.CreatedDate = DateTime.UtcNow;
            questionBank.ManagerId = managerId;
            questionBank.Status = 0;
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
                questionBank.Status = 1;
                await _unitOfWork.QuestionBanks.UpdateAsync(questionBank);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public async Task<List<QuestionBankDto>> GetAllAsync()
        {
            var banks = await _unitOfWork.QuestionBanks.GetAllAsync();
            var activeBanks = banks.Where(b => b.Status == 0).ToList();
            var questionBankDtos = _mapper.Map<List<QuestionBankDto>>(activeBanks);
            return questionBankDtos;
        }

        public async Task<List<QuestionBankDto>> GetByLanguageManageId(string language, Guid managerId)
        {
            var questionBanks = await _unitOfWork.QuestionBanks.GetByLanguageManager(language, managerId);
            if (questionBanks == null)
            {
                throw new NotFoundException($"Không tìm thấy ngân hàng câu hỏi với ngôn ngữ {language} và id người quản lý {managerId}");
            }
            var questionBankDtos = _mapper.Map<List<QuestionBankDto>>(questionBanks);
            return questionBankDtos;
        }

        public async Task UpdateAsync(QuestionBankUpdateDto questionBankUpdateDto)
        {
            var questionBank = await _unitOfWork.QuestionBanks.GetByIdAsync(questionBankUpdateDto.Id);
            if (questionBank == null)
            {
                throw new NotFoundException($"Không tìm thấy ngân hàng câu hỏi có id: {questionBankUpdateDto.Id}");
            }
            else if (DateTime.Now >= questionBank.CreatedDate.AddMonths(2))
            {
                throw new BadRequestException($"Thời gian cập nhật đã kết thúc");
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
