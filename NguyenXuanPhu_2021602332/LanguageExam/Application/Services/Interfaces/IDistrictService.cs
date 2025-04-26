using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IDistrictService
    {
        Task AddAsync(District district);
        Task UpdateAsync(District district);
        Task DeleteAsync(int id);
        Task<District> GetByIdAsync(int id);
        IEnumerable<District> GetAllAsync();

        Task<List<District>> GetDistrictByProviceId(int provinceId);
    }
}
