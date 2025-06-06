using FuelManagement;

namespace ConsoleLoader
{
    /// <summary>
    /// Класс для консольного ввода транспорта.
    /// </summary>
    public static class ConsoleTransport
    {
        /// <summary>
        /// Метод Выбора Транспорта для расчета расхода топлива.
        /// </summary>
        /// <returns>Транспорт.</returns>
        public static TransportBase SelectTransport()
        {
            TransportBase transport = new Car();

            //TODO: duplication
            Dictionary<Type, Action<string>> catchDictionary =
                new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentOutOfRangeException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
            };

            List<Action> actions = new()
            {
                ()=>
                {
                     Console.WriteLine("\nВыберите тип транспорта:" +
                        "\n\t1 - машина" +
                        "\n\t2 - машина-гибрид" +
                        "\n\t3 - вертолет");

                    char readTransport = Console.ReadKey().KeyChar;

                    switch (readTransport)
                    {
                        case '1':
                        {
                            transport = ReadCar();
                            break;
                        }

                        case '2':
                        {
                            transport = ReadHybridCar();
                            break;
                        }

                        case '3':
                        {
                            transport = ReadHelicopter();
                            break;
                        }

                        default:
                        {
                            throw new ArgumentOutOfRangeException(
                                "Неверно введен тип транспорта");
                        }
                    }
                },
            };

            ActionsHandler(actions, catchDictionary);

            return transport;
        }

        /// <summary>
        /// Метод Ввода данных о Машине.
        /// </summary>
        /// <returns>Машина.</returns>
        public static Car ReadCar()
        {
            Dictionary<Type, Action<string>> catchDictionary =
                new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
                {
                    typeof(OverflowException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                    },
                };


            Car car = new Car();

            List<Action> actions = new()
            {
                ()=>
                {
                     Console.WriteLine($"\nВведите данные о двигателе");
                     car.Motor = ReadMotor(car);
                },

                ()=>
                {
                    Console.Write($"\nВведите массу машины в тоннах" +
                        $" (нажмите Enter): ");
                    car.Mass = Convert.ToDouble(Console.ReadLine());
                },
            };

            ActionsHandler(actions, catchDictionary);

            return car;
        }

