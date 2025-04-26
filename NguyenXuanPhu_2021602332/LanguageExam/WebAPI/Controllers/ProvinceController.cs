using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var provinces = await _provinceService.GetAllAsync();
            return Ok(provinces);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var province = await _provinceService.GetByIdAsync(id);
            return Ok(province);
        }
        [HttpPost]
        public async Task<ActionResult> Add(Province province)
        {
            await _provinceService.AddAsync(province);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update(Province province)
        {
            await _provinceService.UpdateAsync(province);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _provinceService.DeleteAsync(id);
            return Ok();
        }
    }
}
