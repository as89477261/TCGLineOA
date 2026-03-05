using System.Configuration;

public class BaseRepository
{
    public string ConnectionString(string conName)
    {
        var result = ConfigurationManager.AppSettings[conName];
        return result;
    }
}