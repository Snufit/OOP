using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PersonLibrary
{
    /// <summary>
    /// Класс Person.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст.
        /// </summary>
        private int _age;

        /// <summary>
        /// Гендер.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="surname">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Гендер.</param>
        public Person(string name, string surname, int age, Gender gender)
        {
            _name = name;
            _surname = surname;
            _age = age;
            Gender = gender;
        }

        /// <summary>
        /// Конструктор класса по умолчанию.
        /// </summary>
        public Person() : this("Иван", "Иванов", 0, Gender.Male)
        { }

        /// <summary>
        /// Получение информации о персоне.
        /// </summary>
        /// <returns>Строка с данными полей объекта класса Person.</returns>
        public string GetInfo()
        {
            return $"{Name} {Surname}, возраст: {Age}, пол: {Gender}\n";
        }

        /// <summary>
        /// Задание имени.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (IsNameOrSurnameValid(value))
                {
                    _name = CheckRegister(value);
                }
                else
                {
                    throw new ArgumentException
                        ("Имя должно быть написано на одном языке.\n" +
                        "Имя может быть двойным и записано через дефис.");
                }
            }
        }

        /// <summary>
        /// Задание фамилии.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (IsNameOrSurnameValid(value)
                    && IsNameAndSurnameValid(_name, value))
                {
                    _surname = CheckRegister(value);
                }
                else
                {
                    throw new ArgumentException
                        ("Фамилия может быть двойной и записана через дефис.\n" +
                         "Фамилия и имя должны быть введены на одном языке.");
                }
            }
        }

        /// <summary>
        /// Преобразование имени и фамилии в правильные регистры.
        /// </summary>
        /// <param name="name">Имя или Фамилия.</param>
        /// <returns>Имя и фамилию в правильном регистре.</returns>
        public string CheckRegister(string name)
        {
            TextInfo txt = CultureInfo.CurrentCulture.TextInfo;
            return txt.ToTitleCase(name.ToLower());
        }

        /// <summary>
        /// Патерн русского языка.
        /// </summary>
        private const string _russianLanguageCheck = @"(^[а-яА-Я]+-?[а-яА-Я]+$)";

        /// <summary>
        /// Патерн английского языка.
        /// </summary>
        private const string _englishLanguageCheck = @"(^[a-zA-Z]+-?[a-zA-Z]+$)";

        /// <summary>
        /// Проверка того, что имя или фамилия введены на одном языке.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <returns>true, если имя или фамилия введены на одном языке;
        /// false, если на разных языках.</returns>
        public bool IsNameOrSurnameValid(string name)
        {
            return (Regex.IsMatch(name, _russianLanguageCheck)
                || Regex.IsMatch(name, _englishLanguageCheck));
        }

        /// <summary>
        /// Проверка того, что имя и фамилия введены на одном языке.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="surname">Фамилия.</param>
        /// <returns>true, если имя и фамилия введены на одном языке;
        /// false, если на разных языках.</returns>
        public bool IsNameAndSurnameValid(string name, string surname)
        {
            return (Regex.IsMatch(name, _russianLanguageCheck) &&
                Regex.IsMatch(surname, _russianLanguageCheck))
                || (Regex.IsMatch(name, _englishLanguageCheck) &&
                Regex.IsMatch(surname, _englishLanguageCheck));
        }

        /// <summary>
        /// Минимальный возраст.
        /// </summary>
        public const int MinAge = 1;

        /// <summary>
        /// Максимальный возраст.
        /// </summary>
        public const int MaxAge = 122;

        /// <summary>
        /// Задание возраста.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (value >= MinAge && value <= MaxAge)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException
                        ($"Возраст должен находиться в пределах " +
                        $"от {MinAge} года до {MaxAge} лет");
                }
            }
        }
    }
}