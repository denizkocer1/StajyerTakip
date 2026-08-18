namespace StajyerTakip.Models.DbModels
{
    public class StajyerBeceri
    {
        
        public short? Seviye { get; set; }
        
        
        public int StajyerId { get; set; }
        public Stajyer Stajyer { get; set; } = null!;
        

        public int BeceriId { get; set; }
        public Beceri Beceri { get; set; } = null!;
    }
}
