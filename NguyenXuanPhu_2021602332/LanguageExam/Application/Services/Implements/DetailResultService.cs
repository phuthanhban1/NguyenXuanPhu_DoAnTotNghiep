using Application.Dtos.DetailResultDtos;
using Application.Dtos.ExamineeDtos;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class DetailResultService : IDetailResultService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DetailResultService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateDetailResult(Guid examId, Guid userId, List<Guid> listResults, string skillName)
        {
            var examinee = await _unitOfWork.Examinees.GetByExamAndUserId(examId, userId);
            var score = 0;
            foreach (var item in listResults)
            {
                var answer = _unitOfWork.Answers.GetById(item).Include(a => a.Question).ToList()[0];
                if (answer.IsCorrect == true)
                {
                    score += answer.Question.Score;
                }
                var detailResult = new DetailResult
                {
                    Id = Guid.NewGuid(),
                    ExamId = examId,
                    UserId = userId,
                    Skill = skillName,
                    AnswerId = item
                };
                await _unitOfWork.DetailResults.AddAsync(detailResult);
            }
            if (skillName == "reading") examinee.ReadingScore = score;
            else if (skillName == "listening") examinee.ListeningScore = score;
            else if (skillName == "writing") examinee.WritingScore = score;
            else if (skillName == "speaking") examinee.SpeakingScore = score;
            await _unitOfWork.Examinees.UpdateAsync(examinee);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<DetailResultDto>> GetAllResult(Guid examId)
        {
            var examinees = await _unitOfWork.Examinees.GetExamineesByExamId(examId);
            examinees = examinees.Where(e => e.IsExamTaken == true).ToList();
            var examineeDtos = _mapper.Map<List<DetailResultDto>>(examinees);
            return examineeDtos;
        }

        
    }
}
