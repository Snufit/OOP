using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Object_oriented_programming
{
    /// <summary>
    /// Класс ConsoleInputPerson.
    /// </summary>
    public class ConsoleInputPerson
    {
        /// <summary>
        /// Чтение персоны с клавиатуры.
        /// </summary>
        /// <returns>Объект класса Person.</returns>
        public static Person ReadPersonFromConsole()
        {
            Console.WriteLine("Введите данные о персоне:");

            Person person = new Person();

            List<Action> actions = new List<Action>()
            {
                () =>
                    {
                        Console.Write("Имя: ");
                        person.Name = Console.ReadLine();
                    },
                () =>
                    {
                        Console.Write("Фамилия: ");
                        person.Surname = Console.ReadLine();
                    },
                () =>
                    {
                        Console.Write("Возраст: ");
                        if (!int.TryParse(Console.ReadLine(), out int age))
                        {
                            throw new FormatException
                                ($"Возраст - это число " +
                                $"от {Person.MinAge} до {Person.MaxAge}");
                        }
                        person.Age = age;
                    },
                () =>
                    {
                        Console.Write("Пол: 0, 'м' или 'M' для Мужского; " +
                        "1, 'ж' или 'F' для Женского\n");
                        string genderConsole = Console.ReadLine().ToLower();

                        switch (genderConsole)
                        {
                            case "0":
                            case "м":
                            case "m":
                            {
                                person.Gender = Gender.Male;
                                break;
                            }
                            case "1":
                            case "ж":
                            case "f":
                            {
                                person.Gender = Gender.Female;
                                break;
                            }
                            default:
                                throw new ArgumentException
                                    ("Некорректный ввод пола.\n" +
                                     "Пожалуйста, введите 0, 'м' или 'M' для " +
                                     "Мужского; 1, 'ж' или 'F' для Женского.");
                        }
                    },
            };

            foreach (var action in actions)
            {
                ActionHandler(action);
            }

            return person;
        }

        /// <summary>
        /// Получение значений, введенных пользователем.
        /// </summary>
        /// <param name="action">Действие.</param>
        public static void ActionHandler(Action action)
        {
            List<Type> exceptionTypes = new List<Type>
            {
                typeof(ArgumentException),
                typeof(FormatException),
                typeof(ArgumentOutOfRangeException),
            };

            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception exception)
                {
                    if (exceptionTypes.Contains(exception.GetType()))
                    {
                        Console.WriteLine(exception.Message);
                    }
                    else
                    {
                        throw exception;
                    }
                }
            }
        }
    }
}