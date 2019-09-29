using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BizCover.Api.Cars.Application.Queries.Responses;
using MediatR;

namespace BizCover.Api.Cars.Application.Queries.Handlers
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, IEnumerable<CarQueryResponse>>
    {
        public Task<IEnumerable<CarQueryResponse>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult<IEnumerable<CarQueryResponse>>(new List<CarQueryResponse>());
        }
    }
}