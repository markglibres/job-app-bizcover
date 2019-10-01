using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using BizCover.Api.Cars.Dtos.Requests;
using BizCover.Api.Cars.Integration.Tests.Dtos;
using BizCover.Api.Cars.Integration.Tests.Seedwork;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BizCover.Api.Cars.Integration.Tests.Scenarios
{
    public class WhenCalculatingCarDiscountPrice : GivenCarApi
    {
        private const decimal ExpectedOriginalPrice = 150000;
        private const decimal ExpectedDiscountPrice = 17000;
        private const decimal ExpectedTotalPrice = 133000;
        
        private IEnumerable<CarApiResponse> _carsToGetDiscount;
        private HttpResponseMessage _response;

        protected override async Task ArrangeAsync()
        {
            await base.ArrangeAsync();
            _carsToGetDiscount = await AddCars();
        }

        protected override async Task ActAsync()
        {
            await base.ActAsync();

            var carsId = _carsToGetDiscount
                .Select(c => c.Id)
                .ToArray();

            _response = await CarsApiClient.GetDiscount(carsId);
        }

        [Test]
        public void Should_Return_Ok_Status()
        {
            Assert.True(_response.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }

        [Test]
        public async Task Should_Match_Prices()
        {
            var responseString = await _response.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<CarsApiDiscountResponse>(responseString);

            Assert.AreEqual(ExpectedOriginalPrice, response.OriginalPrice);
            Assert.AreEqual(ExpectedDiscountPrice, response.DiscountPrice);
            Assert.AreEqual(ExpectedTotalPrice, response.TotalPrice);
        }

        private async Task<IEnumerable<CarApiResponse>> AddCars()
        {
            var vintageCar = Fixture.Create<AddCarRequest>();
            vintageCar.Year = 1975;
            vintageCar.Price = 50000;

            var cheapCar = Fixture.Create<AddCarRequest>();
            cheapCar.Year = 2010;
            cheapCar.Price = 25000;

            var luxuryCar = Fixture.Create<AddCarRequest>();
            luxuryCar.Year = 2018;
            luxuryCar.Price = 75000;

            var cars = new List<CarApiResponse>
            {
                await AddCar(vintageCar),
                await AddCar(cheapCar),
                await AddCar(luxuryCar)
            };

            return cars;
        }

        private async Task<CarApiResponse> AddCar(AddCarRequest car)
        {
            var result = await CarsApiClient.AddCar(car);
            var responseString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CarApiResponse>(responseString);
        }
    }
}