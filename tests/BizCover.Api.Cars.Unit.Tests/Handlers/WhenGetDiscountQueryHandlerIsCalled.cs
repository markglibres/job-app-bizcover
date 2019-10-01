using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using BizCover.Api.Cars.Application.Queries;
using BizCover.Api.Cars.Application.Queries.Handlers;
using BizCover.Api.Cars.Application.Queries.Responses;
using BizCover.Api.Cars.Application.Seedwork;
using BizCover.Api.Cars.Tests;
using BizCover.Repository.Cars;
using Moq;
using NUnit.Framework;

namespace BizCover.Api.Cars.Unit.Tests.Handlers
{
    public class WhenGetDiscountQueryHandlerIsCalled : TestSpec
    {
        private GetDiscountQueryHandler _handler;
        private Mock<ICarService> _mockCarService;
        private GetDiscountQueryResponse _result;

        protected override void Arrange()
        {
            base.Arrange();

            _mockCarService = Fixture.Freeze<Mock<ICarService>>();

            _mockCarService.Setup(s => s.GetCars(It.IsAny<int[]>()))
                .ReturnsAsync(GetCars());
            _mockCarService.Setup(s => s.CalculateDiscount(It.IsAny<IEnumerable<Car>>()))
                .Returns(17000);

            _handler = Fixture.Create<GetDiscountQueryHandler>();
        }

        protected override async Task ActAsync()
        {
            await base.ActAsync();
            _result = await _handler.Handle(Fixture.Create<GetDiscountQuery>(), CancellationToken.None);
        }

        [Test]
        public void Should_Return_NotNull_Response()
        {
            Assert.NotNull(_result);
        }

        [Test]
        public void Should_Match_CalculatedPrices()
        {
            Assert.AreEqual(150000, _result.OriginalPrice);
            Assert.AreEqual(17000, _result.DiscountPrice);
            Assert.AreEqual(133000, _result.TotalPrice);
        }

        private IEnumerable<Car> GetCars()
        {
            var vintageCar = Fixture.Create<Car>();
            vintageCar.Year = 1999;
            vintageCar.Price = 50000;

            var cheapCar = Fixture.Create<Car>();
            cheapCar.Year = 2010;
            cheapCar.Price = 25000;

            var luxuryCar = Fixture.Create<Car>();
            luxuryCar.Year = 2019;
            luxuryCar.Price = 75000;

            return new List<Car>
            {
                vintageCar,
                cheapCar,
                luxuryCar
            };
        }
    }
}