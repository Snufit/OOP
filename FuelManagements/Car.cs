using FuelManagement;
using System;
using System.Collections.Generic;

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
                       $"Масса: {Mass} т.";
            }
        }

        public override string Info
        {
            get => $"{Motor.Info} \nМасса: {Mass} т.";
        }

        public override string TypeTransport
        {
            get => "Машина";
        }

        /// <inheritdoc/>
        public override string FuelConsumption
        {
            get => $"{Math.Round(CalculateFuel(100), 2)} л. на 100 км.";
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
