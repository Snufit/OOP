using FuelManagement;
using System.Threading;
using System;

namespace FuelManagement
{
    /// <summary>
    /// Вертолет.
    /// </summary>
    public class Helicopter : TransportBase
    {
        /// <summary>
        /// Длина лопастей вертолета.
        /// </summary>
        private double _bladeLength;

        /// <summary>
        /// Двигатель.
        /// </summary>
        private Motor _motor;

        /// <summary>
        /// Конструктор класса Вертолет.
        /// </summary>
        /// <param name="motor">Двигатель.</param>
        /// <param name="mass">Масса (т).</param>
        /// <param name="bladeLength">Длина лопастей (м).</param>
        public Helicopter(Motor motor, double mass, double bladeLength)
        {
            Motor = motor;
            Mass = mass;
            BladeLength = bladeLength;
        }

        /// <summary>
        /// Конструктор с параметрами по умолчанию.
        /// </summary>
        public Helicopter() : this(new Motor(250, TypeFuel.AviationKerosene), 10, 18)
        { }

        /// <summary>
        /// Свойство Длина лопастей вертолета.
        /// </summary>
        public double BladeLength
        {
            get => _bladeLength;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException
                        ("Длина лопастей должна быть положительной");
                }

                _bladeLength = value;
            }
        }

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
        /// Переопределенный метод Расчета расхода топлива.
        /// </summary>
        /// <param name="distance">Расстояние (часы).</param>
        /// <returns>Расход топлива (л).</returns>
        public override double CalculateFuel(double distance)
        {
            double coeffСonsumption = Motor.СalculateConsumption();

            return distance * coeffСonsumption * Mass * BladeLength;
        }
    }
}
