using System;
using System.Globalization;
using System.Linq;
using BLL.Controller.HealthCheck;
using CustomerHealthCheck.UserControl;

namespace CustomerHealthCheck.views.EventBanner
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckRegistered();
                CheckRegisteredEnd();
            }
        }

        private void CheckRegisteredEnd()
        {
            var dtRegisterButton = "2023-06-14 00:00:00";
            var parseExactRegisterButton =
                DateTime.ParseExact(dtRegisterButton, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            var dtRegisterButtonEnd = "2024-01-01 00:00:00";
            var parseExactRegisterButtonEnd = DateTime.ParseExact(dtRegisterButtonEnd, "yyyy-MM-dd HH:mm:ss",
                CultureInfo.InvariantCulture);

            if (DateTime.Now > parseExactRegisterButton && DateTime.Now < parseExactRegisterButtonEnd)
            {
                hddRegisterbutton.Value = "1";
                openRegister.Visible = true;
            }
            else
            {
                hddRegisterbutton.Value = "0";
                openRegister.Visible = false;
            }
        }

        private void CheckRegistered()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var statusReq = "complete";
            if (!string.IsNullOrEmpty(uid))
            {
                var lstRegisterPartner = EventCon.Instance.GetUIDRegisterPartner(uid, statusReq);
                if (lstRegisterPartner.RESULT_STATUS == "OK" && lstRegisterPartner.RESULT_OBJ.Count > 0)
                {
                    var bufferResult = lstRegisterPartner.RESULT_OBJ.OrderByDescending(x => x.CreatedDate).ToList();

                    for (var i = 0; i < bufferResult.Count; i++)
                    {
                        var item = bufferResult[i];
                        var control = (UC_EventBanner)Page.LoadControl("~/UserControl/UC_EventBanner.ascx");
                        control.CreateDate = item.CreatedDate.ToString("dd/MM/yyyy HH:mm", new CultureInfo("th-TH"));
                        control.IsExpand = i == 0 ? "true" : "false";
                        control.CountTime = i + 1;
                        control.RefCode = item.RefCode;
                        control.Channel = item.Channel;
                        if (control != null)
                        {
                            pnlAttentionItem.Controls.Add(control);
                            hddCheckRegisterPartner.Value = "1";
                        }
                        else
                        {
                            hddCheckRegisterPartner.Value = "0";
                        }
                    }
                }
                else
                {
                    hddCheckRegisterPartner.Value = "0";
                    registerPartnerStatus.Visible = false;
                }
            }
            else
            {
                Response.Redirect("~/views/EventBanner/index.aspx");
            }
        }
    }
}