using BizCover.Api.Cars.Application.Commands.Responses;
using BizCover.Api.Cars.Application.Dtos;
using MediatR;

namespace BizCover.Api.Cars.Application.Commands
{
    public class UpdateCarCommand : CarDto, IRequest<UpdateCarCommandResponse>
    {
    }
}