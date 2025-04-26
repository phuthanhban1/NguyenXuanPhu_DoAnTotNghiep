using Application.Dtos.AnswerDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IWardService
    {
        Task AddAsync(Ward ward);
        Task UpdateAsync(Ward ward);
        Task DeleteAsync(int id);
        Task<Ward> GetByIdAsync(int id);
        Task<IEnumerable<Ward>> GetAllAsync();

        Task<List<Ward>> GetWardByDistrictId(int districtId);
    }
}
