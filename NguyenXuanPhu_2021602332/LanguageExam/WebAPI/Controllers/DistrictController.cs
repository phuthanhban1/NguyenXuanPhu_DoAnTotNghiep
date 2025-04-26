using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;
        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet("province/{provinceId}")]
        public async Task<ActionResult> GetDistrictByProvinceId(int provinceId)
        {
            var districts = await _districtService.GetDistrictByProviceId(provinceId);
            return Ok(districts);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var district = await _districtService.GetByIdAsync(id);
            return Ok(district);
        }
        [HttpPost]
        public async Task<ActionResult> Add(District district)
        {
            await _districtService.AddAsync(district);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update(District district)
        {
            await _districtService.UpdateAsync(district);
            return Ok();
        }
    }
}
