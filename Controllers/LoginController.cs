using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Models.DtoModels;
using StajyerTakip.Results;
using StajyerTakip.Services.Authentication.Interfaces;

namespace StajyerTakip.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var result = await _authService.LoginAsync(request);

            return StatusCode((int)result.StatusCode, result);
        }
    }




[Route("api/test")]
    public class TestController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("JWT çalýþýyor.");
        }
    }

}
