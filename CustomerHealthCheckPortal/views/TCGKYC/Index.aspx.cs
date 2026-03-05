using System;

namespace CustomerHealthCheck.views.NDID
{
    public partial class Index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) Initial();
        }

        private void Initial()
        {
            BindingNDIDURL();
        }

        private void BindingNDIDURL()
        {
            //var ndidURL = GetAppSetting("NDIDEFormURL");
            //this.myIframe.Attributes.Add("src", ndidURL);
        }
    }
}