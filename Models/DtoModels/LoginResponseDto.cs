namespace StajyerTakip.Models.DtoModels
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = null!;

        public int KullaniciId { get; set; }

        public string KullaniciAdi { get; set; } = null!;

        public string Ad { get; set; } = null!;

        public string Soyad { get; set; } = null!;

        public string RolAdi { get; set; } = null!;
    }
}
