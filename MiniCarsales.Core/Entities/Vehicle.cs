using System;
using MiniCarsales.Core.Interfaces;

namespace MiniCarsales.Core.Entities
{
    public class Vehicle: IEntity
    {
        public int Id { get; set; }

        public string VehicleType { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }
    }
}