using System;
using AutoMapper;
using BizCover.Api.Cars.Application.Mappers;

namespace BizCover.Api.Cars.Unit.Tests.Helpers
{
    public class MapperHelper
    {
        private static readonly Lazy<MapperHelper> Instance = new Lazy<MapperHelper>(() => new MapperHelper());

        private readonly IMapper _mapper;

        private MapperHelper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(typeof(CarMapperProfile)));
            _mapper = config.CreateMapper();
        }

        public static IMapper Mapper => Instance.Value._mapper;
    }
}