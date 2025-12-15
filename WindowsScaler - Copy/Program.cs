using GrahamLibrary;

namespace WindowsScaler
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (SingleInstanceCheck.IsThisTheOnlyInstance () == false)
            {
                MessageBox.Show("Another instance of this application is already running.", "Application Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Application.Run(new FormMain());
        }
    }
}