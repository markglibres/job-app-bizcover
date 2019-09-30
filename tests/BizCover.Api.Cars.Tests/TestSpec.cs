using System.Threading.Tasks;
using BizCover.Api.Cars.Tests.Helpers;
using NUnit.Framework;

namespace BizCover.Api.Cars.Tests
{
    public abstract class TestSpec
    {
        protected readonly BizCoverSettings Config;

        protected TestSpec()
        {
            Config = ConfigHelper.InitConfiguration();
        }

        [SetUp]
        protected async Task Initialize()
        {
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