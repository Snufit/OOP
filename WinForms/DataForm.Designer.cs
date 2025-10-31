using System.Drawing;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using FuelManagement;
using static System.Windows.Forms.DataFormats;

namespace View
{
    /// <summary>
    /// Класс DataForm.
    /// </summary>
    partial class DataForm
    {
        /// <summary>
        /// Необходимая переменная дизайнера.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label _labelTransport;
        private Label _labelFuel;
        private Label _labelCapacity;
        private Label _labelMass;
        private Label _labelHybridCapacity;
        private Label _labelBladeLength;
        private Label _labelFuelHybrid;

        /// <summary>
        /// Кнопка "Добавить".
        /// </summary>
        private Button _buttonAgree;

        /// <summary>
        /// Кнопка "Отменить".
        /// </summary>
        private Button _buttonCancel;

#if DEBUG
        /// <summary>
        /// Кнопка "Заполнить".
        /// </summary>
        private Button _buttonRandom;
#endif

        /// <summary>
        /// ComboBox выбор транспорта.
        /// </summary>
        private ComboBox _comboBoxTransport;

        /// <summary>
        /// ComboBox выбор основного топлива.
        /// </summary>
        private ComboBox _comboBoxFuel;

        /// <summary>
        /// ComboBox выбор дополнительного топлива.
        /// </summary>
        private ComboBox _comboBoxHybridFuel;

        /// <summary>
        /// GroupBox для основных данных(топливо, мощность, масса).
        /// </summary>
        private GroupBox _groupBoxData;

        /// <summary>
        /// GroupBox для дополнительных данных(топливо, мощность).
        /// </summary>
        private GroupBox _groupBoxDataHybridCar;

        /// <summary>
        /// GroupBox для дополнительных данных(длина лопастей).
        /// </summary>
        private GroupBox _groupBoxDataHelicopter;

        /// <summary>
        /// TextBox для ввода мощности.
        /// </summary>
        private TextBox _textBoxCapacity;

        /// <summary>
        /// TextBox для ввода массы.
        /// </summary>
        private TextBox _textBoxMass;

        /// <summary>
        /// TextBox для ввода мощности гибридной машины.
        /// </summary>
        private TextBox _textBoxHybridCapacity;

        /// <summary>
        /// TextBox для ввода длины лопастей вертолета.
        /// </summary>
        private TextBox _textBoxBladeLength;

