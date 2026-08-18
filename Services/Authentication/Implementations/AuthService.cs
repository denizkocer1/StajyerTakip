using StajyerTakip.DAL.Abstract.Base;
using StajyerTakip.Models.DtoModels;
using StajyerTakip.Services.Authentication.Interfaces;

namespace StajyerTakip.Services.Authentication.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(IUnitOfWork unitOfWork, IJwtTokenService jwtTokenService)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
        {
            var kullanici = await _unitOfWork.KullaniciRepository.GetByKullaniciAdiAsync(request.KullaniciAdi);

            if (kullanici is null || !kullanici.AktifMi)
            {
                return null;
            }

            if (string.IsNullOrEmpty(kullanici.SifreHash) ||
                !BCrypt.Net.BCrypt.Verify(request.Sifre, kullanici.SifreHash))
            {
                return null;
            }

            var token = _jwtTokenService.GenerateToken(kullanici);

            return new LoginResponseDto
            {
                Token = token,
                KullaniciId = kullanici.KullaniciId,
                KullaniciAdi = kullanici.KullaniciAdi,
                Ad = kullanici.Ad,
                Soyad = kullanici.Soyad,
                RolAdi = kullanici.Rol.RolAdi
            };
        }
    }
}
