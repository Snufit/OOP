using System;

namespace PersonLibrary
{
    /// <summary>
    /// Клас PersonGenerate для 
    /// создания рандомного человека.
    /// </summary>
    public class PersonGenerate
    {
        /// <summary>
        /// Метод создания рандомного человека.
        /// </summary>
        /// <returns>Объект класса Person.</returns>
        public static Person GenerateRandomPerson()
        {
            string[] maleName =
            {
                "Игорь", "Олег", "Геннадий", "Павел", "Максим", "Ефим",
                "Руслан", "Лаврентий", "Тарас", "Тимур",
            };

            string[] femaleName =
            {
                "Зоя", "Полина", "Валерия", "Ангелина", "Анастасия",
                "Галина", "Оксана", "Марина", "Елена", "Яна",
            };

            string[] maleSurname =
            {
                "Иванов", "Смирнов", "Кузнецов", "Попов", "Васильев",
                "Петров", "Соколов", "Михайлов", "Новиков", "Федоров",
            };

            string[] femaleSurname =
            {
                "Цветаева", "Лебедева", "Соболева", "Громова", "Глебова",
                "Степанова", "Андреева", "Журавлева", "Белова", "Дорохова",
            };

            Random random = new Random();

            Person person = new Person();

            person.Age = random.Next(Person.MinAge, Person.MaxAge);

            person.Gender = (Gender)random.Next(2);

            switch (person.Gender)
            {
                case Gender.Male:
                    {
                        person.Name = maleName[
                        random.Next(0, maleName.Length)];
                        person.Surname = maleSurname[
                            random.Next(0, maleSurname.Length)];
                        break;
                    }
                case Gender.Female:
                    {
                        person.Name = femaleName[
                        random.Next(0, femaleName.Length)];
                        person.Surname = femaleSurname[
                            random.Next(0, femaleSurname.Length)];
                        break;
                    }
            }

            return person;
        }
    }
}