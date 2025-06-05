using Application.Dtos.DetailResultDtos;
using Application.Dtos.ExamineeDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IDetailResultService
    {
        
        Task<List<DetailResultDto>> GetAllResult(Guid examId);
        Task CreateDetailResult(Guid examId, Guid userId, List<Guid> listResults, string skillName);
        
        
    }
}
