using AutoMapper;
using BizCover.Api.Cars.Application.Commands;
using BizCover.Api.Cars.Application.Commands.Responses;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Application.Mappers
{
    public class CarMapperProfile : Profile
    {
        public CarMapperProfile()
        {
            CreateMap<AddCarCommand, Car>();
            CreateMap<UpdateCarCommand, Car>();
            CreateMap<Car, AddCarCommandResponse>();
        }
    }
}