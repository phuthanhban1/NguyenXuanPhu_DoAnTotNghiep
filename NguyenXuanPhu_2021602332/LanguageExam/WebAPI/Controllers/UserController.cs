using Application.Dtos.UserDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(UserCreateDto userCreateDto)
        {
            await _userService.AddAsync(userCreateDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(UserUpdateDto userUpdateDto)
        {
            await _userService.UpdateAsync(userUpdateDto);
            return Ok();
        }

        [HttpPut("password")]
        public async Task<ActionResult> UpdatePassword(UserPassworDto userPassworDto)
        {
            await _userService.UpdatePassword(userPassworDto);
            return Ok();
        }
        [HttpPut("role")]
        public async Task<ActionResult> UpdateRole(UserRoleUpdateDto userRoleUpdateDto)
        {
            await _userService.UpdateRole(userRoleUpdateDto);
            return Ok();
        }
    }
}
