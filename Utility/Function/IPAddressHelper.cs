using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;

public static class IPAddressHelper
{
    //this gets the ip address of the server pc
    public static string GetIpAddress()
    {
        var strHostName = Dns.GetHostName();
        //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName()); <-- Obsolete
        var ipHostInfo = Dns.GetHostEntry(strHostName);
        var ipAddress = ipHostInfo.AddressList[0];

        return ipAddress.ToString();
    }

    public static string GetHostAddress()
    {
        return HttpContext.Current.Request.UserHostAddress;
    }

    public static string GetLocalAddress()
    {
        return Convert.ToString(HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"]);
    }

    public static string GetUserIPAddress()
    {
        try
        {
            //** get ค่า IP จากฝั่ง client ด้วย code-behind **
            var context = HttpContext.Current;
            IPAddress address;

            var ipAddress = "";

            ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipAddress))
            {
                var addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                    if (IPAddress.TryParse(addresses[0], out address))
                        return addresses[0];
            }

            ipAddress = context.Request.ServerVariables["HTTP_CLIENT_IP"];
            if (!string.IsNullOrEmpty(ipAddress) && IPAddress.TryParse(ipAddress, out address)) return ipAddress;


            ipAddress = context.Request.ServerVariables["REMOTE_ADDR"];
            if (ipAddress != "::1") return ipAddress;

            return GetLocalIPAddress();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return GetLocalIPAddress();
        }
    }


    public static string GetLocalIPAddress()
    {
        var myip = "127.0.0.1";
        try
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            myip = host.AddressList[0].ToString();

            foreach (var ip in host.AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
        }
        catch
        {
        }

        return myip;

        //throw new Exception("Local IP Address Not Found!");
    }


    private static bool IsIpV4WithinRange(string ip, string ipStart, string ipEnd)
    {
        var result = false;

        var ip_parts = ip.Split('.').Select(s => uint.Parse(s)).ToArray();
        var ipStart_parts = ipStart.Split('.').Select(s => uint.Parse(s)).ToArray();
        var ipEnd_parts = ipEnd.Split('.').Select(s => uint.Parse(s)).ToArray();

        if (ip_parts.Length != 4 || ipStart_parts.Length != 4 || ipEnd_parts.Length != 4)
            return result;

        var iip = (ip_parts[0] << 24) | (ip_parts[1] << 16) | (ip_parts[2] << 8) | ip_parts[3];
        var iipStart = (ipStart_parts[0] << 24) | (ipStart_parts[1] << 16) | (ipStart_parts[2] << 8) | ipStart_parts[3];
        var iipEnd = (ipEnd_parts[0] << 24) | (ipEnd_parts[1] << 16) | (ipEnd_parts[2] << 8) | ipEnd_parts[3];

        if (iipStart <= iip && iipEnd >= iip) result = true;

        return result;
    }

    private static uint ConverIPV4ToInt32(string ip)
    {
        uint iip = 0;
        var ip_parts = ip.Split('.').Select(s => uint.Parse(s)).ToArray();

        if (ip_parts.Length != 4)
            return iip;

        iip = (ip_parts[0] << 24) | (ip_parts[1] << 16) | (ip_parts[2] << 8) | ip_parts[3];

        return iip;
    }
}