namespace StajyerTakip.Models.DtoModels
{
    public class StajyerListResponseDto
    {
        public int StajyerId { get; set; }

        public string Ad { get; set; } = null!;

        public string Soyad { get; set; } = null!;

        public string? Eposta { get; set; }

        public string? Universite { get; set; }

        public string? Bolum { get; set; }

        public DateOnly? StajBaslangic { get; set; }

        public DateOnly? StajBitis { get; set; }

        public string Durum { get; set; } = null!;

        public bool AktifMi { get; set; }

        public string? DepartmanAdi { get; set; }

        public string? MentorAdSoyad { get; set; }
    }
}
