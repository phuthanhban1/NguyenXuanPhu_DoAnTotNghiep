using Application.Dtos.DetailResultDtos;
using Application.Dtos.ExamDtos;
using Application.Dtos.ExamineeDtos;
using Application.Dtos.RoomDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IExamineeService
    {
        Task AddAsync(Guid examId, Guid userId);
        Task<ExamineeDto> GetExaminee(Guid examId, Guid userId);
        Task<List<ExamineeDto>> GetByExamIdAsync(Guid id);
        //Task<List<ExamineeDto>> GetAllAsync();
        Task<List<ExamineeDto>> GetUserByExamId(Guid id);
        Task CreateExamNumber(Guid id);
        Task CreateRoom(Guid examId, List<RoomExamDto> list);
        Task<Dictionary<Guid, RoomExamGetDto>> CountRoom(Guid examId);
        Task<List<ExamineeScheduleDto>> GetSchedule(Guid userId);
        Task<DetailResultDto> GetResultsByExamUser(ExamineeScoreDto examineeScoreDto);

        Task Test();
    }
}
