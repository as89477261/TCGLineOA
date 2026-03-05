using System;
using System.Configuration;
using System.Web.UI;
using DataModel.Models.Line;

public class BaseMaster : MasterPage
{
    public LineRawTokenModel BASE_LineProfile
    {
        get
        {
            var obj = new LineRawTokenModel
            {
                sub = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode")),
                picture = CookieManager.GetEncryptCookie("lineoa", "pic", GetAppsetting("APIPartialCode"))
            };
            return obj;
        }
    }

    //protected override void OnInit(EventArgs e)
    //{
    //    if (HttpContext.Current.Session != null)
    //    {

    //        if (new SessionManager(SessionEnum.LogOn).DoesKeyExist() == false)
    //        {
    //            //Server.Transfer(Server.MapPath("~/login.aspx"));
    //            Response.Redirect("~/index.aspx", true);
    //        }


    //    }
    //}


    protected string GetAppsetting(string configName)
    {
        return ConfigurationManager.AppSettings[configName];
    }

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

    protected void RedirectToOriginLineURL()
    {
        if (GetAppsetting("IsRedirectToLineURLOrigin") == "1")
        {
            var bufferURL = GetOriginLineURL();
            Response.Redirect(bufferURL);
        }
        else
        {
            if (GetAppsetting("IsAllowEmptyCookie") == "1")
            {
                // allow Using
            }
            else
            {
                Response.Redirect("~/views/Error/General.aspx");
            }
        }
    }

    protected string GetOriginLineURL()
    {
        var url = GetAppsetting(
            "TokenURLLineLiff"); // + "&" + GetAppSetting("TokenURLP2") + "&" + GetAppSetting("TokenURLP3");
        return url;
    }
}