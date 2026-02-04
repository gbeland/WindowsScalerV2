using GrahamLibrary;
using Microsoft.Win32;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;


namespace WindowsScaler
{
    public partial class FormMain : Form
    {
        ClassProfiles_SettingsApplicationPaths thePaths = new ClassProfiles_SettingsApplicationPaths();
        ClassSettings_ApplicationSettings theSettings = new ClassSettings_ApplicationSettings();
        ClassSettings_ApplicationSizeAndPosition theWinFormsWindowSettings = new ClassSettings_ApplicationSizeAndPosition();
        ClassLoggingToTextFile theLogger = new ClassLoggingToTextFile();
        static volatile bool restartBackground = false;
        static volatile bool closeBackground = false;
        static volatile bool pauseBackground = false;
        bool SettingUIControlsSuppressUIChangeNotification = false;

        static int CaptureMethod = 0; // 1 means use ScreenCapture library

        Form theOutputWindow;
        PictureBox theOutputWindowPictureBox;
        ConcurrentQueue<Bitmap> theCaptureQ = new ConcurrentQueue<Bitmap>();



        public FormMain()
        {
            InitializeComponent();

            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }

        static void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case SessionSwitchReason.SessionLock:
                    pauseBackground = true;
                    break;

                case SessionSwitchReason.SessionUnlock:
                    pauseBackground = false;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            theSettings = ClassSettings_ApplicationSettings.Load();
            theWinFormsWindowSettings = ClassSettings_ApplicationSizeAndPosition.Load();

            theLogger = new ClassLoggingToTextFile();
            theLogger.loggingPath = ClassProfiles_SettingsApplicationPaths.UserAppMyDocumentsLogging;
            theLogger.loggingEnabled = true;
            theLogger._ShowTimeStamp = true;

            theOutputWindow = new Form();
            theOutputWindow.TopMost = true;
            theOutputWindow.FormBorderStyle = FormBorderStyle.None;
            theOutputWindow.StartPosition = FormStartPosition.Manual;
            theOutputWindow.Location = new Point(theSettings.OutputX, theSettings.OutputY);
            theOutputWindow.Size = new Size(theSettings.OutputWidth, theSettings.OutputHeight);
            theOutputWindow.Show();

            theOutputWindowPictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.CenterImage,
                BackColor = Color.Red
            };

            theOutputWindowPictureBox.Size = new Size(theSettings.OutputWidth, theSettings.OutputHeight);
            theOutputWindow.Controls.Add(theOutputWindowPictureBox);


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

            try
            {
                labelVersion.Text = System.Reflection.Assembly.GetExecutingAssembly()
                                              .GetCustomAttribute<System.Reflection.AssemblyInformationalVersionAttribute>()?
                                              .InformationalVersion;
            }
            catch
            {
                labelVersion.Text = "?";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerManualScreenGrab.Enabled = false;
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

            SettingUIControlsSuppressUIChangeNotification = false;

            switch (theSettings.MaxFPS)
            {
                case 5: comboBoxTargetFPS.SelectedIndex = 0; break;
                case 10: comboBoxTargetFPS.SelectedIndex = 1; break;
                case 15: comboBoxTargetFPS.SelectedIndex = 2; break;
                case 20: comboBoxTargetFPS.SelectedIndex = 3; break;
                case 25: comboBoxTargetFPS.SelectedIndex = 4; break;
                case 30: comboBoxTargetFPS.SelectedIndex = 5; break;
                case 35: comboBoxTargetFPS.SelectedIndex = 6; break;
                case 40: comboBoxTargetFPS.SelectedIndex = 7; break;
                case 45: comboBoxTargetFPS.SelectedIndex = 8; break;
                case 50: comboBoxTargetFPS.SelectedIndex = 9; break;
                case 55: comboBoxTargetFPS.SelectedIndex = 10; break;
                case 60: comboBoxTargetFPS.SelectedIndex = 11; break;
                default: comboBoxTargetFPS.SelectedIndex = 2; break;
            }
        }

