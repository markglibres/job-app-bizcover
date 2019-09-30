using System;
using Microsoft.Extensions.Configuration;

namespace BizCover.Api.Cars.Tests.Helpers
{
    public static class ConfigHelper
    {
        public static BizCoverSettings InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional:true )
                .AddEnvironmentVariables()
                .Build();

            return new BizCoverSettings
            {
                CarsApiUrl = config["CarsApiUrl"]
            };
        }
    }
}