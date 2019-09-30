using System.Threading.Tasks;
using BizCover.Api.Cars.Application.Seedwork;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Application.Services
{
    public class CarService : ICarService
    {
        public Task<int> AddCar(Car car)
        {
            return Task.FromResult(1);
        }
    }
}