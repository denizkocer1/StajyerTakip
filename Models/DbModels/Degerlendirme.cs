namespace StajyerTakip.Models.DbModels
{
    /// <summary>
    /// yapılan değerlendirmeler
    /// </summary>
    public class Degerlendirme
    {
        /// <summary>
        /// primarykey
        /// </summary>
        public int DegerlendirmeId { get; set; }


    

        public short Puan { get; set; }

       

        public DateTime Tarih { get; set; }

        /// <summary>
        /// değerlendiren kullanıcının id'si(foreignkey)
        /// </summary>
        public int DegerlendirenId { get; set; }
        public Kullanici Degerlendiren { get; set; } = null!;
    

        public int KriterId { get; set; }
        public DegerlendirmeKriteri Kriter { get; set; } = null!;

        
        public int StajyerId { get; set; }
        public Stajyer Stajyer { get; set; } = null!;
    }
}
