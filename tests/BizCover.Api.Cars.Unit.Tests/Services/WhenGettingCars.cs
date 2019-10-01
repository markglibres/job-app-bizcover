using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using BizCover.Repository.Cars;
using Moq;
using NUnit.Framework;

namespace BizCover.Api.Cars.Unit.Tests.Services
{
    public class WhenGettingCars : GivenCarService
    {
        private List<Car> _cars;
        private IEnumerable<Car> _result;

        protected override void Arrange()
        {
            base.Arrange();

            var vintageCar = Fixture.Create<Car>();
            var cheapCar = Fixture.Create<Car>();
            var luxuryCar = Fixture.Create<Car>();

            _cars = new List<Car>
            {
                vintageCar,
                cheapCar,
                luxuryCar
            };

            MockRepository.Setup(r => r.GetAllCars())
                .ReturnsAsync(_cars);
        }

        protected override async Task ActAsync()
        {
            await base.ActAsync();
            _result = await CarService.GetCars(
                _cars.First().Id,
                _cars.Last().Id);
        }

        [Test]
        public void Should_Return_Two_Cars()
        {
            Assert.AreEqual(2, _result.Count());
        }

        [Test]
        public void Should_Match_Expected_Cars()
        {
            Assert.AreEqual(_cars.First()
                    .Id,
                _result.First()
                    .Id);
            Assert.AreEqual(_cars.Last()
                    .Id,
                _result.Last()
                    .Id);
        }
    }
}