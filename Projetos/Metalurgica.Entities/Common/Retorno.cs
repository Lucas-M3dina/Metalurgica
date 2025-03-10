using System.Net;

namespace Metalurgica.Entities.Common
{
    public class Retorno<T>
    {
        public Retorno()
        {
            
        }

        public Retorno(bool success, string errorMessage)
        {
            Success = success;
            Message = errorMessage;
        }

        public Retorno(bool success, HttpStatusCode statusCode)
        {
            Success = success;
            StatusCode = statusCode;
        }

        public Retorno(bool success, HttpStatusCode statusCode, string errorMessage)
        {
            Success = success;
            Message = errorMessage;
            StatusCode = statusCode;
        }

        public Retorno(bool success, T? data, HttpStatusCode statusCode)
        {
            Success = success;
            Data = data;
            StatusCode = statusCode;
        }


        public Retorno(bool success, string errorMessage, T? data, HttpStatusCode statusCode)
        {
            Success = success;
            Message = errorMessage;
            Data = data;
            StatusCode = statusCode;
        }

        public bool Success { get; set; }

        public string Message { get; set; } = "";

        public T? Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
