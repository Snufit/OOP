using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace View
{
    /// <summary>
    /// Класс MainForm.
    /// </summary>
    partial class MainForm
    {
        /// <summary>
        ///  Необходимая переменная дизайнера.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Кнопка "Добавить".
        /// </summary>
        private Button _buttonAddTransport;

        /// <summary>
        /// Кнопка "Удалить".
        /// </summary>
        private Button _buttonRemoveTransport;

        /// <summary>
        /// Кнопка "Найти".
        /// </summary>
        private Button _buttonFindTransport;

        /// <summary>
        /// Кнопка "Сбросить".
        /// </summary>
        private Button _buttonResetTransport;

        /// <summary>
        /// Кнопка "Сохранить".
        /// </summary>
        private Button _buttonSaveTransport;

        /// <summary>
        /// Кнопка "Открыть".
        /// </summary>
        private Button _buttonOpenTransport;

        /// <summary>
        /// Таблица для транспорта.
        /// </summary>
        private DataGridView _gridControlTransport;

        /// <summary>
        /// GroupBox для транспорта.
        /// </summary>
        private GroupBox _groupBoxTransport;

        /// <summary>
        ///  Метод для явного освобождения ресурсов.
        /// </summary>
        /// <param name="disposing">true если ресурсы необходимо
        /// удалить,иначе false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Метод инициализации компонентов (кнопки,текстовые поля и т.д.)
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._groupBoxTransport = new System.Windows.Forms.GroupBox();
            this._gridControlTransport = new System.Windows.Forms.DataGridView();
            this._buttonAddTransport = new System.Windows.Forms.Button();
            this._buttonRemoveTransport = new System.Windows.Forms.Button();
            this._buttonFindTransport = new System.Windows.Forms.Button();
            this._buttonResetTransport = new System.Windows.Forms.Button();
            this._buttonSaveTransport = new System.Windows.Forms.Button();
            this._buttonOpenTransport = new System.Windows.Forms.Button();
            this._groupBoxTransport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridControlTransport)).BeginInit();
            this.SuspendLayout();
            // 
            // _groupBoxTransport
            // 
            this._groupBoxTransport.Controls.Add(this._gridControlTransport);
            this._groupBoxTransport.Location = new System.Drawing.Point(50, 60);
            this._groupBoxTransport.Name = "_groupBoxTransport";
            this._groupBoxTransport.Size = new System.Drawing.Size(700, 320);
            this._groupBoxTransport.TabIndex = 0;
            this._groupBoxTransport.TabStop = false;
            this._groupBoxTransport.Text = "Список транспорта";
            // 
            // _gridControlTransport
            // 
            this._gridControlTransport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridControlTransport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._gridControlTransport.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this._gridControlTransport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._gridControlTransport.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridControlTransport.Location = new System.Drawing.Point(3, 16);
            this._gridControlTransport.Name = "_gridControlTransport";
            this._gridControlTransport.RowTemplate.Height = 60; // Увеличена высота строк
            this._gridControlTransport.RowTemplate.MinimumHeight = 40; // Минимальная высота
            this._gridControlTransport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridControlTransport.Size = new System.Drawing.Size(694, 301);
            this._gridControlTransport.TabIndex = 0;
            // 
            // _buttonAddTransport
            // 
            this._buttonAddTransport.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._buttonAddTransport.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonAddTransport.Location = new System.Drawing.Point(525, 390);
            this._buttonAddTransport.Name = "_buttonAddTransport";
            this._buttonAddTransport.Size = new System.Drawing.Size(100, 30);
            this._buttonAddTransport.TabIndex = 1;
            this._buttonAddTransport.Text = "Добавить";
            this._buttonAddTransport.UseVisualStyleBackColor = false;
            // 
            // _buttonRemoveTransport
            // 
            this._buttonRemoveTransport.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._buttonRemoveTransport.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonRemoveTransport.Location = new System.Drawing.Point(650, 390);
            this._buttonRemoveTransport.Name = "_buttonRemoveTransport";
            this._buttonRemoveTransport.Size = new System.Drawing.Size(100, 30);
            this._buttonRemoveTransport.TabIndex = 2;
            this._buttonRemoveTransport.Text = "Удалить";
            this._buttonRemoveTransport.UseVisualStyleBackColor = false;
            // 
            // _buttonFindTransport
            // 
            this._buttonFindTransport.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._buttonFindTransport.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonFindTransport.Location = new System.Drawing.Point(50, 390);
            this._buttonFindTransport.Name = "_buttonFindTransport";
            this._buttonFindTransport.Size = new System.Drawing.Size(100, 30);
            this._buttonFindTransport.TabIndex = 2;
            this._buttonFindTransport.Text = "Найти";
            this._buttonFindTransport.UseVisualStyleBackColor = false;
            // 
            // _buttonResetTransport
            // 
            this._buttonResetTransport.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._buttonResetTransport.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonResetTransport.Location = new System.Drawing.Point(170, 390);
            this._buttonResetTransport.Name = "_buttonResetTransport";
            this._buttonResetTransport.Size = new System.Drawing.Size(100, 30);
            this._buttonResetTransport.TabIndex = 2;
            this._buttonResetTransport.Text = "Сбросить";
            this._buttonResetTransport.UseVisualStyleBackColor = false;
            // 
            // _buttonSaveTransport
            // 
            this._buttonSaveTransport.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._buttonSaveTransport.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonSaveTransport.Location = new System.Drawing.Point(50, 20);
            this._buttonSaveTransport.Name = "_buttonSaveTransport";
            this._buttonSaveTransport.Size = new System.Drawing.Size(100, 30);
            this._buttonSaveTransport.TabIndex = 2;
            this._buttonSaveTransport.Text = "Сохранить";
            this._buttonSaveTransport.UseVisualStyleBackColor = false;
            // 
            // _buttonOpenTransport
            // 
            this._buttonOpenTransport.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._buttonOpenTransport.ForeColor = System.Drawing.SystemColors.ControlText;
            this._buttonOpenTransport.Location = new System.Drawing.Point(170, 20);
            this._buttonOpenTransport.Name = "_buttonOpenTransport";
            this._buttonOpenTransport.Size = new System.Drawing.Size(100, 30);
            this._buttonOpenTransport.TabIndex = 2;
            this._buttonOpenTransport.Text = "Открыть";
            this._buttonOpenTransport.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._groupBoxTransport);
            this.Controls.Add(this._buttonAddTransport);
            this.Controls.Add(this._buttonRemoveTransport);
            this.Controls.Add(this._buttonFindTransport);
            this.Controls.Add(this._buttonResetTransport);
            this.Controls.Add(this._buttonSaveTransport);
            this.Controls.Add(this._buttonOpenTransport);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this._groupBoxTransport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridControlTransport)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
