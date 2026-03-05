using System.Configuration;
using log4net;

public class LogUtility
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