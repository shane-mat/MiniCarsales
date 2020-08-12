using System;

namespace MiniCarsales.API.Application.Cars.Queries
{
    public class CarDto
    {
        public int Id { get; set; }

        public string VehicleType { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Engine { get; set; }

        public int NumberOfDoors { get; set; }

        public int NumberOfWheels { get; set; }

        public string BodyType { get; set; }
    }
}