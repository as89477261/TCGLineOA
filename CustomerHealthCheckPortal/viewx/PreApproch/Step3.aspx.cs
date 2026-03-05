using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using BLL.Controller;
using BLL.Controller.HealthCheck;
using CustomerHealthController;
using DataModel.Models.CustomerHealthModel;
using DataModel.Models.MasterData;
using DataModel.Models.SMEClinic;

namespace CustomerHealthCheck.viewx.PreApproch
{
    public partial class Step4 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) GetData();
        }

        protected void btnSubmitApproch_Click(object sender, EventArgs e)
        {
            var obj = GenerateApprochObject();
            var result = InsertApproch(obj);
            if (result != null && result.Count > 0)
            {
                var buffer = result.FirstOrDefault();
                CookieManager.SetEncryptCookie("lineoa", "approchid", buffer.ID, GetAppsetting("APIPartialCode"));

                Response.Redirect("Step4.aspx");
            }
        }

        private void GetData()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var hcid = CookieManager.GetEncryptCookie("lineoa", "hcid", GetAppsetting("APIPartialCode"));
            var pid = CookieManager.GetEncryptCookie("lineoa", "pid", GetAppsetting("APIPartialCode"));

            //var bufferPersonal = NDIDPersonalCon.Instance.GetNDIDPersonalByID(uid);
            var bufferPersonal = CustomerProfileCon.Instance.GetCustomerProfileHistoryByUID(uid);
            var bufferHealthCheck = RegisterInfoCon.Instance.GetRegisInfoByRegisID(hcid);
            var bufferFinance = RegisterInfoCon.Instance.GetRegisInfoByRegisID(hcid);
            var bufferProduct = MasterDataCon.Product.Instance.GetProductByID(pid);

            if (bufferPersonal.RESULT_STATUS == "OK"
                && bufferHealthCheck.RESULT_STATUS == "OK"
                && bufferProduct.RESULT_STATUS == "OK")
            {
                //BindingPersonal(bufferPersonal.RESULT_OBJ);
                BindingProduct(bufferProduct.RESULT_OBJ);
                BindingHealthCheckIcon(bufferFinance.RESULT_OBJ);
                BindingHealthCheck(bufferHealthCheck.RESULT_OBJ);
                BindingMeasurePanel(bufferHealthCheck.RESULT_OBJ, bufferProduct.RESULT_OBJ);
            }
        }

        private void BindingPersonal(List<CustomerProfileHistoryModel> obj)
        {
            if (obj != null && obj.Count > 0)
            {
                var buffer = obj.OrderBy(x => x.IdCardType).FirstOrDefault();
                lblFullName.Text = buffer.Name + " " + buffer.SureName;
                lblPhoneNumber.Text = buffer.MobileNumber;
            }
        }

        private void BindingHealthCheck(List<RegisterInfoModel> obj)
        {
            if (obj != null && obj.Count > 0)
            {
                var buffer = obj.FirstOrDefault();
                lblDebtStatus.Text = buffer.DebtStatusName;
                lblTdrAmount.Text = buffer.TdrAmount.ToString();
                lblTdrYear.Text = buffer.TdrYear.ToString();
                lblYearExperience.Text = buffer.YearExperience.ToString();
                lblAssetValue.Text = buffer.AssetValue.ToString();
                lblDebtValue.Text = buffer.DebtValue.ToString();
                lblIncome.Text = buffer.Income.ToString();
                lblExpense.Text = buffer.Expense.ToString();
                lblCostSale.Text = "";
                lblInstallmentAmount.Text = buffer.InstallmentAmount.ToString();

                lblFieldName.Text = buffer.FieldName;
                lblLoanAmount.Text = buffer.LoanAmount.ToString();
                lblLoanType.Text = "";
                lblYearInstallment.Text = buffer.YearInstallment.ToString();

                if (buffer.PersonType == 0)
                {
                    lblFullName.Text = buffer.Name + " " + buffer.Surname;
                    lblPhoneNumber.Text = buffer.Phone;
                }
                else
                {
                    lblFullName.Text = buffer.BusinessName;
                    lblPhoneNumber.Text = buffer.Phone;
                }
            }
        }

        private void BindingProduct(List<ProductModel> obj)
        {
            if (obj != null && obj.Count > 0)
            {
                var buffer = obj.FirstOrDefault();
                lblProductName.Text = buffer.ProductName;
                lblProductDetail.Text = buffer.ProductDetail;
            }
        }

        private void BindingHealthCheckIcon(List<RegisterInfoModel> obj)
        {
            var firstItem = obj.OrderByDescending(x => x.RegisterInfoID).FirstOrDefault();
            var bufferHtmlItem = TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateHealthCheckHistory(
                firstItem.ScoreGroup.ToString(), "1",
                "วันที่ " + firstItem.CreateDate.ToString("dd/MM/yyyy", new CultureInfo("th-TH")),
                firstItem.GroupShortDesc);

            ltlFinanceIcon.Text = bufferHtmlItem;
        }

        private void BindingMeasurePanel(List<RegisterInfoModel> objRegister, List<ProductModel> objProduct)
        {
            if (objRegister != null && objRegister.Count > 0)
            {
                var firstRegisItem = objRegister.OrderByDescending(x => x.RegisterInfoID).FirstOrDefault();
                var firstProductItem = objProduct.OrderByDescending(x => x.CreatedDate).FirstOrDefault();

                var bufferRegisterInfo = CriteriaCon.Instance.CheckDynamicCriteria(firstRegisItem, firstProductItem);
                GenerateSubmitButton(bufferRegisterInfo.IsPassProductCriteria);
                BindingDebugPanel(bufferRegisterInfo);

                var bufferHtmlItem =
                    TCG_HealthCheckTemplateManager.HealthCheckMeasurementStatus.GenerateHealthCheckHistory(
                        bufferRegisterInfo.TCGScoreBandLevel, bufferRegisterInfo.IsPassProductCriteria);
                ltlResultMeasurement.Text = bufferHtmlItem;
            }
        }

        private void BindingDebugPanel(RegisterInfoModel obj)
        {
            var isShowDebug = ConfigurationManager.AppSettings["IsShowScore"];
            if (isShowDebug == "1")
            {
                pnlDebugTestScore.Visible = true;
                var str = "DSCR : " + obj.DSCR + " <br />";
                str += "TCG Band : " + obj.TCGScoreBand + " <br />";
                str += "TCG RBP : " + obj.TCGScoreRBP + " <br />";
                str += "Total Asset exclude land : " + obj.SumAsset + " <br />";

                ltlDebugTestScore.Text = str;
            }
            else
            {
                pnlDebugTestScore.Visible = false;
            }
        }


        private void GenerateSubmitButton(bool isPassCondition)
        {
            if (isPassCondition)
            {
                pnlBtnSubmit.Visible = true;
                pnlBtnBackMain.Visible = false;
            }
            else
            {
                pnlBtnSubmit.Visible = false;
                pnlBtnBackMain.Visible = true;
            }
        }

        private string GenerateApprochBody()
        {
            var sb = new StringBuilder();
            var tw = new StringWriter(sb);
            var hw = new HtmlTextWriter(tw);
            ltlFinanceIcon.Visible = false;
            ltlResultMeasurement.Text = pnlBtnSubmit.Visible ? "คุณผ่านคุณสมบัติ" : "คุณไม่ผ่านคุณสมบัติ";

            pnlInfoPath1.RenderControl(hw);

            var html = sb.ToString();
            html = html.Replace("collapse", "");
            html = html.Replace("ดูข้อมูลสุขภาพหนี้", "");

            return html;
        }

        private UIDMapApprochModel GenerateApprochObject()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var hcid = CookieManager.GetEncryptCookie("lineoa", "hcid", GetAppsetting("APIPartialCode"));
            var pid = CookieManager.GetEncryptCookie("lineoa", "pid", GetAppsetting("APIPartialCode"));

            var obj = new UIDMapApprochModel
            {
                ProductCode = pid,
                UID = uid,
                RegisterInfoID = hcid,
                ApprochBody = GenerateApprochBody(),
                RegisterYear = DateTime.Now.Year.ToString(),
                IsConfirmSendMail = false,
                Status = true,
                Createby = "LineOA"
            };
            return obj;
        }

        private List<UIDMapApprochModel> InsertApproch(UIDMapApprochModel obj)
        {
            var result = ApprochCon.Instance.InsertUIDMapApproch(obj);
            return result.RESULT_OBJ;
        }
    }
}