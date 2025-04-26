using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class ProvinceService : IProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProvinceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task AddAsync(Province province)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Province>> GetAllAsync()
        {
            var provinces = await _unitOfWork.Provinces.GetAllAsync();
            return provinces;
        }
        public Task<Province> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(Province province)
        {
            throw new NotImplementedException();
        }
    }
    
}
