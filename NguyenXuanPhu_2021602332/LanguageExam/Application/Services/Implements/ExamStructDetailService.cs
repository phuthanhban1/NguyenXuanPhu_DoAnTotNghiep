using Application.Dtos.ExamStructDetail;
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
    public class ExamStructDetailService : IExamStructDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ExamStructDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(List<ExamStructDetailCreateDto> list)
        {
            await _unitOfWork.ExamStructDetails.DeleteByStructId(list[0].ExamStructId, list[0].Skill);
            var listEntity = _mapper.Map<List<ExamStructDetail>>(list);
            listEntity.ForEach(l => l.Id = Guid.NewGuid());
            listEntity.ForEach(async l => await _unitOfWork.ExamStructDetails.AddAsync(l));
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ExamStructDetailDto>> GetStruct(Guid id, string skill)
        {
            var list = await _unitOfWork.ExamStructDetails.GetByExamStructId(id, skill);
            var listDto = _mapper.Map<List<ExamStructDetailDto>>(list);
            
            return listDto;
        }
    }
}
