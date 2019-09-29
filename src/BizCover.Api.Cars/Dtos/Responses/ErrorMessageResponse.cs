using System.Net;

namespace BizCover.Api.Cars.Dtos.Responses
{
    public class ErrorMessageResponse
    {
        public HttpStatusCode Status { get; set; }
        public string Error { get; set; }
    }
}