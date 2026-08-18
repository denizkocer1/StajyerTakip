namespace StajyerTakip.Models.DbModels
{
    public class Departman
    {
        public int DepartmanId { get; set; }

        public string DepartmanAdi { get; set; } = null!;

        public ICollection<Kullanici> Kullanicilar { get; set; }
            = new List<Kullanici>();

        public ICollection<Stajyer> Stajyerler { get; set; }
            = new List<Stajyer>();
    }
}
