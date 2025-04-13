using Application.Dtos.ExamDtos;
using Application.Dtos.QuestionBankDtos;
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
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ExamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(ExamCreateDto examCreateDto)
        {
            var exam = _mapper.Map<Exam>(examCreateDto);
            exam.Id = Guid.NewGuid();
            exam.CreatedDate = DateTime.UtcNow;
            exam.IsActive = true;
            exam.UpdatedDate = DateTime.UtcNow;
            await _unitOfWork.Exams.AddAsync(exam);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var exam = await _unitOfWork.Exams.GetByIdAsync(id);
            if (exam == null)
            {
                throw new NotFoundException($"Không tìm thấy kì thi có id {id}");
            }
            else
            {
                await _unitOfWork.Exams.DeleteAsync(exam);
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

        public async Task UpdateAsync(ExamUpdateDto examUpdateDto)
        {
            var exam = await _unitOfWork.Exams.GetByIdAsync(examUpdateDto.Id);
            if (exam == null)
            {
                throw new NotFoundException($"Không tìm thấy kì thi có id {examUpdateDto.Id}");
            }
            else
            {
                _mapper.Map(examUpdateDto, exam);
                await _unitOfWork.Exams.UpdateAsync(exam);
                await _unitOfWork.SaveChangeAsync();
            }
        }
    }
}
