using System.Collections.Generic;
using System.Linq;
using BizCover.Api.Cars.Application.Seedwork;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Application.Services
{
    public class TotalPriceDiscountCalculator : ICarDiscountCalculator
    {
        private const decimal MinimumPrice = 100000;
        private const decimal DiscountRate = (decimal) 0.05;

        public decimal Calculate(IEnumerable<Car> cars)
        {
            var totalPrice = cars
                .ToList()
                .Sum(c => c.Price);

            var discount = totalPrice > MinimumPrice ? totalPrice * DiscountRate : 0;
            return discount;
        }
    }
}