        /// <summary>
        /// Метод для явного освобождения ресурсов.
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
            _buttonAgree = new Button();
            _buttonCancel = new Button();
            _buttonRandom = new Button();
            _comboBoxTransport = new ComboBox();
            _comboBoxFuel = new ComboBox();
            _comboBoxHybridFuel = new ComboBox();
            _labelTransport = new Label();
            _labelFuel = new Label();
            _labelFuelHybrid = new Label();
            _labelCapacity = new Label();
            _labelMass = new Label();
            _labelHybridCapacity = new Label();
            _labelBladeLength = new Label();
            _textBoxCapacity = new TextBox();
            _textBoxMass = new TextBox();
            _textBoxHybridCapacity = new TextBox();
            _textBoxBladeLength = new TextBox();
            _groupBoxData = new GroupBox();
            _groupBoxDataHybridCar = new GroupBox();
            _groupBoxDataHelicopter = new GroupBox();
            _groupBoxData.SuspendLayout();
            _groupBoxDataHybridCar.SuspendLayout();
            _groupBoxDataHelicopter.SuspendLayout();
            SuspendLayout();
            // 
            // _buttonAgree
            // 
            _buttonAgree.BackColor = SystemColors.ButtonHighlight;
            _buttonAgree.ForeColor = SystemColors.ActiveCaptionText;
            _buttonAgree.Location = new Point(300, 300);
            _buttonAgree.Name = "_buttonAgree";
            _buttonAgree.Size = new Size(100, 30);
            _buttonAgree.TabIndex = 0;
            _buttonAgree.Text = "Добавить";
            _buttonAgree.UseVisualStyleBackColor = false;
            // 
            // _buttonCancel
            // 
            _buttonCancel.Location = new Point(420, 300);
            _buttonCancel.Name = "_buttonCancel";
            _buttonCancel.Size = new Size(100, 30);
            _buttonCancel.TabIndex = 1;
            _buttonCancel.Text = "Отменить";
            _buttonCancel.UseVisualStyleBackColor = false;
            // 
            // _buttonRandom
            // 
            _buttonRandom.BackColor = SystemColors.ButtonHighlight;
            _buttonRandom.ForeColor = SystemColors.ActiveCaptionText;
            _buttonRandom.Location = new Point(50, 300);
            _buttonRandom.Name = "_buttonRandom";
            _buttonRandom.Size = new Size(100, 30);
            _buttonRandom.TabIndex = 2;
            _buttonRandom.Text = "Заполнить";
            _buttonRandom.UseVisualStyleBackColor = false;
            // 
            // _comboBoxTransport
            // 
            _comboBoxTransport.DropDownStyle = ComboBoxStyle.DropDownList;
            _comboBoxTransport.Location = new Point(50, 40);
            _comboBoxTransport.Name = "_comboBoxTransport";
            _comboBoxTransport.Size = new Size(150, 23);
            _comboBoxTransport.TabIndex = 3;
            // 
            // _comboBoxFuel
            // 
            _comboBoxFuel.DropDownStyle = ComboBoxStyle.DropDownList;
            _comboBoxFuel.Location = new Point(20, 50);
            _comboBoxFuel.Name = "_comboBoxFuel";
            _comboBoxFuel.Size = new Size(150, 23);
            _comboBoxFuel.TabIndex = 4;
            // 
            // _comboBoxHybridFuel
            // 
            _comboBoxHybridFuel.DropDownStyle = ComboBoxStyle.DropDownList;
            _comboBoxHybridFuel.Location = new Point(20, 50);
            _comboBoxHybridFuel.Name = "_comboBoxHybridFuel";
            _comboBoxHybridFuel.Size = new Size(150, 23);
            _comboBoxHybridFuel.TabIndex = 0;
            // 
            // _labelTransport
            // 
            _labelTransport.Location = new Point(50, 20);
            _labelTransport.Name = "_labelTransport";
            _labelTransport.Size = new Size(150, 20);
            _labelTransport.TabIndex = 0;
            _labelTransport.Text = "Транспорт";
            // 
            // _labelFuel
            // 
            _labelFuel.Location = new Point(20, 30);
            _labelFuel.Name = "_labelFuel";
            _labelFuel.Size = new Size(150, 20);
            _labelFuel.TabIndex = 0;
            _labelFuel.Text = "Топливо";
            // 
            // _labelFuelHybrid
            // 
            _labelFuelHybrid.Location = new Point(20, 30);
            _labelFuelHybrid.Name = "_labelFuelHybrid";
            _labelFuelHybrid.Size = new Size(150, 20);
            _labelFuelHybrid.TabIndex = 0;
            _labelFuelHybrid.Text = "Топливо";
            // 
            // _labelCapacity
            // 
            _labelCapacity.Location = new Point(20, 80);
            _labelCapacity.Name = "_labelCapacity";
            _labelCapacity.Size = new Size(150, 20);
            _labelCapacity.TabIndex = 0;
            _labelCapacity.Text = "Мощность л.с.";
            // 
            // _labelMass
            // 
            _labelMass.Location = new Point(20, 130);
            _labelMass.Name = "_labelMass";
            _labelMass.Size = new Size(150, 20);
            _labelMass.TabIndex = 2;
            _labelMass.Text = "Масса т.";
            // 
            // _labelHybridCapacity
            // 
            _labelHybridCapacity.Location = new Point(20, 80);
            _labelHybridCapacity.Name = "_labelHybridCapacity";
            _labelHybridCapacity.Size = new Size(150, 20);
            _labelHybridCapacity.TabIndex = 2;
            _labelHybridCapacity.Text = "Мощность л.с.";
            // 
            // _labelBladeLength
            // 
            _labelBladeLength.Location = new Point(20, 30);
            _labelBladeLength.Name = "_labelBladeLength";
            _labelBladeLength.Size = new Size(150, 20);
            _labelBladeLength.TabIndex = 1;
            _labelBladeLength.Text = "Длина лопастей м.";
            // 
            // _textBoxCapacity
            // 
            _textBoxCapacity.Location = new Point(20, 100);
            _textBoxCapacity.Name = "_textBoxCapacity";
            _textBoxCapacity.Size = new Size(150, 23);
            _textBoxCapacity.TabIndex = 1;
            // 
            // _textBoxMass
            // 
            _textBoxMass.Location = new Point(20, 150);
            _textBoxMass.Name = "_textBoxMass";
            _textBoxMass.Size = new Size(150, 23);
            _textBoxMass.TabIndex = 3;
            // 
            // _textBoxHybridCapacity
            // 
            _textBoxHybridCapacity.Location = new Point(20, 100);
            _textBoxHybridCapacity.Name = "_textBoxHybridCapacity";
            _textBoxHybridCapacity.Size = new Size(150, 23);
            _textBoxHybridCapacity.TabIndex = 1;
            // 
            // _textBoxBladeLength
            // 
            _textBoxBladeLength.Location = new Point(20, 50);
            _textBoxBladeLength.Name = "_textBoxBladeLength";
            _textBoxBladeLength.Size = new Size(150, 23);
            _textBoxBladeLength.TabIndex = 0;
            // 
            // _groupBoxData
            // 
            _groupBoxData.Controls.Add(_labelCapacity);
            _groupBoxData.Controls.Add(_labelFuel);
            _groupBoxData.Controls.Add(_textBoxCapacity);
            _groupBoxData.Controls.Add(_labelMass);
            _groupBoxData.Controls.Add(_textBoxMass);
            _groupBoxData.Controls.Add(_comboBoxFuel);
            _groupBoxData.Location = new Point(50, 80);
            _groupBoxData.Name = "_groupBoxData";
            _groupBoxData.Size = new Size(220, 200);
            _groupBoxData.TabIndex = 0;
            _groupBoxData.TabStop = false;
            _groupBoxData.Text = "Ввод данных о двигателе и массе";
            // 
            // _groupBoxDataHybridCar
            // 
            _groupBoxDataHybridCar.Controls.Add(_comboBoxHybridFuel);
            _groupBoxDataHybridCar.Controls.Add(_textBoxHybridCapacity);
            _groupBoxDataHybridCar.Controls.Add(_labelHybridCapacity);
            _groupBoxDataHybridCar.Controls.Add(_labelFuelHybrid);
            _groupBoxDataHybridCar.Location = new Point(300, 80);
            _groupBoxDataHybridCar.Name = "_groupBoxDataHybridCar";
            _groupBoxDataHybridCar.Size = new Size(220, 200);
            _groupBoxDataHybridCar.TabIndex = 4;
            _groupBoxDataHybridCar.TabStop = false;
            _groupBoxDataHybridCar.Text = "Ввод данных о 2-ом двигателе";
            _groupBoxDataHybridCar.Visible = false;
            // 
            // _groupBoxDataHelicopter
            // 
            _groupBoxDataHelicopter.Controls.Add(_textBoxBladeLength);
            _groupBoxDataHelicopter.Controls.Add(_labelBladeLength);
            _groupBoxDataHelicopter.Location = new Point(300, 80);
            _groupBoxDataHelicopter.Name = "_groupBoxDataHelicopter";
            _groupBoxDataHelicopter.Size = new Size(220, 100);
            _groupBoxDataHelicopter.TabIndex = 5;
            _groupBoxDataHelicopter.TabStop = false;
            _groupBoxDataHelicopter.Text = "Ввод данных о лопастях";
            _groupBoxDataHelicopter.Visible = false;
            // 
            // DataForm
            // 
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(560, 350);
            Controls.Add(_labelTransport);
            Controls.Add(_buttonAgree);
            Controls.Add(_buttonCancel);
            Controls.Add(_buttonRandom);
            Controls.Add(_comboBoxTransport);
            Controls.Add(_groupBoxData);
            Controls.Add(_groupBoxDataHybridCar);
            Controls.Add(_groupBoxDataHelicopter);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DataForm";
            Text = "Добавить транспорт";
            _groupBoxData.ResumeLayout(false);
            _groupBoxData.PerformLayout();
            _groupBoxDataHybridCar.ResumeLayout(false);
            _groupBoxDataHybridCar.PerformLayout();
            _groupBoxDataHelicopter.ResumeLayout(false);
            _groupBoxDataHelicopter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}