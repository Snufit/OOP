using FuelManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Класс FilterForm.
    /// </summary>
    public partial class FilterForm : Form
    {
        /// <summary>
        /// Исходный список транспорта.
        /// </summary>
        private BindingList<TransportBase> _transportList;

        /// <summary>
        /// Отфильтрованный список транспорта.
        /// </summary>
        private BindingList<TransportBase> _filteredTransportList;

        /// <summary>
        /// Событие на фильтрацию списка.
        /// </summary>
        public EventHandler TransportFiltered;

        /// <summary>
        /// Конструктор FilterForm.
        /// </summary>
        /// <param name="transportList">Исходный список транспорта.</param>
        public FilterForm(BindingList<TransportBase> transportList)
        {
            _transportList = transportList;

            InitializeComponent();

            _buttonAgree.Click += new EventHandler(AgreeButtonClick);
        }

        /// <summary>
        /// Метод нажатия на кнопку "ОК"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void AgreeButtonClick(object sender, EventArgs e)
        {
            bool checkClick = _checkBoxFindCar.Checked
                || _checkBoxFindHybridCar.Checked
                || _checkBoxFindHelicopter.Checked
                || _checkBoxMass.Checked
                || _checkBoxCapacity.Checked;

            if (!checkClick)
            {
                MessageBox.Show("Заполните критерии поиска.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var filteredList = new List<TransportBase>(_transportList);

                if (_checkBoxFindCar.Checked 
                    || _checkBoxFindHybridCar.Checked 
                    || _checkBoxFindHelicopter.Checked)
                {
                    filteredList = FilterByType(filteredList);
                }

                if (_checkBoxMass.Checked && 
                    !string.IsNullOrEmpty(_textBoxMass.Text))
                {
                    filteredList = FilterByMass
                        (filteredList, Convert.ToDouble(_textBoxMass.Text));
                }

                if (_checkBoxCapacity.Checked && 
                    !string.IsNullOrEmpty(_textBoxCapacity.Text))
                {
                    filteredList = FilterByCapacity
                        (filteredList, Convert.ToDouble(_textBoxCapacity.Text));
                }

                _filteredTransportList = 
                    new BindingList<TransportBase>(filteredList);

                if (_filteredTransportList.Count == 0)
                {
                    MessageBox.Show("Совпадений не найдено.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                TransportFiltered?.Invoke
                    (this, new TransportFilterEventArgs(_filteredTransportList));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при фильтрации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод фильтрации данных по типу транспорта.
        /// </summary>
        /// <param name="transportList">Исходный список.</param>
        /// <returns>Отфильтрованный список.</returns>
        private List<TransportBase> FilterByType(List<TransportBase> transportList)
        {
            var filtered = new List<TransportBase>();

            if (_checkBoxFindCar.Checked)
            {
                filtered.AddRange(transportList.OfType<Car>().Where(c => !(c is HybridCar)));
            }

            if (_checkBoxFindHybridCar.Checked)
            {
                filtered.AddRange(transportList.OfType<HybridCar>());
            }

            if (_checkBoxFindHelicopter.Checked)
            {
                filtered.AddRange(transportList.OfType<Helicopter>());
            }

            return filtered;
        }

        /// <summary>
        /// Метод фильтрации данных по массе.
        /// </summary>
        /// <param name="transportList">Отфильтрованный список.</param>
        /// <param name="Mass">Масса.</param>
        private List<TransportBase> FilterByMass(
            List<TransportBase> transportList, double mass)
        {
            return transportList.Where(
                t => Math.Abs(t.Mass - mass) < 0.001).ToList();
        }

        /// <summary>
        /// Метод фильтрации данных по мощности.
        /// </summary>
        /// <param name="transportList">Исходный список.</param>
        /// <param name="capacity">Мощность.</param>
        /// <returns>Отфильтрованный список.</returns>
        private List<TransportBase> FilterByCapacity(
            List<TransportBase> transportList, double capacity)
        {
            return transportList.Where(t =>
            {
                if (t is Car)
                {
                    var car = t as Car;
                    return Math.Abs(car.Motor.Capacity - capacity) < 0.001;
                }
                else if (t is Helicopter)
                {
                    var helicopter = t as Helicopter;
                    return Math.Abs(helicopter.Motor.Capacity - capacity) < 0.001;
                }
                return false;
            }).ToList();
        }
    }
}
