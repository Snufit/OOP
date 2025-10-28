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
        private static readonly Dictionary<TypeTransport, string[]> _transportFuelTypes =
            new Dictionary<TypeTransport, string[]>()
        {
            {
                TypeTransport.Car,
                new string[] { "Бензин", "Дизель", "Газ", "Электричество" }
            },
            {
                TypeTransport.HybridCar,
                 new string[] { "Бензин", "Дизель", "Газ", "Электричество" }
            },
            {
                TypeTransport.Helicopter,
                new string[] { "Авиационный бензин", "Авиационный керосин" }
            },
        };

        /// <summary>
        /// Словарь тип топлива.
        /// </summary>
        private static readonly Dictionary<TypeTransport, (bool HybridVisible, bool HelicopterVisible)> _groupBoxVisibility =
            new Dictionary<TypeTransport, (bool, bool)>()
        {
            { TypeTransport.Car, (false, false) },
            { TypeTransport.HybridCar, (true, false) },
            { TypeTransport.Helicopter, (false, true) }
        };

        /// <summary>
        /// Конструктор DataForm.
        /// </summary>
        public DataForm()
        {
            InitializeComponent();

            FillComboBox(_typesTransports.Keys.ToArray(),
                _comboBoxTransport);

            FillComboBoxFuel();

            _comboBoxTransport.SelectedIndexChanged += new
                EventHandler(AddGroupBoxData);

            _comboBoxTransport.SelectedIndexChanged += new
                EventHandler(comboBoxTransportFillComboBoxFuel);

            _comboBoxFuel.SelectedIndexChanged += new
                EventHandler(FillComboBoxHybridFuel);

            _buttonAgree.Click += new EventHandler(AgreeButtonClick);

            _buttonCancel.Click += new EventHandler(CancelButtonClick);

            _buttonRandom.Click += new EventHandler(RandomButtonClick);

            _textBoxCapacity.KeyPress += new
                KeyPressEventHandler(TextBoxKeyPress);

            _textBoxMass.KeyPress += new
                KeyPressEventHandler(TextBoxKeyPress);

            _textBoxHybridCapacity.KeyPress += new
                KeyPressEventHandler(TextBoxKeyPress);

            _textBoxBladeLength.KeyPress += new
                KeyPressEventHandler(TextBoxKeyPress);
        }

        /// <summary>
        /// Метод нажатия на кнопку "Ок"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void AgreeButtonClick(object sender, EventArgs e)
        {
            try
            {
                TypeTransport typeTransport =
                    _typesTransports[_comboBoxTransport.Text];

                TransportBase transport = null;

                switch (typeTransport)
                {
                    //TODO: RSDN +
                    case TypeTransport.Car:
                    {
                        Motor motor = new Motor();
                        motor.TypeFuel = _typesFuel[(string)_comboBoxFuel.SelectedItem];
                        motor.Capacity = Convert.ToDouble(_textBoxCapacity.Text);
                        double mass = Convert.ToDouble(_textBoxMass.Text);

                        transport = new Car()
                        {
                            Motor = motor,
                            Mass = mass
                        };
                        break;
                    }

                    case TypeTransport.HybridCar:
                    {
                        Motor motor = new Motor();
                        motor.TypeFuel = _typesFuel[(string)_comboBoxFuel.SelectedItem];
                        motor.Capacity = Convert.ToDouble(_textBoxCapacity.Text);

                        Motor additionalMotor = new Motor();
                        additionalMotor.TypeFuel = _typesFuel[(string)_comboBoxHybridFuel.SelectedItem];
                        additionalMotor.Capacity = Convert.ToDouble(_textBoxHybridCapacity.Text);

                        double mass = Convert.ToDouble(_textBoxMass.Text);

                        transport = new HybridCar()
                        {
                            Motor = motor,
                            AdditionalMotor = additionalMotor,
                            Mass = mass,
                        };
                        break;
                    }
                    case TypeTransport.Helicopter:
                    {
                        Motor motor = new Motor();
                        motor.TypeFuel = _typesFuel[(string)_comboBoxFuel.SelectedItem];
                        motor.Capacity = Convert.ToDouble(_textBoxCapacity.Text);
                        double mass = Convert.ToDouble(_textBoxMass.Text);
                        double bladeLength = Convert.ToDouble(_textBoxBladeLength.Text);

                         transport = new Helicopter()
                         {
                            Motor = motor,
                            Mass = mass,
                            BladeLength = bladeLength
                         };
                         break;
                    }
                }

                TransportAdded?.Invoke(this,
                    new TransportAddedEventArgs(transport));

                _lastTransport = transport;
            }
            catch
            {
                MessageBox.Show("Введите данные.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Метод добавления GroupBox на форму.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void AddGroupBoxData(object sender, EventArgs e)
        {
            TypeTransport typeTransport =
                    _typesTransports[_comboBoxTransport.Text];

            switch (typeTransport)
            {
                //TODO: RSDN +
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
        /// Заполнение comboBox массивом данных comboBox.
        /// </summary>
        /// <param name="dataSource">Массив данных.</param>
        /// <param name="comboBox">ComboBox.</param>
        private void FillComboBox<T>(T[] dataSource, ComboBox comboBox)
        {
            comboBox.DataSource = dataSource;
            comboBox.SelectedItem = dataSource.GetValue(0);
        }

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
        //TODO: refactor
        /// <summary>
        /// Заполнение  ComboBoxFuel массивом данных
        /// в соответствии с выбранным типом транспорта.
        /// </summary>
        private void FillComboBoxFuel()
        {
            object key = _comboBoxTransport.SelectedItem;

            TypeTransport typeTransport =
                _typesTransports[_comboBoxTransport.Text];

            string[] namesTransports = _typesFuel.Keys.ToArray();

            Dictionary<TypeTransport, string[]> fuelTypes = new()
            {
                {
                    TypeTransport.Car,
                    [namesTransports[0], namesTransports[1],
                     namesTransports[2], namesTransports[3]]
                },
                {
                    TypeTransport.HybridCar,
                    [namesTransports[0], namesTransports[1],
                     namesTransports[2], namesTransports[3]]
                },
                {
                    TypeTransport.Helicopter,
                    [namesTransports[4], namesTransports[5]]
                },
            };

            FillComboBox(fuelTypes[typeTransport], _comboBoxFuel);
        }

        /// <summary>
        /// Заполнение ComboBoxHybridFuel массивом данных
        /// в соответствии с выбранным ComboBoxFuel.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void FillComboBoxHybridFuel(object sender, EventArgs e)
        {
            //TOOD: refactor
            if (_groupBoxDataHybridCar.Visible == true)
            {
                string valueComboBoxFuel = (string)_comboBoxFuel.SelectedItem;

                string[] valuesComboBoxHybridFuel =
                    _comboBoxFuel.Items.Cast<string>().ToArray();

                int index = Array.IndexOf(valuesComboBoxHybridFuel, valueComboBoxFuel);

                if (index > -1)
                {
                    string[] newArray = new string[valuesComboBoxHybridFuel.Length - 1];

                    Array.Copy(valuesComboBoxHybridFuel, 0, newArray, 0, index);

                    Array.Copy(valuesComboBoxHybridFuel, index + 1, newArray, index,
                        valuesComboBoxHybridFuel.Length - index - 1);

                    FillComboBox(newArray, _comboBoxHybridFuel);

                    return;
                }

                FillComboBox(valuesComboBoxHybridFuel, _comboBoxHybridFuel);
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

            if (e.KeyChar == '0' &&
                string.IsNullOrEmpty(textBox.Text.Trim('0')))
            {
                e.Handled = true;
            }
        }

#if DEBUG
        /// <summary>
        ///  Заполнение данными полей textBox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomButtonClick(object sender, EventArgs e)
        {
            Random random = new Random();

            int mass = Convert.ToInt32(_textBoxMass.Text = random.Next(1, 15).ToString());

            _textBoxCapacity.Text = Convert.ToString(mass * 100);

            _textBoxHybridCapacity.Text = Convert.ToString(mass * 80);

            _textBoxBladeLength.Text = random.Next(10, 20).ToString();
        }

        private void DataForm_Load(object sender, EventArgs e)
        {

        }
#endif
    }
}
