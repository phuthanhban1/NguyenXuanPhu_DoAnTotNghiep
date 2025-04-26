using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IProvinceService
    {
        Task AddAsync(Province province);
        Task UpdateAsync(Province province);
        Task DeleteAsync(Guid id);
        Task<Province> GetByIdAsync(Guid id);
        Task<IEnumerable<Province>> GetAllAsync();
    }
}
