using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace TCGUtility
{
    public class Utility
    {
        public static void writeLog(string logMsg, ref log4net.ILog log4)
        {
            try
            {
                if (ConfigurationManager.AppSettings["logging"].ToString().Equals("Y"))
                {
                    log4.Info(logMsg);
                }
            }
            catch
            {
            }
        }
    }
}
