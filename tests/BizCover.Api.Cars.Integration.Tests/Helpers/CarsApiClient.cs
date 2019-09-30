using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BizCover.Api.Cars.Integration.Tests.Helpers
{
    public class CarsApiClient
    {
        private readonly string _carsApiUrl;
        private readonly HttpClient _httpClient;

        public CarsApiClient(string carsApiUrl)
        {
            _carsApiUrl = carsApiUrl;
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> AddCar(object body)
        {
            var content = GetBody(body);
            return await _httpClient.PostAsync(_carsApiUrl, content);
        }

        public async Task<HttpResponseMessage> GetCar(int carId)
        {
            return await _httpClient.GetAsync(_carsApiUrl + $"/{carId}");
        }

        public async Task<HttpResponseMessage> GetCars()
        {
            return await _httpClient.GetAsync(_carsApiUrl);
        }

        public async Task<HttpResponseMessage> UpdateCar(int carId, object body)
        {
            var content = GetBody(body);
            return await _httpClient.PutAsync(_carsApiUrl + $"/{carId}", content);
        }

        private static StringContent GetBody(object body)
        {
            return new StringContent(JsonConvert.SerializeObject(body),
                Encoding.UTF8,
                "application/json");
        }
    }
}