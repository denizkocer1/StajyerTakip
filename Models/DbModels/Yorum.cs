namespace StajyerTakip.Models.DbModels
{
    public class Yorum
    {
        public int YorumId { get; set; }

        public string YorumMetni { get; set; } = null!;

        public DateTime Tarih { get; set; }
        
        
        public int StajyerId { get; set; }
        public Stajyer Stajyer { get; set; } = null!;
        
        
        public int YazanId { get; set; }
        public Kullanici Yazan { get; set; } = null!;
    }
}
