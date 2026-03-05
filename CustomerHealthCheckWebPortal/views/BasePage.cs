using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using OIC_UTILITY.Interface;

public class BasePage : System.Web.UI.Page
{

    public BasePage()
    {


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
            this.GetType(),
            "JSScript" + Guid.NewGuid(),
            JavaScriptManager.GenerateDialog(title, message),
        true);

    }
    protected void AlertWithStatus(string title, string message, string status)
    {
        ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            "JSScript" + Guid.NewGuid(),
            JavaScriptManager.GenerateDialogWithStatus(title, message, status),
        true);

    }
    protected void AlertSuccess(string title, string message)
    {
        ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            "JSScript" + Guid.NewGuid(),
            JavaScriptManager.GenerateSuccessDialog(title, message),
        true);

    }
    protected void AlertSuccessNotDownBackdrop(string title, string message)
    {
        ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            "JSScript" + Guid.NewGuid(),
            JavaScriptManager.GenerateSuccessDialogNotDownBackdrop(title, message),
        true);

    }
    protected void ShowModal(string controlID)
    {
        ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            "JSScript" + Guid.NewGuid(),
            JavaScriptManager.GenerateShowModal(controlID),
            true);

    }
    protected void HideModal(string controlID)
    {
        ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            "JSScript" + Guid.NewGuid(),
            JavaScriptManager.GenerateHideModal(controlID),
            true);

    }
    protected void RunJs(string command)
    {
        ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
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

    protected void CheckPermissionForShow(Control con, string level, string type)
    {
        //var status = 0;
        //if (level.Contains(BASE_PERMISSION.USER_LEVEL))
        //{
        //    status += 1;
        //}

        //if (type.Contains(BASE_PERMISSION.USER_TYPE))
        //{
        //    status += 1;
        //}

        //con.Visible = status == 2 ? true : false;
    }


    //protected void KeepEventLog(string user, string module, string action = "", string param = "")
    //{
    //    var result = LogEventController.Instance.Insert(new UKE_T_LOGEVENT()
    //    {

    //        event_action = action,
    //        event_module = module,
    //        event_page = System.IO.Path.GetFileName(Request.Url.AbsolutePath),
    //        event_param = param,
    //        create_by = "SYSTEM",
    //        create_date = DateTime.Now,
    //        event_user = user
    //    });
    //}
    //protected void KeepErrorLog(string user, string module, string action = "", string param = "", string error_code = "", string msg = "")
    //{
    //    var result = LogErrorController.Instance.Insert(new UKE_T_LOGERROR()
    //    {
    //        error_module = module,
    //        app_type = "INTERNAL",
    //        error_action = action,
    //        error_page = System.IO.Path.GetFileName(Request.Url.AbsolutePath),
    //        error_code = error_code,
    //        error_message = msg,
    //        create_date = DateTime.Now,
    //        create_by = "SYSTEM"
    //    });
    //}
}

public static class DropDownListManager
{
    //public static DropDownList BindingDSG(this DropDownList control)
    //{
    //    try
    //    {
    //        var buffer = OrganizeController.Instance.GetDSG();

    //        if (buffer != null)
    //            buffer = buffer.OrderBy(o => o.DESCRIPTION).ToList();

    //        control.DataSource = buffer;
    //        control.DataTextField = "DESCRIPTION";
    //        control.DataValueField = "SECTION_CODE";
    //        control.DataBind();

    //        return control;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw;
    //    }
    //}

    //public static DropDownList BindingASG(this DropDownList control)
    //{
    //    try
    //    {
    //        var buffer = "";// OrganizeController.Instance.GetASG("");

    //        if (buffer != null)
    //            buffer = buffer.OrderBy(o => o.DESCRIPTION).ToList();

    //        control.DataSource = buffer;
    //        control.DataTextField = "DESCRIPTION";
    //        control.DataValueField = "SECTION_CODE";
    //        control.DataBind();

    //        return control;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw;
    //    }
    //}

    //public static DropDownList BindingDepartment(this DropDownList control)
    //{
    //    try
    //    {
    //        var buffer = OrganizeController.Instance.GetDepartment("");

    //        if (buffer != null)
    //            buffer = buffer.OrderBy(o => o.DESCRIPTION).ToList();

    //        control.DataSource = buffer;
    //        control.DataTextField = "DESCRIPTION";
    //        control.DataValueField = "SECTION_CODE";
    //        control.DataBind();

    //        return control;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw;
    //    }
    //}

    //public static DropDownList BindingDivision(this DropDownList control)
    //{
    //    try
    //    {
    //        var buffer = OrganizeController.Instance.GetDivision("");

    //        if (buffer != null)
    //            buffer = buffer.OrderBy(o => o.DESCRIPTION).ToList();

    //        control.DataSource = buffer;
    //        control.DataTextField = "DESCRIPTION";
    //        control.DataValueField = "SECTION_CODE";
    //        control.DataBind();

    //        return control;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw;
    //    }
    //}

    //public static DropDownList BindingYear(this DropDownList control, int yearRang)
    //{
    //    try
    //    {
    //        var lstYear = new int[yearRang];

    //        for (int i = 0; i < lstYear.Count(); i++)
    //        {
    //            lstYear[i] = (DateTime.Now.Year - i) + 543;
    //        }

    //        control.DataSource = lstYear;
    //        control.DataBind();

    //        return control;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw;
    //    }
    //}
}
