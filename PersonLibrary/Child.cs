using System;

namespace PersonLibrary
{
    /// <summary>
    /// Класс Child.
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Поле мамы.
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Поле папы.
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Поле места обучения.
        /// </summary>
        private string _placeOfStudy;

        /// <inheritdoc/>
        public override int MaxAge { get; } = 17;

        /// <summary>
        /// Конструктор класса Child.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="surname">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="mother">Мама.</param>
        /// <param name="father">Папа.</param>
        /// <param name="placeOfStudy">Место обучения.</param>
        public Child(string name, string surname, int age, Gender gender,
            Adult mother, Adult father, string placeOfStudy)
            : base(name, surname, age, gender)
        {
            _mother = mother;
            _father = father;
            _placeOfStudy = placeOfStudy;
        }

        /// <summary>
        /// Конструктор класса Child по умолчанию.
        /// </summary>
        public Child() : this("Иван", "Иванов", 0, Gender.Male,
            null, null, null)
        { }

        /// <summary>
        /// Задание мамы.
        /// </summary>
        public Adult Mother
        {
            get
            {
                return _mother;
            }
            set
            {
                if (value != null && value.Gender != Gender.Female)
                {
                    throw new ArgumentException
                        ("Мама должна быть женского пола.");
                }
                _mother = value;
            }
        }

        /// <summary>
        /// Задание папы.
        /// </summary>
        public Adult Father
        {
            get
            {
                return _father;
            }
            set
            {
                if (value != null && value.Gender != Gender.Male)
                {
                    throw new ArgumentException
                        ("Папа должен быть мужского пола.");
                }
                _father = value;
            }
        }

        /// <summary>
        /// Задание места обучения.
        /// </summary>
        public string PlaceOfStudy
        {
            get { return _placeOfStudy; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        ("Ребенок нигде не обучается.");
                }
                _placeOfStudy = value;
            }
        }

        /// <summary>
        /// Получение информации о ребенке.
        /// </summary>
        /// <returns>Строка с данными полей объекта класса Child.</returns>
        public override string GetInfo()
        {
            string infoMother = Mother.Surname + " " + Mother.Name;
            string infoFather = Father.Surname + " " + Father.Name;

            if (Mother == null)
            {
                infoMother = "Нет матери";
            }

            if (Father == null)
            {
                infoFather = "Нет отца";
            }

            return base.GetInfo() + $", мама: {infoMother}, " +
                $"папа: {infoFather}, место обучения: {PlaceOfStudy}\n";
        }

        /// <summary>
        /// Метод для класса Child.
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetChewingGum()
        {
            return "Жует жвачку и не слушает преподавателя";
        }
    }
}