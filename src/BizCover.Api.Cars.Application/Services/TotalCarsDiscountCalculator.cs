using System.Collections.Generic;
using System.Linq;
using BizCover.Api.Cars.Application.Seedwork;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Application.Services
{
    public class TotalCarsDiscountCalculator : ICarDiscountCalculator
    {
        private const int MinimumCars = 2;
        private const decimal Discount = (decimal) 0.03;

        public decimal Calculate(IEnumerable<Car> cars)
        {
            var carListing = cars.ToList();
            var totalPrice = carListing
                .Sum(c => c.Price);

            var total = carListing.Count();
            var discount = total > MinimumCars ? totalPrice * Discount : 0;

            return discount;
        }
    }
}