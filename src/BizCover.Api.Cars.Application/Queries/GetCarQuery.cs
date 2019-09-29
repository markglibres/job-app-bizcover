using BizCover.Api.Cars.Application.Queries.Responses;
using MediatR;

namespace BizCover.Api.Cars.Application.Queries
{
    public class GetCarQuery : IRequest<CarQueryResponse>
    {
        public int Id { get; set; }
    }
}