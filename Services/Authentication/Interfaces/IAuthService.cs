using StajyerTakip.Models.DtoModels;

namespace StajyerTakip.Services.Authentication.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginRequestDto request); //dönüş null ise kullanıcı adı/şifre hatalı veya kullanıcı pasif demektir.
    }
}
