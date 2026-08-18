namespace StajyerTakip.Models.DbModels
{
    public class Modul
    {
        public int ModulId { get; set; }

        public int SiraNo { get; set; }

        public string ModulAdi { get; set; } = null!;

        public ICollection<RolModulYetki> RolModulYetkileri { get; set; }
            = new List<RolModulYetki>();
    }
}