        private void SetUIControlsAndSave()
        {
            SetUIControls();
            ClassSettings_ApplicationSettings.Save(theSettings);
            restartBackground = true;
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

            switch (comboBoxTargetFPS.SelectedIndex)
            {
                case 0: theSettings.MaxFPS = 5; break;
                case 1: theSettings.MaxFPS = 10; break;
                case 2: theSettings.MaxFPS = 15; break;
                case 3: theSettings.MaxFPS = 20; break;
                case 4: theSettings.MaxFPS = 25; break;
                case 5: theSettings.MaxFPS = 30; break;
                case 6: theSettings.MaxFPS = 35; break;
                case 7: theSettings.MaxFPS = 40; break;
                case 8: theSettings.MaxFPS = 45; break;
                case 9: theSettings.MaxFPS = 50; break;
                case 10: theSettings.MaxFPS = 55; break;
                case 11: theSettings.MaxFPS = 60; break;
                default: theSettings.MaxFPS = 15; break;
            }

            theSettings.SaveTime = DateTime.Now;
        }

        private void GetUIControlsAndSave(bool suppressIfUI)
        {
            GetUIControls(suppressIfUI);
            ClassSettings_ApplicationSettings.Save(theSettings);
            restartBackground = true;
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

            if (pauseBackground == true)
                return;

            if (closeBackground == true)
                return;

            restartBackground = false;
            xConnectGetWorkerIsRunning = true;
            backgroundWorker_DoWork.RunWorkerAsync();
        }


        enum workerStates : int
        {
            starting,
            updateFPS_Reading,
            drawScaledImage,
            closing,
            closeApp
        }



        private void backgroundWorkerDoWork_Event(object sender, DoWorkEventArgs e)
        {
            int exceptionAt = 0;
            const int FPSBufferSize = 100;
            List<double> PastFPS = new List<double>();

            backgroundWorker_DoWork.ReportProgress((int)workerStates.starting, null);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                while (restartBackground == false && closeBackground == false && pauseBackground == false)
                {
                    if (theCaptureQ.Count > 0)
                    {
                        double fpsNumber = (double)1000 / (double)sw.ElapsedMilliseconds;
                        if (fpsNumber > 0 && fpsNumber < 1000)
                            PastFPS.Add((int)((double)1000 / sw.ElapsedMilliseconds));

                        sw.Restart();

                        if (PastFPS.Count > FPSBufferSize)
                            PastFPS.RemoveAt(0);

                        if (theCaptureQ.Count > 0)
                        {
                            if (theCaptureQ.TryDequeue(out Bitmap? theImage) == true)
                            {
                                backgroundWorker_DoWork.ReportProgress((int)workerStates.drawScaledImage, theImage);
                            }
                        }

                        if (PastFPS.Count >= FPSBufferSize)
                            backgroundWorker_DoWork.ReportProgress((int)workerStates.updateFPS_Reading, (double)PastFPS.Average());
                    }
                    else
                        Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                backgroundWorker_DoWork.ReportProgress(exceptionAt, "Internal error 1: " + ex.Message);
            }

            backgroundWorker_DoWork.ReportProgress((int)workerStates.closing);

            if (closeBackground == true)
                backgroundWorker_DoWork.ReportProgress((int)workerStates.closeApp);

        }

        private void backgroundWorkerGetxConnectInfo_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case (int)workerStates.starting:
                    {
                        labelState.Text = "Starting";

                        if (pauseBackground == false)
                        {
                            timerManualScreenGrab.Enabled = true;
                            int interval = (int)(1000 / Math.Max(theSettings.MaxFPS, 1));
                            timerManualScreenGrab.Interval = interval;
                        }

                        theOutputWindow.Location = new Point(theSettings.OutputX, theSettings.OutputY);
                        theOutputWindow.Size = new Size(theSettings.OutputWidth, theSettings.OutputHeight);

                        theOutputWindowPictureBox.Size = new Size(theSettings.OutputWidth, theSettings.OutputHeight);
                    }
                    ; break; // capture


                case (int)workerStates.drawScaledImage: // Got input image
                    {
                        labelState.Text = "Got Image";
                        Bitmap? inScreenImage = (Bitmap?)e.UserState;

                        if (inScreenImage != null)
                        {
                            theOutputWindowPictureBox.Image = pictureBoxExampleImage.Image = new Bitmap(inScreenImage);
                        }

                    }
                    ; break; // capture

