using System.Threading;
using System.Threading.Tasks;
using BizCover.Api.Cars.Application.Queries.Responses;
using MediatR;

namespace BizCover.Api.Cars.Application.Queries.Handlers
{
    public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, GetDiscountQueryResponse>
    {
        public Task<GetDiscountQueryResponse> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetDiscountQueryResponse());
        }
    }
}