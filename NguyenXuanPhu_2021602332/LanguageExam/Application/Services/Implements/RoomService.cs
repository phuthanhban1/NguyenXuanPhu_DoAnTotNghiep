using Application.Dtos.RoomDtos;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(RoomCreateDto roomDto)
        {
            var room = new Room
            {
                Name = roomDto.Name,
                Amount = roomDto.Amount
            };
            room.Id = Guid.NewGuid();
            await _unitOfWork.Rooms.AddAsync(room);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var room = await _unitOfWork.Rooms.GetByIdAsync(id);
            if (room == null)
            {
                throw new NotFoundException("Room not found");
            }
            await _unitOfWork.Rooms.DeleteAsync(room);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<RoomDto>> GetAllAsync()
        {
            var list = await _unitOfWork.Rooms.GetAllAsync();
            var result = _mapper.Map<List<RoomDto>>(list);
            return result;
        }

        public async Task<RoomDto> GetByIdAsync(Guid id)
        {
            var room = await _unitOfWork.Rooms.GetByIdAsync(id);
            if (room == null)
            {
                throw new NotFoundException("Room not found");
            }
            var result = _mapper.Map<RoomDto>(room);
            return result;
        }

        public async Task UpdateAsync(RoomDto roomDto)
        {
            var room = await _unitOfWork.Rooms.GetByIdAsync(roomDto.Id);
            if (room == null)
            {
                throw new NotFoundException("Room not found");
            }
            room.Name = roomDto.Name;
            room.Amount = roomDto.Amount;
            await _unitOfWork.Rooms.UpdateAsync(room);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