                case (int)workerStates.updateFPS_Reading: label_Operations_CurrentFPS.Text = ((double)e.UserState).ToString("0.0"); break; // Draw scaled image

                case (int)workerStates.closing:
                    {
                        timerManualScreenGrab.Enabled = false;

                        labelState.Text = "Closed";
                        xConnectGetWorkerIsRunning = false;
                    }
                    ; break;

                case (int)workerStates.closeApp: this.Close(); break;
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
            var path = ClassProfiles_SettingsApplicationPaths.UserAppDataSystemConfigurationPath;
            var psi = new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true,    // let the shell open the folder
                WorkingDirectory = path
            };
            Process.Start(psi);
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
            var path = ClassProfiles_SettingsApplicationPaths.UserAppMyDocumentsLogging;
            var psi = new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true,    // let the shell open the folder
                WorkingDirectory = path
            };
            Process.Start(psi);
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
            theSettings.OutputWidth = theSettings.InputWidth / 2;
            theSettings.OutputHeight = theSettings.InputHeight / 2;
            SetUIControlsAndSave();
        }

        private void numericUpDownMaxFPS_ValueChanged(object sender, EventArgs e)
        {
            //theSettings.MaxFPS = (int)Math.Max(numericUpDownMaxFPS.Value, 1);
            GetUIControlsAndSave(true);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUIControlsAndSave(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            closeBackground = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pauseBackground = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pauseBackground = false;
        }

        private void timer1_ManualScreenGrab(object sender, EventArgs e)
        {
            if (pauseBackground == true || pauseBackground == true)
                return;

            Bitmap? inputBitmap = CaptureScreenAndSave(theSettings.InputX, theSettings.InputY, theSettings.InputWidth, theSettings.InputHeight);

            if (inputBitmap == null)
                return;


            // You can specify a different pixel format if needed, for example, 32bppARGB for transparency support
            Bitmap outputAreaOnlyBitmap = new Bitmap(theSettings.OutputWidth, theSettings.OutputHeight);
            using (Graphics g = Graphics.FromImage(outputAreaOnlyBitmap))
            {
                Rectangle AreaToCopyFrom = new Rectangle(0, 0, theSettings.InputWidth, theSettings.InputHeight);
                Rectangle AreaToCopyTo = new Rectangle(0, 0, theSettings.OutputWidth, theSettings.OutputHeight);

                try
                {
                    g.DrawImage(
                        inputBitmap,
                        AreaToCopyTo,
                        AreaToCopyFrom,
                        GraphicsUnit.Pixel);
                }
                catch
                {
                    return;
                }
            }

            theCaptureQ.Enqueue(new Bitmap(outputAreaOnlyBitmap));
        }


        public Bitmap? CaptureScreenAndSave(int x, int y, int width, int height)
        {
            Rectangle bounds = new Rectangle(x, y, width, height);

            if (IsWorkstationLocked() == true)
                return null;

            if (pauseBackground == true || pauseBackground == true)
                return null;

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    try
                    {
                        g.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
                    }
                    catch
                    {
                        return null;
                    }
                }
                return new Bitmap(bitmap);
            }
        }

        private const int DESKTOP_SWITCHDESKTOP = 0x0100; // Corrected constant for clarity

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr OpenDesktop(string lpszDesktop, int dwFlags, bool fInherit, uint dwDesiredAccess);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SwitchDesktop(IntPtr hDesktop);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool CloseDesktop(IntPtr hDesktop);

        public static bool IsWorkstationLocked()
        {
            IntPtr hDesktop = OpenDesktop("Default", 0, false, (uint)DESKTOP_SWITCHDESKTOP);
            if (hDesktop == IntPtr.Zero)
            {
                // Handle error if necessary
                return false;
            }

            bool result = SwitchDesktop(hDesktop);
            CloseDesktop(hDesktop);

            // If SwitchDesktop returns false (0 in the original snippet), it means the workstation is locked 
            // because we can't switch away from the locked desktop to the default user desktop.
            return !result;
        }

    }
}
