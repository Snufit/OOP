using FuelManagement;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace View
{
    /// <summary>
    /// Класс MainForm.
    /// </summary>
    public partial class MainForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Лист для заполнения таблицы.
        /// </summary>
        private BindingList<TransportBase> _transportList =
            new BindingList<TransportBase>();

        /// <summary>
        /// Поле для хранения ссылки на форму фильтрации.
        /// </summary>
        private FilterForm _currentFilterForm;

        /// <summary>
        /// Отфильтрованный лист для заполнения таблицы.
        /// </summary>
        private BindingList<TransportBase> _filteredTransportList;

        /// <summary>
        ///  Поле для хранения состояния формы DataForm.
        /// </summary>
        private bool _isDataFormOpen = false;

        /// <summary>
        ///  Поле для хранения состояния формы FindForm.
        /// </summary>
        private bool _isFindFormOpen = false;

        /// <summary>
        /// Поле для сохранения и открытия файла.
        /// </summary>
        private readonly XmlSerializer _serializerXml =
            new XmlSerializer(typeof(BindingList<TransportBase>));

        /// <summary>
        /// Свойство для отслеживания активности фильтров.
        /// </summary>
        private bool _isFilterActive
        {
            get { return _filteredTransportList != null && _filteredTransportList != _transportList; }
        }

        /// <summary>
        /// Конструктор MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _filteredTransportList = null;
            FillingDataGridView(_transportList);
            UpdateButtonStates();

            _buttonAddTransport.Click += AddTransportButtonClick;

            _buttonRemoveTransport.Click += RemoveTransportButtonClick;

            _buttonFindTransport.Click += FindTransportButtonClick;

            _buttonResetTransport.Click += ResetedFilter;

            _buttonSaveTransport.Click += SaveFile;

            _buttonOpenTransport.Click += OpenFile;
        }

        /// <summary>
        /// Обработчик отмены добавления данных в лист.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="transportBase"></param>
        private void CancelTransport(object sender, EventArgs transportBase)
        {
            TransportAddedEventArgs addedEventArgs =
                transportBase as TransportAddedEventArgs;

            _transportList.Remove(addedEventArgs?.TransportBase);
        }

        /// <summary>
        /// Обработчик добавления данных в лист.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="transportBase"></param>
        private void AddedTransport(object sender, EventArgs transportBase)
        {
            TransportAddedEventArgs addedEventArgs =
                transportBase as TransportAddedEventArgs;

            _transportList.Add(addedEventArgs?.TransportBase);
        }

        /// <summary>
        /// Метод обновления состояния кнопок в зависимости от активности фильтров.
        /// </summary>
        private void UpdateButtonStates()
        {
            bool isFilterActive = _isFilterActive;

            _buttonAddTransport.Enabled = !isFilterActive;

            // Визуальное отображение состояния кнопки
            if (isFilterActive)
            {
                _buttonAddTransport.BackColor = SystemColors.Control;
                _buttonAddTransport.ForeColor = SystemColors.GrayText;
                _buttonAddTransport.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                _buttonAddTransport.BackColor = SystemColors.ButtonHighlight;
                _buttonAddTransport.ForeColor = SystemColors.ControlText;
                _buttonAddTransport.FlatStyle = FlatStyle.Standard;
            }
        }

        /// <summary>
        /// Метод нажатия на кнопку "Добавить".
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void AddTransportButtonClick(object sender, EventArgs e)
        {
            if (_isFilterActive)
            {
                MessageBox.Show("Невозможно добавить транспорт при активных фильтрах. " +
                               "Сбросьте фильтры для добавления новых элементов.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_isDataFormOpen)
            {
                _isDataFormOpen = true;
                DataForm dataForm = new DataForm();
                dataForm.FormClosed += (s, args) =>
                {
                    _isDataFormOpen = false;
                    UpdateButtonStates();
                };
                dataForm.TransportAdded += AddedTransport;
                dataForm.TransportCancel += CancelTransport;
                dataForm.Show();
            }
        }

        /// <summary>
        /// Метод нажатия на кнопку "Удалить"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void RemoveTransportButtonClick(object sender, EventArgs e)
        {
            if (_filteredTransportList.Count == 0)
            {
                ResetFilters();
                MessageBox.Show(
                    "Все элементы в отфильтрованном списке удалены. " +
                    "Фильтр сброшен.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (_gridControlTransport.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строки для удаления.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedTransports = _gridControlTransport.SelectedRows
                .Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow && row.DataBoundItem is TransportBase)
                .Select(row => (TransportBase)row.DataBoundItem)
                .ToList();

            if (!selectedTransports.Any()) return;

            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить {selectedTransports.Count} элементов?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (var transport in selectedTransports)
                {
                    _transportList.Remove(transport);
                }

                if (_filteredTransportList != null)
                {
                    var updatedFilteredList = _filteredTransportList
                        .Where(item => _transportList.Contains(item))
                        .ToList();

                    _filteredTransportList = new BindingList<TransportBase>(updatedFilteredList);

                    if (_filteredTransportList.Count == 0)
                    {
                        ResetFilters();
                        MessageBox.Show(
                            "Все элементы в отфильтрованном списке удалены. " +
                            "Фильтр сброшен.", "Информация",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        FillingDataGridView(_filteredTransportList);
                        MessageBox.Show("Элементы успешно удалены.", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    FillingDataGridView(_transportList);
                    MessageBox.Show("Элементы успешно удалены.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Метод заполнения таблицы "Список транспорта".
        /// </summary>
        private void FillingDataGridView(BindingList<TransportBase> transportList)
        {
            _gridControlTransport.AutoGenerateColumns = false;
            _gridControlTransport.Columns.Clear();

            var typeColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Вид транспорта",
                DataPropertyName = "TypeTransport",
                Width = 120,
                ReadOnly = true
            };
            _gridControlTransport.Columns.Add(typeColumn);

            var infoColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Основная информация",
                DataPropertyName = "DisplayInfo",
                Width = 250,
                ReadOnly = true
            };
            _gridControlTransport.Columns.Add(infoColumn);

            var consumptionColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Расход топлива",
                DataPropertyName = "FuelConsumption",
                Width = 120,
                ReadOnly = true
            };
            _gridControlTransport.Columns.Add(consumptionColumn);
            _gridControlTransport.DataSource = transportList;
            _gridControlTransport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _gridControlTransport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        /// <summary>
        /// Метод нажатия на кнопку "Найти"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void FindTransportButtonClick(object sender, EventArgs e)
        {
            if (!_isFindFormOpen)
            {
                _isFindFormOpen = true;

                _currentFilterForm = new FilterForm(_transportList);
                _currentFilterForm.FormClosed += (s, args) =>
                {
                    _isFindFormOpen = false;
                    _currentFilterForm = null; 
                    UpdateButtonStates();
                };
                _currentFilterForm.TransportFiltered += FilteredTransport;
                _currentFilterForm.Show();
            }
            else
            {
                _currentFilterForm?.BringToFront();
            }
        }

        /// <summary>
        /// Обработчик закрытия главной формы.
        /// </summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Закрываем форму фильтрации при закрытии главной формы
            _currentFilterForm?.Close();
            base.OnFormClosed(e);
        }

        /// <summary>
        /// Обработчик фильтрации данных.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="transportList">Данные о событие.</param>
        private void FilteredTransport(object sender, EventArgs transportList)
        {
            TransportFilterEventArgs filterEventArgs =
                transportList as TransportFilterEventArgs;

            _filteredTransportList = filterEventArgs?.FilteredTransportList;

            FillingDataGridView(_filteredTransportList);
            UpdateButtonStates();
        }

        /// <summary>
        /// Метод нажатия на кнопку "Сбросить".
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событии.</param>
        private void ResetedFilter(object sender, EventArgs e)
        {
            ResetFilters();
            MessageBox.Show("Фильтры сброшены.", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Метод для сохранения данных в файл.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void SaveFile(object sender, EventArgs e)
        {
            if (!_transportList.Any() || _transportList is null)
            {
                MessageBox.Show("Список пуст!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы (*tran.)|*.tran|Все файлы (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName.ToString();

                using (var file = File.Create(filePath))
                {
                    _serializerXml.Serialize(file, _transportList);
                }
            }
        }

        /// <summary>
        /// Метод для открытия данных из файла.
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы (*.tran)|*.tran|Все файлы (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            string filePath = openFileDialog.FileName.ToString();

            try
            {
                if (_currentFilterForm != null && !_currentFilterForm.IsDisposed)
                {
                    _currentFilterForm.Close();
                    _currentFilterForm = null;
                }

                using (var file = new StreamReader(filePath))
                {
                    _transportList = (BindingList<TransportBase>)
                        _serializerXml.Deserialize(file);
                }

                ResetFilters();

                _gridControlTransport.DataSource = _transportList;

                MessageBox.Show("Файл успешно загружен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить файл: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод сброса фильтров.
        /// </summary>
        private void ResetFilters()
        {
            _filteredTransportList = null;
            FillingDataGridView(_transportList);
            UpdateButtonStates();

            if (_currentFilterForm != null && !_currentFilterForm.IsDisposed)
            {
                _currentFilterForm.Close();
                _currentFilterForm = null;
            }
        }
    }
}
