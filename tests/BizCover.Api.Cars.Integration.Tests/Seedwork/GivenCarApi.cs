using BizCover.Api.Cars.Integration.Tests.Helpers;
using BizCover.Api.Cars.Tests;

namespace BizCover.Api.Cars.Integration.Tests.Seedwork
{
    public abstract class GivenCarApi : TestSpec
    {
        protected CarsApiClient CarsApiClient;

        protected GivenCarApi()
        {
            CarsApiClient = new CarsApiClient(Config.CarsApiUrl);
        }
    }
}