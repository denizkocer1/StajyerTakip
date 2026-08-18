using StajyerTakip.DAL.Abstract.Base;
using StajyerTakip.Models.DbModels;
using StajyerTakip.Models.DtoModels;
using StajyerTakip.Results;
using StajyerTakip.Services.InternalServices.Interfaces;
using System.Net;


namespace StajyerTakip.Services.InternalServices.Implementations
{
    public class StajyerService : IStajyerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StajyerService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async Task<DataResult<List<StajyerListResponseDto>>> GetAllAsync()
        {
            var stajyerler = await _unitOfWork.StajyerRepository.GetAllWithRelationsAsync();

            var stajyerListesi = stajyerler.Select(s => new StajyerListResponseDto
            {
                StajyerId = s.StajyerId,
                Ad = s.Ad,
                Soyad = s.Soyad,
                Eposta = s.Eposta,
                Universite = s.Universite,
                Bolum = s.Bolum,
                StajBaslangic = s.StajBaslangic,
                StajBitis = s.StajBitis,
                Durum = s.Durum,
                AktifMi = s.AktifMi,
                DepartmanAdi = s.Departman?.DepartmanAdi,
                MentorAdSoyad = s.Mentor is null ? null : $"{s.Mentor.Ad} {s.Mentor.Soyad}"
            }).ToList();

            return DataResult<List<StajyerListResponseDto>>
                .SuccessDataResult(
                    stajyerListesi,
                    "Stajyerler başarıyla getirildi."
                );
        }

        public async Task<DataResult<Stajyer>> GetStajyer(int id)
        {
            var entity = await _unitOfWork.StajyerRepository.GetByIdAsync(id);

            if (entity is null)
            {
                return DataResult<Stajyer>.ErrorDataResult(
                    "Stajyer bulunamadı.",
                    HttpStatusCode.NotFound
                );
            }

            return DataResult<Stajyer>.SuccessDataResult(
                entity,
                "Stajyer başarıyla getirildi."
            );
        }


        public async Task<DataResult<StajyerCreateResponseDto>> CreateAsync(StajyerCreateDto dto)
        {
            var stajyer = new Stajyer
            {
                Ad = dto.Ad,
                Soyad = dto.Soyad,
                DogumTarihi = dto.DogumTarihi,
                Cinsiyet = dto.Cinsiyet,
                Telefon = dto.Telefon,
                Eposta = dto.Eposta,
                YasadigiSehir = dto.YasadigiSehir,
                DaimiAdres = dto.DaimiAdres,
                StajDonemiKaldigiYer = dto.StajDonemiKaldigiYer,
                FotografYolu = dto.FotografYolu,
                Universite = dto.Universite,
                Bolum = dto.Bolum,
                Sinif = dto.Sinif,
                GenelOrtalama = dto.GenelOrtalama,
                KacinciStaj = dto.KacinciStaj,
                StajBaslangic = dto.StajBaslangic,
                StajBitis = dto.StajBitis,
                StajKonusu = dto.StajKonusu,
                ReferanslaMiGeldi = dto.ReferanslaMiGeldi,
                TekrarCalisilirMi = dto.TekrarCalisilirMi,
                DepartmanId = dto.DepartmanId,
                MentorId = dto.MentorId,
                Durum = "Aktif", //yeni eklenen stajyer varsayılan olarak aktif durumda başlar.
                AktifMi = true,
                OlusturmaTarihi = DateTime.UtcNow
            };

            await _unitOfWork.StajyerRepository.AddAsync(stajyer);
            await _unitOfWork.CommitAsync();


            var response = new StajyerCreateResponseDto
            {
                StajyerId = stajyer.StajyerId,
                Ad = stajyer.Ad,
                Soyad = stajyer.Soyad,
                Durum = stajyer.Durum,
                OlusturmaTarihi = stajyer.OlusturmaTarihi
            };


            return DataResult<StajyerCreateResponseDto>
            .SuccessDataResult(
                response,
                "Stajyer başarıyla eklendi."
             );
        }
    }
}
