using System.Threading.Tasks;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Application.Seedwork
{
    public interface ICarService
    {
        Task<int> AddCar(Car car);
    }
}