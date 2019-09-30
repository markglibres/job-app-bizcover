using System.Threading.Tasks;
using BizCover.Api.Cars.Application.Seedwork;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Car> AddCar(Car car)
        {
            var newCarId = await _carRepository.Add(car);
            car.Id = newCarId;

            return car;
        }

        public async Task Update(Car car)
        {
            await _carRepository.Update(car);
        }
    }
}