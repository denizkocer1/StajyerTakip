using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Models.DtoModels;
using StajyerTakip.Services.Authentication.Interfaces;
using Microsoft.AspNetCore.Authorization;

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

            if (result is null)
            {
                return Unauthorized();
            }

            return Ok(result);
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
