using System;
using System.Configuration;
using System.Text;

public class BasePage
{
    protected string GetAppsetting(string configName)
    {
        return ConfigurationManager.AppSettings[configName];
    }

    public string DecodeBase64(string value)
    {
        var valueBytes = Convert.FromBase64String(value);
        return Encoding.UTF8.GetString(valueBytes);
    }
}