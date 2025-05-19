using Application.Dtos.ExamQuestionDtos;
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
    public class ExamQuestionService : IExamQuestionService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ExamQuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(ExamQuestionCreateDto examQuestionCreateDto)
        {
            var examQuestion = new ExamQuestion
            {
                ExamId = examQuestionCreateDto.ExamId,
                ExamStructId = examQuestionCreateDto.ExamStructId
            };
            examQuestion.Id = Guid.NewGuid();
            await _unitOfWork.ExamQuestions.AddAsync(examQuestion);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
