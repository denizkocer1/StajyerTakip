namespace StajyerTakip.Models.DtoModels
{
    public class DegerlendirmeCreateResponseDto
    {

        public int DegerlendirmeId { get; set; }

        public int StajyerId { get; set; }

        public int KriterId { get; set; }

        public short Puan { get; set; }

        public int DegerlendirenId { get; set; }

        public DateTime Tarih { get; set; }
    }
}
