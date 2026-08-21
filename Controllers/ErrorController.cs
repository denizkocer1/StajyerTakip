using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace StajyerTakip.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (context is not null)
            {
                Log.Error(
                    context.Error,
                    "Beklenmeyen bir sistem hatası oluştu."
                );
            }

            return Problem(
                title: "Bir hata oluştu",
                detail: "Beklenmeyen bir sistem hatası oluştu.",
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }
}