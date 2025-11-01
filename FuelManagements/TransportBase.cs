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
    public abstract class TransportBase
    {
        /// <summary>
        /// Масса.
        /// </summary>
        private double _mass;

        /// <summary>
        /// Свойство Масса.
        /// </summary>
        [Browsable(false)]
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
        /// Тип транспорта.
        /// </summary>
        [DisplayName("Вид транспорта")]
        public abstract string TypeTransport { get; }

        /// <summary>
        /// Информация о транспорте.
        /// </summary>
        [Browsable(false)]
        public abstract string Info { get; }

        /// <summary>
        /// Расход топлива.
        /// </summary>
        [DisplayName("Расход топлива")]
        public abstract string FuelConsumption { get; }

        /// <summary>
        /// Метод расчета расхода топлива.
        /// </summary>
        /// <param name="distance">Расстояние.</param>
        /// <returns>Расход топлива (л).</returns>
        public abstract double CalculateFuel(double distance);

        /// <summary>
        /// Отформатированная информация для отображения.
        /// </summary>
        [DisplayName("Основная информация")]
        public abstract string DisplayInfo { get; }
    }
}
