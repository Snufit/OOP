using System.Drawing;

namespace View
{
    /// <summary>
    /// Класс FilterForm. 
    /// </summary>
    partial class FilterForm
    {
        /// <summary>
        /// Кнопка "ОК".
        /// </summary>
        private Button _buttonAgree;

        /// <summary>
        /// CheckBox для машины.
        /// </summary>
        private CheckBox _checkBoxFindCar;

        /// <summary>
        /// CheckBox для гибридной машины.
        /// </summary>
        private CheckBox _checkBoxFindHybridCar;

        /// <summary>
        /// CheckBox для вертолета.
        /// </summary>
        private CheckBox _checkBoxFindHelicopter;

        /// <summary>
        /// CheckBox для мощности.
        /// </summary>
        private CheckBox _checkBoxCapacity;

        /// <summary>
        /// CheckBox для массы.
        /// </summary>
        private CheckBox _checkBoxMass;

        private TextBox _textBoxCapacity;
        private TextBox _textBoxMass;

        /// <summary>
        /// GroupBox для поиска по типу транспорта.
        /// </summary>
        private GroupBox _groupBoxFilterType;

        /// <summary>
        /// GroupBox для поиска по типу транспорта.
        /// </summary>
        private GroupBox _groupBoxFilterData;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _buttonAgree = new Button();
            _checkBoxFindCar = new CheckBox();
            _checkBoxFindHybridCar = new CheckBox();
            _checkBoxFindHelicopter = new CheckBox();
            _checkBoxCapacity = new CheckBox();
            _checkBoxMass = new CheckBox();
            _textBoxCapacity = new TextBox();
            _textBoxMass = new TextBox();
            _groupBoxFilterType = new GroupBox();
            _groupBoxFilterData = new GroupBox();
            _groupBoxFilterType.SuspendLayout();
            _groupBoxFilterData.SuspendLayout();
            SuspendLayout();
            // 
            // _buttonAgree
            // 
            _buttonAgree.BackColor = SystemColors.ButtonHighlight;
            _buttonAgree.ForeColor = SystemColors.ActiveCaptionText;
            _buttonAgree.Location = new Point(130, 260);
            _buttonAgree.Name = "_buttonAgree";
            _buttonAgree.Size = new Size(100, 30);
            _buttonAgree.TabIndex = 0;
            _buttonAgree.Text = "ОК";
            _buttonAgree.UseVisualStyleBackColor = false;
            // 
            // _checkBoxFindCar
            // 
            _checkBoxFindCar.AutoSize = true;
            _checkBoxFindCar.Location = new Point(20, 30);
            _checkBoxFindCar.Name = "_checkBoxFindCar";
            _checkBoxFindCar.Size = new Size(74, 19);
            _checkBoxFindCar.TabIndex = 0;
            _checkBoxFindCar.Text = "Машина";
            // 
            // _checkBoxFindHybridCar
            // 
            _checkBoxFindHybridCar.AutoSize = true;
            _checkBoxFindHybridCar.Location = new Point(20, 60);
            _checkBoxFindHybridCar.Name = "_checkBoxFindHybridCar";
            _checkBoxFindHybridCar.Size = new Size(134, 19);
            _checkBoxFindHybridCar.TabIndex = 1;
            _checkBoxFindHybridCar.Text = "Гибридная машина";
            // 
            // _checkBoxFindHelicopter
            // 
            _checkBoxFindHelicopter.AutoSize = true;
            _checkBoxFindHelicopter.Location = new Point(20, 90);
            _checkBoxFindHelicopter.Name = "_checkBoxFindHelicopter";
            _checkBoxFindHelicopter.Size = new Size(76, 19);
            _checkBoxFindHelicopter.TabIndex = 2;
            _checkBoxFindHelicopter.Text = "Вертолет";
            // 
            // _checkBoxCapacity
            // 
            _checkBoxCapacity.AutoSize = true;
            _checkBoxCapacity.Location = new Point(20, 30);
            _checkBoxCapacity.Name = "_checkBoxCapacity";
            _checkBoxCapacity.Size = new Size(108, 19);
            _checkBoxCapacity.TabIndex = 2;
            _checkBoxCapacity.Text = "Мощность л.с.";
            // 
            // _checkBoxMass
            // 
            _checkBoxMass.AutoSize = true;
            _checkBoxMass.Location = new Point(20, 60);
            _checkBoxMass.Name = "_checkBoxMass";
            _checkBoxMass.Size = new Size(72, 19);
            _checkBoxMass.TabIndex = 2;
            _checkBoxMass.Text = "Масса т.";
            // 
            // _textBoxCapacity
            // 
            _textBoxCapacity.Location = new Point(130, 30);
            _textBoxCapacity.Name = "_textBoxCapacity";
            _textBoxCapacity.Size = new Size(50, 23);
            _textBoxCapacity.TabIndex = 3;
            // 
            // _textBoxMass
            // 
            _textBoxMass.Location = new Point(130, 60);
            _textBoxMass.Name = "_textBoxMass";
            _textBoxMass.Size = new Size(50, 23);
            _textBoxMass.TabIndex = 4;
            // 
            // _groupBoxFilterType
            // 
            _groupBoxFilterType.Controls.Add(_checkBoxFindCar);
            _groupBoxFilterType.Controls.Add(_checkBoxFindHybridCar);
            _groupBoxFilterType.Controls.Add(_checkBoxFindHelicopter);
            _groupBoxFilterType.Location = new Point(30, 20);
            _groupBoxFilterType.Name = "_groupBoxFilterType";
            _groupBoxFilterType.Size = new Size(200, 120);
            _groupBoxFilterType.TabIndex = 0;
            _groupBoxFilterType.TabStop = false;
            _groupBoxFilterType.Text = "Поиск по типу транспорта";
            // 
            // _groupBoxFilterData
            // 
            _groupBoxFilterData.Controls.Add(_checkBoxCapacity);
            _groupBoxFilterData.Controls.Add(_checkBoxMass);
            _groupBoxFilterData.Controls.Add(_textBoxCapacity);
            _groupBoxFilterData.Controls.Add(_textBoxMass);
            _groupBoxFilterData.Location = new Point(30, 150);
            _groupBoxFilterData.Name = "_groupBoxFilterData";
            _groupBoxFilterData.Size = new Size(200, 100);
            _groupBoxFilterData.TabIndex = 0;
            _groupBoxFilterData.TabStop = false;
            _groupBoxFilterData.Text = "Поиск по данным транспорта";
            // 
            // FilterForm
            // 
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(260, 310);
            Controls.Add(_groupBoxFilterType);
            Controls.Add(_groupBoxFilterData);
            Controls.Add(_buttonAgree);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FilterForm";
            Text = "Найти";
            Load += FilterForm_Load;
            _groupBoxFilterType.ResumeLayout(false);
            _groupBoxFilterType.PerformLayout();
            _groupBoxFilterData.ResumeLayout(false);
            _groupBoxFilterData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}