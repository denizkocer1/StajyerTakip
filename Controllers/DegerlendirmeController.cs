using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Models.DtoModels;
using StajyerTakip.Services.InternalServices.Interfaces;

namespace StajyerTakip.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DegerlendirmeController : ControllerBase
    {
        private readonly IDegerlendirmeService _degerlendirmeService;

        public DegerlendirmeController(IDegerlendirmeService degerlendirmeService)
        {
            _degerlendirmeService = degerlendirmeService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Mentor")]
        public async Task<IActionResult> Create([FromBody] DegerlendirmeCreateDto dto)
        {
            var result = await _degerlendirmeService.CreateAsync(dto);

            return StatusCode((int)result.StatusCode, result);
        }
    }
}
