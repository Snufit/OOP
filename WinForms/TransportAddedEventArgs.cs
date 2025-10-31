using FuelManagement;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Класс отдает данные событию при добавлении
    /// нового транспорта.
    /// </summary>
    internal class TransportAddedEventArgs : EventArgs
    {
        /// <summary>
        /// Свойство для получения добавленного транспорта.
        /// </summary>
        public TransportBase TransportBase { get; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="transportBase">Добавленный транспорт.</param>
        /// <exception cref="ArgumentNullException">Проверка транспорта
        /// на null</exception>
        public TransportAddedEventArgs(TransportBase transportBase)
        {
            if (transportBase == null)
            {
                throw new ArgumentNullException(nameof(transportBase),
                    "Объект транспорта не может быть null");
            }

            TransportBase = transportBase;
        }
    }
}
