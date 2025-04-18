﻿using Application.Dtos.QuestionLevelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IQuestionLevelService
    {
        Task AddAsync(QuestionLevelCreateDto questionLevelCreateDto);
        Task UpdateAsync(QuestionLevelUpdateDto questionLevelUpdateDto);
        Task DeleteAsync(Guid id);
        //Task<QuestionLevelDto> GetByIdAsync(Guid id);
        //Task<List<QuestionLevelDto>> GetAllAsync();
    }
}
