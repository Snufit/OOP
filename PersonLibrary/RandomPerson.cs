using System;

namespace PersonLibrary
{
    //TODO: rename +
    /// <summary>
    /// Клас GetRandomPerson для 
    /// создания рандомного человека.
    /// </summary>
    public class GetRandomPerson
    {
        /// <summary>
        /// Метод присоения полям Person рандомных значений.
        /// </summary>
        /// <param name="person">Объект класса Person.</param>
        public static void SetRandomPerson(PersonBase person)
        {
            string[] maleName =
            {
                "Игорь", "Олег", "Геннадий", "Павел",
                "Максим", "Ефим", "Руслан", "Лаврентий",
                "Тарас", "Тимур",
            };

            string[] femaleName =
            {
                "Зоя", "Полина", "Валерия", "Ангелина",
                "Анастасия", "Галина", "Оксана", "Марина",
                "Елена", "Яна",
            };

            string[] maleSurname =
            {
                "Иванов", "Смирнов", "Кузнецов", "Попов",
                "Васильев", "Петров", "Соколов", "Михайлов",
                "Новиков", "Федоров",
            };

            string[] femaleSurname =
            {
                "Цветаева", "Лебедева", "Соболева", "Громова",
                "Глебова", "Степанова", "Андреева", "Журавлева",
                "Белова", "Дорохова",
            };

            Random random = new Random
                (Guid.NewGuid().GetHashCode());

            person.Age = random.Next(person.MinAge, person.MaxAge);

            person.Gender = (Gender)random.Next(2);

            switch (person.Gender)
            {
                case Gender.Male:
                    {
                        person.Name = maleName
                                [random.Next(0, maleName.Length)];
                        person.Surname = maleSurname
                                [random.Next(0, maleSurname.Length)];
                        break;
                    }
                case Gender.Female:
                    {
                        person.Name = femaleName
                                [random.Next(0, femaleName.Length)];
                        person.Surname = femaleSurname
                                [random.Next(0, femaleSurname.Length)];
                        break;
                    }
            }
        }

        /// <summary>
        /// Метод присоения полям Person рандомных значений
        /// с заданным полом.
        /// </summary>
        /// <param name="person">Объект класса Person.</param>
        public static void SetRandomPerson(PersonBase person,
            Gender gender)
        {
            string[] maleName =
            {
                "Игорь", "Олег", "Геннадий", "Павел",
                "Максим", "Ефим", "Руслан", "Лаврентий",
                "Тарас", "Тимур",
            };

            string[] femaleName =
            {
                "Зоя", "Полина", "Валерия", "Ангелина",
                "Анастасия", "Галина", "Оксана", "Марина",
                "Елена", "Яна",
            };

            string[] maleSurname =
            {
                "Иванов", "Смирнов", "Кузнецов", "Попов",
                "Васильев", "Петров", "Соколов", "Михайлов",
                "Новиков", "Федоров",
            };

            string[] femaleSurname =
            {
                "Цветаева", "Лебедева", "Соболева", "Громова",
                "Глебова", "Степанова", "Андреева", "Журавлева",
                "Белова", "Дорохова",
            };

            Random random = new Random
                (Guid.NewGuid().GetHashCode());

            person.Age = random.Next(person.MinAge, person.MaxAge);

            if (gender == Gender.Male)
            {
                person.Gender = Gender.Male;
            }
            else if (gender == Gender.Female)
            {
                person.Gender = Gender.Female;
            }

            switch (person.Gender)
            {
                //TODO: RSDN +
                case Gender.Male:
                {
                    person.Name = maleName
                        [random.Next(0, maleName.Length)];
                    person.Surname = maleSurname
                        [random.Next(0, maleSurname.Length)];
                    break;
                }
                case Gender.Female:
                {
                    person.Name = femaleName
                         [random.Next(0, femaleName.Length)];
                    person.Surname = femaleSurname
                         [random.Next(0, femaleSurname.Length)];
                     break;
                }
            }
        }

