using System.Net;
using StajyerTakip.DAL.Abstract.Base;
using StajyerTakip.Models.DtoModels;
using StajyerTakip.Results;
using StajyerTakip.Services.Authentication.Interfaces;
using StajyerTakip.Models.DbModels;
using StajyerTakip.Models.DbModels.Constants;


namespace StajyerTakip.Services.Authentication.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(
            IUnitOfWork unitOfWork,
            IJwtTokenService jwtTokenService)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<DataResult<LoginResponseDto>> LoginAsync(LoginRequestDto request)
        {
            var kullanici = await _unitOfWork.KullaniciRepository
                .GetByKullaniciAdiAsync(request.KullaniciAdi);

            if (kullanici is null || !kullanici.AktifMi)
            {
                await _unitOfWork.AuditLogRepository.AddAsync(new AuditLog
                {
                    Created = DateTime.UtcNow,
                    KullaniciId = kullanici?.KullaniciId,
                    TableName = nameof(Kullanici),
                    RecordId = kullanici?.KullaniciId,
                    LogTypeId = (int)Enums.AuditLogType.LoginFailed,
                    Description = $"{request.KullaniciAdi} kullanıcı adı ile giriş başarısız."
                });

                await _unitOfWork.CommitAsync();

                return DataResult<LoginResponseDto>.ErrorDataResult(
                    "Kullanıcı adı veya şifre hatalı.",
                    HttpStatusCode.Unauthorized
                );
            }

            if (string.IsNullOrEmpty(kullanici.SifreHash) ||
                !BCrypt.Net.BCrypt.Verify(request.Sifre, kullanici.SifreHash))
            {
                await _unitOfWork.AuditLogRepository.AddAsync(new AuditLog
                {
                    Created = DateTime.UtcNow,
                    KullaniciId = kullanici.KullaniciId,
                    TableName = nameof(Kullanici),
                    RecordId = kullanici.KullaniciId,
                    LogTypeId = (int)Enums.AuditLogType.LoginFailed,
                    Description = $"{request.KullaniciAdi} kullanıcı adı ile giriş başarısız."
                });

                await _unitOfWork.CommitAsync();

                return DataResult<LoginResponseDto>.ErrorDataResult(
                    "Kullanıcı adı veya şifre hatalı.",
                    HttpStatusCode.Unauthorized
                );
            }

            var token = _jwtTokenService.GenerateToken(kullanici);

            var response = new LoginResponseDto
            {
                Token = token,
                KullaniciId = kullanici.KullaniciId,
                KullaniciAdi = kullanici.KullaniciAdi,
                Ad = kullanici.Ad,
                Soyad = kullanici.Soyad,
                RolAdi = kullanici.Rol.RolAdi
            };

            await _unitOfWork.AuditLogRepository.AddAsync(new AuditLog
            {
                Created = DateTime.UtcNow,
                KullaniciId = kullanici.KullaniciId,
                TableName = nameof(Kullanici),
                RecordId = kullanici.KullaniciId,
                LogTypeId = (int)Enums.AuditLogType.Login,
                Description = $"{kullanici.KullaniciAdi} kullanıcısı giriş yaptı."
            });

            await _unitOfWork.CommitAsync();

            return DataResult<LoginResponseDto>.SuccessDataResult(
                response,
                "Giriş başarılı."
            );
        }
    }
}