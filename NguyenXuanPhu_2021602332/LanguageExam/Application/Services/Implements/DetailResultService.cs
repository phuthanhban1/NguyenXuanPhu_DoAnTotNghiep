using Application.Dtos.DetailResultDtos;
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
        public Task AddAsync(DetailResultCreateDto detailResultCreateDto)
        {
            throw new NotImplementedException();
        }

        public async Task CreateDetailResult(Guid examId, Guid userId, List<Guid> listResults, string skillName)
        {
            var examinee = await _unitOfWork.Examinees.GetByExamAndUserId(examId, userId);
            foreach (var item in listResults)
            {
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
            await _unitOfWork.SaveChangeAsync();
        }

        
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<string, int>> GetResultsByExamUser(Guid examId, Guid userId)
        {
            var listResult = await _unitOfWork.DetailResults.GetDetailResultsByExamUser(examId, userId);
            var result = new Dictionary<string, List<Guid>>();
            foreach (var item in listResult)
            {
                if (result.ContainsKey(item.Skill))
                {
                    result[item.Skill].Add(item.AnswerId);
                }
                else
                {
                    result[item.Skill] = new List<Guid> { item.AnswerId };
                }
            }
            var resultCount = new Dictionary<string, int>();
            foreach (var skill in result.Keys)
            {
                var list = result[skill];
                foreach (var item in list)
                {
                    var answer = _unitOfWork.Answers.GetById(item).Include(a => a.Question).ToList()[0];
                    if (answer.IsCorrect == true)
                    {
                        if (!resultCount.ContainsKey(skill))
                        {
                            resultCount[skill] = 0;
                        }
                        resultCount[skill] += answer.Question.Score;
                    }
                    
                }
            }
            return resultCount;
        }

        public Task UpdateAsync(DetailResultUpdateDto detailResultUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
