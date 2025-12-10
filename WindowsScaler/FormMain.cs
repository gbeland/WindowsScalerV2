using GrahamLibrary;
using ScreenCapture.NET;
using System.ComponentModel;
using System.Diagnostics;

namespace WindowsScaler
{
    public partial class FormMain : Form
    {
        ClassProfiles_SettingsApplicationPaths thePaths = new ClassProfiles_SettingsApplicationPaths();
        ClassSettings_ApplicationSettings theSettings = new ClassSettings_ApplicationSettings();
        ClassSettings_ApplicationSizeAndPosition theWinFormsWindowSettings = new ClassSettings_ApplicationSizeAndPosition();
        ClassLoggingToTextFile theLogger = new ClassLoggingToTextFile();
        volatile bool restartBackground = false;
        bool SettingUIControlsSuppressUIChangeNotification = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a screen-capture service
            IScreenCaptureService screenCaptureService = new DX11ScreenCaptureService();

            // Get all available graphics cards
            IEnumerable<GraphicsCard> graphicsCards = screenCaptureService.GetGraphicsCards();

            theSettings = ClassSettings_ApplicationSettings.Load();
            theWinFormsWindowSettings = ClassSettings_ApplicationSizeAndPosition.Load();

            theLogger = new ClassLoggingToTextFile();
            theLogger.loggingPath = ClassProfiles_SettingsApplicationPaths.UserAppMyDocumentsLogging;
            theLogger.loggingEnabled = true;
            theLogger._ShowTimeStamp = true;

            theLogger.WriteString("Start application");

            System.Drawing.Rectangle theRect = new System.Drawing.Rectangle(theWinFormsWindowSettings.WindowPositionX, theWinFormsWindowSettings.WindowPositionY, theWinFormsWindowSettings.WindowPositionWidth, theWinFormsWindowSettings.WindowPositionHeight);

            if (theWinFormsWindowSettings.IsMaximized)
                WindowState = FormWindowState.Maximized;
            else if (Screen.AllScreens.Any(screen => screen.WorkingArea.IntersectsWith(theRect)))
            {
                StartPosition = FormStartPosition.Manual;
                DesktopBounds = theRect;
                WindowState = FormWindowState.Normal;
            }

            theLogger.WriteString("Start application");
            SetUIControls();

            timerCheckWorker.Enabled = true;

            labelVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            theLogger.WriteString("Close application");

            if (WindowState == FormWindowState.Maximized)
                theWinFormsWindowSettings.IsMaximized = true;
            else
                theWinFormsWindowSettings.IsMaximized = false;

            theWinFormsWindowSettings.WindowPositionX = DesktopBounds.X;
            theWinFormsWindowSettings.WindowPositionY = DesktopBounds.Y;
            theWinFormsWindowSettings.WindowPositionWidth = DesktopBounds.Width;
            theWinFormsWindowSettings.WindowPositionHeight = DesktopBounds.Height;

            ClassSettings_ApplicationSizeAndPosition.Save(theWinFormsWindowSettings);
            ClassSettings_ApplicationSettings.Save(theSettings);
        }
        private void SetUIControls()
        {
            SettingUIControlsSuppressUIChangeNotification = true;

            numericUpDownInputX.Value = theSettings.InputX;
            numericUpDownInputY.Value = theSettings.InputY;
            numericUpDownInputWidth.Value = theSettings.InputWidth;
            numericUpDownInputHeight.Value = theSettings.InputHeight;

            numericUpDownOutputPosX.Value = theSettings.OutputX;
            numericUpDownOutputPosY.Value = theSettings.OutputY;
            numericUpDownOutputWidth.Value = theSettings.OutputWidth;
            numericUpDownOutputHeight.Value = theSettings.OutputHeight;

            numericUpDownMaxFPS.Value = theSettings.MaxFPS;

            SettingUIControlsSuppressUIChangeNotification = false;
        }

        private void SetUIControlsAndSave()
        {
            SetUIControls();
            ClassSettings_ApplicationSettings.Save(theSettings);
        }

        private void GetUIControls(bool suppressIfUI)
        {
            if (suppressIfUI == true && SettingUIControlsSuppressUIChangeNotification == true)
                return;

            theSettings.InputX = (int)numericUpDownInputX.Value;
            theSettings.InputY = (int)numericUpDownInputY.Value;
            theSettings.InputWidth = (int)numericUpDownInputWidth.Value;
            theSettings.InputHeight = (int)numericUpDownInputHeight.Value;

            theSettings.OutputX = (int)numericUpDownOutputPosX.Value;
            theSettings.OutputY = (int)numericUpDownOutputPosY.Value;
            theSettings.OutputWidth = (int)numericUpDownOutputWidth.Value;
            theSettings.OutputHeight = (int)numericUpDownOutputHeight.Value;

            theSettings.MaxFPS = (int)numericUpDownMaxFPS.Value;
            if (theSettings.MaxFPS < 1 || theSettings.MaxFPS > 100)
                theSettings.MaxFPS = 30;

            theSettings.SaveTime = DateTime.Now;
        }

        private void GetUIControlsAndSave(bool suppressIfUI)
        {
            GetUIControls(suppressIfUI);
            ClassSettings_ApplicationSettings.Save(theSettings);
        }


        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        volatile bool xConnectGetWorkerIsRunning = false;

