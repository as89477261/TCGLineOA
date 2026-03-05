using System.Configuration;
using log4net;

namespace CustomerHealthCheck
{
    public class Utility
    {
        public static void writeLog(string logMsg, ref ILog log4)
        {
            try
            {
                if (ConfigurationManager.AppSettings["logging"].Equals("Y")) log4.Info(logMsg);
            }
            catch
            {
            }
        }
    }
}