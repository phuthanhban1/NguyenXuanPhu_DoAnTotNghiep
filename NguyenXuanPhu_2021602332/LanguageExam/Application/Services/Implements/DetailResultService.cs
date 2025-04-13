using Application.Dtos.DetailResultDtos;
using Application.Services.Interfaces;
using AutoMapper;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class DetailResultService : IDetailResultService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DetailResultService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task AddAsync(DetailResultCreateDto detailResultCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DetailResultUpdateDto detailResultUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
