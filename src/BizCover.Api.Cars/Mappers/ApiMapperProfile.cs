using AutoMapper;
using BizCover.Api.Cars.Application.Commands;
using BizCover.Api.Cars.Application.Commands.Responses;
using BizCover.Api.Cars.Application.Queries;
using BizCover.Api.Cars.Application.Queries.Responses;
using BizCover.Api.Cars.Dtos.Requests;
using BizCover.Api.Cars.Dtos.Responses;

namespace BizCover.Api.Cars.Mappers
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            CreateMap<AddCarRequest, AddCarCommand>();
            CreateMap<UpdateCarRequest, UpdateCarCommand>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<GetDiscountRequest, GetDiscountQuery>();

            CreateMap<AddCarCommandResponse, CarResponse>();
            CreateMap<GetDiscountQueryResponse, GetDiscountResponse>();
        }
    }
}