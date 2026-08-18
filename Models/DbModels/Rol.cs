namespace StajyerTakip.Models.DbModels
{
    public class Rol
    {
        public int RolId { get; set; } //PK

        public string RolAdi { get; set; } = null!;

        public ICollection<Kullanici> Kullanicilar { get; set; }
            = new List<Kullanici>();

        public ICollection<RolModulYetki> RolModulYetkileri { get; set; }
            = new List<RolModulYetki>();
    }
}
