using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BizCover.Api.Cars.Application.Commands.Responses;
using BizCover.Api.Cars.Application.Seedwork;
using BizCover.Repository.Cars;
using MediatR;

namespace BizCover.Api.Cars.Application.Commands.Handlers
{
    public class AddCarCommandHandler : IRequestHandler<AddCarCommand, AddCarCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarService _carService;

        public AddCarCommandHandler(
            IMapper mapper,
            ICarService carService)
        {
            _mapper = mapper;
            _carService = carService;
        }

        public async Task<AddCarCommandResponse> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(request);
            var carId = await _carService.AddCar(car);
            return new AddCarCommandResponse { Id = carId };
        }
    }
}