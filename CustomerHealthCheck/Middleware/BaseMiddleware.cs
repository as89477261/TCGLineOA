using System.Configuration;
using System.Web.UI;

public class BaseMiddleware : Page
{
    protected string GetAppsetting(string configName)
    {
        return ConfigurationManager.AppSettings[configName];
    }
}