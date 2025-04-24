using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement
{
    public class HybridCar : TransportBase
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

            fuelConsumption = fuelUsed / distance * 0.9; // Снижение расхода на 10% для гибридов
        }
    }
}
