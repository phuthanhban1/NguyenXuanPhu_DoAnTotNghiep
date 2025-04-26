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
    public class DistrictService : IDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DistrictService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task AddAsync(District district)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<District> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<District> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<District>> GetDistrictByProviceId(int provinceId)
        {
            var districts = await _unitOfWork.Districts.FindAsync(d => d.ProvinceId == provinceId);
            return (List<District>)districts;
        }

        public Task UpdateAsync(District district)
        {
            throw new NotImplementedException();
        }

    }
}
