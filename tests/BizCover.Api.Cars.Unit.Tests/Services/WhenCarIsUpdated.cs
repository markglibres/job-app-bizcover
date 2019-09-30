using System.Threading.Tasks;
using AutoFixture;
using BizCover.Repository.Cars;
using Moq;
using NUnit.Framework;

namespace BizCover.Api.Cars.Unit.Tests.Services
{
    public class WhenCarIsUpdated : GivenCarService
    {
        private Car _car;
        private Car _carToUpdate;

        protected override void Arrange()
        {
            base.Arrange();
            MockRepository.Setup(r => r.Update(It.IsAny<Car>()))
                .Callback((Car car) => { _car = car; })
                .Returns(Task.CompletedTask);

            _carToUpdate = Fixture.Create<Car>();
        }

        protected override async Task ActAsync()
        {
            await base.ActAsync();
            await CarService.Update(_carToUpdate);
        }

        [Test]
        public void Should_Call_Repository()
        {
            MockRepository.Verify(r => r.Update(It.IsAny<Car>()), Times.Once);
        }

        [Test]
        public void Should_Match_Car_Id()
        {
            Assert.AreEqual(_carToUpdate.Id, _car.Id);
        }
    }
}