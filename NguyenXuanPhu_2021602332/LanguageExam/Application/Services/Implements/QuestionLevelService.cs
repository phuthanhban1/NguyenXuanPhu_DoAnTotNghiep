using Application.Dtos.QuestionLevelDtos;
using Application.Services.Interfaces;
using AutoMapper;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class QuestionLevelService : IQuestionLevelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuestionLevelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task AddAsync(QuestionLevelCreateDto questionLevelCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(QuestionLevelUpdateDto questionLevelUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
