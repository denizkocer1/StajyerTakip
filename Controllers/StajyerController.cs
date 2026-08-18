using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Models.DtoModels;
using StajyerTakip.Services.InternalServices.Interfaces;

namespace StajyerTakip.Controllers
{
    [ApiController]
    [Route("api/stajyerler")]
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
            var stajyer = await _stajyerService.CreateAsync(dto);

            var response = new StajyerCreateResponseDto
            {
                StajyerId = stajyer.StajyerId,
                Ad = stajyer.Ad,
                Soyad = stajyer.Soyad,
                Durum = stajyer.Durum,
                OlusturmaTarihi = stajyer.OlusturmaTarihi
            };

            return Created($"/api/stajyerler/{stajyer.StajyerId}", response);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Mentor,Yonetici")]
        public async Task<IActionResult> GetAll()
        {
            var stajyerler = await _stajyerService.GetAllAsync();

            return Ok(stajyerler);
        }
    }
}
