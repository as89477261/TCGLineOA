using System;
using System.IO;

public static class LocalLogManager
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

    public static void Logger(string lines, string subPath)
    {
        var path = "C:/Log/" + subPath + "/";
        VerifyDir(path);
        var fileName = DateTime.Now.Day + DateTime.Now.Month.ToString() + DateTime.Now.Year + "_Logs.txt";
        try
        {
            var file = new StreamWriter(path + fileName, true);
            file.WriteLine(DateTime.Now + ": " + lines + Environment.NewLine + Environment.NewLine);
            file.Close();
        }
        catch (Exception)
        {
        }
    }

    public static void Logger(string lines)
    {
        var path = "C:/Log/";
        VerifyDir(path);
        var fileName = DateTime.Now.Day + DateTime.Now.Month.ToString() + DateTime.Now.Year + "_Logs.txt";
        try
        {
            var file = new StreamWriter(path + fileName, true);
            file.WriteLine(DateTime.Now + ": " + lines + Environment.NewLine + Environment.NewLine);
            file.Close();
        }
        catch (Exception)
        {
        }
    }

    public static void LogRequest(string lines)
    {
        var path = "C:/Log/Request/";
        VerifyDir(path);
        var fileName = DateTime.Now.Day + DateTime.Now.Month.ToString() + DateTime.Now.Year + "_Logs.txt";
        try
        {
            var file = new StreamWriter(path + fileName, true);
            file.WriteLine(DateTime.Now + ": " + lines + Environment.NewLine + Environment.NewLine);
            file.Close();
        }
        catch (Exception)
        {
        }
    }

    public static void LogResponse(string lines)
    {
        var path = "C:/Log/Response/";
        VerifyDir(path);
        var fileName = DateTime.Now.Day + DateTime.Now.Month.ToString() + DateTime.Now.Year + "_Logs.txt";
        try
        {
            var file = new StreamWriter(path + fileName, true);
            file.WriteLine(DateTime.Now + ": " + lines + Environment.NewLine + Environment.NewLine);
            file.Close();
        }
        catch (Exception)
        {
        }
    }

    public static void LogException(string lines)
    {
        var path = "C:/Log/Exception/";
        VerifyDir(path);
        var fileName = DateTime.Now.Day + DateTime.Now.Month.ToString() + DateTime.Now.Year + "_Logs.txt";
        try
        {
            var file = new StreamWriter(path + fileName, true);
            file.WriteLine(DateTime.Now + ": " + lines + Environment.NewLine + Environment.NewLine);
            file.Close();
        }
        catch (Exception)
        {
        }
    }
}