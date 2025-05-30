﻿using Application.Dtos.ExamDtos;
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
        public async Task AddAsync(Guid managerId, ExamCreateDto examCreateDto)
        {
            var exam = _mapper.Map<Exam>(examCreateDto);
            exam.ManagerId = managerId;
            exam.Id = Guid.NewGuid();
            exam.CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
            exam.IsCreated = false;
            await _unitOfWork.Exams.AddAsync(exam);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task Confirm(Guid id)
        {
            var exam = await _unitOfWork.Exams.GetByIdAsync(id);
            exam.IsCreated = true;
            await _unitOfWork.Exams.UpdateAsync(exam);
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

        public async Task<List<ExamDto>> GetAllAsync()
        {
            var exams = await _unitOfWork.Exams.GetAllAsync();
            var examDtos = _mapper.Map<List<ExamDto>>(exams);
            examDtos = examDtos.OrderByDescending(x => x.StartDate).ToList();
            return examDtos;
        }

        public async Task<Exam> GetById(Guid id)
        {
            var exam = await _unitOfWork.Exams.GetByIdAsync(id);
            return exam;
        }

        

        public async Task<List<ExamDto>> GetByManagerIdAsync(Guid id)
        {
            var exams = await _unitOfWork.Exams.GetAllAsync();
            var examByManagers = exams.Where(exams => exams.ManagerId == id).ToList();
            var examDtos = _mapper.Map<List<ExamDto>>(examByManagers);
            return examDtos;
        }

        public async Task<ExamDto> GetExamByCreate(Guid id)
        {
            var exam = await _unitOfWork.Exams.GetExamByCreate(id);
            if (exam == null)
            {
                throw new NotFoundException($"Không tìm thấy kì thi mà người tạo đề có nhiệm vụ");
            }
            var examDto = _mapper.Map<ExamDto>(exam);
            return examDto;
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
