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
    public class WhenUpdateCarCommandHandlerIsCalled : TestSpec
    {
        private Car _car;
        private UpdateCarCommand _command;
        private UpdateCarCommandHandler _handler;
        private Mock<ICarService> _mockCarService;
        private UpdateCarCommandResponse _response;

        protected override void Arrange()
        {
            base.Arrange();

            _mockCarService = Fixture.Freeze<Mock<ICarService>>();
            _mockCarService.Setup(s => s.Update(It.IsAny<Car>()))
                .Callback((Car car) => { _car = car; })
                .Returns(Task.CompletedTask);

            _handler = Fixture.Create<UpdateCarCommandHandler>();
        }

        protected override async Task ActAsync()
        {
            await base.ActAsync();
            _command = Fixture.Create<UpdateCarCommand>();
            _response = await _handler.Handle(_command, CancellationToken.None);
        }

        [Test]
        public void Should_Call_CarService_Once()
        {
            _mockCarService.Verify(s => s.Update(It.IsAny<Car>()), Times.Once);
        }

        [Test]
        public void Should_Return_Not_Null_Response()
        {
            Assert.NotNull(_response);
        }

        [Test]
        public void Should_Match_Car_Properties()
        {
            Assert.AreEqual(_command.Id, _car.Id);
            Assert.AreEqual(_command.Make, _car.Make);
            Assert.AreEqual(_command.Model, _car.Model);
            Assert.AreEqual(_command.Year, _car.Year);
            Assert.AreEqual(_command.Price, _car.Price);
            Assert.AreEqual(_command.Colour, _car.Colour);
            Assert.AreEqual(_command.CountryManufactured, _car.CountryManufactured);
        }
    }
}