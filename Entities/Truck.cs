using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Truck : IVehicle
    {
        public int numOfWheels => 10;
        public Wagon Wagon { get; } = null;

        public Truck(Wagon wagon)
        {
            Wagon = wagon;
        }
    }
}
