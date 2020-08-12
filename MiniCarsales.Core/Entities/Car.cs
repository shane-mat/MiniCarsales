using System;
using MiniCarsales.Core.Interfaces;
using MiniCarsales.Core.Constants;

namespace MiniCarsales.Core.Entities
{
    public class Car : Vehicle, IEntity
    {
        public string Engine { get; set; }
        
        public int NumberOfDoors { get; set; }

        public int NumberOfWheels { get; set; }

        public string BodyType { get; set; }
    }
}