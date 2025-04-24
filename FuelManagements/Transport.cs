using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement
{
    public interface Transport
    {
        string ModelName { get; set; }
        double FuelConsumption { get; } // Метод для получения расхода топлива
        void InitializeFuelConsumption(double distance, double fuelUsed);
    }
}
