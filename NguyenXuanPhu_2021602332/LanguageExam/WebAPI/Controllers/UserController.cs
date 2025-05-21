using Application.Dtos.UserDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }
        //[HttpPost]
        //public async Task<ActionResult> Add([FromForm] UserCreateDto userCreateDto)
        //{
        //    await _userService.AddAsync(userCreateDto);
        //    return Ok();
        //}

        [HttpPost]
        public async Task<ActionResult> Add(UserCreateDto userCreateDto)
        {
            await _userService.AddAsync(userCreateDto);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            userUpdateDto.Id = Guid.Parse(sid);
            await _userService.UpdateAsync(userUpdateDto);
            return Ok();
        }

        [HttpPut("password")]
        public async Task<ActionResult> UpdatePassword(UserPassworDto userPasswordDto)
        {
            await _userService.UpdatePassword(userPasswordDto);
            return Ok();
        }

        [Authorize(Roles = "quản trị viên")]
        [HttpPut("update-role")]
        public async Task<ActionResult> UpdateRole(UserRoleUpdateDto userRoleUpdateDto)
        {
            await _userService.UpdateRole(userRoleUpdateDto);
            return Ok();
        }

        [HttpGet("check-email")]
        public async Task<ActionResult> CheckEmail(string email)
        {
            var check = await _userService.CheckUserByEmail(email);
            return Ok(new { exists = check });
        }

        [HttpGet("test")]
        public async Task<ActionResult> Test()
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }

            return Ok(new { Sid = sid });
        }

        [HttpGet("authorize")]
        public async Task<ActionResult> CheckAuthorize()
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            
            return Ok();
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginDto userLoginDto)
        {
            var token = await _userService.Login(userLoginDto);
            if (token == null)
            {
                return Unauthorized("Email và mật khẩu không hợp lệ");
            }
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, // Chỉ server đọc được
                Secure = true,   // Chỉ gửi qua HTTPS (nên dùng ở môi trường thật)
                SameSite = SameSiteMode.None,  // khi muon cross-site
                Expires = DateTime.UtcNow.AddHours(2) // Thời gian sống
            };

            Response.Cookies.Append("token", token, cookieOptions);

            return Ok(token);
        }
        [HttpGet("role")]
        public async Task<ActionResult> GetRole()
        {
            return Ok(HttpContext.User.FindFirst(ClaimTypes.Role)?.Value);
        }

        //[Authorize(Roles = "quản trị viên")]
        [HttpGet("account")]
        public async Task<ActionResult> GetAccounts()
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            var users = await _userService.GetAccounts(Guid.Parse(sid));
            return Ok(users);
        }

        [HttpGet("account-by-role/{role}")]
        public async Task<ActionResult> GetByRole(int role)
        {
            var users = await _userService.GetUserByRole(role);
            return Ok(users);
        }

        [HttpGet("user-id")]
        public async Task<ActionResult> GetUserId()
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            return Ok(sid);
        }

        [HttpGet("user")]
        public async Task<ActionResult> GetInforUser()
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            var user = await _userService.GetUser(Guid.Parse(sid));
            return Ok(user);
        }

        [HttpGet("check-infor")]
        public async Task<IActionResult> CheckFullInfor()
        {
            var sid = HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            if (sid == null)
            {
                return Unauthorized();
            }
            var check = await _userService.CheckFullInfor(Guid.Parse(sid));
            return Ok(check);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("jwt_token");
            return Ok();
        }
    }
}
