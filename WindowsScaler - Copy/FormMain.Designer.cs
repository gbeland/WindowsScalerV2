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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label_Operations_CurrentFPS = new Label();
            timerCheckWorker = new System.Windows.Forms.Timer(components);
            backgroundWorker_DoWork = new System.ComponentModel.BackgroundWorker();
            tabControl1 = new TabControl();
            tabPageOperations = new TabPage();
            buttonClose = new Button();
            pictureBoxExampleImage = new PictureBox();
            labelState = new Label();
            labelVersion = new Label();
            tabPageSettings = new TabPage();
            groupBox3 = new GroupBox();
            buttonSetUoutputToRightOfInput = new Button();
            button2XInputSize = new Button();
            numericUpDownOutputPosX = new NumericUpDown();
            label14 = new Label();
            label16 = new Label();
            numericUpDownOutputHeight = new NumericUpDown();
            numericUpDownOutputPosY = new NumericUpDown();
            label17 = new Label();
            label18 = new Label();
            numericUpDownOutputWidth = new NumericUpDown();
            groupBox1 = new GroupBox();
            numericUpDownInputX = new NumericUpDown();
            label12 = new Label();
            label6 = new Label();
            numericUpDownInputHeight = new NumericUpDown();
            numericUpDownInputY = new NumericUpDown();
            label8 = new Label();
            label7 = new Label();
            numericUpDownInputWidth = new NumericUpDown();
            buttonOpenMyDocumentsDirectory = new Button();
            buttonOpenDataDirectory = new Button();
            tabControl1.SuspendLayout();
            tabPageOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxExampleImage).BeginInit();
            tabPageSettings.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOutputPosX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOutputHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOutputPosY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOutputWidth).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInputX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInputHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInputY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInputWidth).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 0;
            label1.Text = "FPS";
            // 
            // label_Operations_CurrentFPS
            // 
            label_Operations_CurrentFPS.BorderStyle = BorderStyle.FixedSingle;
            label_Operations_CurrentFPS.Location = new Point(44, 6);
            label_Operations_CurrentFPS.Margin = new Padding(2, 0, 2, 0);
            label_Operations_CurrentFPS.Name = "label_Operations_CurrentFPS";
            label_Operations_CurrentFPS.Size = new Size(89, 25);
            label_Operations_CurrentFPS.TabIndex = 1;
            label_Operations_CurrentFPS.Text = "Last Reading";
            label_Operations_CurrentFPS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timerCheckWorker
            // 
            timerCheckWorker.Interval = 500;
            timerCheckWorker.Tick += timerGetFromxConnect_Tick;
            // 
            // backgroundWorker_DoWork
            // 
            backgroundWorker_DoWork.WorkerReportsProgress = true;
            backgroundWorker_DoWork.WorkerSupportsCancellation = true;
            backgroundWorker_DoWork.DoWork += backgroundWorkerDoWork_Event;
            backgroundWorker_DoWork.ProgressChanged += backgroundWorkerGetxConnectInfo_ProgressChanged;
            backgroundWorker_DoWork.RunWorkerCompleted += backgroundWorkerGetxConnectInfo_RunWorkerCompleted;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageOperations);
            tabControl1.Controls.Add(tabPageSettings);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(562, 268);
            tabControl1.TabIndex = 11;
            tabControl1.Click += tabControl1_Click;
            // 
            // tabPageOperations
            // 
            tabPageOperations.Controls.Add(buttonClose);
            tabPageOperations.Controls.Add(pictureBoxExampleImage);
            tabPageOperations.Controls.Add(labelState);
            tabPageOperations.Controls.Add(labelVersion);
            tabPageOperations.Controls.Add(label_Operations_CurrentFPS);
            tabPageOperations.Controls.Add(label1);
            tabPageOperations.Location = new Point(4, 24);
            tabPageOperations.Margin = new Padding(2);
            tabPageOperations.Name = "tabPageOperations";
            tabPageOperations.Padding = new Padding(2);
            tabPageOperations.Size = new Size(554, 240);
            tabPageOperations.TabIndex = 0;
            tabPageOperations.Text = "Operations";
            tabPageOperations.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClose.Location = new Point(471, 213);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 24;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // pictureBoxExampleImage
            // 
            pictureBoxExampleImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxExampleImage.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxExampleImage.Location = new Point(4, 38);
            pictureBoxExampleImage.Margin = new Padding(4, 3, 4, 3);
            pictureBoxExampleImage.Name = "pictureBoxExampleImage";
            pictureBoxExampleImage.Size = new Size(535, 169);
            pictureBoxExampleImage.TabIndex = 23;
            pictureBoxExampleImage.TabStop = false;
            // 
            // labelState
            // 
            labelState.BorderStyle = BorderStyle.FixedSingle;
            labelState.Location = new Point(170, 6);
            labelState.Margin = new Padding(2, 0, 2, 0);
            labelState.Name = "labelState";
            labelState.Size = new Size(133, 25);
            labelState.TabIndex = 22;
            labelState.Text = "State";
            labelState.TextAlign = ContentAlignment.MiddleCenter;
            labelState.Visible = false;
            // 
            // labelVersion
            // 
            labelVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(4, 220);
            labelVersion.Margin = new Padding(2, 0, 2, 0);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(70, 15);
            labelVersion.TabIndex = 19;
            labelVersion.Text = "labelVersion";
            // 
            // tabPageSettings
            // 
            tabPageSettings.Controls.Add(groupBox3);
            tabPageSettings.Controls.Add(groupBox1);
            tabPageSettings.Controls.Add(buttonOpenMyDocumentsDirectory);
            tabPageSettings.Controls.Add(buttonOpenDataDirectory);
            tabPageSettings.Location = new Point(4, 24);
            tabPageSettings.Margin = new Padding(2);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Padding = new Padding(2);
            tabPageSettings.Size = new Size(503, 197);
            tabPageSettings.TabIndex = 1;
            tabPageSettings.Text = "Settings";
            tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(buttonSetUoutputToRightOfInput);
            groupBox3.Controls.Add(button2XInputSize);
            groupBox3.Controls.Add(numericUpDownOutputPosX);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(numericUpDownOutputHeight);
            groupBox3.Controls.Add(numericUpDownOutputPosY);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(numericUpDownOutputWidth);
            groupBox3.Location = new Point(204, 9);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(265, 135);
            groupBox3.TabIndex = 35;
            groupBox3.TabStop = false;
            groupBox3.Text = "Output Window";
            // 
            // buttonSetUoutputToRightOfInput
            // 
            buttonSetUoutputToRightOfInput.Location = new Point(187, 33);
            buttonSetUoutputToRightOfInput.Margin = new Padding(4, 3, 4, 3);
            buttonSetUoutputToRightOfInput.Name = "buttonSetUoutputToRightOfInput";
            buttonSetUoutputToRightOfInput.Size = new Size(69, 27);
            buttonSetUoutputToRightOfInput.TabIndex = 35;
            buttonSetUoutputToRightOfInput.Text = "Auto Pos";
            buttonSetUoutputToRightOfInput.UseVisualStyleBackColor = true;
            buttonSetUoutputToRightOfInput.Click += buttonSetUoutputToRightOfInput_Click;
            // 
            // button2XInputSize
            // 
            button2XInputSize.Location = new Point(187, 82);
            button2XInputSize.Margin = new Padding(4, 3, 4, 3);
            button2XInputSize.Name = "button2XInputSize";
            button2XInputSize.Size = new Size(69, 27);
            button2XInputSize.TabIndex = 34;
            button2XInputSize.Text = "Auto Size";
            button2XInputSize.UseVisualStyleBackColor = true;
            button2XInputSize.Click += button2XInputSize_Click;
            // 
            // numericUpDownOutputPosX
            // 
            numericUpDownOutputPosX.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownOutputPosX.Location = new Point(84, 20);
            numericUpDownOutputPosX.Margin = new Padding(4, 3, 4, 3);
            numericUpDownOutputPosX.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownOutputPosX.Name = "numericUpDownOutputPosX";
            numericUpDownOutputPosX.Size = new Size(97, 22);
            numericUpDownOutputPosX.TabIndex = 26;
            numericUpDownOutputPosX.ValueChanged += numericUpDownOutputPosX_ValueChanged;
            // 
            // label14
            // 
            label14.Location = new Point(-11, 104);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(82, 15);
            label14.TabIndex = 33;
            label14.Text = "Height";
            label14.TextAlign = ContentAlignment.TopRight;
            // 
            // label16
            // 
            label16.Location = new Point(-11, 24);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(82, 15);
            label16.TabIndex = 27;
            label16.Text = "Position X";
            label16.TextAlign = ContentAlignment.TopRight;
            // 
            // numericUpDownOutputHeight
            // 
            numericUpDownOutputHeight.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownOutputHeight.Location = new Point(84, 99);
            numericUpDownOutputHeight.Margin = new Padding(4, 3, 4, 3);
            numericUpDownOutputHeight.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownOutputHeight.Name = "numericUpDownOutputHeight";
            numericUpDownOutputHeight.Size = new Size(97, 22);
            numericUpDownOutputHeight.TabIndex = 32;
            numericUpDownOutputHeight.ValueChanged += numericUpDownOutputHeight_ValueChanged;
            // 
            // numericUpDownOutputPosY
            // 
            numericUpDownOutputPosY.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownOutputPosY.Location = new Point(84, 46);
            numericUpDownOutputPosY.Margin = new Padding(4, 3, 4, 3);
            numericUpDownOutputPosY.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownOutputPosY.Name = "numericUpDownOutputPosY";
            numericUpDownOutputPosY.Size = new Size(97, 22);
            numericUpDownOutputPosY.TabIndex = 28;
            numericUpDownOutputPosY.ValueChanged += numericUpDownOutputPosY_ValueChanged;
            // 
            // label17
            // 
            label17.Location = new Point(-11, 77);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new Size(82, 15);
            label17.TabIndex = 31;
            label17.Text = "Width";
            label17.TextAlign = ContentAlignment.TopRight;
            // 
            // label18
            // 
            label18.Location = new Point(-11, 51);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(82, 15);
            label18.TabIndex = 29;
            label18.Text = "Position X";
            label18.TextAlign = ContentAlignment.TopRight;
            // 
            // numericUpDownOutputWidth
            // 
            numericUpDownOutputWidth.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownOutputWidth.Location = new Point(84, 73);
            numericUpDownOutputWidth.Margin = new Padding(4, 3, 4, 3);
            numericUpDownOutputWidth.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownOutputWidth.Name = "numericUpDownOutputWidth";
            numericUpDownOutputWidth.Size = new Size(97, 22);
            numericUpDownOutputWidth.TabIndex = 30;
            numericUpDownOutputWidth.ValueChanged += numericUpDownOutputWidth_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numericUpDownInputX);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(numericUpDownInputHeight);
            groupBox1.Controls.Add(numericUpDownInputY);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(numericUpDownInputWidth);
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(190, 135);
            groupBox1.TabIndex = 34;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input Window";
            // 
            // numericUpDownInputX
            // 
            numericUpDownInputX.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownInputX.Location = new Point(88, 21);
            numericUpDownInputX.Margin = new Padding(4, 3, 4, 3);
            numericUpDownInputX.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownInputX.Name = "numericUpDownInputX";
            numericUpDownInputX.Size = new Size(97, 22);
            numericUpDownInputX.TabIndex = 26;
            numericUpDownInputX.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label12
            // 
            label12.Location = new Point(-7, 106);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(82, 15);
            label12.TabIndex = 33;
            label12.Text = "Height";
            label12.TextAlign = ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.Location = new Point(-7, 25);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(82, 15);
            label6.TabIndex = 27;
            label6.Text = "Position X";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // numericUpDownInputHeight
            // 
            numericUpDownInputHeight.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownInputHeight.Location = new Point(88, 102);
            numericUpDownInputHeight.Margin = new Padding(4, 3, 4, 3);
            numericUpDownInputHeight.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownInputHeight.Name = "numericUpDownInputHeight";
            numericUpDownInputHeight.Size = new Size(97, 22);
            numericUpDownInputHeight.TabIndex = 32;
            numericUpDownInputHeight.ValueChanged += numericUpDownInputHeight_ValueChanged;
            // 
            // numericUpDownInputY
            // 
            numericUpDownInputY.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownInputY.Location = new Point(88, 47);
            numericUpDownInputY.Margin = new Padding(4, 3, 4, 3);
            numericUpDownInputY.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownInputY.Name = "numericUpDownInputY";
            numericUpDownInputY.Size = new Size(97, 22);
            numericUpDownInputY.TabIndex = 28;
            numericUpDownInputY.ValueChanged += numericUpDownInputY_ValueChanged;
            // 
            // label8
            // 
            label8.Location = new Point(-7, 78);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(82, 15);
            label8.TabIndex = 31;
            label8.Text = "Width";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // label7
            // 
            label7.Location = new Point(-7, 52);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(82, 15);
            label7.TabIndex = 29;
            label7.Text = "Position Y";
            label7.TextAlign = ContentAlignment.TopRight;
            // 
            // numericUpDownInputWidth
            // 
            numericUpDownInputWidth.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownInputWidth.Location = new Point(88, 74);
            numericUpDownInputWidth.Margin = new Padding(4, 3, 4, 3);
            numericUpDownInputWidth.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownInputWidth.Name = "numericUpDownInputWidth";
            numericUpDownInputWidth.Size = new Size(97, 22);
            numericUpDownInputWidth.TabIndex = 30;
            numericUpDownInputWidth.ValueChanged += numericUpDownInputWidth_ValueChanged;
            // 
            // buttonOpenMyDocumentsDirectory
            // 
            buttonOpenMyDocumentsDirectory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonOpenMyDocumentsDirectory.Location = new Point(10, 158);
            buttonOpenMyDocumentsDirectory.Margin = new Padding(2);
            buttonOpenMyDocumentsDirectory.Name = "buttonOpenMyDocumentsDirectory";
            buttonOpenMyDocumentsDirectory.Size = new Size(190, 29);
            buttonOpenMyDocumentsDirectory.TabIndex = 25;
            buttonOpenMyDocumentsDirectory.Text = "Open Logging Directory";
            buttonOpenMyDocumentsDirectory.UseVisualStyleBackColor = true;
            buttonOpenMyDocumentsDirectory.Click += buttonOpenMyDocumentsDirectory_Click;
            // 
            // buttonOpenDataDirectory
            // 
            buttonOpenDataDirectory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonOpenDataDirectory.Location = new Point(222, 158);
            buttonOpenDataDirectory.Margin = new Padding(2);
            buttonOpenDataDirectory.Name = "buttonOpenDataDirectory";
            buttonOpenDataDirectory.Size = new Size(218, 29);
            buttonOpenDataDirectory.TabIndex = 15;
            buttonOpenDataDirectory.Text = "Open System Settings Directory";
            buttonOpenDataDirectory.UseVisualStyleBackColor = true;
            buttonOpenDataDirectory.Click += buttonOpenDataDirectory_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 268);
            Controls.Add(tabControl1);
            Margin = new Padding(2);
            MinimumSize = new Size(500, 200);
            Name = "FormMain";
            ShowIcon = false;
            Text = "ScreeenScaler";
            TopMost = true;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPageOperations.ResumeLayout(false);
            tabPageOperations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxExampleImage).EndInit();
            tabPageSettings.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownOutputPosX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOutputHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOutputPosY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOutputWidth).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownInputX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInputHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInputY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInputWidth).EndInit();
            ResumeLayout(false);

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
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.PictureBox pictureBoxExampleImage;
        private Button buttonClose;
    }
}
