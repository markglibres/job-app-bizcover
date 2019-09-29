using BizCover.Api.Cars.Application.Commands.Responses;
using MediatR;

namespace BizCover.Api.Cars.Application.Commands
{
    public class AddCarCommand : IRequest<AddCarCommandResponse>
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string CountryManufactured { get; set; }

        public string Colour { get; set; }

        public decimal Price { get; set; }
    }
}