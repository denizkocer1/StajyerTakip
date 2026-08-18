

namespace StajyerTakip.Models.DbModels
{
    public class Beceri
    {
        public int BeceriId { get; set; } //primary key

        public string BeceriAdi { get; set; } = null!;
        

        public int BeceriKategoriId { get; set; } //foreign key

        public BeceriKategori BeceriKategori { get; set; } = null!;


        public ICollection<StajyerBeceri> StajyerBecerileri { get; set; }
            = new List<StajyerBeceri>();
    }
}
