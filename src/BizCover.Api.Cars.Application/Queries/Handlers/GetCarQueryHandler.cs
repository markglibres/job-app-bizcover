using System.Threading;
using System.Threading.Tasks;
using BizCover.Api.Cars.Application.Queries.Responses;
using MediatR;

namespace BizCover.Api.Cars.Application.Queries.Handlers
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, CarQueryResponse>
    {
        public Task<CarQueryResponse> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CarQueryResponse());
        }
    }
}