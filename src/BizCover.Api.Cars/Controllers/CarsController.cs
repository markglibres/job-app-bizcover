using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BizCover.Api.Cars.Application.Commands;
using BizCover.Api.Cars.Application.Queries;
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
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
            var repo = new CarRepository();

            var car = new Car();
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateCarResponse), (int) HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(ErrorMessageResponse), (int) HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add([FromBody] AddCarRequest request)
        {
            var result = await _mediator.Send(new AddCarCommand());
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CarResponse>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessageResponse), (int) HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetCarsQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(CarResponse), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessageResponse), (int) HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] GetCarRequest request)
        {
            var result = await _mediator.Send(new GetCarQuery());
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(CarResponse), (int) HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(ErrorMessageResponse), (int) HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCarRequest request)
        {
            var result = await _mediator.Send(new UpdateCarCommand());
            return Ok(result);
        }
    }
}