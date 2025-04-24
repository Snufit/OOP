using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement
{
    public class Helicopter : TransportBase
    {
        public string ModelName { get; set; }
        private double fuelConsumption;

        public double FuelConsumption => fuelConsumption;

        public void InitializeFuelConsumption(double distance, double fuelUsed)
        {
            if (distance <= 0 || fuelUsed <= 0)
            {
                throw new ArgumentOutOfRangeException("Distance and fuel used must be positive values.");
            }

            fuelConsumption = fuelUsed / distance * 1.5; // Увеличение расхода на 50% для вертолета
        }
    }
}
