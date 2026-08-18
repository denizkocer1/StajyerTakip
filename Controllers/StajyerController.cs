using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Models.DtoModels;
using StajyerTakip.Services.InternalServices.Interfaces;

namespace StajyerTakip.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StajyerController : ControllerBase
    {
        private readonly IStajyerService _stajyerService;

        public StajyerController(IStajyerService stajyerService)
        {
            _stajyerService = stajyerService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Mentor")]
        public async Task<IActionResult> Create([FromBody] StajyerCreateDto dto)
        {
            var result = await _stajyerService.CreateAsync(dto);

            return StatusCode((int)result.StatusCode, result);
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize(Roles = "Admin,Mentor,Yonetici")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _stajyerService.GetAllAsync();

            return StatusCode((int)result.StatusCode, result);
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _stajyerService.GetStajyer(id);

            return StatusCode((int)result.StatusCode, result);
        }
    }
}
