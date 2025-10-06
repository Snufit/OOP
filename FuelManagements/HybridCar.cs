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
        /// Переопределенный метод расчета расхода топлива.
        /// Предполагается, что гибридная машина использует оба двигателя
        /// пропорционально (50% на основном, 50% на дополнительном).
        /// </summary>
        /// <param name="distance">Общее расстояние (км).</param>
        /// <returns>Общий расход топлива (л).</returns>
        public override double CalculateFuel(double distance)
        {
            double basicRatio = 0.5;
            double addRatio = 0.5;

            double distanceBasic = distance * basicRatio;
            double distanceAdd = distance * addRatio;

            double coeffBasic = Motor.СalculateConsumption();
            double coeffAdd = AdditionalMotor.СalculateConsumption();

            //TODO: rewrite +
            double consumptionBasic = distanceBasic * coeffBasic * Mass;
            double consumptionAdd = distanceAdd * coeffAdd * Mass;

            return consumptionBasic + consumptionAdd;
        }

        /// <summary>
        /// Дополнительный метод для раздельного расчета расхода топлива.
        /// </summary>
        /// <param name="distanceBasic">Расстояние на основном двигателе (км).</param>
        /// <param name="distanceAdd">Расстояние на дополнительном двигателе (км).</param>
        /// <returns>Кортеж с расходами (основной, дополнительный).</returns>
        public (double basicConsumption, double additionalConsumption) CalculateFuelSeparate(double distanceBasic, double distanceAdd)
        {
            double coeffBasic = Motor.СalculateConsumption();
            double coeffAdd = AdditionalMotor.СalculateConsumption();

            double consumptionBasic = distanceBasic * coeffBasic * Mass;
            double consumptionAdd = distanceAdd * coeffAdd * Mass;

            return (consumptionBasic, consumptionAdd);
        }
    }
}
