using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BizCover.Api.Cars.Dtos.Requests
{
    public class GetCarRequest
    {
        [BindProperty(Name = "id")]
        public int Id { get; set; }
    }
}