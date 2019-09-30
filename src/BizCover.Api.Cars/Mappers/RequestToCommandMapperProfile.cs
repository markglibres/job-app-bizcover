using AutoMapper;
using BizCover.Api.Cars.Application.Commands;
using BizCover.Api.Cars.Dtos.Requests;

namespace BizCover.Api.Cars.Mappers
{
    public class RequestToCommandMapperProfile : Profile
    {
        public RequestToCommandMapperProfile()
        {
            CreateMap<AddCarRequest, AddCarCommand>();
        }
    }
}