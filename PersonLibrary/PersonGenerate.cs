using System;

namespace PersonLibrary
{
    /// <summary>
    /// Класс PersonGenerate для 
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
                "Арагорн", "Леголас", "Гимли", "Фродо", "Сэм", "Боромир",
                "Гэндальф", "Торин", "Саруман", "Галадриэль",
            };

            string[] femaleName =
            {
                "Арвен", "Эовин", "Галадриэль", "Сэдила", "Миракель",
                "Танувиэль", "Дисенна", "Грейс", "Ниндорин", "Иленда",
            };

            string[] maleSurname =
            {
                "Баггинс", "Грейдоз", "Суммер", "Брандибак", "Оакеншилд",
                "Лотарингий", "Татуин", "Дукодин", "Сарибан", "Мордор",
            };

            string[] femaleSurname =
            {
                "Тинвэ", "Линдерион", "Роселл", "Фелинор", "Атфилла",
                "Минарэль", "Сильварис", "Аэлис", "Истрия", "Таннтель",
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