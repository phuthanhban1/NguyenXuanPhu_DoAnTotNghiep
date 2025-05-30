﻿using Application.Dtos.QuestionBankDtos;
using Application.Dtos.SkillDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ISkillService
    {
        Task AddAsync(SkillCreateDto skillDto);
        Task UpdateAsync(SkillUpdateDto skillDto);
        Task DeleteAsync(Guid id);
        Task<QuestionBankDto> GetByIdAsync(Guid id);
        Task<List<SkillDto>> GetByQuestionBankIdAsync(Guid questionBankId);
        Task<SkillDetailDto> GetByCreate(Guid id);
        Task<SkillDetailDto> GetByReview(Guid id);
        Task ConfirmSkill(Guid skillId, string role);
        Task<SkillOverViewDto> GetCreateSkill(Guid skillId);
        Task<SkillOverViewDto> GetReviewSkill(Guid skillId);
        Task<List<string>> GetSkillByBankId(Guid id);
    }
}
