using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using BizCover.Api.Cars.Application.Commands;
using BizCover.Api.Cars.Application.Commands.Handlers;
using BizCover.Api.Cars.Application.Commands.Responses;
using BizCover.Api.Cars.Application.Seedwork;
using BizCover.Api.Cars.Tests;
using BizCover.Repository.Cars;
using Moq;
using NUnit.Framework;

namespace BizCover.Api.Cars.Unit.Tests.Handlers
{
    public class WhenAddCarCommandHandlerIsCalled : TestSpec
    {
        private AddCarCommandHandler _handler;
        private Mock<ICarService> _mockCarService;
        private AddCarCommandResponse _response;
        private Car _newCar;

        protected override void Arrange()
        {
            base.Arrange();
            _newCar = Fixture.Create<Car>();
            _newCar.Year = (new Random()).Next(1908, DateTime.Now.Year);

            _mockCarService = Fixture.Freeze<Mock<ICarService>>();
            _mockCarService.Setup(s => s.AddCar(It.IsAny<Car>()))
                .ReturnsAsync(_newCar);

            _handler = Fixture.Create<AddCarCommandHandler>();
        }

        protected override async Task ActAsync()
        {
            await base.ActAsync();
            var command = Fixture.Create<AddCarCommand>();
            _response = await _handler.Handle(command, CancellationToken.None);
        }

        [Test]
        public void Should_Call_CarService_Once()
        {
            _mockCarService.Verify(s => s.AddCar(It.IsAny<Car>()), Times.Once);
        }

        [Test]
        public void Should_Return_Not_Null_Response()
        {
            Assert.IsAssignableFrom<int>(_response?.Id);
        }

        [Test]
        public void Should_Match_Car_Properties()
        {
            Assert.AreEqual(_newCar.Id, _response.Id);
            Assert.AreEqual(_newCar.Make, _response.Make);
            Assert.AreEqual(_newCar.Model, _response.Model);
            Assert.AreEqual(_newCar.Year, _response.Year);
            Assert.AreEqual(_newCar.Price, _response.Price);
            Assert.AreEqual(_newCar.Colour, _response.Colour);
            Assert.AreEqual(_newCar.CountryManufactured, _response.CountryManufactured);
        }

    }
}