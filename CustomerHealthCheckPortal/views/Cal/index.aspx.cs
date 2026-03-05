using BLL.Controller;
using System;
using System.Web.UI;

namespace CustomerHealthCheck.views.Cal
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.Calculate_Load);
            }
        }
    }
}