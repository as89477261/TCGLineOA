using System;
using System.Net;
using System.Threading.Tasks;

public class WebClientExtension : WebClient
{
    public WebClientExtension() : this(30000)
    {
    }

    public WebClientExtension(int timeout)
    {
        Timeout = timeout;
    }

    public int Timeout { get; set; }


    protected override WebRequest GetWebRequest(Uri uri)
    {
        var w = base.GetWebRequest(uri);
        w.Timeout = Timeout;
        ((HttpWebRequest)w).ReadWriteTimeout = Timeout;
        return w;
    }

    public new async Task<string> DownloadStringTaskAsync(Uri address)
    {
        var t = base.DownloadStringTaskAsync(address);
        if (await Task.WhenAny(t, Task.Delay(Timeout)) != t)
            CancelAsync();
        return await t;
    }
}