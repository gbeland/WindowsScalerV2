using System;
using System.IO;

namespace GrahamLibrary
{
    public static class SingleInstanceCheck
    {
        public static bool IsThisTheOnlyInstance()
        {
            bool returnValue = true;
            try
            {
                string mutexName = "Global\\" + GlobalProperties.appGuid;
                using (var mutex = new System.Threading.Mutex(false, mutexName, out bool createdNew))
                {
                    if (createdNew == false)
                    {
                        // Another instance is already running
                        returnValue = false;
                    }
                }
            }
            catch
            {
                returnValue = true;
            }
            return returnValue;
        }   
    }
}
