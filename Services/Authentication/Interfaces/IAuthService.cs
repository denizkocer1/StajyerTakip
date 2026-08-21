using StajyerTakip.Models.DtoModels;
using StajyerTakip.Results;

namespace StajyerTakip.Services.Authentication.Interfaces
{
    public interface IAuthService
    {
        Task<DataResult<LoginResponseDto>> LoginAsync(LoginRequestDto request);
    }
}