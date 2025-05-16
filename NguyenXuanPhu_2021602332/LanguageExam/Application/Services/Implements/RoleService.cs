using Application.Dtos.RoleDtos;
using Application.Services.Interfaces;
using AutoMapper;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<RoleDto>> GetRoles()
        {
            var list = await _unitOfWork.Roles.GetUserRole();
            var listDto = _mapper.Map<List<RoleDto>>(list);
            return listDto;
        }
    }
}
