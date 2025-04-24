using System;
using System.Runtime.ConstrainedExecution;

class Program
{
    static void Main(string[] args)
    {
        Transport transport;

        Console.WriteLine("Выберите транспортное средство (1 - Машина, 2 - Гибрид, 3 - Вертолет):");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                transport = new Car();
                break;
            case "2":
                transport = new HybridCar();
                break;
            case "3":
                transport = new Helicopter();
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        Console.WriteLine("Введите название модели:");
        transport.ModelName = Console.ReadLine();

        Console.WriteLine("Введите расстояние (км):");
        double distance = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите количество израсходованного топлива (литры):");
        double fuelUsed = Convert.ToDouble(Console.ReadLine());

        try
        {
            transport.InitializeFuelConsumption(distance, fuelUsed);
            Console.WriteLine($"Модель: {transport.ModelName}, Расход топлива: {transport.FuelConsumption} л/100 км");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}