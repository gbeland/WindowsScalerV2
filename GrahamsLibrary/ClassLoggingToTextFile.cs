using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrahamLibrary
{
    public class ClassLoggingToTextFile
    {
        public bool loggingEnabled = true;
        public bool _ShowTimeStamp = true;
        public string loggingPath = "";
        public string logFilenameLastPart = "Activity.txt";
         
        public void WriteString(string EventText)
        {
            if (loggingEnabled == true)
            {
                string theString = "";

                if (_ShowTimeStamp == true)
                {
                    string nDateTime = DateTime.Now.ToString("hh:mm:ss tt") + " - ";

                    theString += nDateTime + EventText;
                }
                else
                {
                    theString += EventText;
                }

                if (loggingPath != null && loggingPath != "" && logFilenameLastPart != null && logFilenameLastPart != "")
                {
                    string actualFilenamePath;

                    if (Directory.Exists(loggingPath) == false)
                    {
                        Directory.CreateDirectory(loggingPath);
                    }

                    DateTime dateNow = DateTime.Now;
                    string dateString = dateNow.Year.ToString("D4") + "-" + dateNow.Month.ToString("D2") + "-" + dateNow.Day.ToString("D2");
                    actualFilenamePath = loggingPath + "\\" + dateString + "-H" + dateNow.Hour.ToString("D2") + "-" + logFilenameLastPart;

                    // Write the string array to a new file named "WriteLines.txt".
                    using (StreamWriter outputFile = new StreamWriter(actualFilenamePath, true))
                    {
                        outputFile.WriteLine(theString);
                    }
                }
            }

            return;
        }
    }
}
