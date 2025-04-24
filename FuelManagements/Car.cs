using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement
{
    public class Car : Transport
    {
        public string ModelName { get; set; }
        private double fuelConsumption; // Локальная переменная для хранения расхода топлива

        public double FuelConsumption => fuelConsumption;

        public void InitializeFuelConsumption(double distance, double fuelUsed)
        {
            if (distance <= 0 || fuelUsed <= 0)
            {
                throw new ArgumentOutOfRangeException("Distance and fuel used must be positive values.");
            }

            fuelConsumption = fuelUsed / distance; // Расчет расхода топлива
        }
    }
}
