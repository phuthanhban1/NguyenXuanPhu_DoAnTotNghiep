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
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task AddAsync(QuestionBankCreateDto questionBankCreateDto, Guid managerId)
        {
            var check = await _unitOfWork.QuestionBanks.FindByName("Tiếng Hàn", questionBankCreateDto.Name);
            if (check)
            {
                throw new BadRequestException($"Không thể thêm do tên ngân hàng đã tồn tại");
            }
            var questionBank = _mapper.Map<QuestionBank>(questionBankCreateDto);
            questionBank.Id = Guid.NewGuid();
            questionBank.CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow); 
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
                var currentDate = DateOnly.FromDateTime(DateTime.Now);
                if ((currentDate.DayNumber - questionBank.CreatedDate.DayNumber) > 7)
                {
                    throw new NotFoundException("Không thể xóa ngân hàng câu hỏi do đã được tạo hơn 7 ngày");
                } else if(questionBank.Status == 1)
                {
                    throw new BadRequestException("Không thể xóa do ngân hàng câu hỏi đang hoạt động");
                }
                await _unitOfWork.QuestionBanks.DeleteAsync(questionBank);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public async Task<List<QuestionBankDto>> GetAllAsync()
        {
            var banks = await _unitOfWork.QuestionBanks.GetAllAsync();
            var questionBankDtos = _mapper.Map<List<QuestionBankDto>>(banks);
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

        public async Task<QuestionBankDetailDto> GetDetail(Guid id)
        {
            var qb = _unitOfWork.QuestionBanks.GetById(id).ToList();
            var questionBankDto = new QuestionBankDetailDto
            {
                Id = qb[0].Id,
                Name = qb[0].Name,
                Status = qb[0].Status
            };
            return questionBankDto;
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
                if(questionBank.Name != questionBankUpdateDto.Name)
                {
                    var check = await _unitOfWork.QuestionBanks.FindByName("Tiếng Hàn", questionBankUpdateDto.Name);
                    if(check)
                    {
                        throw new BadRequestException($"Không thể sửa do tên ngân hàng đã tồn tại");
                    }
                }
                if(questionBank.Name == questionBankUpdateDto.Name && questionBank.Status == questionBankUpdateDto.Status)
                {
                    throw new BadRequestException("Không thể sửa do thông tin không thay đổi");
                }
                questionBank.Status = questionBankUpdateDto.Status;
                questionBank.Name = questionBankUpdateDto.Name;
               
                var listSkill = await _unitOfWork.Skills.GetSkillsByBankId(questionBank.Id);
                if (listSkill.Count > 0)
                {
                    foreach (var skill in listSkill)
                    {
                        skill.CreatedUserId = null;
                        skill.ReviewedUserId = null;
                        skill.CreateDue = DateTime.Now.AddDays(7);
                        skill.ReviewDue = DateTime.Now.AddDays(14);
                        await _unitOfWork.Skills.UpdateAsync(skill);
                    }
                }
                await _unitOfWork.QuestionBanks.UpdateAsync(questionBank);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        
    }
}
