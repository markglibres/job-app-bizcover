using System;
using System.Threading.Tasks;
using AutoFixture;
using BizCover.Repository.Cars;
using Moq;
using NUnit.Framework;

namespace BizCover.Api.Cars.Unit.Tests.Services
{
    public class WhenCarIsAdded : GivenCarService
    {
        private Car _newCar;
        private int _newCarId;
        private Car _newCarToAdd;

        protected override void Arrange()
        {
            base.Arrange();
            _newCarId = new Random().Next(1, 100);
            MockRepository.Setup(r => r.Add(It.IsAny<Car>()))
                .ReturnsAsync(_newCarId);

            _newCarToAdd = Fixture.Create<Car>();
        }

        protected override async Task ActAsync()
        {
            await base.ActAsync();
            _newCar = await CarService.AddCar(_newCarToAdd);
        }

        [Test]
        public void Should_Call_Repository()
        {
            MockRepository.Verify(r => r.Add(It.IsAny<Car>()), Times.Once);
        }

        [Test]
        public void Should_Match_Car_Id()
        {
            Assert.AreEqual(_newCarId, _newCar.Id);
        }
    }
}