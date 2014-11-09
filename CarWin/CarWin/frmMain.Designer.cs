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
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.ch2Max = new System.Windows.Forms.TextBox();
            this.ch2Center = new System.Windows.Forms.TextBox();
            this.ch2Min = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ch1Max = new System.Windows.Forms.TextBox();
            this.ch1Center = new System.Windows.Forms.TextBox();
            this.ch1Min = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ch2 = new System.Windows.Forms.TextBox();
            this.ch1 = new System.Windows.Forms.TextBox();
            this.tabModels = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ch2_trimm = new System.Windows.Forms.NumericUpDown();
            this.ch2_expright = new System.Windows.Forms.NumericUpDown();
            this.ch2_expleft = new System.Windows.Forms.NumericUpDown();
            this.ch2_reverse = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.ch1_trimm = new System.Windows.Forms.NumericUpDown();
            this.ch1_expright = new System.Windows.Forms.NumericUpDown();
            this.ch1_expleft = new System.Windows.Forms.NumericUpDown();
            this.ch1_reverse = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnCh4 = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.CheckBox();
            this.btnPrev = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.mdlName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.MatchByte = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.addr3 = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.addr2 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.addr1 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.addr0 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSaveCurr = new System.Windows.Forms.Button();
            this.cbCurrentItem = new System.Windows.Forms.ComboBox();
            this.btnLoadCurr = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabModels.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch2_trimm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch2_expright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch2_expleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch1_trimm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch1_expright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch1_expleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MatchByte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addr3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addr0)).BeginInit();
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
            this.serialPort.DtrEnable = true;
            this.serialPort.RtsEnable = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabModels);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(763, 342);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnCalibrate);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.btnLoad);
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
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(250, 77);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(100, 23);
            this.btnCalibrate.TabIndex = 18;
            this.btnCalibrate.Text = "New Calibration";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(250, 106);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(144, 106);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 23);
            this.btnLoad.TabIndex = 16;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
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
            // ch1Max
            // 
            this.ch1Max.Location = new System.Drawing.Point(356, 25);
            this.ch1Max.Name = "ch1Max";
            this.ch1Max.Size = new System.Drawing.Size(100, 20);
            this.ch1Max.TabIndex = 11;
            // 
            // ch1Center
            // 
            this.ch1Center.Location = new System.Drawing.Point(250, 25);
            this.ch1Center.Name = "ch1Center";
            this.ch1Center.Size = new System.Drawing.Size(100, 20);
            this.ch1Center.TabIndex = 10;
            // 
            // ch1Min
            // 
            this.ch1Min.Location = new System.Drawing.Point(144, 25);
            this.ch1Min.Name = "ch1Min";
            this.ch1Min.Size = new System.Drawing.Size(100, 20);
            this.ch1Min.TabIndex = 9;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(271, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Center";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Колесо";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(464, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Channel 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(464, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Channel 1";
            // 
            // ch2
            // 
            this.ch2.Location = new System.Drawing.Point(529, 51);
            this.ch2.Name = "ch2";
            this.ch2.Size = new System.Drawing.Size(100, 20);
            this.ch2.TabIndex = 1;
            // 
            // ch1
            // 
            this.ch1.Location = new System.Drawing.Point(529, 25);
            this.ch1.Name = "ch1";
            this.ch1.Size = new System.Drawing.Size(100, 20);
            this.ch1.TabIndex = 0;
            // 
            // tabModels
            // 
            this.tabModels.Controls.Add(this.panel2);
            this.tabModels.Controls.Add(this.splitter1);
            this.tabModels.Controls.Add(this.panel3);
            this.tabModels.Location = new System.Drawing.Point(4, 22);
            this.tabModels.Name = "tabModels";
            this.tabModels.Padding = new System.Windows.Forms.Padding(3);
            this.tabModels.Size = new System.Drawing.Size(755, 316);
            this.tabModels.TabIndex = 1;
            this.tabModels.Text = "Модели";
            this.tabModels.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ch2_trimm);
            this.panel2.Controls.Add(this.ch2_expright);
            this.panel2.Controls.Add(this.ch2_expleft);
            this.panel2.Controls.Add(this.ch2_reverse);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.ch1_trimm);
            this.panel2.Controls.Add(this.ch1_expright);
            this.panel2.Controls.Add(this.ch1_expleft);
            this.panel2.Controls.Add(this.ch1_reverse);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.btnCh4);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnPrev);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.mdlName);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.MatchByte);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.addr3);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.addr2);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.addr1);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.addr0);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(211, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(541, 310);
            this.panel2.TabIndex = 3;
            // 
            // ch2_trimm
            // 
            this.ch2_trimm.Location = new System.Drawing.Point(311, 204);
            this.ch2_trimm.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.ch2_trimm.Name = "ch2_trimm";
            this.ch2_trimm.Size = new System.Drawing.Size(120, 20);
            this.ch2_trimm.TabIndex = 32;
            this.ch2_trimm.Leave += new System.EventHandler(this.ch2_trimm_Leave);
            // 
            // ch2_expright
            // 
            this.ch2_expright.Location = new System.Drawing.Point(311, 178);
            this.ch2_expright.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.ch2_expright.Name = "ch2_expright";
            this.ch2_expright.Size = new System.Drawing.Size(120, 20);
            this.ch2_expright.TabIndex = 31;
            this.ch2_expright.Leave += new System.EventHandler(this.ch2_expright_Leave);
            // 
            // ch2_expleft
            // 
            this.ch2_expleft.Location = new System.Drawing.Point(311, 152);
            this.ch2_expleft.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.ch2_expleft.Name = "ch2_expleft";
            this.ch2_expleft.Size = new System.Drawing.Size(120, 20);
            this.ch2_expleft.TabIndex = 30;
            this.ch2_expleft.Leave += new System.EventHandler(this.ch2_expleft_Leave);
            // 
            // ch2_reverse
            // 
            this.ch2_reverse.AutoSize = true;
            this.ch2_reverse.Location = new System.Drawing.Point(311, 129);
            this.ch2_reverse.Name = "ch2_reverse";
            this.ch2_reverse.Size = new System.Drawing.Size(63, 17);
            this.ch2_reverse.TabIndex = 29;
            this.ch2_reverse.Text = "Реверс";
            this.ch2_reverse.UseVisualStyleBackColor = true;
            this.ch2_reverse.CheckedChanged += new System.EventHandler(this.ch2_reverse_CheckedChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(251, 206);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 13);
            this.label21.TabIndex = 28;
            this.label21.Text = "Триммер";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(221, 180);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 13);
            this.label22.TabIndex = 27;
            this.label22.Text = "Расход правый";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(227, 154);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(78, 13);
            this.label23.TabIndex = 26;
            this.label23.Text = "Расход левый";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(258, 130);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 13);
            this.label24.TabIndex = 25;
            this.label24.Text = "Канал 2";
            // 
            // ch1_trimm
            // 
            this.ch1_trimm.Location = new System.Drawing.Point(96, 204);
            this.ch1_trimm.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.ch1_trimm.Name = "ch1_trimm";
            this.ch1_trimm.Size = new System.Drawing.Size(120, 20);
            this.ch1_trimm.TabIndex = 24;
            this.ch1_trimm.Leave += new System.EventHandler(this.ch1_trimm_Leave);
            // 
            // ch1_expright
            // 
            this.ch1_expright.Location = new System.Drawing.Point(96, 178);
            this.ch1_expright.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.ch1_expright.Name = "ch1_expright";
            this.ch1_expright.Size = new System.Drawing.Size(120, 20);
            this.ch1_expright.TabIndex = 23;
            this.ch1_expright.Leave += new System.EventHandler(this.ch1_expright_Leave);
            // 
            // ch1_expleft
            // 
            this.ch1_expleft.Location = new System.Drawing.Point(96, 152);
            this.ch1_expleft.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.ch1_expleft.Name = "ch1_expleft";
            this.ch1_expleft.Size = new System.Drawing.Size(120, 20);
            this.ch1_expleft.TabIndex = 22;
            this.ch1_expleft.Leave += new System.EventHandler(this.ch1_expleft_Leave);
            // 
            // ch1_reverse
            // 
            this.ch1_reverse.AutoSize = true;
            this.ch1_reverse.Location = new System.Drawing.Point(96, 129);
            this.ch1_reverse.Name = "ch1_reverse";
            this.ch1_reverse.Size = new System.Drawing.Size(63, 17);
            this.ch1_reverse.TabIndex = 21;
            this.ch1_reverse.Text = "Реверс";
            this.ch1_reverse.UseVisualStyleBackColor = true;
            this.ch1_reverse.CheckedChanged += new System.EventHandler(this.ch1_reverse_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(36, 206);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "Триммер";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 180);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Расход правый";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 154);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "Расход левый";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(43, 130);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Канал 1";
            // 
            // btnCh4
            // 
            this.btnCh4.AutoSize = true;
            this.btnCh4.Location = new System.Drawing.Point(275, 100);
            this.btnCh4.Name = "btnCh4";
            this.btnCh4.Size = new System.Drawing.Size(54, 17);
            this.btnCh4.TabIndex = 16;
            this.btnCh4.Text = "dCh 4";
            this.btnCh4.UseVisualStyleBackColor = true;
            this.btnCh4.Leave += new System.EventHandler(this.btnPrev_Leave);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(208, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 17);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Leave += new System.EventHandler(this.btnPrev_Leave);
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.Location = new System.Drawing.Point(155, 100);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(38, 17);
            this.btnNext.TabIndex = 14;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Leave += new System.EventHandler(this.btnPrev_Leave);
            // 
            // btnPrev
            // 
            this.btnPrev.AutoSize = true;
            this.btnPrev.Location = new System.Drawing.Point(96, 100);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(38, 17);
            this.btnPrev.TabIndex = 13;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Leave += new System.EventHandler(this.btnPrev_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(93, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Кнопки (фиксация)";
            // 
            // mdlName
            // 
            this.mdlName.Location = new System.Drawing.Point(96, 5);
            this.mdlName.Name = "mdlName";
            this.mdlName.Size = new System.Drawing.Size(161, 20);
            this.mdlName.TabIndex = 11;
            this.mdlName.Leave += new System.EventHandler(this.mdlName_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Наименование";
            // 
            // MatchByte
            // 
            this.MatchByte.Location = new System.Drawing.Point(96, 57);
            this.MatchByte.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MatchByte.Name = "MatchByte";
            this.MatchByte.Size = new System.Drawing.Size(75, 20);
            this.MatchByte.TabIndex = 9;
            this.MatchByte.Leave += new System.EventHandler(this.MatchByte_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Match Byte";
            // 
            // addr3
            // 
            this.addr3.Location = new System.Drawing.Point(356, 31);
            this.addr3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.addr3.Name = "addr3";
            this.addr3.Size = new System.Drawing.Size(75, 20);
            this.addr3.TabIndex = 7;
            this.addr3.Leave += new System.EventHandler(this.addr3_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(345, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = ".";
            // 
            // addr2
            // 
            this.addr2.Location = new System.Drawing.Point(268, 31);
            this.addr2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.addr2.Name = "addr2";
            this.addr2.Size = new System.Drawing.Size(75, 20);
            this.addr2.TabIndex = 5;
            this.addr2.Leave += new System.EventHandler(this.addr2_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(257, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = ".";
            // 
            // addr1
            // 
            this.addr1.Location = new System.Drawing.Point(182, 31);
            this.addr1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.addr1.Name = "addr1";
            this.addr1.Size = new System.Drawing.Size(75, 20);
            this.addr1.TabIndex = 3;
            this.addr1.Leave += new System.EventHandler(this.addr1_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(171, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = ".";
            // 
            // addr0
            // 
            this.addr0.Location = new System.Drawing.Point(96, 31);
            this.addr0.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.addr0.Name = "addr0";
            this.addr0.Size = new System.Drawing.Size(75, 20);
            this.addr0.TabIndex = 1;
            this.addr0.Leave += new System.EventHandler(this.addr0_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(52, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Адрес";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(203, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 310);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.btnLoadFromFile);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnSaveCurr);
            this.panel3.Controls.Add(this.cbCurrentItem);
            this.panel3.Controls.Add(this.btnLoadCurr);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 310);
            this.panel3.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Записать в файл";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.Location = new System.Drawing.Point(12, 123);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(169, 23);
            this.btnLoadFromFile.TabIndex = 7;
            this.btnLoadFromFile.Text = "Читать из файла";
            this.btnLoadFromFile.UseVisualStyleBackColor = true;
            this.btnLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Записать модель";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSaveCurr
            // 
            this.btnSaveCurr.Location = new System.Drawing.Point(12, 65);
            this.btnSaveCurr.Name = "btnSaveCurr";
            this.btnSaveCurr.Size = new System.Drawing.Size(169, 23);
            this.btnSaveCurr.TabIndex = 5;
            this.btnSaveCurr.Text = "Перечитать модель";
            this.btnSaveCurr.UseVisualStyleBackColor = true;
            this.btnSaveCurr.Click += new System.EventHandler(this.btnSaveCurr_Click);
            // 
            // cbCurrentItem
            // 
            this.cbCurrentItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cbCurrentItem.Location = new System.Drawing.Point(12, 9);
            this.cbCurrentItem.Name = "cbCurrentItem";
            this.cbCurrentItem.Size = new System.Drawing.Size(169, 21);
            this.cbCurrentItem.TabIndex = 3;
            this.cbCurrentItem.SelectedIndexChanged += new System.EventHandler(this.cbCurrentItem_SelectedIndexChanged);
            // 
            // btnLoadCurr
            // 
            this.btnLoadCurr.Location = new System.Drawing.Point(12, 36);
            this.btnLoadCurr.Name = "btnLoadCurr";
            this.btnLoadCurr.Size = new System.Drawing.Size(169, 23);
            this.btnLoadCurr.TabIndex = 1;
            this.btnLoadCurr.Text = "Обновить";
            this.btnLoadCurr.UseVisualStyleBackColor = true;
            this.btnLoadCurr.Click += new System.EventHandler(this.btnLoadCurr_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.mdl";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Model|*.mdl";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.mdl";
            this.saveFileDialog1.Filter = "Model|*.mdl";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 390);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarWin";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabModels.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch2_trimm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch2_expright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch2_expleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch1_trimm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch1_expright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch1_expleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MatchByte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addr3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addr0)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Button btnConnect;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabModels;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSaveCurr;
        private System.Windows.Forms.ComboBox cbCurrentItem;
        private System.Windows.Forms.Button btnLoadCurr;
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
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCalibrate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown ch2_trimm;
        private System.Windows.Forms.NumericUpDown ch2_expright;
        private System.Windows.Forms.NumericUpDown ch2_expleft;
        private System.Windows.Forms.CheckBox ch2_reverse;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown ch1_trimm;
        private System.Windows.Forms.NumericUpDown ch1_expright;
        private System.Windows.Forms.NumericUpDown ch1_expleft;
        private System.Windows.Forms.CheckBox ch1_reverse;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox btnCh4;
        private System.Windows.Forms.CheckBox btnCancel;
        private System.Windows.Forms.CheckBox btnNext;
        private System.Windows.Forms.CheckBox btnPrev;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox mdlName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown MatchByte;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown addr3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown addr2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown addr1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown addr0;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLoadFromFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

