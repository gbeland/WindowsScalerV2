using System;
using System.IO;

namespace GrahamLibrary
{
    public class ClassProfiles_SettingsApplicationPaths
    {
        static public string UserAppDataSystemConfigurationPath = "";
        static public string UserAppDataSystemManagementPath = "";

        static public string UserAppMyDocumentsDirectory = "";
        static public string UserAppMyDocumentsDirectoryHistory = "";
        static public string UserAppMyDocumentsLogging = "";

        public ClassProfiles_SettingsApplicationPaths()
        {
            UserAppDataSystemConfigurationPath = "\\ProgramData\\Samsung\\" + GlobalProperties.theAppName + "\\SystemConfiguration\\";
            if (Directory.Exists(UserAppDataSystemConfigurationPath) == false)
                Directory.CreateDirectory(UserAppDataSystemConfigurationPath);

            UserAppDataSystemManagementPath = "\\ProgramData\\Samsung\\" + GlobalProperties.theAppName + "\\SystemManagement\\";
            if (Directory.Exists(UserAppDataSystemManagementPath) == false)
                Directory.CreateDirectory(UserAppDataSystemManagementPath);

            UserAppMyDocumentsDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), GlobalProperties.theAppName + "\\");
            if (Directory.Exists(UserAppMyDocumentsDirectory) == false)
                Directory.CreateDirectory(UserAppMyDocumentsDirectory);

            UserAppMyDocumentsDirectoryHistory = System.IO.Path.Combine(UserAppMyDocumentsDirectory, "History\\");
            if (Directory.Exists(UserAppMyDocumentsDirectoryHistory) == false)
                Directory.CreateDirectory(UserAppMyDocumentsDirectoryHistory);

            UserAppMyDocumentsLogging = System.IO.Path.Combine(UserAppMyDocumentsDirectory, "Logging\\");
            if (Directory.Exists(UserAppMyDocumentsLogging) == false)
                Directory.CreateDirectory(UserAppMyDocumentsLogging);
        }
    }
}
