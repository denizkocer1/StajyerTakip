namespace StajyerTakip.Models.DbModels
{
    public class Link
    {
        public int LinkId { get; set; }

        public string LinkTuru { get; set; } = null!;

        public string Url { get; set; } = null!;
        
        
        public int StajyerId { get; set; }
        public Stajyer Stajyer { get; set; } = null!;
    }
}
