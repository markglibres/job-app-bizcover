using System;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using BizCover.Api.Cars.Dtos.Requests;
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
            _carToAdd = Fixture.Create<AddCarRequest>();
            _carToAdd.Year = (new Random()).Next(1908, DateTime.Now.Year);
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
            dynamic response =
                JsonConvert.DeserializeObject<ExpandoObject>(responseString, new ExpandoObjectConverter());
            Assert.IsAssignableFrom<long>(response.id);
        }
    }
}