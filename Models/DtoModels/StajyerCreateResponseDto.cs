namespace StajyerTakip.Models.DtoModels
{
    public class StajyerCreateResponseDto
    {
        public int StajyerId { get; set; }

        public string Ad { get; set; } = null!;

        public string Soyad { get; set; } = null!;

        public string Durum { get; set; } = null!;

        public DateTime OlusturmaTarihi { get; set; }
    }
}
