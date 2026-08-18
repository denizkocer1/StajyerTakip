namespace StajyerTakip.Models.DbModels
{
    public class BeceriKategori
    {
        public int BeceriKategoriId { get; set; }

        public string KategoriAdi { get; set; } = null!;

        public ICollection<Beceri> Beceriler { get; set; } = new List<Beceri>();
    }

}



