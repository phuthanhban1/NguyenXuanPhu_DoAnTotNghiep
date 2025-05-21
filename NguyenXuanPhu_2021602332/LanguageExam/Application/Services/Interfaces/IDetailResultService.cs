using Application.Dtos.DetailResultDtos;
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
        Task AddAsync(DetailResultCreateDto detailResultCreateDto);
        Task UpdateAsync(DetailResultUpdateDto detailResultUpdateDto);
        Task DeleteAsync(Guid id);

        Task CreateDetailResult(Guid examId, Guid userId, List<Guid> listResults, string skillName);

        Task<Dictionary<string, int>> GetResultsByExamUser(Guid examId, Guid userId);
    }
}
