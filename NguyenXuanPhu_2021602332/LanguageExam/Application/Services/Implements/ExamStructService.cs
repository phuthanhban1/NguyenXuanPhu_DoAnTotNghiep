using Application.Dtos.ExamStruct;
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
    public class ExamStructService : IExamStructService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ExamStructService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(Guid userId, ExamStructCreateDto examStructCreateDto)
        {
            var examStruct = new ExamStruct
            {
                Id = Guid.NewGuid(),
                Name = examStructCreateDto.Name,
                QuestionBankId = examStructCreateDto.QuestionBankId,
                UserCreateId = userId
            };
            await _unitOfWork.ExamStructs.AddAsync(examStruct);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task Delete(Guid id)
        {
            var examStruct = await _unitOfWork.ExamStructs.GetByIdAsync(id);
            if(examStruct != null)
            {
                await _unitOfWork.ExamStructs.DeleteAsync(examStruct);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public async Task<List<ExamStructDto>> GetListByBankId(Guid id)
        {
            var list = await _unitOfWork.ExamStructs.GetListsByBankId(id);
            var listDto = _mapper.Map<List<ExamStructDto>>(list);
            return listDto;
        }

        public async Task Update(ExamStructUpdateDto examStructUpdateDto)
        {
            var examStruct = await _unitOfWork.ExamStructs.GetByIdAsync(examStructUpdateDto.Id);
            examStruct.Name = examStructUpdateDto.Name;
            await _unitOfWork.ExamStructs.UpdateAsync(examStruct);
            await _unitOfWork.SaveChangeAsync();

        }
    }
}
