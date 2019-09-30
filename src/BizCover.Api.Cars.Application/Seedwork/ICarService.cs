using System.Threading.Tasks;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Application.Seedwork
{
    public interface ICarService
    {
        Task<Car> AddCar(Car car);
    }
}