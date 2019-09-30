using System.Threading;
using System.Threading.Tasks;
using BizCover.Api.Cars.Application.Commands.Responses;
using MediatR;

namespace BizCover.Api.Cars.Application.Commands.Handlers
{
    public class AddCarCommandHandler : IRequestHandler<AddCarCommand, AddCarCommandResponse>
    {
        public Task<AddCarCommandResponse> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new AddCarCommandResponse{ Id = 1 });
        }
    }
}