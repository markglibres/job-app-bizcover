using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BizCover.Api.Cars.Application.Commands.Responses;
using BizCover.Api.Cars.Application.Seedwork;
using BizCover.Repository.Cars;
using MediatR;

namespace BizCover.Api.Cars.Application.Commands.Handlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdateCarCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarService _carService;

        public UpdateCarCommandHandler(
            IMapper mapper,
            ICarService carService)
        {
            _mapper = mapper;
            _carService = carService;
        }

        public async Task<UpdateCarCommandResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(request);

            await _carService.Update(car);

            return new UpdateCarCommandResponse();
        }
    }
}