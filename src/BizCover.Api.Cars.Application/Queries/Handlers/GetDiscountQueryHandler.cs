using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BizCover.Api.Cars.Application.Queries.Responses;
using BizCover.Api.Cars.Application.Seedwork;
using MediatR;

namespace BizCover.Api.Cars.Application.Queries.Handlers
{
    public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, GetDiscountQueryResponse>
    {
        private readonly ICarService _carService;

        public GetDiscountQueryHandler(
            ICarService carService)
        {
            _carService = carService;
        }

        public async Task<GetDiscountQueryResponse> Handle(
            GetDiscountQuery request,
            CancellationToken cancellationToken)
        {
            var cars = (await _carService.GetCars(request.Ids.ToArray()))
                .ToList();

            var originalPrice = cars
                .Sum(c => c.Price);

            var discountPrice = _carService.CalculateDiscount(cars);

            return new GetDiscountQueryResponse
            {
                DiscountPrice = discountPrice,
                OriginalPrice = originalPrice,
                TotalPrice = originalPrice - discountPrice
            };
        }
    }
}