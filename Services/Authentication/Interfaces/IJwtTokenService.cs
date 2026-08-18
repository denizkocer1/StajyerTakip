using StajyerTakip.Models.DbModels;

namespace StajyerTakip.Services.Authentication.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(Kullanici kullanici);
    }
}
