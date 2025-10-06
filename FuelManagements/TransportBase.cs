using FuelManagement;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace FuelManagement
{
    /// <summary>
    /// Абстрактный класс Транспорт.
    /// </summary>
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(HybridCar))]
    [XmlInclude(typeof(Helicopter))]
    /// <summary>
    /// Абстрактный класс Транспорт.
    /// </summary>
    public abstract class TransportBase
    {
        /// <summary>
        /// Масса.
        /// </summary>
        private double _mass;

        /// <summary>
        /// Свойство Масса.
        /// </summary>
        public double Mass
        {
            get => _mass;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException
                        ("Масса должна быть положительной");
                }

                _mass = value;
            }
        }

        /// <summary>
        /// Метод расчета расхода топлива.
        /// </summary>
        /// <param name="distance">Расстояние.</param>
        /// <returns>Расход топлива (л).</returns>
        public abstract double CalculateFuel(double distance);
    }
}
