using System.Collections.Generic;
using AutoFixture;
using BizCover.Api.Cars.Application.Seedwork;
using BizCover.Repository.Cars;
using Moq;
using NUnit.Framework;

namespace BizCover.Api.Cars.Unit.Tests.Services
{
    public class WhenCalculatingDiscount : GivenCarService
    {
        private decimal _result;

        protected override void Arrange()
        {
            var oneCalculator = Fixture.Create<Mock<ICarDiscountCalculator>>();
            var twoCalculator = Fixture.Create<Mock<ICarDiscountCalculator>>();

            oneCalculator.Setup(c => c.Calculate(It.IsAny<IEnumerable<Car>>()))
                .Returns(50);
            twoCalculator.Setup(c => c.Calculate(It.IsAny<IEnumerable<Car>>()))
                .Returns(25);

            Fixture.Register<IEnumerable<ICarDiscountCalculator>>(() => new List<ICarDiscountCalculator>
                {oneCalculator.Object, twoCalculator.Object});

            base.Arrange();
        }

        protected override void Act()
        {
            base.Act();
            _result = CarService.CalculateDiscount(new List<Car>());
        }

        [Test]
        public void Should_Match_Expected_Discount()
        {
            Assert.AreEqual(75, _result);
        }
    }
}