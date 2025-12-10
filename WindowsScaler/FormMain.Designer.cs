namespace WindowsScaler
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Operations_CurrentFPS = new System.Windows.Forms.Label();
            this.timerCheckWorker = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker_DoWork = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOperations = new System.Windows.Forms.TabPage();
            this.labelState = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Operations_CurrentMode = new System.Windows.Forms.ComboBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.numericUpDownMaxFPS = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonSetUoutputToRightOfInput = new System.Windows.Forms.Button();
            this.button2XInputSize = new System.Windows.Forms.Button();
            this.numericUpDownOutputPosX = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDownOutputHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOutputPosY = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDownOutputWidth = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownInputX = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownInputHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInputY = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownInputWidth = new System.Windows.Forms.NumericUpDown();
            this.buttonOpenMyDocumentsDirectory = new System.Windows.Forms.Button();
            this.buttonOpenDataDirectory = new System.Windows.Forms.Button();
            this.pictureBoxExampleImage = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPageOperations.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxFPS)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExampleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FPS";
            // 
            // label_Operations_CurrentFPS
            // 
            this.label_Operations_CurrentFPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Operations_CurrentFPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Operations_CurrentFPS.Location = new System.Drawing.Point(74, 9);
            this.label_Operations_CurrentFPS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Operations_CurrentFPS.Name = "label_Operations_CurrentFPS";
            this.label_Operations_CurrentFPS.Size = new System.Drawing.Size(106, 22);
            this.label_Operations_CurrentFPS.TabIndex = 1;
            this.label_Operations_CurrentFPS.Text = "Last Reading";
            this.label_Operations_CurrentFPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerCheckWorker
            // 
            this.timerCheckWorker.Interval = 500;
            this.timerCheckWorker.Tick += new System.EventHandler(this.timerGetFromxConnect_Tick);
            // 
            // backgroundWorker_DoWork
            // 
            this.backgroundWorker_DoWork.WorkerReportsProgress = true;
            this.backgroundWorker_DoWork.WorkerSupportsCancellation = true;
            this.backgroundWorker_DoWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDoWork_Event);
            this.backgroundWorker_DoWork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerGetxConnectInfo_ProgressChanged);
            this.backgroundWorker_DoWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerGetxConnectInfo_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageOperations);
            this.tabControl1.Controls.Add(this.tabPageSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(668, 235);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPageOperations
            // 
            this.tabPageOperations.Controls.Add(this.pictureBoxExampleImage);
            this.tabPageOperations.Controls.Add(this.label2);
            this.tabPageOperations.Controls.Add(this.labelState);
            this.tabPageOperations.Controls.Add(this.comboBox_Operations_CurrentMode);
            this.tabPageOperations.Controls.Add(this.labelVersion);
            this.tabPageOperations.Controls.Add(this.label_Operations_CurrentFPS);
            this.tabPageOperations.Controls.Add(this.label1);
            this.tabPageOperations.Location = new System.Drawing.Point(4, 22);
            this.tabPageOperations.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageOperations.Name = "tabPageOperations";
            this.tabPageOperations.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageOperations.Size = new System.Drawing.Size(660, 209);
            this.tabPageOperations.TabIndex = 0;
            this.tabPageOperations.Text = "Operations";
            this.tabPageOperations.UseVisualStyleBackColor = true;
            // 
            // labelState
            // 
            this.labelState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelState.Location = new System.Drawing.Point(285, 9);
            this.labelState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(106, 22);
            this.labelState.TabIndex = 22;
            this.labelState.Text = "State";
            this.labelState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mode:";
            // 
            // comboBox_Operations_CurrentMode
            // 
            this.comboBox_Operations_CurrentMode.FormattingEnabled = true;
            this.comboBox_Operations_CurrentMode.Items.AddRange(new object[] {
            "Normal",
            "Blank",
            "Red",
            "Green",
            "Blue",
            "White"});
            this.comboBox_Operations_CurrentMode.Location = new System.Drawing.Point(467, 11);
            this.comboBox_Operations_CurrentMode.Name = "comboBox_Operations_CurrentMode";
            this.comboBox_Operations_CurrentMode.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Operations_CurrentMode.TabIndex = 1;
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(589, 189);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(64, 13);
            this.labelVersion.TabIndex = 19;
            this.labelVersion.Text = "labelVersion";
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.numericUpDownMaxFPS);
            this.tabPageSettings.Controls.Add(this.label3);
            this.tabPageSettings.Controls.Add(this.groupBox3);
            this.tabPageSettings.Controls.Add(this.groupBox1);
            this.tabPageSettings.Controls.Add(this.buttonOpenMyDocumentsDirectory);
            this.tabPageSettings.Controls.Add(this.buttonOpenDataDirectory);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageSettings.Size = new System.Drawing.Size(660, 209);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMaxFPS
            // 
            this.numericUpDownMaxFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownMaxFPS.Location = new System.Drawing.Point(89, 141);
            this.numericUpDownMaxFPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxFPS.Name = "numericUpDownMaxFPS";
            this.numericUpDownMaxFPS.Size = new System.Drawing.Size(64, 22);
            this.numericUpDownMaxFPS.TabIndex = 36;
            this.numericUpDownMaxFPS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxFPS.ValueChanged += new System.EventHandler(this.numericUpDownMaxFPS_ValueChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Max FPS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonSetUoutputToRightOfInput);
            this.groupBox3.Controls.Add(this.button2XInputSize);
            this.groupBox3.Controls.Add(this.numericUpDownOutputPosX);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.numericUpDownOutputHeight);
            this.groupBox3.Controls.Add(this.numericUpDownOutputPosY);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.numericUpDownOutputWidth);
            this.groupBox3.Location = new System.Drawing.Point(206, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 117);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output Window";
            // 
            // buttonSetUoutputToRightOfInput
            // 
            this.buttonSetUoutputToRightOfInput.Location = new System.Drawing.Point(185, 29);
            this.buttonSetUoutputToRightOfInput.Name = "buttonSetUoutputToRightOfInput";
            this.buttonSetUoutputToRightOfInput.Size = new System.Drawing.Size(107, 23);
            this.buttonSetUoutputToRightOfInput.TabIndex = 35;
            this.buttonSetUoutputToRightOfInput.Text = "Set Right of Input";
            this.buttonSetUoutputToRightOfInput.UseVisualStyleBackColor = true;
            this.buttonSetUoutputToRightOfInput.Click += new System.EventHandler(this.buttonSetUoutputToRightOfInput_Click);
            // 
            // button2XInputSize
            // 
            this.button2XInputSize.Location = new System.Drawing.Point(185, 71);
            this.button2XInputSize.Name = "button2XInputSize";
            this.button2XInputSize.Size = new System.Drawing.Size(107, 23);
            this.button2XInputSize.TabIndex = 34;
            this.button2XInputSize.Text = "2x Input Size";
            this.button2XInputSize.UseVisualStyleBackColor = true;
            this.button2XInputSize.Click += new System.EventHandler(this.button2XInputSize_Click);
            // 
            // numericUpDownOutputPosX
            // 
            this.numericUpDownOutputPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownOutputPosX.Location = new System.Drawing.Point(93, 17);
            this.numericUpDownOutputPosX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownOutputPosX.Name = "numericUpDownOutputPosX";
            this.numericUpDownOutputPosX.Size = new System.Drawing.Size(83, 22);
            this.numericUpDownOutputPosX.TabIndex = 26;
            this.numericUpDownOutputPosX.ValueChanged += new System.EventHandler(this.numericUpDownOutputPosX_ValueChanged);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(11, 90);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Height";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(11, 21);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Position X";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDownOutputHeight
            // 
            this.numericUpDownOutputHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownOutputHeight.Location = new System.Drawing.Point(93, 86);
            this.numericUpDownOutputHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownOutputHeight.Name = "numericUpDownOutputHeight";
            this.numericUpDownOutputHeight.Size = new System.Drawing.Size(83, 22);
            this.numericUpDownOutputHeight.TabIndex = 32;
            this.numericUpDownOutputHeight.ValueChanged += new System.EventHandler(this.numericUpDownOutputHeight_ValueChanged);
            // 
            // numericUpDownOutputPosY
            // 
            this.numericUpDownOutputPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownOutputPosY.Location = new System.Drawing.Point(93, 40);
            this.numericUpDownOutputPosY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownOutputPosY.Name = "numericUpDownOutputPosY";
            this.numericUpDownOutputPosY.Size = new System.Drawing.Size(83, 22);
            this.numericUpDownOutputPosY.TabIndex = 28;
            this.numericUpDownOutputPosY.ValueChanged += new System.EventHandler(this.numericUpDownOutputPosY_ValueChanged);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(11, 67);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 13);
            this.label17.TabIndex = 31;
            this.label17.Text = "Width";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(11, 44);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "Position X";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDownOutputWidth
            // 
            this.numericUpDownOutputWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownOutputWidth.Location = new System.Drawing.Point(93, 63);
            this.numericUpDownOutputWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownOutputWidth.Name = "numericUpDownOutputWidth";
            this.numericUpDownOutputWidth.Size = new System.Drawing.Size(83, 22);
            this.numericUpDownOutputWidth.TabIndex = 30;
            this.numericUpDownOutputWidth.ValueChanged += new System.EventHandler(this.numericUpDownOutputWidth_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownInputX);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericUpDownInputHeight);
            this.groupBox1.Controls.Add(this.numericUpDownInputY);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numericUpDownInputWidth);
            this.groupBox1.Location = new System.Drawing.Point(9, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 117);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Window";
            // 
            // numericUpDownInputX
            // 
            this.numericUpDownInputX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownInputX.Location = new System.Drawing.Point(93, 18);
            this.numericUpDownInputX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownInputX.Name = "numericUpDownInputX";
            this.numericUpDownInputX.Size = new System.Drawing.Size(83, 22);
            this.numericUpDownInputX.TabIndex = 26;
            this.numericUpDownInputX.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(11, 92);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Height";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Position X";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDownInputHeight
            // 
            this.numericUpDownInputHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownInputHeight.Location = new System.Drawing.Point(93, 88);
            this.numericUpDownInputHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownInputHeight.Name = "numericUpDownInputHeight";
            this.numericUpDownInputHeight.Size = new System.Drawing.Size(83, 22);
            this.numericUpDownInputHeight.TabIndex = 32;
            this.numericUpDownInputHeight.ValueChanged += new System.EventHandler(this.numericUpDownInputHeight_ValueChanged);
            // 
            // numericUpDownInputY
            // 
            this.numericUpDownInputY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownInputY.Location = new System.Drawing.Point(93, 41);
            this.numericUpDownInputY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownInputY.Name = "numericUpDownInputY";
            this.numericUpDownInputY.Size = new System.Drawing.Size(83, 22);
            this.numericUpDownInputY.TabIndex = 28;
            this.numericUpDownInputY.ValueChanged += new System.EventHandler(this.numericUpDownInputY_ValueChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(11, 68);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Width";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 45);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Position Y";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDownInputWidth
            // 
            this.numericUpDownInputWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownInputWidth.Location = new System.Drawing.Point(93, 64);
            this.numericUpDownInputWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownInputWidth.Name = "numericUpDownInputWidth";
            this.numericUpDownInputWidth.Size = new System.Drawing.Size(83, 22);
            this.numericUpDownInputWidth.TabIndex = 30;
            this.numericUpDownInputWidth.ValueChanged += new System.EventHandler(this.numericUpDownInputWidth_ValueChanged);
            // 
            // buttonOpenMyDocumentsDirectory
            // 
            this.buttonOpenMyDocumentsDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpenMyDocumentsDirectory.Location = new System.Drawing.Point(9, 177);
            this.buttonOpenMyDocumentsDirectory.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOpenMyDocumentsDirectory.Name = "buttonOpenMyDocumentsDirectory";
            this.buttonOpenMyDocumentsDirectory.Size = new System.Drawing.Size(163, 25);
            this.buttonOpenMyDocumentsDirectory.TabIndex = 25;
            this.buttonOpenMyDocumentsDirectory.Text = "Open Logging Directory";
            this.buttonOpenMyDocumentsDirectory.UseVisualStyleBackColor = true;
            this.buttonOpenMyDocumentsDirectory.Click += new System.EventHandler(this.buttonOpenMyDocumentsDirectory_Click);
            // 
            // buttonOpenDataDirectory
            // 
            this.buttonOpenDataDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpenDataDirectory.Location = new System.Drawing.Point(190, 177);
            this.buttonOpenDataDirectory.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOpenDataDirectory.Name = "buttonOpenDataDirectory";
            this.buttonOpenDataDirectory.Size = new System.Drawing.Size(187, 25);
            this.buttonOpenDataDirectory.TabIndex = 15;
            this.buttonOpenDataDirectory.Text = "Open System Settings Directory";
            this.buttonOpenDataDirectory.UseVisualStyleBackColor = true;
            this.buttonOpenDataDirectory.Click += new System.EventHandler(this.buttonOpenDataDirectory_Click);
            // 
            // pictureBoxExampleImage
            // 
            this.pictureBoxExampleImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxExampleImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxExampleImage.Location = new System.Drawing.Point(9, 56);
            this.pictureBoxExampleImage.Name = "pictureBoxExampleImage";
            this.pictureBoxExampleImage.Size = new System.Drawing.Size(526, 145);
            this.pictureBoxExampleImage.TabIndex = 23;
            this.pictureBoxExampleImage.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 235);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(573, 243);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "ScreeenScaler";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageOperations.ResumeLayout(false);
            this.tabPageOperations.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxFPS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExampleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Operations_CurrentFPS;
        private System.Windows.Forms.Timer timerCheckWorker;
        private System.ComponentModel.BackgroundWorker backgroundWorker_DoWork;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOperations;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.Button buttonOpenDataDirectory;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button buttonOpenMyDocumentsDirectory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownInputX;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDownInputHeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownInputWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownInputY;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonSetUoutputToRightOfInput;
        private System.Windows.Forms.Button button2XInputSize;
        private System.Windows.Forms.NumericUpDown numericUpDownOutputPosX;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDownOutputHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownOutputPosY;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericUpDownOutputWidth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Operations_CurrentMode;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxFPS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.PictureBox pictureBoxExampleImage;
    }
}
