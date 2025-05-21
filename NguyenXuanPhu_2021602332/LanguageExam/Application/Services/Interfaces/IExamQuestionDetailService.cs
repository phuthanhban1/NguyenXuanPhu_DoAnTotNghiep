using Application.Dtos.ContentBlockDtos;
using Application.Dtos.ExamQuestionDetailDtos;
using Application.Dtos.ExamStructDetail;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IExamQuestionDetailService
    {
        Task GenExam(ExamQuestionDetailCreateDto examQuestionDetailCreateDto);
        Task<Dictionary<string, Dictionary<int, List<ContentBlockExamDto>>>> GetExamQuestionDetail(Guid examId);
    }
}
