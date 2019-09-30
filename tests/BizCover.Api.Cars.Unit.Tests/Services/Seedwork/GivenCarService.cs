using AutoFixture;
using BizCover.Api.Cars.Application.Services;
using BizCover.Api.Cars.Tests;
using BizCover.Repository.Cars;
using Moq;

namespace BizCover.Api.Cars.Unit.Tests.Services
{
    public abstract class GivenCarService : TestSpec
    {
        protected CarService CarService;
        protected Mock<ICarRepository> MockRepository;

        protected override void Arrange()
        {
            base.Arrange();
            MockRepository = Fixture.Freeze<Mock<ICarRepository>>();
            CarService = Fixture.Create<CarService>();
        }
    }
}