using System;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;

public class BaseLogin : Page
{
    protected void Alert(string title, string message)
    {
        ScriptManager.RegisterStartupScript(
            this,
            GetType(),
            "JSScript" + Guid.NewGuid(),
            JavaScriptManager.GenerateDialog(title, message),
            true);
    }

    protected void AlertWithStatus(string title, string message, string status)
    {
        ScriptManager.RegisterStartupScript(
            this,
            GetType(),
            "JSScript" + Guid.NewGuid(),
            JavaScriptManager.GenerateDialogWithStatus(title, message, status),
            true);
    }

    protected void AlertSuccess(string title, string message)
    {
        ScriptManager.RegisterStartupScript(
            this,
            GetType(),
            "JSScript" + Guid.NewGuid(),
            JavaScriptManager.GenerateSuccessDialog(title, message),
            true);
    }

    protected void AlertSuccessNotDownBackdrop(string title, string message)
    {
        ScriptManager.RegisterStartupScript(
            this,
            GetType(),
            "JSScript" + Guid.NewGuid(),
            JavaScriptManager.GenerateSuccessDialogNotDownBackdrop(title, message),
            true);
    }

    protected void ShowModal(string controlID)
    {
        ScriptManager.RegisterStartupScript(
            this,
            GetType(),
            "JSScript" + Guid.NewGuid(),
            JavaScriptManager.GenerateShowModal(controlID),
            true);
    }

    protected void HideModal(string controlID)
    {
        ScriptManager.RegisterStartupScript(
            this,
            GetType(),
            "JSScript" + Guid.NewGuid(),
            JavaScriptManager.GenerateHideModal(controlID),
            true);
    }

    protected void RunJs(string command)
    {
        ScriptManager.RegisterStartupScript(
            this,
            GetType(),
            "JSScript" + Guid.NewGuid(),
            command,
            true);
    }


    protected string ToThaiDate(object obj)
    {
        if (obj != null)
        {
            var date = (DateTime)obj;
            var result = date.ToThaiDate();
            return result;
        }

        return null;
    }

    protected string GetUserIPAddress()
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

    protected string GetLocalIPAddress()
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
}