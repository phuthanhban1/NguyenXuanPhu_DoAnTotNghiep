﻿using Application.Dtos.ExamDtos;
using Application.Dtos.QuestionBankDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IExamService
    {
        Task AddAsync(Guid managerId, ExamCreateDto examCreateDto);
        Task UpdateAsync(ExamUpdateDto examUpdateDto);
        Task DeleteAsync(Guid id);
        Task<List<ExamDto>> GetComingExams();
        Task<List<ExamDto>> GetAllAsync();
        Task<List<ExamDto>> GetByManagerIdAsync(Guid id);
        Task<ExamDto> GetExamByCreate(Guid id);
        Task<Exam> GetById(Guid id);
        Task Confirm(Guid id);
        Task<List<Exam>> GetExamHasResult();
    }
}
