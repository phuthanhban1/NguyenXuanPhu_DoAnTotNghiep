using Application.Dtos.ExamQuestionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IExamQuestionService
    {
        Task Add(ExamQuestionCreateDto examQuestionCreateDto);
    }
}
