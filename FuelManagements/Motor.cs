using FuelManagement;
using System;
using System.Collections.Generic;

namespace FuelManagement
{
    /// <summary>
    /// Класс Двигатель.
    /// </summary>
    public class Motor
    {
        /// <summary>
        /// Мощность двигателя.
        /// </summary>
        private double _capacity;

        /// <summary>
        /// Словарь тип топлива.
        /// </summary>
        private static readonly Dictionary<TypeFuel, string> _typesFuel =
            new Dictionary<TypeFuel, string>()
        {
            {TypeFuel.Petrol, "Бензин"},
            {TypeFuel.Diesel, "Дизель"},
            {TypeFuel.Electricity, "Электричество"},
            {TypeFuel.Gas, "Газ"},
            {TypeFuel.AviationKerosene, "Авиационный керосин"},
            {TypeFuel.AviationGasoline, "Авиационный бензин"},
        };

        /// <summary>
        /// Конструктор класса Двигатель.
        /// </summary>
        /// <param name="capacity">Мощность двигателя.</param>
        /// <param name="typeFuel">Вид топлива.</param>
        public Motor(double capacity, TypeFuel typeFuel)
        {
            Capacity = capacity;
            TypeFuel = typeFuel;
        }

        /// <summary>
        /// Конструктор с параметрами по умолчанию.
        /// </summary>
        public Motor() : this(180, TypeFuel.Petrol)
        { }

        /// <summary>
        /// Свойство Мощность двигателя.
        /// </summary>
        public double Capacity
        {
            get => _capacity;
            set
            {
                if (double.IsNaN(value))
                {
                    throw new ArgumentException
                        ("Мощность должна быть задана");
                }

                if (value <= 0)
                {
                    throw new ArgumentException
                        ("Мощность должна быть положительной");
                }

                _capacity = value;
            }
        }

        /// <summary>
        /// Свойство Вид топлива.
        /// </summary>
        public TypeFuel TypeFuel
        {
            get; set;
        }

        /// <summary>
        /// Информация о двигателе.
        /// </summary>
        public string Info
        {
            get => $"Тип топлива: {_typesFuel[TypeFuel]}\nМощность: {Capacity} л.с.";
        }

        /// <summary>
        /// Расчет коэффициента расхода.
        /// </summary>
        /// <returns>Коэффициент расхода.</returns>
        public double СalculateConsumption()
        {
            double сonsumptionСapacity;

            if (Capacity <= 100)
            {
                сonsumptionСapacity = 0.08;
            }
            else if (100 < Capacity && Capacity <= 200)
            {
                сonsumptionСapacity = 0.09;
            }
            else
            {
                сonsumptionСapacity = 0.1;
            }

            Dictionary<TypeFuel, double> сonsumptionFuel =
                new Dictionary<TypeFuel, double>()
            {
                {TypeFuel.Electricity, 0.75},
                {TypeFuel.Diesel, 0.90},
                {TypeFuel.Petrol, 0.95},
                {TypeFuel.Gas, 1},
                {TypeFuel.AviationKerosene, 30},
                {TypeFuel.AviationGasoline, 35}
            };

            double сonsumption = сonsumptionСapacity * сonsumptionFuel[TypeFuel];

            return сonsumption;
        }
    }
}
