using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerHealthCheck.views.CheckRegister.CenterRegisterDB
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var eid = CheckEventCode();
                if (eid != "")
                {
                    var isRegister = CheckUIDRegister("", "");
                    if (isRegister == true)
                    {
                        BindingEventInfo();
                        CheckPanelVisible(isRegister);
                    }
                    else
                    {
                        BindingRegisterInfo();
                        CheckPanelVisible(isRegister);
                    }
                }
                else
                {

                }

            }
        }
        private string CheckEventCode()
        {
            var buffer = Request.QueryString["eid"];
            return buffer;
        }private void BindingEventInfo()
        {

        }
        private void BindingRegisterInfo()
        {

        }
        private bool CheckUIDRegister(string uid, string eventCode)
        {
            return true;
        }
        private void CheckPanelVisible(bool isRegister)
        {

        }
    }
}