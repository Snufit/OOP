using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using FuelManagement;

namespace View
{
    //TODO: rename
    /// <summary>
    /// Класс BasicForm.
    /// </summary>
    public partial class BasicForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Лист для заполнения таблицы.
        /// </summary>
        private BindingList<TransportBase> _transportList =
            new BindingList<TransportBase>();

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
        /// Конструктор BasicForm.
        /// </summary>
        public BasicForm()
        {
            InitializeComponent();

            FillingDataGridView(_transportList);

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
        /// Метод нажатия на кнопку "Добавить".
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void AddTransportButtonClick(object sender, EventArgs e)
        {
            if (!_isDataFormOpen)
            {
                _isDataFormOpen = true;

                //TODO: rsdn
                DataForm DataForm = new DataForm();
                DataForm.FormClosed += (s, args) => { _isDataFormOpen = false; };
                DataForm.TransportAdded += AddedTransport;
                DataForm.TransportCancel += CancelTransport;
                DataForm.Show();
            }
        }

        /// <summary>
        /// Метод нажатия на кнопку "Удалить"
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void RemoveTransportButtonClick(object sender, EventArgs e)
        {
            if (_gridControlTransport.SelectedRows.Count > 0)
            {
                var selectedTransports = _gridControlTransport.SelectedRows
                    .Cast<DataGridViewRow>()
                    .Where(row => !row.IsNewRow)
                    .Select(row => row.DataBoundItem as TransportBase)
                    .Where(transport => transport != null)
                    .ToList();

                foreach (var transport in selectedTransports)
                {
                    _transportList.Remove(transport);
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.");
            }
        }

        /// <summary>
        /// Метод заполнения таблицы "Список транспорта".
        /// </summary>
        private void FillingDataGridView(BindingList<TransportBase> transportList)
        {
            _gridControlTransport.DataSource = transportList;
        }

        //TODO: XML
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

                FilterForm findForm = new FilterForm(_transportList);
                findForm.FormClosed += (s, args) => { _isFindFormOpen = false; };
                findForm.TransportFiltered += FilteredTransport;
                findForm.Show();
            }
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
        }

        /// <summary>
        /// Метод нажатия на кнопку "Сбросить".
        /// </summary>
        /// <param name="sender">Событие.</param>
        /// <param name="e">Данные о событие.</param>
        private void ResetedFilter(object sender, EventArgs e)
        {
            FillingDataGridView(_transportList);
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
                using (var file = new StreamReader(filePath))
                {
                    _transportList = (BindingList<TransportBase>)
                        _serializerXml.Deserialize(file);
                }

                _gridControlTransport.DataSource = _transportList;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить файл!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //TODO: remove
        private void _gridControlTransport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BasicForm_Load(object sender, EventArgs e)
        {

        }

        private void BasicForm_Load_1(object sender, EventArgs e)
        {

        }

        private void _groupBoxTransport_Enter(object sender, EventArgs e)
        {

        }
    }
}
