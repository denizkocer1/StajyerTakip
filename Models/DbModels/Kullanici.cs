namespace StajyerTakip.Models.DbModels
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }

        

        public string Ad { get; set; } = null!;

        public string Soyad { get; set; } = null!;

        public string KullaniciAdi { get; set; } = null!;

        public string? Eposta { get; set; }

        public string? SifreHash { get; set; }

        

        public bool AktifMi { get; set; }

        public DateTime OlusturmaTarihi { get; set; }


        public int RolId { get; set; }
        public Rol Rol { get; set; } = null!;


        public int? DepartmanId { get; set; }
        public Departman? Departman { get; set; }


        public ICollection<Degerlendirme> Degerlendirmeler { get; set; }
            = new List<Degerlendirme>();

        public ICollection<Dosya> Dosyalar { get; set; }
            = new List<Dosya>();

        public ICollection<Stajyer> Stajyerler { get; set; }
            = new List<Stajyer>();

        public ICollection<Yorum> Yorumlar { get; set; }
            = new List<Yorum>();
    }
}
