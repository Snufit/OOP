using FuelManagement;
using System;
using System.Collections.Generic;

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
                if (double.IsNaN(value))
                {
                    throw new ArgumentException
                        ("Длина лопастей должна быть задана");
                }

                if (value <= 0)
                {
                    throw new ArgumentException
                        ("Длина лопастей должна быть положительной");
                }

                _bladeLength = value;
            }
        }

        public override string DisplayInfo
        {
            get
            {
                var fuelNames = new Dictionary<TypeFuel, string>
            {
                {TypeFuel.Petrol, "Бензин"},
                {TypeFuel.Diesel, "Дизель"},
                {TypeFuel.Electricity, "Электричество"},
                {TypeFuel.Gas, "Газ"},
                {TypeFuel.AviationKerosene, "Авиационный керосин"},
                {TypeFuel.AviationGasoline, "Авиационный бензин"}
            };

                return $"Тип топлива: {fuelNames[Motor.TypeFuel]}\n" +
                       $"Мощность: {Motor.Capacity} л.с.\n" +
                       $"Масса: {Mass} т.\n" +
                       $"Длина лопастей: {BladeLength} м.";
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

        /// <inheritdoc/>
        public override string Info
        {
            get => $"{Motor.Info}\nМасса: {Mass} т.\nДлина лопастей: {BladeLength} м.";
        }

        /// <inheritdoc/>
        public override string TypeTransport
        {
            get => "Вертолет";
        }

        /// <inheritdoc/>
        public override string FuelConsumption
        {
            get => $"{Math.Round(CalculateFuel(1), 2)} л. в час";
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
