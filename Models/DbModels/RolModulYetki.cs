namespace StajyerTakip.Models.DbModels
{
    public class RolModulYetki
    {
        public char Yetki { get; set; }
        

        public int RolId { get; set; }
        public Rol Rol { get; set; } = null!;
        
        
        public int ModulId { get; set; }
        public Modul Modul { get; set; } = null!;
    }
}
