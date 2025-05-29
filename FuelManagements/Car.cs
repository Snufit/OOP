using FuelManagement;
using System.Threading;
using System;

namespace FuelManagement
{
    /// <summary>
    /// Класс Машина.
    /// </summary>
    public class Car : TransportBase
    {
        /// <summary>
        /// Двигатель.
        /// </summary>
        private Motor _motor;

        /// <summary>
        /// Конструктор класса Машина.
        /// </summary>
        /// <param name="motor">Двигатель.</param>
        /// <param name="mass">Масса (т).</param>
        public Car(Motor motor, double mass)
        {
            Motor = motor;
            Mass = mass;
        }

        /// <summary>
        /// Конструктор с параметрами по умолчанию.
        /// </summary>
        public Car() : this(new Motor(100, TypeFuel.Petrol), 1)
        { }

        /// <summary>
        /// Свойство Двигатель.
        /// </summary>
        public Motor Motor
        {
            get => _motor;
            set
            {
                if (value is null)
                {
                    throw new NullReferenceException
                              ("Передано null");
                }

                _motor = value;
            }
        }

        /// <summary>
        /// Переопределенный метод расчета расхода топлива.
        /// </summary>
        /// <param name="distance">Расстояние (км).</param>
        /// <returns>Расход топлива (л).</returns>
        public override double CalculateFuel(double distance)
        {
            double coeffСonsumption = Motor.СalculateConsumption();

            return distance * coeffСonsumption * Mass;
        }
    }
}
