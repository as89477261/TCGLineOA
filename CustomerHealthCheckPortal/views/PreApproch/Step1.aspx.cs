using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using BLL.Controller.HealthCheck;
using DataModel.Models.MasterData;

namespace CustomerHealthCheck.views.PreApproch
{
    public partial class Step1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
                ConfigSite();
                Binding();
            }
        }

        protected void GetData()
        {
            var buffer = MasterDataCon.Product.Instance.GetProduct();
            if (buffer.RESULT_CODE == "200") GenerateUserControl(buffer.RESULT_OBJ);
        }

        private void GenerateUserControl(List<ProductModel> obj)
        {
            var lstProdHtml = string.Empty;
            var lstData = obj.OrderBy(x => x.ProductCode).ToList();
            var firstBuffer = lstData.FirstOrDefault();
            lstProdHtml += TCG_HealthCheckTemplateManager.HealthCheckProduct.GenerateProductList(
                firstBuffer.ProductName, firstBuffer.ProductDetail, firstBuffer.ProductCode, firstBuffer.ProductCode);

            for (var i = 1; i < lstData.Count; i++)
            {
                lstProdHtml += TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateDividerLine();
                lstProdHtml += TCG_HealthCheckTemplateManager.HealthCheckProduct.GenerateProductList(
                    lstData[i].ProductName, lstData[i].ProductDetail, lstData[i].ProductCode, lstData[i].ProductCode);
            }

            ltlProductList.Text = lstProdHtml;
        }

        protected void ConfigSite()
        {
        }

        protected void Binding()
        {
        }
    }
}