namespace StajyerTakip.Models.DbModels
{
    public class DegerlendirmeKriteri
    {
        public int KriterId { get; set; } //primarykey

        public string KriterAdi { get; set; } = null!;

        public string? Aciklama { get; set; }

        public bool AktifMi { get; set; }

        public ICollection<Degerlendirme> Degerlendirmeler { get; set; }
            = new List<Degerlendirme>();
    }
}
