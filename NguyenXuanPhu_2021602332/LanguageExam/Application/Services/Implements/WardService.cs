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
    public class WardService : IWardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public WardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddAsync(Ward ward)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Answer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ward>> GetWardByDistrictId(int districtId)
        {
            var wards = await _unitOfWork.Wards.FindAsync(w => w.DistrictId == districtId);
            return wards.ToList();
        }

        public Task UpdateAsync(Ward ward)
        {
            throw new NotImplementedException();
        }

       

        Task<IEnumerable<Ward>> IWardService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Ward> IWardService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
  
}
