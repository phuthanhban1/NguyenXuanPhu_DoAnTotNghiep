using Application.Dtos.ExamineeDtos;
using Application.Dtos.RoomDtos;
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
        public async Task AddAsync(Guid examId, Guid userId)
        {
            var examinees = await _unitOfWork.Examinees.GetExamineesByExamId(examId);
            var count = examinees.Count();
            var exam = await _unitOfWork.Exams.GetByIdAsync(examId);
            if(exam.Amount - count <= 0)
            {
                throw new BadRequestException("Số lượng thí sinh đã đủ");
            }
            var examinee = new Examinee
            {
                ExamId = examId,
                UserId = userId,
            };
            await _unitOfWork.Examinees.AddAsync(examinee);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task CreateExamNumber(Guid id)
        {
            var examinees = await _unitOfWork.Examinees.GetExamineesByExamId(id);
            var date = examinees[0].Exam.StartDate;
            var index = 0;
            foreach(var examinee in examinees)
            {
                index++;
                var examineeNumber = date.ToString("ddMMyy") + "8" + index.ToString("D6");
                examinee.ExamineeNumber = examineeNumber;
                await _unitOfWork.Examinees.UpdateAsync(examinee);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task CreateRoom(Guid examId, List<RoomExamDto> list)
        {
            var examinees = await _unitOfWork.Examinees.GetExamineesByExamId(examId);
            foreach(var room in list) { 
                int availableSlots = room.Amount;
                int index = 1;
                while(examinees.Any() && availableSlots > 0)
                {
                    var examinee = examinees[0];
                    examinee.RoomId = room.Id;
                    examinee.Location = index;
                    index++;
                    availableSlots--;
                    examinees.RemoveAt(0);
                    await _unitOfWork.Examinees.UpdateAsync(examinee);
                }

                if (!examinees.Any()) { break; }
            };
            await _unitOfWork.SaveChangeAsync();

        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExamineeDto>> GetByExamIdAsync(Guid id)
        {
            var list = await _unitOfWork.Examinees.GetExamineesByExamId(id);
            var examineeDtos = _mapper.Map<List<ExamineeDto>>(list);
            return examineeDtos;
        }

        public async Task<ExamineeDto> GetExaminee(Guid examId, Guid userId)
        {
            var examinee = await _unitOfWork.Examinees.GetByExamAndUserId(examId, userId);
            var examineeDto = _mapper.Map<ExamineeDto>(examinee);
            return examineeDto;
        }

        public async Task<List<ExamineeDto>> GetUserByExamId(Guid id)
        {
            var examinees = await _unitOfWork.Examinees.GetExamineesByExamId(id);
            var examineeDtos = _mapper.Map<List<ExamineeDto>>(examinees);
            return examineeDtos;
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
