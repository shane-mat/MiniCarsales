using System;
using System.ComponentModel.DataAnnotations;
using MiniCarsales.API.Application.Common.Commands;
using AutoMapper;
using MiniCarsales.Core.Entities;
using MiniCarsales.Infrastructure.Data;

namespace MiniCarsales.API.Application.Cars.Commands
{
    public class CreateCarCommand : ICreateCommand<Car>
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }
        
        [Required]
        public string Engine { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Number of Doors must be numeric")]
        public string NumberOfDoors { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Number of Wheels must be numeric")]
        public string NumberOfWheels { get; set; }

        [Required]
        public string BodyType { get; set; }
    }

    public class CreateCarCommandHandler : CreateCommandHandler<Car, CreateCarCommand>
    {
        public CreateCarCommandHandler(VehicleContext context, IMapper mapper) : base(context, mapper) { }
    }
}