        private void timerGetFromxConnect_Tick(object sender, EventArgs e)
        {
            // See if the worker is running.
            // Various activity can cause it to end.
            // Start it if we need to

            if (xConnectGetWorkerIsRunning == true)
                return;

            xConnectGetWorkerIsRunning = true;
            backgroundWorker_DoWork.RunWorkerAsync();
        }

        private void backgroundWorkerDoWork_Event(object sender, DoWorkEventArgs e)
        {
            int exceptionAt = 0;
            const int FPSBufferSize = 10;
            List<double> PastFPS = new List<double>();
            int minimumMSDelay = (int)((decimal)1000 / theSettings.MaxFPS);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                while (restartBackground == false)
                {
                    minimumMSDelay = (int)((decimal)1000 / theSettings.MaxFPS);

                    if (sw.ElapsedMilliseconds >= minimumMSDelay)
                    {
                        PastFPS.Add((int)((double)1000 / sw.ElapsedMilliseconds));

                        sw.Restart();

                        if (PastFPS.Count > FPSBufferSize)
                            PastFPS.RemoveAt(0);


                        // Get screen capture
                        backgroundWorker_DoWork.ReportProgress(0, null);
                        //Thread.Sleep(1);
                        // Create scaled image
                        backgroundWorker_DoWork.ReportProgress(1, null);
                        //Thread.Sleep(1);

                        // Send Scaled Image
                        backgroundWorker_DoWork.ReportProgress(2, null);

                        // Send average FPS 
                        // Send Scaled Image

                        if (PastFPS.Count >= FPSBufferSize)
                            backgroundWorker_DoWork.ReportProgress(66, (double)PastFPS.Average());
                    }
                    else
                        Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                backgroundWorker_DoWork.ReportProgress(exceptionAt, "Internal error 1: " + ex.Message);
            }

            backgroundWorker_DoWork.ReportProgress(86);
        }

        private void backgroundWorkerGetxConnectInfo_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 0: labelState.Text = "Capture"; break; // capture
                case 1: labelState.Text = "Scaled"; break; // Created scaled image
                case 2: labelState.Text = "Draw"; break; // Draw scaled image
                case 66: label_Operations_CurrentFPS.Text = ((double)e.UserState).ToString("0.0"); break; // Draw scaled image
                case 86: labelState.Text = "Closed"; xConnectGetWorkerIsRunning = false; break;
            }

            if (e.ProgressPercentage == 0)
            {
            }
            else if (e.ProgressPercentage == 1)
            {
            }
            else if (e.ProgressPercentage == 2 || e.ProgressPercentage == 3)
            {
            }
        }

        private void backgroundWorkerGetxConnectInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            xConnectGetWorkerIsRunning = false;
        }

        private void timerFlashxConnectReading_Tick(object sender, EventArgs e)
        {

        }


        //--------------------------------------------------------------------------------
        // Handle the various determination of the override status
        //--------------------------------------------------------------------------------
        private void buttonOpenDataDirectory_Click(object sender, EventArgs e)
        {
            Process.Start(ClassProfiles_SettingsApplicationPaths.UserAppDataSystemConfigurationPath);
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                //theSettings.xConnect_Address = textBoxxConnectAddress.Text;
                ClassSettings_ApplicationSettings.Save(theSettings);

                //theSettings.webRelay10_Address = textBoxWebRelayIP.Text;
                ClassSettings_ApplicationSettings.Save(theSettings);
            }
        }


        private void buttonOpenMyDocumentsDirectory_Click(object sender, EventArgs e)
        {
            Process.Start(ClassProfiles_SettingsApplicationPaths.UserAppMyDocumentsLogging);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GetUIControlsAndSave(true);
        }

        private void numericUpDownInputY_ValueChanged(object sender, EventArgs e)
        {
            GetUIControlsAndSave(true);
        }

        private void numericUpDownInputWidth_ValueChanged(object sender, EventArgs e)
        {
            GetUIControlsAndSave(true);
        }

        private void numericUpDownInputHeight_ValueChanged(object sender, EventArgs e)
        {
            GetUIControlsAndSave(true);
        }

        private void numericUpDownOutputPosX_ValueChanged(object sender, EventArgs e)
        {
            GetUIControlsAndSave(true);
        }

        private void numericUpDownOutputPosY_ValueChanged(object sender, EventArgs e)
        {
            GetUIControlsAndSave(true);
        }

        private void numericUpDownOutputWidth_ValueChanged(object sender, EventArgs e)
        {
            GetUIControlsAndSave(true);
        }

        private void numericUpDownOutputHeight_ValueChanged(object sender, EventArgs e)
        {
            GetUIControlsAndSave(true);
        }

        private void buttonSetUoutputToRightOfInput_Click(object sender, EventArgs e)
        {
            theSettings.OutputX = theSettings.InputX + theSettings.InputWidth;
            theSettings.OutputY = theSettings.InputHeight;
            SetUIControlsAndSave();
        }

        private void button2XInputSize_Click(object sender, EventArgs e)
        {
            theSettings.OutputWidth = theSettings.InputWidth * 2;
            theSettings.OutputHeight = theSettings.InputHeight * 2;
            SetUIControlsAndSave();
        }

        private void numericUpDownMaxFPS_ValueChanged(object sender, EventArgs e)
        {
            //theSettings.MaxFPS = (int)Math.Max(numericUpDownMaxFPS.Value, 1);
            GetUIControlsAndSave(true);
        }
    }
}
