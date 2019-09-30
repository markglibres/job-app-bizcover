using System;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using BizCover.Api.Cars.Dtos.Requests;
using BizCover.Api.Cars.Integration.Tests.Seedwork;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;

namespace BizCover.Api.Cars.Integration.Tests.Scenarios
{
    public class WhenCarIsUpdated : GivenCarApi
    {
        private int _carIdToUpdate;
        private UpdateCarRequest _carToUpdate;
        private HttpResponseMessage _response;

        protected override async Task ArrangeAsync()
        {
            await base.ArrangeAsync();
            var carToAdd = Fixture.Create<AddCarRequest>();
            carToAdd.Year = new Random().Next(1908, DateTime.Now.Year);

            var result = await CarsApiClient.AddCar(carToAdd);

            var responseString = await result.Content.ReadAsStringAsync();
            dynamic response =
                JsonConvert.DeserializeObject<ExpandoObject>(responseString, new ExpandoObjectConverter());

            _carToUpdate = Fixture.Create<UpdateCarRequest>();
            _carToUpdate.Year = new Random().Next(1908, DateTime.Now.Year);

            _carIdToUpdate = (int) response.id;
        }

        protected override async Task ActAsync()
        {
            await base.ActAsync();
            _response = await CarsApiClient.UpdateCar(_carIdToUpdate, _carToUpdate);
        }

        [Test]
        public void Should_Return_Ok_Status()
        {
            Assert.True(_response.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }
    }
}