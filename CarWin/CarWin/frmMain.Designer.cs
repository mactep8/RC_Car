namespace CarWin
{
    partial class frmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBind = new System.Windows.Forms.Button();
            this.btnSetCurrent = new System.Windows.Forms.Button();
            this.btnSaveCurr = new System.Windows.Forms.Button();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.cbCurrentItem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadCurr = new System.Windows.Forms.Button();
            this.btnLoadAll = new System.Windows.Forms.Button();
            this.ch1 = new System.Windows.Forms.TextBox();
            this.ch2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ch1Min = new System.Windows.Forms.TextBox();
            this.ch1Center = new System.Windows.Forms.TextBox();
            this.ch1Max = new System.Windows.Forms.TextBox();
            this.ch2Max = new System.Windows.Forms.TextBox();
            this.ch2Center = new System.Windows.Forms.TextBox();
            this.ch2Min = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLoadCalibration = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbPort);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 48);
            this.panel1.TabIndex = 1;
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(12, 12);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(121, 21);
            this.cbPort.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(139, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(94, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Соединение";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(763, 342);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnLoadCalibration);
            this.tabPage1.Controls.Add(this.ch2Max);
            this.tabPage1.Controls.Add(this.ch2Center);
            this.tabPage1.Controls.Add(this.ch2Min);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.ch1Max);
            this.tabPage1.Controls.Add(this.ch1Center);
            this.tabPage1.Controls.Add(this.ch1Min);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.ch2);
            this.tabPage1.Controls.Add(this.ch1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(755, 316);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config & Monitor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(755, 316);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnBind);
            this.panel3.Controls.Add(this.btnSetCurrent);
            this.panel3.Controls.Add(this.btnSaveCurr);
            this.panel3.Controls.Add(this.btnSaveAll);
            this.panel3.Controls.Add(this.cbCurrentItem);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnLoadCurr);
            this.panel3.Controls.Add(this.btnLoadAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 310);
            this.panel3.TabIndex = 1;
            // 
            // btnBind
            // 
            this.btnBind.Location = new System.Drawing.Point(12, 181);
            this.btnBind.Name = "btnBind";
            this.btnBind.Size = new System.Drawing.Size(169, 23);
            this.btnBind.TabIndex = 7;
            this.btnBind.Text = "Привязка";
            this.btnBind.UseVisualStyleBackColor = true;
            // 
            // btnSetCurrent
            // 
            this.btnSetCurrent.Location = new System.Drawing.Point(12, 36);
            this.btnSetCurrent.Name = "btnSetCurrent";
            this.btnSetCurrent.Size = new System.Drawing.Size(169, 23);
            this.btnSetCurrent.TabIndex = 6;
            this.btnSetCurrent.Text = "Установить";
            this.btnSetCurrent.UseVisualStyleBackColor = true;
            // 
            // btnSaveCurr
            // 
            this.btnSaveCurr.Location = new System.Drawing.Point(12, 152);
            this.btnSaveCurr.Name = "btnSaveCurr";
            this.btnSaveCurr.Size = new System.Drawing.Size(169, 23);
            this.btnSaveCurr.TabIndex = 5;
            this.btnSaveCurr.Text = "Загрузить текущий";
            this.btnSaveCurr.UseVisualStyleBackColor = true;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(12, 123);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(169, 23);
            this.btnSaveAll.TabIndex = 4;
            this.btnSaveAll.Text = "Загрузить все";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            // 
            // cbCurrentItem
            // 
            this.cbCurrentItem.FormattingEnabled = true;
            this.cbCurrentItem.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbCurrentItem.Location = new System.Drawing.Point(70, 9);
            this.cbCurrentItem.Name = "cbCurrentItem";
            this.cbCurrentItem.Size = new System.Drawing.Size(75, 21);
            this.cbCurrentItem.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Текущий";
            // 
            // btnLoadCurr
            // 
            this.btnLoadCurr.Location = new System.Drawing.Point(12, 94);
            this.btnLoadCurr.Name = "btnLoadCurr";
            this.btnLoadCurr.Size = new System.Drawing.Size(169, 23);
            this.btnLoadCurr.TabIndex = 1;
            this.btnLoadCurr.Text = "Считать текущий";
            this.btnLoadCurr.UseVisualStyleBackColor = true;
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Location = new System.Drawing.Point(12, 65);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(169, 23);
            this.btnLoadAll.TabIndex = 0;
            this.btnLoadAll.Text = "Считать все";
            this.btnLoadAll.UseVisualStyleBackColor = true;
            // 
            // ch1
            // 
            this.ch1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ch1.Location = new System.Drawing.Point(647, 6);
            this.ch1.Name = "ch1";
            this.ch1.Size = new System.Drawing.Size(100, 20);
            this.ch1.TabIndex = 0;
            // 
            // ch2
            // 
            this.ch2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ch2.Location = new System.Drawing.Point(647, 32);
            this.ch2.Name = "ch2";
            this.ch2.Size = new System.Drawing.Size(100, 20);
            this.ch2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(582, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Channel 1";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(582, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Channel 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Калибровочные значения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Колесо";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(162, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Min";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(271, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Center";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(369, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Max";
            // 
            // ch1Min
            // 
            this.ch1Min.Location = new System.Drawing.Point(144, 25);
            this.ch1Min.Name = "ch1Min";
            this.ch1Min.Size = new System.Drawing.Size(100, 20);
            this.ch1Min.TabIndex = 9;
            // 
            // ch1Center
            // 
            this.ch1Center.Location = new System.Drawing.Point(250, 25);
            this.ch1Center.Name = "ch1Center";
            this.ch1Center.Size = new System.Drawing.Size(100, 20);
            this.ch1Center.TabIndex = 10;
            // 
            // ch1Max
            // 
            this.ch1Max.Location = new System.Drawing.Point(356, 25);
            this.ch1Max.Name = "ch1Max";
            this.ch1Max.Size = new System.Drawing.Size(100, 20);
            this.ch1Max.TabIndex = 11;
            // 
            // ch2Max
            // 
            this.ch2Max.Location = new System.Drawing.Point(356, 51);
            this.ch2Max.Name = "ch2Max";
            this.ch2Max.Size = new System.Drawing.Size(100, 20);
            this.ch2Max.TabIndex = 15;
            // 
            // ch2Center
            // 
            this.ch2Center.Location = new System.Drawing.Point(250, 51);
            this.ch2Center.Name = "ch2Center";
            this.ch2Center.Size = new System.Drawing.Size(100, 20);
            this.ch2Center.TabIndex = 14;
            // 
            // ch2Min
            // 
            this.ch2Min.Location = new System.Drawing.Point(144, 51);
            this.ch2Min.Name = "ch2Min";
            this.ch2Min.Size = new System.Drawing.Size(100, 20);
            this.ch2Min.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(94, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Курок";
            // 
            // btnLoadCalibration
            // 
            this.btnLoadCalibration.Location = new System.Drawing.Point(462, 23);
            this.btnLoadCalibration.Name = "btnLoadCalibration";
            this.btnLoadCalibration.Size = new System.Drawing.Size(114, 23);
            this.btnLoadCalibration.TabIndex = 16;
            this.btnLoadCalibration.Text = "Load Calibration";
            this.btnLoadCalibration.UseVisualStyleBackColor = true;
            this.btnLoadCalibration.Click += new System.EventHandler(this.btnLoadCalibration_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 390);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "CarWin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Button btnConnect;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBind;
        private System.Windows.Forms.Button btnSetCurrent;
        private System.Windows.Forms.Button btnSaveCurr;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.ComboBox cbCurrentItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadCurr;
        private System.Windows.Forms.Button btnLoadAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ch2;
        private System.Windows.Forms.TextBox ch1;
        private System.Windows.Forms.TextBox ch2Max;
        private System.Windows.Forms.TextBox ch2Center;
        private System.Windows.Forms.TextBox ch2Min;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ch1Max;
        private System.Windows.Forms.TextBox ch1Center;
        private System.Windows.Forms.TextBox ch1Min;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLoadCalibration;
    }
}

