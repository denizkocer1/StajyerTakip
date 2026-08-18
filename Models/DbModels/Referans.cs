namespace StajyerTakip.Models.DbModels
{
    public class Referans
    {
        public int ReferansId { get; set; }


        public string AdSoyad { get; set; } = null!;

        public string? Yakinlik { get; set; }

        public string? Unvan { get; set; }

        public string? Sirket { get; set; }

        public string? Telefon { get; set; }

        public string? Eposta { get; set; }


        public int StajyerId { get; set; }
        public Stajyer Stajyer { get; set; } = null!;
    }
}
