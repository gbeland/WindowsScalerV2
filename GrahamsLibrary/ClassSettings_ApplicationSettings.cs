using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace GrahamLibrary
{
    public class ClassSettings_ApplicationSettings
    {
        static private string theFilename = GlobalProperties.theAppName + "-003.json";

        [JsonInclude]
        public int InputX { get; set; } = 0;
        [JsonInclude]
        public int InputY { get; set; } = 0;
        [JsonInclude]
        public int InputWidth { get; set; } = 0;
        [JsonInclude]
        public int InputHeight { get; set; } = 0;

        [JsonInclude]
        public int OutputX { get; set; } = 0;
        [JsonInclude]
        public int OutputY { get; set; } = 0;
        [JsonInclude]
        public int OutputWidth { get; set; } = 0;
        [JsonInclude]
        public int OutputHeight { get; set; } = 0;
        [JsonInclude]
        public decimal MaxFPS { get; set; }
        [JsonInclude]
        public DateTime SaveTime { get; set; } = DateTime.Now;


        public ClassSettings_ApplicationSettings()
        {
        }

        public void Set_PasswordProtectionEnabled(bool UserProtectionEnabledIn)
        {
            ClassSettings_ApplicationSettings.Save(this);
        }


        static public ClassSettings_ApplicationSettings Load()
        {
            ClassSettings_ApplicationSettings? theSettings;

            // Load the Profiles for diagnostics
            if (File.Exists(ClassProfiles_SettingsApplicationPaths.UserAppDataSystemConfigurationPath + theFilename))
            {
                try
                {
                    using (StreamReader file = File.OpenText(ClassProfiles_SettingsApplicationPaths.UserAppDataSystemConfigurationPath + theFilename))
                    {
                        theSettings = JsonSerializer.Deserialize<ClassSettings_ApplicationSettings>(file.ReadToEnd());
                    }
                }
                catch
                {
                    theSettings = new ClassSettings_ApplicationSettings();
                }
            }
            else
            {
                theSettings = new ClassSettings_ApplicationSettings();
                Save(theSettings);
            }

            if (theSettings == null)
                theSettings = new ClassSettings_ApplicationSettings();

            if (theSettings.MaxFPS <= 0 || theSettings.MaxFPS > 300)
                theSettings.MaxFPS = 30;

            return theSettings;
        }



        static public void Save(ClassSettings_ApplicationSettings theSettings)
        {
            theSettings.SaveTime = DateTime.Now;

            using (StreamWriter file = File.CreateText(ClassProfiles_SettingsApplicationPaths.UserAppDataSystemConfigurationPath + theFilename))
            {
                file.Write(JsonSerializer.Serialize(theSettings, new JsonSerializerOptions { WriteIndented = true }));
            }
        }


        public void Save()
        {
            ClassSettings_ApplicationSettings.Save(this);
        }

        public static void DeleteInformation()
        {
            ClassSettings_ApplicationSettings theSettings = new ClassSettings_ApplicationSettings();
            Save(theSettings);
        }
    }
}
