using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BizCover.Api.Cars.Application.Commands;
using BizCover.Api.Cars.Dtos.Requests;
using BizCover.Api.Cars.Dtos.Responses;
using BizCover.Repository.Cars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BizCover.Api.Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CarsController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            var repo = new CarRepository();

            var car = new Car();
        }

        [HttpPost]
        [ProducesResponseType(typeof(CarResponse), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessageResponse), (int) HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add([FromBody] AddCarRequest request)
        {
            var command = _mapper.Map<AddCarCommand>(request);
            var result = await _mediator.Send(command);

            var response = _mapper.Map<CarResponse>(result);
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(OkResult), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessageResponse), (int) HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCarRequest request)
        {
            var command = _mapper.Map<UpdateCarCommand>(request);
            command.Id = id;

            await _mediator.Send(command);

            return Ok();
        }
    }
}