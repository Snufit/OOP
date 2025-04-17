using System;
using System.Text.RegularExpressions;

namespace PersonLibrary
{
    /// <summary>
    /// Класс Adult.
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Поле номера паспорта.
        /// </summary>
        private string _numberPassport;

        /// <summary>
        /// Поле серии паспорта.
        /// </summary>
        private string _seriesPassport;

        /// <summary>
        /// Поле партнера.
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Поле работы.
        /// </summary>
        private string _job;

        /// <inheritdoc/>
        public override int MinAge { get; } = 18;

        /// <summary>
        /// Количество цифр в серии паспорта.
        /// </summary>
        public const int PassportSeriesDigits = 4;

        /// <summary>
        /// Количество цифр в номере паспорта.
        /// </summary>
        public const int PassportNumberDigits = 6;

        /// <summary>
        /// Конструктор класса Adult.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="surname">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="numberPassport">Номер паспорта.</param>
        /// <param name="seriesPassport">Серия паспорта.</param>
        /// <param name="partner">Партнер.</param>
        /// <param name="job">Работа.</param>
        public Adult(string name, string surname, int age, Gender gender,
            string numberPassport, string seriesPassport, Adult partner,
            string job)
            : base(name, surname, age, gender)
        {
            _numberPassport = numberPassport;
            _seriesPassport = seriesPassport;
            _partner = partner;
            _job = job;
        }

        /// <summary>
        /// Конструктор класса Adult по умолчанию.
        /// </summary>
        public Adult() : this("Иван", "Иванов", 0, Gender.Male,
            "", "", null, null)
        { }

        /// <summary>
        /// Задание номера паспорта.
        /// </summary>
        public string NumberPassport
        {
            get
            {
                return _numberPassport;
            }

            set
            {
                if (value.Length == PassportNumberDigits
                    && IsSeriesOrNumberPassportValid(value))
                {
                    _numberPassport = value;
                }
                else
                {
                    throw new ArgumentException
                        ($"Номер паспорта должен содержать " +
                        $"{PassportNumberDigits} цифр");
                }
            }
        }

        /// <summary>
        /// Задание серии паспорта.
        /// </summary>
        public string SeriesPassport
        {
            get
            {
                return _seriesPassport;
            }

            set
            {
                if (value.Length == PassportSeriesDigits
                    && IsSeriesOrNumberPassportValid(value))
                {
                    _seriesPassport = value;
                }
                else
                {
                    throw new ArgumentException
                        ($"Серия паспорта должна содержать " +
                        $"{PassportSeriesDigits} цифры");
                }
            }
        }

        public Adult Partner
        {
            get
            {
                return _partner;
            }
            set
            {
                if (value != null && value.Gender == Gender)
                {
                    throw new ArgumentException
                        ("Однополые браки запрещены в РФ " +
                        "(Семейный кодекс РФ)");
                }

                if (value != null)
                {
                    value._partner = this;
                }

                _partner = value;
            }
        }

        /// <summary>
        /// Задание работы.
        /// </summary>
        public string Job
        {
            get { return _job; }
            set
            {
                _job = string.IsNullOrWhiteSpace(value)
                    ? "Безработный" : value;
            }
        }

        /// <summary>
        /// Получение информации о взрослом.
        /// </summary>
        /// <returns>Строка с данными полей объекта класса Adult.</returns>
        public override string GetInfo()
        {
            string partner = string.Empty;

            if (Gender == Gender.Male && Partner == null)
            {
                partner = "Не женат";
            }

            if (Gender == Gender.Female && Partner == null)
            {
                partner = "Не замужем";
            }

            if (Partner != null)
            {
                partner = Partner.Surname + " " + Partner.Name;
            }

            if (Job == null)
            {
                Job = "Безработный";
            }

            return base.GetInfo() + $", серия паспорта: {SeriesPassport}, " +
                $"номер паспорта: {NumberPassport}, партнер: {partner}, " +
                $"место работы: {Job}\n";
        }

        /// <summary>
        /// Проверка того, что серия и номер паспорта содержат только цифры.
        /// </summary>
        /// <param name="pasport">Серия или номер паспорта.</param>
        /// <returns>true, если серия или номер паспорта содержат 
        /// только цифры; false, если и символы.</returns>
        public bool IsSeriesOrNumberPassportValid(string pasport)
        {
            return Regex.IsMatch(pasport, @"^\d+$");
        }

        /// <summary>
        /// Метод для класса Adult.
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetExtraIncome()
        {
            return "Ищет дополнительный заработок, чтобы содержать семью";
        }
    }
}