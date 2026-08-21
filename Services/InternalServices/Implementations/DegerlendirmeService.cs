using StajyerTakip.DAL.Abstract.Base;
using StajyerTakip.Models.DbModels;
using StajyerTakip.Models.DtoModels;
using StajyerTakip.Results;
using StajyerTakip.Services.InternalServices.Interfaces;
using System.Net;
using System.Security.Claims;
using StajyerTakip.Models.DbModels.Constants;

namespace StajyerTakip.Services.InternalServices.Implementations
{
    public class DegerlendirmeService : IDegerlendirmeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DegerlendirmeService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork; //Veritabanı işlemlerine ulaşmak için de constructor üzerinden IUnitOfWork alıyorum
            _httpContextAccessor = httpContextAccessor;


        }

        private int? CurrentUserId
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext?
                    .User
                    .FindFirst(ClaimTypes.NameIdentifier)?
                    .Value;

                if (int.TryParse(userId, out var id))
                {
                    return id;
                }

                return null;
            }
        }

        public async Task<DataResult<DegerlendirmeCreateResponseDto>> CreateAsync(
            DegerlendirmeCreateDto dto)
        {
            var stajyer = await _unitOfWork.StajyerRepository.GetByIdAsync(dto.StajyerId);

            if (stajyer is null)
            {
                return DataResult<DegerlendirmeCreateResponseDto>.ErrorDataResult(
                    "Stajyer bulunamadı.",
                    HttpStatusCode.NotFound
                );
            }

            var kriter = await _unitOfWork.DegerlendirmeKriteriRepository.GetByIdAsync(dto.KriterId);

            if (kriter is null)
            {
                return DataResult<DegerlendirmeCreateResponseDto>.ErrorDataResult(
                    "Değerlendirme kriteri bulunamadı.",
                    HttpStatusCode.NotFound
                );
            }


            if (dto.Puan < 0 || dto.Puan > 100)
            {
                return DataResult<DegerlendirmeCreateResponseDto>.ErrorDataResult(
                    "Puan 0 ile 100 arasında olmalıdır.",
                    HttpStatusCode.BadRequest
                );
            }

            if (CurrentUserId is null)
            {
                return DataResult<DegerlendirmeCreateResponseDto>.ErrorDataResult(
                    "Giriş yapan kullanıcı bilgisi bulunamadı.",
                    HttpStatusCode.Unauthorized
                );
            }

            var degerlendirme = new Degerlendirme
            {
                StajyerId = dto.StajyerId,
                KriterId = dto.KriterId,
                Puan = dto.Puan,
                DegerlendirenId = CurrentUserId.Value,
                Tarih = DateTime.UtcNow
            };

            
            await _unitOfWork.DegerlendirmeRepository.AddAsync(degerlendirme);

            await _unitOfWork.CommitAsync();

            var auditLog = new AuditLog
            {
                Created = DateTime.UtcNow,
                KullaniciId = CurrentUserId,
                TableName = nameof(Degerlendirme),
                RecordId = degerlendirme.DegerlendirmeId,
                LogTypeId = (int)Enums.AuditLogType.Create,
                Description = "Stajyer için değerlendirme oluşturuldu."
            };

            await _unitOfWork.AuditLogRepository.AddAsync(auditLog);
            await _unitOfWork.CommitAsync();

            var response = new DegerlendirmeCreateResponseDto
            {
                DegerlendirmeId = degerlendirme.DegerlendirmeId,
                StajyerId = degerlendirme.StajyerId,
                KriterId = degerlendirme.KriterId,
                Puan = degerlendirme.Puan,
                DegerlendirenId = degerlendirme.DegerlendirenId,
                Tarih = degerlendirme.Tarih
            };

            return DataResult<DegerlendirmeCreateResponseDto>
                .SuccessDataResult(
                    response,
                    "Değerlendirme başarıyla eklendi."
                );

        }




    }
}
