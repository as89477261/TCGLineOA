using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using BLL.Controller.HealthCheck;
using DataModel.Models.MasterData;

namespace CustomerHealthCheck.viewx.PreApproch
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
            try
            {
                LocalLogManager.Logger("prepare get data");
                var buffer = MasterDataCon.Product.Instance.GetProduct();
                if (buffer.RESULT_CODE == "200") GenerateUserControl(buffer.RESULT_OBJ);
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.GetBaseException().Message);
            }
        }

        private void GenerateUserControl(List<ProductModel> obj)
        {
            try
            {
                LocalLogManager.Logger("obj count : " + obj.Count);
                var lstProdHtml = string.Empty;
                var lstData = obj.OrderBy(x => x.ProductCode).ToList();
                var firstBuffer = lstData.FirstOrDefault();
                lstProdHtml += TCG_HealthCheckTemplateManager.HealthCheckProduct.GenerateProductList(
                    firstBuffer.ProductName, firstBuffer.ProductDetail, firstBuffer.ProductCode,
                    firstBuffer.ProductCode);
                LocalLogManager.Logger(lstProdHtml);
                for (var i = 1; i < lstData.Count; i++)
                {
                    lstProdHtml += TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateDividerLine();
                    lstProdHtml += TCG_HealthCheckTemplateManager.HealthCheckProduct.GenerateProductList(
                        lstData[i].ProductName, lstData[i].ProductDetail, lstData[i].ProductCode,
                        lstData[i].ProductCode);
                }

                ltlProductList.Text = lstProdHtml;
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.GetBaseException().Message);
            }
        }

        protected void ConfigSite()
        {
        }

        protected void Binding()
        {
        }
    }
}