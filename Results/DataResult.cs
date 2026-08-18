using System.Net; //http kodları buradan geliyor

namespace StajyerTakip.Results
{
    public class DataResult<T> : Result
    {
        public T? Data { get; set; }

        public static DataResult<T> SuccessDataResult(
            T data,
            string message = "İşlem başarılı")
        {
            return new DataResult<T>
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = HttpStatusCode.OK
            };
        }

        public static DataResult<T> ErrorDataResult(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new DataResult<T>
            {
                Success = false,
                Message = message,
                Data = default,
                StatusCode = statusCode
            };
        }
    }
}