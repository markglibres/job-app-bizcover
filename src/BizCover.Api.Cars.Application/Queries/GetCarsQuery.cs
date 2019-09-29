using System.Collections.Generic;
using BizCover.Api.Cars.Application.Queries.Responses;
using MediatR;

namespace BizCover.Api.Cars.Application.Queries
{
    public class GetCarsQuery : IRequest<IEnumerable<CarQueryResponse>>
    {
    }
}