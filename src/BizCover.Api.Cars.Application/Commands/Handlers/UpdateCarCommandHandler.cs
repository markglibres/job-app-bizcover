using System.Threading;
using System.Threading.Tasks;
using BizCover.Api.Cars.Application.Commands.Responses;
using MediatR;

namespace BizCover.Api.Cars.Application.Commands.Handlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdateCarCommandResponse>
    {
        public Task<UpdateCarCommandResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new UpdateCarCommandResponse());
        }
    }
}