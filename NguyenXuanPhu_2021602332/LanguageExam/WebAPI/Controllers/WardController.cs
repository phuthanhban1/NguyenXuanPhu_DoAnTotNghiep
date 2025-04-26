using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    {
        private readonly IWardService _wardService;
        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }
        [HttpGet("district/{districtId}")]
        public async Task<ActionResult> GetWardByDistrictId(int districtId)
        {
            var wards = await _wardService.GetWardByDistrictId(districtId);
            return Ok(wards);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var ward = await _wardService.GetByIdAsync(id);
            return Ok(ward);
        }
        [HttpPost]
        public async Task<ActionResult> Add(Ward ward)
        {
            await _wardService.AddAsync(ward);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update(Ward ward)
        {
            await _wardService.UpdateAsync(ward);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _wardService.DeleteAsync(id);
            return Ok();
        }
    }
}
