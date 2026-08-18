namespace StajyerTakip.Models.DtoModels
{
    public class StajyerCreateDto
    {
        public string Ad { get; set; } = null!;

        public string Soyad { get; set; } = null!;

        public DateOnly? DogumTarihi { get; set; }

        public string? Cinsiyet { get; set; }

        public string? Telefon { get; set; }

        public string? Eposta { get; set; }

        public string? YasadigiSehir { get; set; }

        public string? DaimiAdres { get; set; }

        public string? StajDonemiKaldigiYer { get; set; }

        public string? FotografYolu { get; set; }

        public string? Universite { get; set; }

        public string? Bolum { get; set; }

        public string? Sinif { get; set; }

        public decimal? GenelOrtalama { get; set; }

        public short? KacinciStaj { get; set; }

        public DateOnly? StajBaslangic { get; set; }

        public DateOnly? StajBitis { get; set; }

        public string? StajKonusu { get; set; }

        public bool? ReferanslaMiGeldi { get; set; }

        public bool? TekrarCalisilirMi { get; set; }

        public int? DepartmanId { get; set; }

        public int? MentorId { get; set; }
    }
}
