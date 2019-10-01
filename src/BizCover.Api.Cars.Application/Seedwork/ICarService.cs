using System.Collections.Generic;
using System.Threading.Tasks;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Application.Seedwork
{
    public interface ICarService
    {
        Task<Car> AddCar(Car car);
        Task Update(Car car);
        Task<IEnumerable<Car>> GetCars(params int[] carIds);
        decimal CalculateDiscount(IEnumerable<Car> cars);
    }
}