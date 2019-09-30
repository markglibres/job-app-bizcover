using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using BizCover.Api.Cars.Tests.Helpers;
using NUnit.Framework;

namespace BizCover.Api.Cars.Tests
{
    public abstract class TestSpec
    {
        protected readonly BizCoverSettings Config;
        protected IFixture Fixture;

        protected TestSpec()
        {
            Config = ConfigHelper.InitConfiguration();
        }

        [SetUp]
        protected async Task Initialize()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            Fixture.Register(() => MapperHelper.Mapper);

            Arrange();
            await ArrangeAsync();

            Act();
            await ActAsync();
        }

        protected virtual void Arrange()
        {
        }

        protected virtual Task ArrangeAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual void Act()
        {
        }

        protected virtual Task ActAsync()
        {
            return Task.CompletedTask;
        }
    }
}