using System;
using System.Collections.Generic;
using DataModel.Models.NDID.Utility;

namespace CustomerHealthCheck.views.Request
{
    public partial class Step3 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfigSite();
                Binding();
            }
        }

        private void Binding()
        {
            var ndididcard = CookieManager.GetEncryptCookie("lineoa", "ndididcard", GetAppsetting("APIPartialCode"));
            if (!string.IsNullOrEmpty(ndididcard))
            {
                var bufferIDP = ServiceInterface.Utility.IDP.GetIDPModelByID(ndididcard);
                if (bufferIDP != null && bufferIDP.Count > 0) RenderIDPList(bufferIDP);
                // render empty panel
            }
        }

        private void ConfigSite()
        {
        }

        private void RenderIDPList(List<IDPModel> lstIDP)
        {
            var bufferTemplate = string.Empty;
            foreach (var IDPItem in lstIDP)
            {
                IDPItem.ConvertRawNodeToObject();
                bufferTemplate += TCG_HealthCheckTemplateManager.NDIDIDPPanel.GenerateIDPList(
                    IDPItem.node_object.industry_code, IDPItem.node_object.marketing_name_th, IDPItem.node_id);
            }

            ltlIdpList.Text = bufferTemplate;
        }
    }
}