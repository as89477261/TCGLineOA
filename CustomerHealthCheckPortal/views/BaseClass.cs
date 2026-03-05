using System.Configuration;

namespace CustomerHealthCheck
{
    public static class BaseClass
    {
        public static string GetAppsetting(string configName)
        {
            return ConfigurationManager.AppSettings[configName];
        }
    }
}