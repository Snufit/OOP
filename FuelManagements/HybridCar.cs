using FuelManagement;
using System.Threading;
using System;

namespace FuelManagement
{
    /// <summary>
    /// Класс Гибридная Машина.
    /// </summary>
    public class HybridCar : Car
    {
        /// <summary>
        /// Дополнительный двигатель.
        /// </summary>
        private Motor _additionalMotor;

        /// <summary>
        /// Конструктор класса Гибридная Машина.
        /// </summary>
        /// <param name="motor">Основной Двигатель.</param>
        /// <param name="mass">Масса.</param>
        /// <param name="additionalMotor">Дополнительный двигатель.</param>
        /// <param name="fielPer100km">Расход на 100 км.</param>
        public HybridCar(Motor motor, double mass, Motor additionalMotor) :
            base(motor, mass)
        {
            AdditionalMotor = additionalMotor;
        }

        /// <summary>
        /// Конструктор с параметрами по умолчанию.
        /// </summary>
        public HybridCar() : this(new Motor(100, TypeFuel.Petrol), 1,
            new Motor(50, TypeFuel.Electricity))
        { }

        /// <summary>
        /// Свойство Дополнительный двигатель.
        /// </summary>
        public Motor AdditionalMotor
        {
            get => _additionalMotor;
            set
            {
                if (value.TypeFuel == Motor.TypeFuel)
                {
                    throw new ArgumentException("Вид топлива основного " +
                        "двигателя и дополнительного должны отличаться");
                }

                if (value is null)
                {
                    throw new NullReferenceException
                              ("Передано null");
                }

                _additionalMotor = value;
            }
        }

        /// <summary>
        /// Переопределенный метод Расчета расхода топлива.
        /// </summary>
        /// <param name="distanceBasic">Расстояние, пройденное на основном
        /// двигателе.</param>
        /// <param name="distanceAdd">Расстояние, пройденное на дополнительном
        /// двигателе.</param>
        /// <returns>Расход топлива (л).</returns>
        public (double, double) CalculateFuel(double distanceBasic,
            double distanceAdd)
        {
            double coeffСonsumptionBasic = Motor.СalculateConsumption();
            double consumptionBasic = (distanceBasic / 100) * coeffConsumptionBasic;

            double coeffСonsumptionAdd = AdditionalMotor.СalculateConsumption();
            double consumptionAdd = (distanceAdd / 100) * coeffConsumptionAdd;

            double consumptionAdd;
            double massFactor = 1 + (Mass / 1000.0) * 0.1;

            //TODO: rewrite

            // Форматируем расход в зависимости от типа топлива
            if (Motor.TypeFuel == TypeFuel.Electricity)
            {
                consumptionBasic = Math.Round(consumptionBasic, 1); // Конвертируем в кВт·ч
            }
            else
            {
                consumptionBasic = Math.Round(consumptionBasic, 1); // Оставляем в литрах
            }

            if (AdditionalMotor.TypeFuel == TypeFuel.Electricity)
            {
                consumptionAdd = Math.Round(consumptionAdd, 1); // Конвертируем в кВт·ч
            }
            else
            {
                consumptionAdd = Math.Round(consumptionAdd, 1); // Оставляем в литрах
            }

            return (consumptionBasic, consumptionAdd);
        }
    }
}