        /// <summary>
        /// Метод присоения полям Adult рандомных значений.
        /// </summary>
        /// <param name="adult">Объект класса Adult.</param>
        public static void SetRandomAdult(Adult adult)
        {
            Random random = new Random
                (Guid.NewGuid().GetHashCode());

            string[] jobPlace =
            {
                "Газпром нефть", "Роснефть", "Магнит", "Росатом",
                "Почта России","Россети", "Сбер", "Роскосмос",
                "Норильский никель", "Русгидро", "Тинькофф",
            };

            adult.Job = jobPlace[random.Next(0, jobPlace.Length)];

            adult.Age = random.Next(adult.MinAge, adult.MaxAge);

            adult.SeriesPassport =
                PassportDataGeneration(Adult.PassportSeriesDigits);

            adult.NumberPassport =
                PassportDataGeneration(Adult.PassportNumberDigits);

            if (random.Next(2) == 0)
            {
                //TODO: RSDN +
                switch (adult.Gender)
                {
                    case Gender.Male:
                    {
                        adult.Partner = GetRandomAdult(Gender.Female);
                        break;
                    }
                    case Gender.Female:
                    {
                        adult.Partner = GetRandomAdult(Gender.Male);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Метод генерации паспортных данных.
        /// </summary>
        /// <param name="numberOfDigits">Кол-во цифр в номере 
        /// или серии паспорта.</param>
        /// <returns>Строку с номером или серией паспорта.</returns>
        private static string PassportDataGeneration
            (int numberOfDigits)
        {
            Random random = new Random
                (Guid.NewGuid().GetHashCode());
            string passportId = "";
            for (int i = 0; i < numberOfDigits; i++)
            {
                passportId += random.Next(0, 10).ToString();
            }

            return passportId;
        }

        /// <summary>
        /// Метод заполнения полей обьекта класса Adult.
        /// </summary>
        /// <returns>Объект класса Adult.</returns>
        public static Adult GetRandomAdult()
        {
            Adult adult = new Adult();
            SetRandomPerson(adult);
            SetRandomAdult(adult);
            return adult;
        }

        /// <summary>
        /// Метод заполнения полей обьекта класса Adult
        /// с заданным полем.
        /// </summary>
        /// <param name="gender">Пол.</param>
        /// <returns>Объект класса Adult.</returns>
        public static Adult GetRandomAdult(Gender gender)
        {
            Adult adult = new Adult();
            SetRandomPerson(adult, gender);
            SetRandomAdult(adult);
            return adult;
        }

        /// <summary>
        /// Метод присоения полям Child рандомных значений.
        /// </summary>
        /// <param name="adult">Объект класса Adult.</param>
        public static void SetRandomChild(Child child)
        {
            Random random = new Random
                (Guid.NewGuid().GetHashCode());

            string[] placeOfStudy =
            {
                "МБОУ СОШ №24»", "МОУ «СОШ №12»",
                "МБОУ «СОШ №1»", "Лицей им. Н.Г. Булакина»",
                "МБОУ «СОШ №6»", "МБОУ «СОШ №7»", "МБОУ «СОШ №8»",
            };

            child.PlaceOfStudy = placeOfStudy
                [random.Next(0, placeOfStudy.Length)];

            child.Age = random.Next(child.MinAge, child.MaxAge);

            Adult father = GetRandomAdult(Gender.Male);
            child.Father = father;

            Adult mother = GetRandomAdult(Gender.Female);
            child.Mother = mother;

            mother.Surname = father.Surname;
            mother.Surname += "а";

            if (child.Gender == Gender.Male)
            {
                child.Surname = father.Surname;
            }
            else if (child.Gender == Gender.Female)
            {
                child.Surname = mother.Surname;
            }
        }

        /// <summary>
        /// Метод заполнения полей обьекта класса Child.
        /// </summary>
        /// <returns>Объект класса Child</returns>
        public static Child GetRandomChild()
        {
            Child child = new Child();
            SetRandomPerson(child);
            SetRandomChild(child);
            return child;
        }
    }
}