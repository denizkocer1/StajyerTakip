namespace StajyerTakip.Models.DbModels
{
    public class Stajyer
    {
        public int StajyerId { get; set; }  //PK

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

        public string Durum { get; set; } = null!;

        public bool AktifMi { get; set; }

        public DateTime OlusturmaTarihi { get; set; }

        public DateTime? GuncellemeTarihi { get; set; }
        

        public int? DepartmanId { get; set; }
        public Departman? Departman { get; set; }
        

        public int? MentorId { get; set; }
        public Kullanici? Mentor { get; set; }


        public ICollection<Degerlendirme> Degerlendirmeler { get; set; }
            = new List<Degerlendirme>();

        public ICollection<Dosya> Dosyalar { get; set; }
            = new List<Dosya>();

        public ICollection<Link> Linkler { get; set; }
            = new List<Link>();

        public ICollection<Proje> Projeler { get; set; }
            = new List<Proje>();

        public ICollection<Referans> Referanslar { get; set; }
            = new List<Referans>();

        public ICollection<StajyerBeceri> StajyerBecerileri { get; set; }
            = new List<StajyerBeceri>();

        public ICollection<Yorum> Yorumlar { get; set; }
            = new List<Yorum>();
    }
}

