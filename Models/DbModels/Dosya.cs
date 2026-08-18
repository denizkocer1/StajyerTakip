namespace StajyerTakip.Models.DbModels
{
    public class Dosya
    {
        public int DosyaId { get; set; }

        public string DosyaAdi { get; set; } = null!;

        public string DosyaYolu { get; set; } = null!;

        public string? Uzanti { get; set; }

        public int? BoyutKb { get; set; }

        public DateTime YuklemeTarihi { get; set; }


        public int DosyaKategoriId { get; set; }
        public DosyaKategori DosyaKategori { get; set; } = null!;


        public int StajyerId { get; set; }
        public Stajyer Stajyer { get; set; } = null!;


        public int? YukleyenId { get; set; }
        public Kullanici? Yukleyen { get; set; }
    }
}
