using StajyerTakip.DAL.Abstract.Base;
using StajyerTakip.Models.DbModels;
using StajyerTakip.Models.DtoModels;
using StajyerTakip.Services.InternalServices.Interfaces;


namespace StajyerTakip.Services.InternalServices.Implementations
{
    public class StajyerService : IStajyerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StajyerService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async Task<List<StajyerListResponseDto>> GetAllAsync()
        {
            var stajyerler = await _unitOfWork.StajyerRepository.GetAllWithRelationsAsync();

            return stajyerler.Select(s => new StajyerListResponseDto
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
        }

        public async Task<Stajyer> CreateAsync(StajyerCreateDto dto)
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

            return stajyer;
        }
    }
}
