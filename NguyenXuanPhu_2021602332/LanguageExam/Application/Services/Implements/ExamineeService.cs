using Application.Dtos.DetailResultDtos;
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
                IsExamTaken = false
            };
            await _unitOfWork.Examinees.AddAsync(examinee);
            await _unitOfWork.SaveChangeAsync();
        }
        public async Task<Dictionary<Guid, RoomExamGetDto>> CountRoom(Guid examId)
        {
            var rooms = new Dictionary<Guid, RoomExamGetDto>();
            var listExaminees = await _unitOfWork.Examinees.GetExamineesByExamId(examId);
            if (listExaminees[0].RoomId == null)
            {
                return null;
            }
            foreach (var item in listExaminees)
            {
                var roomId = (Guid)item.RoomId;
                if(rooms.ContainsKey(roomId))
                {
                    rooms[roomId].ExamineeAmount += 1;
                } else
                {
                    rooms[roomId] = new RoomExamGetDto
                    {
                        Id = roomId,
                        Name = item.Room.Name,
                        Amount = item.Room.Amount,
                        ExamineeAmount = 1
                    };
                }
            }
            return rooms;
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

        public async Task<List<ExamineeScheduleDto>> GetSchedule(Guid userId)
        {
            var listExaminee = await _unitOfWork.Examinees.GetExamineesByUserId(userId);
            var listExamineeSchedules = new List<ExamineeScheduleDto>();
            foreach (var examinee in listExaminee)
            {
                var exam = await _unitOfWork.Exams.GetByIdAsync(examinee.ExamId);
                var examSchedule = new ExamineeScheduleDto
                {
                    Id = exam.Id,
                    Name = exam.Name,
                    StartDate = exam.StartDate,
                    Password = exam.Password
                };
                if(examinee.Room != null)
                {
                    examSchedule.RoomName = examinee.Room.Name;
                }
                if(examinee.ExamineeNumber != null)
                {
                    examSchedule.ExamineeNumber = examinee.ExamineeNumber;
                }
                listExamineeSchedules.Add(examSchedule);
            }
            return listExamineeSchedules;
        }

        public async Task<List<ExamineeDto>> GetUserByExamId(Guid id)
        {
            var examinees = await _unitOfWork.Examinees.GetExamineesByExamId(id);
            var examineeDtos = _mapper.Map<List<ExamineeDto>>(examinees);
            return examineeDtos;
        }

        public async Task<DetailResultDto> GetResultsByExamUser(ExamineeScoreDto examineeScoreDto)
        {
            var examinee = await _unitOfWork.Examinees.GetExamineeByNumber(examineeScoreDto.ExamId, examineeScoreDto.ExamineeNumber);
            if(examinee == null)
            {
                throw new NotFoundException($"Không tìm thấy thí sinh có mã {examineeScoreDto.ExamineeNumber}");
            }
            if (examinee.User.DateOfBirth != examineeScoreDto.DateOfBirth)
            {
                throw new BadRequestException("Thí sinh có ngày sinh không tồn tại");
            }
            var examineeDto = _mapper.Map<DetailResultDto>(examinee);
            return examineeDto;
        }

        public async Task Test()
        {
            for(int i = 1; i <= 50; i++)
            {
                var email = $"thisinh{i}@gmail.com";
                var user = await _unitOfWork.Users.GetUserByEmail(email, Guid.Parse("A0E4F1D5-3C8B-4F2A-8E6C-7D9B5E0A2F1D"));
                var examinee = new Examinee
                {
                    ExamId = Guid.Parse("D0D95456-6423-48C6-AE88-BC18EFD2D3C6"),
                    UserId = user.Id,
                    IsExamTaken = true,
                    ReadingScore = new Random().Next(0, 101),
                    ListeningScore = new Random().Next(0, 101),
                };
                await _unitOfWork.Examinees.AddAsync(examinee);
            }
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
