using System.Net;  //http kodları burdan geliyor- 200 201 400 404 gibi sayı yazmak yerine HttpStatusCode.BadRequest yazılabiliyor.

namespace StajyerTakip.Results
{
    public class Result // result classı StajyerTakip.Results namespace i altında oluştu.
        //bu sınıfın 3 bilgisi var.
    {
        public bool Success { get; set; }  //işlem başarılı mı başarısız mı

        public string Message { get; set; } = string.Empty; //kullanıcıya hangi mesajı dönücez

        public HttpStatusCode StatusCode { get; set; } //http sonucu ne  - ok,badrequest,unauthorized,notfound...

        public static Result SuccessResult(string message = "İşlem başarılı")
        {
            return new Result
            {
                Success = true,
                Message = message,
                StatusCode = HttpStatusCode.OK
            };
        }

        //public - bu metoda başka sınıdlardan ulaşılabilir.
        //static - normalde bir metoda ulaşmak için önce nesne oluşturmamız gerekebilirdi ama 
        //static olduğu için new Result() oluşturmadan doğrudan sınıfın adı üzerinden çağırabiliyoruz
        //Result - metodun dönüş tipi

        public static Result ErrorResult(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new Result
            {
                Success = false,
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}