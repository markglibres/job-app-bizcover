using AutoMapper;
using BizCover.Api.Cars.Application.Commands.Responses;
using BizCover.Api.Cars.Dtos.Responses;

namespace BizCover.Api.Cars.Mappers
{
    public class CommandToResponseMapperProfile : Profile
    {
        public CommandToResponseMapperProfile()
        {
            CreateMap<AddCarCommandResponse, CreateCarResponse>();
        }
    }
}