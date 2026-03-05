using System;
using System.IO;

namespace OIC_UTILITY
{
    public class LogManager
    {
        public static void VerifyDir(string path)
        {
            try
            {
                var dir = new DirectoryInfo(path);
                if (!dir.Exists) dir.Create();
            }
            catch
            {
            }
        }

        public static void Logger(string lines)
        {
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Log.txt");
            //VerifyDir(path);
            var path = @"C:\logs\apiedoc.txt";
            var fileName = DateTime.Now.Day + DateTime.Now.Month.ToString() + DateTime.Now.Year + "_Logs.txt";
            try
            {
                var file = new StreamWriter(path + fileName, true);
                file.WriteLine(DateTime.Now + ": " + lines);
                file.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}