using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizCover.Api.Cars.Application.Seedwork;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IEnumerable<ICarDiscountCalculator> _carDiscountCalculators;

        public CarService(
            ICarRepository carRepository,
            IEnumerable<ICarDiscountCalculator> carDiscountCalculators)
        {
            _carRepository = carRepository;
            _carDiscountCalculators = carDiscountCalculators;
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

        public async Task<IEnumerable<Car>> GetCars(params int[] carIds)
        {
            var cars = await _carRepository.GetAllCars();
            return cars.Where(c => carIds.Contains(c.Id));
        }

        public decimal CalculateDiscount(IEnumerable<Car> cars)
        {
            decimal discount = 0;

            _carDiscountCalculators.ToList()
                .ForEach(calculator =>
                {
                    discount += calculator.Calculate(cars);
                });

            return discount;
        }
    }
}