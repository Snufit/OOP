using System;
using System.Collections.Generic;

namespace PersonLibrary
{
    /// <summary>
    /// Класс PersonList.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Объявление списка объектов типа Person.
        /// </summary>
        private readonly List<Person> _persons = new List<Person>();

        /// <summary>
        /// Добавление персоны.
        /// </summary>
        /// <param name="person">Объект класса Person.</param>
        public void AddPerson(Person person)
        {
            _persons.Add(person);
        }

        /// <summary>
        /// Удаление персон.
        /// </summary>
        /// <param name="person">Объект класса Person.</param>
        public void RemovePerson(Person person)
        {
            _persons.Remove(person);
        }

        /// <summary>
        /// Удаление персон по индексу.
        /// </summary>
        /// <param name="index">Индекс объекта.</param>
        /// <exception cref="IndexOutOfRangeException">Исключение, которое
        /// генерируется, если введенный индекс находится за пределами его
        /// границ.</exception>
        public void RemovePersonAtIndex(int index)
        {
            if (index >= 0 && index < _persons.Count)
            {
                _persons.RemoveAt(index);
            }
            else
            {
                throw new IndexOutOfRangeException
                    ($"'Элемента с индексом {index} нет в списке");
            }
        }

        /// <summary>
        /// Поиск персоны по указанному индексу.
        /// </summary>
        /// <param name="index">Индекс объекта.</param>
        /// <returns>index</returns>
        /// <exception cref="IndexOutOfRangeException">Исключение, которое
        /// генерируется, если введенный индекс находится за пределами его
        /// границ.</exception>
        public Person GetPersonAtIndex(int index)
        {
            if (index >= 0 && index < _persons.Count)
            {
                return _persons[index];
            }
            else
            {
                throw new IndexOutOfRangeException
                    ($"Элемента с индексом {index} нет в списке");
            }
        }

        /// <summary>
        /// Получение индекса по персоне.
        /// </summary>
        /// <param name="person">Объект класса Person.</param>
        /// <returns>Индекс объекта.</returns>
        public int ReturnIndexPerson(Person person)
        {
            if (_persons.Contains(person))
            {
                return _persons.IndexOf(person);
            }
            else
            {
                throw new ArgumentException
                    ("Данной персоны не существует");
            }
        }

        /// <summary>
        /// Удаление всех персон.
        /// </summary>
        public void RemovePerson()
        {
            _persons.Clear();
        }

        /// <summary>
        /// Количество персон в списке.
        /// </summary>
        /// <returns>Количество персон в списке.</returns>
        public int GetCountPerson()
        {
            return _persons.Count;
        }

        /// <summary>
        /// Получение информации о списке персон.
        /// </summary>
        /// <returns>Строка с данными полей объектов списка.</returns>
        public string GetInfo()
        {
            string infoPerson = default;
            foreach (Person persona in _persons)
            {
                infoPerson += persona.GetInfo();
            }
            return infoPerson;
        }
    }
}