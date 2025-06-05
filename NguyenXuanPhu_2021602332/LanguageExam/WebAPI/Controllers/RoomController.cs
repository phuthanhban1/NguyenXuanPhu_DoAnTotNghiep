using Application.Dtos.RoomDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _roomService.GetAllAsync();
            if (list == null)
            {
                return BadRequest("Room is null");
            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        new public async Task<IActionResult> GetById(Guid id)
        {
            var room = await _roomService.GetByIdAsync(id);
            if (room == null)
            {
                return BadRequest("Room is null");
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomCreateDto roomCreateDto)
        {
            if (roomCreateDto == null)
            {
                return BadRequest("Room is null");
            }
            await _roomService.AddAsync(roomCreateDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(RoomDto roomDto)
        {
            if (roomDto == null)
            {
                return BadRequest("Room is null");
            }
            await _roomService.UpdateAsync(roomDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Room is null");
            }
            await _roomService.DeleteAsync(id);
            return Ok();
        }
    }
}
