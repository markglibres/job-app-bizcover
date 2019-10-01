using System.Collections.Generic;
using System.Linq;
using BizCover.Api.Cars.Application.Seedwork;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Application.Services
{
    public class OldCarDiscountCalculator : ICarDiscountCalculator
    {
        private const int MaximumYear = 2000;
        private const decimal Discount = (decimal) 0.10;

        public decimal Calculate(IEnumerable<Car> cars)
        {
            decimal totalDiscount = 0;

            cars
                .ToList()
                .ForEach(c => { totalDiscount += c.Year < MaximumYear ? c.Price * Discount : 0; });

            return totalDiscount;
        }
    }
}