        /// <summary>
        /// Метод Ввода данных о Вертолете.
        /// </summary>
        /// <returns>Вертолет.</returns>
        public static Helicopter ReadHelicopter()
        {
            Dictionary<Type, Action<string>> catchDictionary =
                new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
                {
                    typeof(OverflowException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
            };

            Helicopter helicopter = new Helicopter();

            List<Action> actions = new()
            {
                ()=>
                {
                     Console.WriteLine($"\nВведите данные о двигателе");
                     helicopter.Motor = ReadMotor(helicopter);
                },

                ()=>
                {
                    Console.Write($"\nВведите массу вертолета в тоннах" +
                        $" (нажмите Enter): ");
                    helicopter.Mass = Convert.ToDouble(Console.ReadLine());
                },
                ()=>
                {
                    Console.Write($"\nВведите длину лопастей вертолета в" +
                        $" метрах (нажмите Enter): ");
                    helicopter.BladeLength = Convert.ToDouble(Console.ReadLine());
                },
            };

            ActionsHandler(actions, catchDictionary);

            return helicopter;
        }

        /// <summary>
        /// Метод Ввода данных о Гибридной машине.
        /// </summary>
        /// <returns>Гибридная машина.</returns>
        public static HybridCar ReadHybridCar()
        {
            Dictionary<Type, Action<string>> catchDictionary =
                new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
                {
                    typeof(OverflowException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
            };

            HybridCar hybridCar = new HybridCar();

            List<Action> actions = new()
            {
                ()=>
                {
                     Console.WriteLine($"\nВведите данные об основном" +
                         $" двигателе");
                     hybridCar.Motor = ReadMotor(hybridCar);
                },

                ()=>
                {
                    Console.WriteLine($"\nВведите данные о дополнительном" +
                        $" двигателе");
                    hybridCar.AdditionalMotor = ReadMotor(hybridCar.Motor);
                },

                ()=>
                {
                    Console.Write($"\nВведите массу машины в тоннах" +
                        $" (нажмите Enter): ");
                    hybridCar.Mass = Convert.ToDouble(Console.ReadLine());
                },
            };

            ActionsHandler(actions, catchDictionary);

            return hybridCar;
        }

        /// <summary>
        /// Метод Ввода данных о Двигателе.
        /// </summary>
        /// <param name="transport">Объект транспорт.</param>
        /// <returns>Двигатель.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Выход
        /// за пределы.</exception>
        public static Motor ReadMotor(TransportBase transport)
        {
            Dictionary<Type, Action<string>> catchDictionary =
                new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentOutOfRangeException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
                {
                    typeof(ArgumentException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
                {
                    typeof(OverflowException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
            };

            Motor motor = new Motor();

            List<Action> actions = new()
            {
                ()=>
                {
                    Dictionary<char, TypeFuel> сonsumptionFuel;
                    char keyInfo;

                    Console.WriteLine($"\n\tВыберите вид топлива: ");

                    if (transport is Car || transport is HybridCar)
                    {
                        Console.WriteLine($"\t1 - бензин" +
                                         "\n\t2 - дизель" +
                                         "\n\t3 - электричество" +
                                         "\n\t4 - газ");

                        keyInfo = Console.ReadKey().KeyChar;

                        сonsumptionFuel = new()
                        {
                            {'1', TypeFuel.Petrol},
                            {'2', TypeFuel.Diesel},
                            {'3', TypeFuel.Electricity},
                            {'4', TypeFuel.Gas},
                        };
                    }
                    else
                    {
                        Console.WriteLine($"\n\t1 - авиационный керосин" +
                                           "\n\t2 - авиационный бензин");

                        keyInfo = Console.ReadKey().KeyChar;

                        сonsumptionFuel = new()
                        {
                            {'1', TypeFuel.AviationKerosene},
                            {'2', TypeFuel.AviationGasoline},
                        };
                    }

                    if(!сonsumptionFuel.ContainsKey(keyInfo))
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                     motor.TypeFuel = сonsumptionFuel[keyInfo];
                },

                ()=>
                {
                    Console.Write($"\n\tВведите мощность двигателя в л.с " +
                        $"(нажмите Enter): ");

                    motor.Capacity = Convert.ToDouble(Console.ReadLine());
                },
            };

            ActionsHandler(actions, catchDictionary);

            return motor;
        }

        /// <summary>
        /// Метод Ввода данных о Гибридном Двигателе.
        /// </summary>
        /// <param name="motor">Основной двигатель.</param>
        /// <returns>Гибридный двигатель.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Выход
        /// за пределы.</exception>
        public static Motor ReadMotor(Motor motor)
        {
            Dictionary<Type, Action<string>> catchDictionary =
                new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentOutOfRangeException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
                {
                    typeof(ArgumentException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
                {
                    typeof(OverflowException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
            };

            Motor additionalMotor = new Motor();

            List<Action> actions = new()
            {
                ()=>
                {
                   Console.WriteLine($"\n\tВыберите вид топлива: " +
                        "\n\t1 - бензин" +
                        "\n\t2 - дизель" +
                        //BUG:
                        "\n\t3 - электричество" +
                        "\n\t4 - газ");

                   char keyInfo = Console.ReadKey().KeyChar;

                   Dictionary<char, TypeFuel> сonsumptionFuel = new()
                   {
                        {'1', TypeFuel.Petrol},
                        {'2', TypeFuel.Diesel},
                        {'3', TypeFuel.Electricity},
                        {'4', TypeFuel.Gas},
                   };

                   if(!сonsumptionFuel.ContainsKey(keyInfo))
                   {
                       throw new ArgumentOutOfRangeException();
                   }

                   if (сonsumptionFuel[keyInfo] != motor.TypeFuel)
                   {
                       additionalMotor.TypeFuel = сonsumptionFuel[keyInfo];
                   }
                   else
                   {
                       throw new ArgumentException ("Гибридная машина " +
                           "не может иметь одинаковые двигатели");
                   }
                },

                ()=>
                {
                    Console.Write($"\n\tВведите мощность двигателя в л.с " +
                        $"(нажмите Enter): ");

                    motor.Capacity = Convert.ToDouble(Console.ReadLine());
                },
            };

            ActionsHandler(actions, catchDictionary);

            return additionalMotor;
        }

        /// <summary>
        /// Метод Расчета расхода топлива.
        /// </summary>
        /// <param name="transport">Объект транспорт.</param>
        public static void СalculateСonsumptionFuel(TransportBase transport)
        {
            Dictionary<Type, Action<string>> catchDictionary =
                new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentOutOfRangeException),
                    (string message) =>
                    {
                        Console.WriteLine($"\nИсключение: {message}");
                    }
                },
            };

            Action action =
                () =>
                {
                    //TODO: to switch case pattern matching
                    if (transport is HybridCar newHybridCar)
                    {
                        Console.Write($"\nВведите расстояние в км для двигателя," +
                            $" работающего на {newHybridCar.Motor.TypeFuel} " +
                            $"(нажмите Enter): ");

                        double firstDistance = Convert.ToDouble(Console.ReadLine());

                        ReadPositiveDouble(firstDistance);

                        Console.Write($"\nВведите расстояние в км для двигателя," +
                            $" работающего на {newHybridCar.AdditionalMotor.TypeFuel}" +
                            $" (нажмите Enter): ");

                        double secondDistance = Convert.ToDouble(Console.ReadLine());

                        ReadPositiveDouble(secondDistance);

                        var consumption = newHybridCar.CalculateFuel(firstDistance, secondDistance);

                        var consumptionBasic = Math.Round(consumption.Item1, 1);
                        var consumptionAdd = Math.Round(consumption.Item2, 1);

                        Console.Write($"\nРасход топлива для прохождения расстояния" +
                            $" {firstDistance} км составит {consumptionBasic} л." +
                            $", для {secondDistance} км - {consumptionAdd} л.\n");
                    }
                    else if (transport is Car newCar)
                    {
                        Console.Write("\nВведите расстояние в км (нажмите Enter): ");

                        double distance = Convert.ToDouble(Console.ReadLine());

                        ReadPositiveDouble(distance);

                        Console.Write($"\nРасход топлива для прохождения расстояния" +
                           $" {distance} км составит" +
                           $" {Math.Round(newCar.CalculateFuel(distance), 1)} л.\n");
                    }

                    else if (transport is Helicopter newHelicopter)
                    {
                        Console.Write("\nВведите длительность полета в часах" +
                            " (нажмите Enter): ");

                        double distance = Convert.ToDouble(Console.ReadLine());

                        ReadPositiveDouble(distance);

                        Console.Write($"\nРасход топлива для полета {distance} ч" +
                            $" составит {Math.Round(newHelicopter.CalculateFuel(distance), 1)} л.\n");
                    }
                };

            ActionHandler(action, catchDictionary);
        }

        /// <summary>
        /// Метод проверки на ввод положительного числа.
        /// </summary>
        /// <param name="value">.</param>
        private static void ReadPositiveDouble(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Число должно быть" +
                    " положительным");
            }
        }

        /// <summary>
        /// Метод Обработки действий.
        /// </summary>
        /// <param name="assignActions">Действие требующее проверки.</param>
        /// <param name="catchDictionary">Словарь исключений.</param>
        private static void ActionsHandler(List<Action> assignActions,
            Dictionary<Type, Action<string>> catchDictionary)
        {
            foreach (var assignAction in assignActions)
            {
                ActionHandler(assignAction, catchDictionary);
            }
        }

        /// <summary>
        /// Метод Обработки действия.
        /// </summary>
        /// <param name="assignAction">Действие требующее проверки.</param>
        /// <param name="catchDictionary">Словарь исключений.</param>
        private static void ActionHandler(Action assignAction,
            Dictionary<Type, Action<string>> catchDictionary)
        {
            while (true)
            {
                try
                {
                    assignAction.Invoke();
                    break;
                }
                catch (Exception ex)
                {
                    catchDictionary[ex.GetType()].Invoke(ex.Message);
                }
            }
        }
    }
}
