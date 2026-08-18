namespace StajyerTakip.Models.DbModels
{
    public class DosyaKategori
    {
        public int DosyaKategoriId { get; set; }

        public string KategoriAdi { get; set; } = null!;

        public ICollection<Dosya> Dosyalar { get; set; }
            = new List<Dosya>();
    }
}
