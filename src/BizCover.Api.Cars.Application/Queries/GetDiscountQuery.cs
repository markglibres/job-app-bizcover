using System.Collections.Generic;
using BizCover.Api.Cars.Application.Queries.Responses;
using MediatR;

namespace BizCover.Api.Cars.Application.Queries
{
    public class GetDiscountQuery : IRequest<GetDiscountQueryResponse>
    {
        public IEnumerable<int> Ids { get; set; }
    }
}