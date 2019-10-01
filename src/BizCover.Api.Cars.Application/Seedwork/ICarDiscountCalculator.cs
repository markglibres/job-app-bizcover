using System;
using System.Collections.Generic;
using System.Text;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Application.Seedwork
{
    public interface ICarDiscountCalculator
    {
        decimal Calculate(IEnumerable<Car> cars);
    }
}
