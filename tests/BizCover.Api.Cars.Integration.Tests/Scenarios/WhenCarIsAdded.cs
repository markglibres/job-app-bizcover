using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BizCover.Api.Cars.Integration.Tests.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;

namespace BizCover.Api.Cars.Integration.Tests.Seedwork
{
    public class WhenCarIsAdded : GivenCarApi
    {
        private HttpResponseMessage _carAddedResult;
        private AddCarRequest _carToAdd;

        protected override void Arrange()
        {
            base.Arrange();
            _carToAdd = new AddCarRequest
            {
                Make = "Ford",
                Model = "Expedition",
                Year = 2012,
                Price = (decimal) 50000.00,
                Colour = "Maroon",
                CountryManufactured = "US"
            };
        }

        protected override async Task ActAsync()
        {
            await base.ActAsync();
            _carAddedResult = await CarsApiClient.AddCar(_carToAdd);
        }

        [Test]
        public void Should_Return_Ok_Status()
        {
            Assert.True(_carAddedResult.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, _carAddedResult.StatusCode);
        }

        [Test]
        public async Task Should_Return_Car_Id()
        {
            var responseString = await _carAddedResult.Content.ReadAsStringAsync();
            dynamic response = JsonConvert.DeserializeObject<ExpandoObject>(responseString, new ExpandoObjectConverter());
            Assert.IsAssignableFrom<long>(response.id);
        }
    }
}