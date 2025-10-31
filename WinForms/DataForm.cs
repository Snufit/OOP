using FuelManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Класс DataForm.
    /// </summary>
    public partial class DataForm : Form
    {
        /// <summary>
        /// Поле для обработки события добавления.
        /// </summary>
        public EventHandler TransportAdded;

        /// <summary>
        /// Поле для обработки события отмена.
        /// </summary>
        public EventHandler TransportCancel;

        /// <summary>
        /// Поле для хранения последнего добавленного объекта.
        /// </summary>
        private TransportBase _lastTransport;

        /// <summary>
        /// Словарь тип транспорта.
        /// </summary>
        private static readonly Dictionary<string, TypeTransport> _typesTransports =
            new Dictionary<string, TypeTransport>
        {
            {"Машина", TypeTransport.Car},
            {"Гибридная машина", TypeTransport.HybridCar},
            {"Вертолет", TypeTransport.Helicopter},
        };

        /// <summary>
        /// Словарь тип топлива.
        /// </summary>
        private static readonly Dictionary<string, TypeFuel> _typesFuel = new Dictionary<string, TypeFuel>
        {
            {"Бензин", TypeFuel.Petrol},
            {"Дизель", TypeFuel.Diesel},
            {"Электричество", TypeFuel.Electricity},
            {"Газ", TypeFuel.Gas},
            {"Авиационный керосин", TypeFuel.AviationKerosene},
            {"Авиационный бензин", TypeFuel.AviationGasoline},
        };

        /// <summary>
        /// Словарь доступных типов топлива для каждого транспорта.
        /// </summary>
        private static readonly Dictionary<TypeTransport, TypeFuel[]> _transportFuelTypes =
            new Dictionary<TypeTransport, TypeFuel[]>
        {
            {
                TypeTransport.Car,
                //TODO: RSDN
                new TypeFuel[] { TypeFuel.Petrol, TypeFuel.Diesel, TypeFuel.Gas, TypeFuel.Electricity }
            },
            {
                TypeTransport.HybridCar,
                //TODO: RSDN
                new TypeFuel[] { TypeFuel.Petrol, TypeFuel.Diesel, TypeFuel.Gas, TypeFuel.Electricity }
            },
            {
                TypeTransport.Helicopter,
                new TypeFuel[] { TypeFuel.AviationGasoline, TypeFuel.AviationKerosene }
            },
        };

        /// <summary>
        /// Конструктор DataForm.
        /// </summary>
        public DataForm()
        {
            InitializeComponent();

            FillComboBox(_typesTransports.Keys.ToArray(), _comboBoxTransport);
            FillComboBoxFuel();

            _comboBoxTransport.SelectedIndexChanged += AddGroupBoxData;
            _comboBoxTransport.SelectedIndexChanged += comboBoxTransportFillComboBoxFuel;
            _comboBoxFuel.SelectedIndexChanged += FillComboBoxHybridFuel;
            _buttonAgree.Click += AgreeButtonClick;
            _buttonCancel.Click += CancelButtonClick;

#if DEBUG
            _buttonRandom.Click += RandomButtonClick;
#endif

            _textBoxCapacity.KeyPress += TextBoxKeyPress;
            _textBoxMass.KeyPress += TextBoxKeyPress;
            _textBoxHybridCapacity.KeyPress += TextBoxKeyPress;
            _textBoxBladeLength.KeyPress += TextBoxKeyPress;
        }

        /// <summary>
        /// Метод нажатия на кнопку "Ок"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void AgreeButtonClick(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            try
            {
                TypeTransport typeTransport = _typesTransports[_comboBoxTransport.Text];
                TransportBase transport = CreateTransport(typeTransport);

                if (transport != null)
                {
                    TransportAdded?.Invoke(this, new TransportAddedEventArgs(transport));
                    _lastTransport = transport;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании транспорта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Создает транспорт указанного типа.
        /// </summary>
        /// <param name="typeTransport">Тип транспорта.</param>
        /// <returns>Созданный транспорт.</returns>
        private TransportBase CreateTransport(TypeTransport typeTransport)
        {
            switch (typeTransport)
            {
                case TypeTransport.Car:
                    return CreateCar();

                case TypeTransport.HybridCar:
                    return CreateHybridCar();

                case TypeTransport.Helicopter:
                    return CreateHelicopter();

                default:
                    throw new ArgumentException("Неизвестный тип транспорта");
            }
        }

        /// <summary>
        /// Создает автомобиль.
        /// </summary>
        /// <returns>Созданный автомобиль.</returns>
        private Car CreateCar()
        {
            Motor motor = new Motor();
            motor.TypeFuel = (TypeFuel)_comboBoxFuel.SelectedValue;
            motor.Capacity = Convert.ToDouble(_textBoxCapacity.Text);
            double mass = Convert.ToDouble(_textBoxMass.Text);

            return new Car()
            {
                Motor = motor,
                Mass = mass
            };
        }

        /// <summary>
        /// Создает гибридный автомобиль.
        /// </summary>
        /// <returns>Созданный гибридный автомобиль.</returns>
        private HybridCar CreateHybridCar()
        {
            Motor motor = new Motor();
            motor.TypeFuel = (TypeFuel)_comboBoxFuel.SelectedValue;
            motor.Capacity = Convert.ToDouble(_textBoxCapacity.Text);

            Motor additionalMotor = new Motor();
            additionalMotor.TypeFuel = (TypeFuel)_comboBoxHybridFuel.SelectedValue;
            additionalMotor.Capacity = Convert.ToDouble(_textBoxHybridCapacity.Text);

            double mass = Convert.ToDouble(_textBoxMass.Text);

            return new HybridCar()
            {
                Motor = motor,
                AdditionalMotor = additionalMotor,
                Mass = mass,
            };
        }

        /// <summary>
        /// Создает вертолет.
        /// </summary>
        /// <returns>Созданный вертолет.</returns>
        private Helicopter CreateHelicopter()
        {
            Motor motor = new Motor();
            motor.TypeFuel = (TypeFuel)_comboBoxFuel.SelectedValue;
            motor.Capacity = Convert.ToDouble(_textBoxCapacity.Text);
            double mass = Convert.ToDouble(_textBoxMass.Text);
            double bladeLength = Convert.ToDouble(_textBoxBladeLength.Text);

            return new Helicopter()
            {
                Motor = motor,
                Mass = mass,
                BladeLength = bladeLength
            };
        }

        /// <summary>
        /// Проверяет корректность введенных данных.
        /// </summary>
        /// <returns>True если данные корректны, иначе False.</returns>
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(_textBoxMass.Text) ||
                string.IsNullOrWhiteSpace(_textBoxCapacity.Text))
            {
                MessageBox.Show("Заполните все обязательные поля.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка гибридной машины
            if (_groupBoxDataHybridCar.Visible &&
                string.IsNullOrWhiteSpace(_textBoxHybridCapacity.Text))
            {
                MessageBox.Show("Заполните мощность второго двигателя.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка вертолета
            if (_groupBoxDataHelicopter.Visible &&
                string.IsNullOrWhiteSpace(_textBoxBladeLength.Text))
            {
                MessageBox.Show("Заполните длину лопастей.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка числовых значений
            if (!double.TryParse(_textBoxMass.Text, out double mass) || mass <= 0)
            {
                MessageBox.Show("Введите корректную массу.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(_textBoxCapacity.Text, out double capacity) || capacity <= 0)
            {
                MessageBox.Show("Введите корректную мощность.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Метод добавления GroupBox на форму.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void AddGroupBoxData(object sender, EventArgs e)
        {
            TypeTransport typeTransport = _typesTransports[_comboBoxTransport.Text];

            switch (typeTransport)
            {
                case TypeTransport.Car:
                {
                    _groupBoxDataHybridCar.Visible = false;
                    _groupBoxDataHelicopter.Visible = false;
                    break;
                }
                case TypeTransport.HybridCar:
                {
                    _groupBoxDataHybridCar.Visible = true;
                    _groupBoxDataHelicopter.Visible = false;
                    break;
                }
                case TypeTransport.Helicopter:
                {
                    _groupBoxDataHybridCar.Visible = false;
                    _groupBoxDataHelicopter.Visible = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Метод нажатия на кнопку "Отмена"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void CancelButtonClick(object sender, EventArgs e)
        {
            if (_lastTransport != null)
            {
                TransportCancel?.Invoke(this, new TransportAddedEventArgs(_lastTransport));
            }
        }

        /// <summary>
        /// Заполнение comboBox массивом данных.
        /// </summary>
        /// <param name="dataSource">Массив данных.</param>
        /// <param name="comboBox">ComboBox.</param>
        private void FillComboBox<T>(T[] dataSource, ComboBox comboBox)
        {
            comboBox.DataSource = dataSource;
            comboBox.SelectedItem = dataSource.GetValue(0);
        }

        //TODO: RSDN
        /// <summary>
        /// Заполнение ComboBoxFuel массивом данных
        /// в соответствии с выбранным типом транспорта.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void comboBoxTransportFillComboBoxFuel(object sender, EventArgs e)
        {
            FillComboBoxFuel();
        }

        /// <summary>
        /// Заполнение ComboBoxFuel массивом данных
        /// в соответствии с выбранным типом транспорта.
        /// </summary>
        private void FillComboBoxFuel()
        {
            TypeTransport typeTransport = _typesTransports[_comboBoxTransport.Text];

            if (_transportFuelTypes.TryGetValue(typeTransport, out TypeFuel[] availableFuels))
            {
                var fuelDictionary = availableFuels.ToDictionary(
                    fuel => _typesFuel.First(x => x.Value == fuel).Key,
                    fuel => fuel
                );

                _comboBoxFuel.DataSource = new BindingSource(fuelDictionary, null);
                _comboBoxFuel.DisplayMember = "Key";
                _comboBoxFuel.ValueMember = "Value";
            }
        }

        /// <summary>
        /// Заполнение ComboBoxHybridFuel массивом данных
        /// в соответствии с выбранным ComboBoxFuel.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void FillComboBoxHybridFuel(object sender, EventArgs e)
        {
            if (_groupBoxDataHybridCar.Visible 
                && _comboBoxFuel.SelectedValue is TypeFuel selectedFuel)
            {
                TypeTransport typeTransport = _typesTransports[_comboBoxTransport.Text];

                if (_transportFuelTypes.TryGetValue(typeTransport, out TypeFuel[] availableFuels))
                {
                    // Исключаем выбранное топливо из доступных для второго двигателя
                    var hybridFuels = availableFuels.Where(fuel => fuel != selectedFuel).ToArray();

                    // Создаем словарь для отображения
                    var fuelDictionary = hybridFuels.ToDictionary(
                        fuel => _typesFuel.First(x => x.Value == fuel).Key,
                        fuel => fuel
                    );

                    _comboBoxHybridFuel.DataSource = new BindingSource(fuelDictionary, null);
                    _comboBoxHybridFuel.DisplayMember = "Key";
                    _comboBoxHybridFuel.ValueMember = "Value";
                }
            }
        }

        /// <summary>
        /// Проверка данных вводимых в textBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && textBox.Text.Contains(","))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '0' && textBox.Text == "0")
            {
                e.Handled = true;
            }
        }

#if DEBUG
        /// <summary>
        /// Заполнение данными полей textBox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomButtonClick(object sender, EventArgs e)
        {
            Random random = new Random();

            int mass = random.Next(1, 15);
            _textBoxMass.Text = mass.ToString();

            _textBoxCapacity.Text = (mass * 100).ToString();

            if (_groupBoxDataHybridCar.Visible)
            {
                _textBoxHybridCapacity.Text = (mass * 80).ToString();
            }

            if (_groupBoxDataHelicopter.Visible)
            {
                _textBoxBladeLength.Text = random.Next(10, 20).ToString();
            }
        }
#endif
    }
}