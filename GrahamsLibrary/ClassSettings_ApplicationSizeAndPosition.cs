using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace GrahamLibrary
{
    public class ClassSettings_ApplicationSizeAndPosition
    {
        static private string theFilename = GlobalProperties.theAppName + "-001.json";

        [JsonInclude]
        public bool IsMaximized { get; set; } = false;
        [JsonInclude]
        public int WindowPositionX { get; set; } = 0;
        [JsonInclude]
        public int WindowPositionY { get; set; } = 0;
        [JsonInclude]
        public int WindowPositionWidth { get; set; } = -1;
        [JsonInclude]
        public int WindowPositionHeight { get; set; } = -1;

        public ClassSettings_ApplicationSizeAndPosition()
        {
        }


        static public ClassSettings_ApplicationSizeAndPosition Load()
        {
            ClassSettings_ApplicationSizeAndPosition? theSettings;

            // Load the Profiles for diagnostics
            if (File.Exists(ClassProfiles_SettingsApplicationPaths.UserAppDataSystemConfigurationPath + theFilename))
            {
                try
                {
                    using (StreamReader file = File.OpenText(ClassProfiles_SettingsApplicationPaths.UserAppDataSystemConfigurationPath + theFilename))
                    {
                        theSettings = JsonSerializer.Deserialize<ClassSettings_ApplicationSizeAndPosition>(file.ReadToEnd());
                    }
                }
                catch
                {
                    theSettings = new ClassSettings_ApplicationSizeAndPosition();
                }
            }
            else
            {
                theSettings = new ClassSettings_ApplicationSizeAndPosition();
            }

            if (theSettings == null)
                theSettings = new ClassSettings_ApplicationSizeAndPosition();

            return theSettings;
        }



        static public void Save(ClassSettings_ApplicationSizeAndPosition theSettings)
        {
            using (StreamWriter file = File.CreateText(ClassProfiles_SettingsApplicationPaths.UserAppDataSystemConfigurationPath + theFilename))
            {
                file.Write(JsonSerializer.Serialize(theSettings, new JsonSerializerOptions { WriteIndented = true }));
            }
        }


        public void Save()
        {
            ClassSettings_ApplicationSizeAndPosition.Save(this);
        }

        public static void DeleteInformation()
        {
            ClassSettings_ApplicationSizeAndPosition theSettings = new ClassSettings_ApplicationSizeAndPosition();
            Save(theSettings);
        }
    }
}
