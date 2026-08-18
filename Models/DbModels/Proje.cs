namespace StajyerTakip.Models.DbModels
{
    public class Proje
    {
        public int ProjeId { get; set; }

        public string Baslik { get; set; } = null!;

        public string? Aciklama { get; set; }
        
        
        public int StajyerId { get; set; }
        public Stajyer Stajyer { get; set; } = null!;
    }
}
