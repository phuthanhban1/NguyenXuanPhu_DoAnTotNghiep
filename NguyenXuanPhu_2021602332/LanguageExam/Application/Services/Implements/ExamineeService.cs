using Application.Dtos.ExamineeDtos;
using Application.Exceptions;
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
    public class ExamineeService : IExamineeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ExamineeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(ExamineeCreateDto examineeCreateDto)
        {
            var examinee = new Examinee
            {
                ExamId = examineeCreateDto.ExamId,
                UserId = examineeCreateDto.UserId,
            };
            await _unitOfWork.Examinees.AddAsync(examinee);
            await _unitOfWork.SaveChangeAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ExamineeUpdateDto examineeUpdateDto)
        {
            var examinee = await _unitOfWork.Examinees.GetByExamAndUserId(examineeUpdateDto.ExamId, examineeUpdateDto.UserId);
            if(examinee == null)
            {
                throw new NotFoundException($"Không tìm thấy thí sinh có id {examineeUpdateDto.UserId} trong kì thi có id {examineeUpdateDto.ExamId}");
            } else
            {
                _mapper.Map(examineeUpdateDto, examinee);
                await _unitOfWork.Examinees.UpdateAsync(examinee);
                await _unitOfWork.SaveChangeAsync();
            }
                
        }
    }
}
