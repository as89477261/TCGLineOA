using BLL.Controller;
using System;
using System.Web.UI;

namespace CustomerHealthCheck.views.SignUp
{
    public partial class Index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingConfig();
                LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.TCGRegister_Load);
            }
        }

        private void BindingConfig()
        {
            var dummyID = Guid.NewGuid().ToString();

            hddDummyID.Value = dummyID;
            hddAcceptCondition.Value = "0";
        }
    }
}