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

            var catchDictionary = GetCatchDictionary();

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
            var catchDictionary = GetCatchDictionary();

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
                    car.Mass = ReadMassInTons();
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
            var catchDictionary = GetCatchDictionary();

            Helicopter helicopter = new Helicopter();

            List<Action> actions = new()
            {
                ()=>
                {
                     Console.WriteLine($"\nВведите данные о двигателе");
                     helicopter.Motor.Capacity = ReadHelicopterEnginePower();
                },

                ()=>
                {
                    helicopter.Mass = ReadHelicopterMassInTons();
                },
                ()=>
                {
                    helicopter.BladeLength = ReadBladeLength();
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
            var catchDictionary = GetCatchDictionary();

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
                    hybridCar.AdditionalMotor = ReadAdditionalMotor(hybridCar.Motor);
                },

                ()=>
                {
                    hybridCar.Mass = ReadMassInTons();
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
            var catchDictionary = GetCatchDictionary();

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
                    motor.Capacity = ReadEnginePower(motor.TypeFuel);
                },
            };

            ActionsHandler(actions, catchDictionary);

            return motor;
        }

        /// <summary>
        /// Метод Ввода данных о Гибридном Двигателе.
        /// </summary>
        /// <param name="mainMotor">Основной двигатель.</param>
        /// <returns>Гибридный двигатель.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Выход
        /// за пределы.</exception>
        public static Motor ReadAdditionalMotor(Motor mainMotor)
        {
            var catchDictionary = GetCatchDictionary();

            Motor additionalMotor = new Motor();

            List<Action> actions = new()
            {
                () =>
                {
                    Console.WriteLine($"\n\tВыберите вид топлива для дополнительного двигателя: " +
                    "\n\t1 - бензин" +
                    "\n\t2 - дизель" +
                    "\n\t3 - электричество" +
                    "\n\t4 - газ");

                    char keyInfo = Console.ReadKey().KeyChar;

                    Dictionary<char, TypeFuel> consumptionFuel = new()
                    {
                        { '1', TypeFuel.Petrol },
                        { '2', TypeFuel.Diesel },
                        { '3', TypeFuel.Electricity },
                        { '4', TypeFuel.Gas },
                    };

                    if (!consumptionFuel.ContainsKey(keyInfo))
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    additionalMotor.TypeFuel = consumptionFuel[keyInfo];

                    if (additionalMotor.TypeFuel == mainMotor.TypeFuel)
                    {
                        throw new ArgumentException ("Гибридная машина " +
                            "не может иметь одинаковые двигатели");
                    }
                },
                () =>
                {
                    additionalMotor.Capacity = ReadEnginePower(additionalMotor.TypeFuel);
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
            var catchDictionary = GetCatchDictionary();

            Action action =
                () =>
                {
                    switch (transport)
                    {
                        case HybridCar newHybridCar:
                        {
                            Console.Write($"\nВведите расстояние в км для двигателя, " +
                                $"работающего на {newHybridCar.Motor.TypeFuel} " +
                                $"(нажмите Enter): ");

                            double firstDistance = Convert.ToDouble(Console.ReadLine());
                            ReadPositiveDouble(firstDistance);

                            Console.Write($"\nВведите расстояние в км для двигателя, " +
                                $"работающего на {newHybridCar.AdditionalMotor.TypeFuel} " +
                                $"(нажмите Enter): ");

                            double secondDistance = Convert.ToDouble(Console.ReadLine());
                            ReadPositiveDouble(secondDistance);

                            var consumption = newHybridCar.CalculateFuel(firstDistance, secondDistance);
                            var consumptionBasic = Math.Round(consumption.Item1, 1);
                            var consumptionAdd = Math.Round(consumption.Item2, 1);

                            string unitBasic = 
                            (newHybridCar.Motor.TypeFuel == TypeFuel.Electricity) ? "кВт·ч" : "л";
                            string unitAdd = 
                            (newHybridCar.AdditionalMotor.TypeFuel == TypeFuel.Electricity) ? "кВт·ч" : "л";

                            Console.Write($"\nРасход топлива для прохождения расстояния " +
                                $"{firstDistance} км составит {consumptionBasic} {unitBasic}. " +
                                $"Для {secondDistance} км - {consumptionAdd} {unitAdd}.\n");
                        }
                        break;

                        case Car newCar:
                        {
                            Console.Write("\nВведите расстояние в км (нажмите Enter): ");
                            double distance = Convert.ToDouble(Console.ReadLine());
                            ReadPositiveDouble(distance);

                            double consumption = newCar.CalculateFuel(distance);
                            string unit = newCar.Motor.TypeFuel == TypeFuel.Electricity ? "кВт·ч" : "л";

                            Console.Write($"\nРасход топлива для прохождения расстояния " +
                                $"{distance} км составит " +
                                $"{Math.Round(consumption, 1)} {unit}.\n");
                        }
                        break;

                        case Helicopter newHelicopter:
                        {
                            Console.Write("\nВведите длительность полета в часах (нажмите Enter): ");
                            double flightHours = Convert.ToDouble(Console.ReadLine());
                            ReadPositiveDouble(flightHours);
                            Console.Write($"\nРасход топлива для полета {flightHours} ч " +
                                $"составит {Math.Round(newHelicopter.CalculateFuel(flightHours), 1)} л.\n");
                        }
                        break;

                        default:
                        {
                            Console.WriteLine("Неизвестный тип транспорта.");
                        }
                        break;
                    }
                };

            ActionHandler(action, catchDictionary);
        }

        /// <summary>
        /// Метод ввода мощности двигателя в л.с.
        /// </summary>
        /// <returns>
        public static double ReadEnginePower(TypeFuel fuelType)
        {
            double power;
            do
            {
                Console.Write($"\n\tВведите мощность двигателя в л.с. " +
                      $"(не более {GetMaxPowerByFuelType(fuelType)} л.с.) (нажмите Enter): ");
                power = Convert.ToDouble(Console.ReadLine());

                if (power < GetMinPowerByFuelType(fuelType) || power > GetMaxPowerByFuelType(fuelType))
                {
                    Console.WriteLine($"\n\tПожалуйста, введите мощность двигателя в пределах от " +
                        $"{GetMinPowerByFuelType(fuelType)} до {GetMaxPowerByFuelType(fuelType)} л.с.");
                }
            } while (power < GetMinPowerByFuelType(fuelType) || power > GetMaxPowerByFuelType(fuelType));

            return power;
        }

        /// <summary>
        /// Метод ввода массы автомобиля в тоннах.
        /// </summary>
        /// <returns>
        public static double ReadMassInTons()
        {
            double mass;
            do
            {
                Console.Write($"\n\tВведите массу машины в тоннах (не более 10 тонн)" +
                        $" (нажмите Enter): ");
                
                mass = Convert.ToDouble(Console.ReadLine());

                if (mass < 0.1 || mass > 10.0)
                {
                    Console.WriteLine($"\n\tПожалуйста, введите массу в пределах от 0,1 до 10 тонн.");
                }
            } while (mass < 0.1 || mass > 10.0);

            return mass;
        }

        /// <summary>
        /// Метод ввода мощности вертолета в л.с. с учетом ограничений.
        /// </summary>
        /// <returns>Мощность вертолета в л.с.</returns>
        public static double ReadHelicopterEnginePower()
        {
            double power;
            do
            {
                Console.Write($"\n\tВведите мощность двигателя вертолета в л.с. (не более 3600 л.с.)" +
                              $" (нажмите Enter): ");
                power = Convert.ToDouble(Console.ReadLine());

                if (power < 110 || power > 3600)
                {
                    Console.WriteLine($"\n\tПожалуйста, введите мощность двигателя в пределах от 110 до 3600 л.с.");
                }
            } while (power < 110 || power > 3600);

            return power;
        }

        /// <summary>
        /// Метод ввода массы вертолета в тоннах с учетом ограничений.
        /// </summary>
        /// <returns>Масса вертолета в тоннах.</returns>
        public static double ReadHelicopterMassInTons()
        {
            double mass;
            do
            {
                Console.Write($"\n\tВведите массу вертолета в тоннах (не более 23 тонн)" +
                              $" (нажмите Enter): ");

                mass = Convert.ToDouble(Console.ReadLine());

                if (mass < 0.1 || mass > 23)
                {
                    Console.WriteLine($"\n\tПожалуйста, введите массу в пределах от 0,1 до 23 тонн.");
                }
            } while (mass < 0.1 || mass > 23);

            return mass;
        }

        /// <summary>
        /// Метод ввода длины лопастей вертолета в метрах с учетом ограничений.
        /// </summary>
        /// <returns>Длина лопастей вертолета в метрах.</returns>
        public static double ReadBladeLength()
        {
            double length;
            do
            {
                Console.Write($"\n\tВведите длину лопастей вертолета в метрах (не более 10 метров)" +
                              $" (нажмите Enter): ");

                length = Convert.ToDouble(Console.ReadLine());

                if (length < 1 || length > 10) 
                {
                    Console.WriteLine($"\n\tПожалуйста, введите длину в пределах от 1 до 10 метров.");
                }
            } while (length < 1 || length > 10);

            return length;
        }

        /// <summary>
        /// Метод получения минимальной допустимой мощности для заданного типа топлива.
        /// </summary>
        /// <param name="fuelType">Тип топлива.</param>
        /// <returns>Минимальная мощность в л.с.</returns>
        private static double GetMinPowerByFuelType(TypeFuel fuelType)
        {
            return (fuelType == TypeFuel.Electricity) ? 1 : 1;
        }

        /// <summary>
        /// Метод получения максимальной допустимой мощности для заданного типа топлива.
        /// </summary>
        /// <param name="fuelType">Тип топлива.</param>
        /// <returns>Максимальная мощность в л.с.</returns>
        private static double GetMaxPowerByFuelType(TypeFuel fuelType)
        {
            return (fuelType == TypeFuel.Electricity) ? 800 : 1000;
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
        /// Словарь для обработки исключений.
        /// </summary>
        /// </returns>
        private static Dictionary<Type, Action<string>> GetCatchDictionary()
        {
            return new Dictionary<Type, Action<string>>
            {
                {
                    typeof(ArgumentOutOfRangeException),
                    (msg) => Console.WriteLine($"\nИсключение: {msg}")
                },
                {
                    typeof(ArgumentException),
                    (msg) => Console.WriteLine($"\nИсключение: {msg}")
                },
                {
                    typeof(FormatException),
                    (msg) => Console.WriteLine($"\nИсключение: {msg}")
                },
                {
                    typeof(OverflowException),
                    (msg) => Console.WriteLine($"\nИсключение: {msg}")
                },
            };

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
