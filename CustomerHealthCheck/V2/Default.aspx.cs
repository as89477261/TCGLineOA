using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerHealthCheck.RegisterControllerService;
using log4net;
using Utiltiy;

namespace CustomerHealthCheck.V2
{
    public partial class Default : Page
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly RegisterControllerSoapClient registerController = new RegisterControllerSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                try
                {
                    var registerInfo = GetRegisterInfo();
                    var scoreInfo = calculateScore(registerInfo);
                    registerInfo = calculateDSCR(registerInfo); //calculateDSCR(registerInfo);
                    registerInfo = calculateTCGScoreAndRBP(registerInfo);

                    registerInfo.id = saveRegisterData(registerInfo, scoreInfo);
                    if (Session["uid"] != null)
                    {
                        registerController.InsertUIDRegisterInfo(
                            Session["uid"].ToString(),
                            registerInfo.id,
                            Session["infoType"].ToString(),
                            Session["subInfoType"].ToString());
                        var uidMapRegisterType = GetUIDMapCustomerProfile(Session["uid"].ToString(),
                            registerInfo.personType == PersonType.Person ? "1" : "2");

                        if (uidMapRegisterType != null)
                        {
                            if (registerInfo.personType == PersonType.Person)
                            {
                                registerInfo.title = uidMapRegisterType.TitleName;
                                registerInfo.businessName = uidMapRegisterType.CompanyName;
                                registerInfo.name = uidMapRegisterType.Name;
                                registerInfo.surname = uidMapRegisterType.SureName;

                                if (string.IsNullOrEmpty(registerInfo.name))
                                    registerInfo.name = registerInfo.businessName;
                                if (string.IsNullOrEmpty(registerInfo.surname))
                                    registerInfo.surname = "";
                            }
                            else if (registerInfo.personType == PersonType.Corporate)
                            {
                                registerInfo.title = uidMapRegisterType.TitleName;
                                registerInfo.businessName = uidMapRegisterType.CompanyName;
                            }

                            registerInfo.phone = uidMapRegisterType.MobileNumber;
                            registerInfo.idCard = uidMapRegisterType.IdCard;

                            registerController.UpdateRegisterInfo(registerInfo);

                            Session["RegisterInfo"] = registerInfo;
                            Session["ScoreInfo"] = scoreInfo;

                            Response.Redirect("ResultInfo.aspx");
                        }
                    }


                    Session["RegisterInfo"] = registerInfo;
                    Session["ScoreInfo"] = scoreInfo;

                    Response.Redirect("Result.aspx");
                }
                catch (Exception ex)
                {
                    Utility.writeLog("Page_Load >> Page.IsPostBack Error : " + ex, ref log4);
                }
            else
                try
                {
                    bindProvince();
                    bindIndustry();
                    bindObjTerm();
                    Session.Remove("RegisterInfo");
                    Session.Remove("ScoreInfo");
                    Session.Remove("uid");

                    try
                    {
                        if (Request.QueryString["modalSuccess"] != null)
                        {
                            var result = Convert.ToBoolean(Request.QueryString["modalSuccess"]);
                            showModalResult(result);
                            if (Request.QueryString["line"] != null)
                            {
                                var urlRedirectMenu = ConfigurationManager.AppSettings["lineMenuURL"];
                                Response.AddHeader("REFRESH", string.Format("2;URL={0}", urlRedirectMenu));
                            }
                        }

                        if (Request.QueryString["uid"] != null) Session["uid"] = Request.QueryString["uid"];

                        if (Request.QueryString["infoType"] != null)
                            Session["infoType"] = Request.QueryString["infoType"];
                        else
                            Session["infoType"] = ConfigurationManager.AppSettings["infoType"];

                        if (Request.QueryString["subInfoType"] != null)
                            Session["subInfoType"] = Request.QueryString["subInfoType"];
                        else
                            Session["subInfoType"] = ConfigurationManager.AppSettings["subInfoType"];
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    Utility.writeLog("Page_Load >> Page.IsPostBack == false Error : " + ex, ref log4);
                }
        }

        public void bindProvince()
        {
            try
            {
                var buffer = registerController.GetProvince();
                ddProvince.DataSource = buffer;
                ddProvince.DataTextField = "Name";
                ddProvince.DataValueField = "ProvinceCode";
                ddProvince.DataBind();
                ddProvince.Items.Insert(0, new ListItem("กรุณาเลือกจังหวัด", "0"));

                SessionHelper.Province = buffer;
            }
            catch (Exception ex)
            {
                Utility.writeLog("bindProvince Error : " + ex, ref log4);
            }
        }

        public void bindIndustry()
        {
            try
            {
                ddIndustry.DataSource = registerController.GetIndustryType();
                ddIndustry.DataTextField = "Name";
                ddIndustry.DataValueField = "IndustryGroup";
                ddIndustry.DataBind();
                ddIndustry.Items.Insert(0, new ListItem("กรุณาเลือกประเภทกิจการ", "0"));
            }
            catch (Exception ex)
            {
                Utility.writeLog("bindIndustry Error : " + ex, ref log4);
            }
        }

        public void bindObjTerm()
        {
            try
            {
                ddObjTerm.DataSource = registerController.GetObjTerm();
                ddObjTerm.DataTextField = "FieldName";
                ddObjTerm.DataValueField = "ID";
                ddObjTerm.DataBind();
                ddObjTerm.Items.Insert(0, new ListItem("ตรวจสอบสุขภาพหนี้", "0"));
            }
            catch (Exception ex)
            {
                Utility.writeLog("bindObjTerm Error : " + ex, ref log4);
            }
        }

        public RegisterInfo GetRegisterInfo()
        {
            var registerInfo = new RegisterInfo();

            try
            {
                registerInfo.personType = radioBusiness.Checked ? PersonType.Corporate : PersonType.Person;
                registerInfo.officeType = radioOfficeOwner.Checked ? EstablishmentType.OfficeOwner :
                    radioOfficeRental.Checked ? EstablishmentType.OfficeRental : EstablishmentType.NoShow;
                registerInfo.yearIncorporate = Convert.ToInt32(txtYearIncorporate.Text);
                registerInfo.industryCode = ddIndustry.SelectedValue;
                registerInfo.provinceCode = ddProvince.SelectedValue;
                registerInfo.regionCode = SessionHelper.Province.AsEnumerable()
                    .Where(s => s.Field<string>("ProvinceCode") == ddProvince.SelectedValue)
                    .Select(s => s.Field<string>("RegionCode")).FirstOrDefault();

                registerInfo.ownerAge = Convert.ToInt32(txtOwnerAge.Text);
                registerInfo.maritalStatus = (MaritalType)Convert.ToInt32(ddMaritalStatus.SelectedValue);
                registerInfo.yearExperience = Convert.ToInt32(txtYearExperience.Text);
                registerInfo.debtStatus = (DebtStatusType)Convert.ToInt32(ddDebtStatus.SelectedValue);
                if (registerInfo.debtStatus == DebtStatusType.TDR)
                {
                    registerInfo.TdrAmount = Convert.ToInt32(txtTdrAmount.Text);
                    registerInfo.TdrYear = Convert.ToInt32(txtTdrYear.Text);
                }

                registerInfo.assetValue = Convert.ToDouble(txtAssetValue.Text);
                registerInfo.debtValue = Convert.ToDouble(txtDebtValue.Text);
                registerInfo.income = Convert.ToDouble(txtIncome.Text);
                registerInfo.expense = Convert.ToDouble(txtExpense.Text);
                registerInfo.CostSale = Convert.ToDouble(txtCostSale.Text);
                registerInfo.installmentAmount = Convert.ToDouble(txtInstallmentAmount.Text);
                registerInfo.isGetProfit = radioGetProfitYes.Checked ? IsGetProfit.Yes : IsGetProfit.No;
                //registerInfo.objectiveTerm = radioObjShortTerm.Checked ? ObjectiveTerm.Short : ObjectiveTerm.Long;
                registerInfo.objectiveTerm = Convert.ToInt32(ddObjTerm.SelectedValue);
                registerInfo.loanAmount = Convert.ToDouble(txtLoanAmount.Text);
                registerInfo.yearInstallment = Convert.ToInt32(txtInstallmentYear.Text);
                registerInfo.LandAsset = Convert.ToDouble(txtLandAsset.Text != "" ? txtLandAsset.Text : "0");
                // New Data Extension
                //registerInfo. = Convert.ToInt32(txtInstallmentYear.Text);
                //registerInfo.CostSale = Convert.ToInt32(txtCostSale.Text);

                registerInfo.LoanLCTR = Convert.ToDouble(txtLCTR.Text != "" ? txtLCTR.Text : "0");
                registerInfo.LoanLG = Convert.ToDouble(txtLG.Text != "" ? txtLG.Text : "0");
                registerInfo.LoanPN = Convert.ToDouble(txtPN.Text != "" ? txtPN.Text : "0");
                registerInfo.LoanOD = Convert.ToDouble(txtOD.Text != "" ? txtOD.Text : "0");
                registerInfo.LoanTL = Convert.ToDouble(txtLoan.Text != "" ? txtLoan.Text : "0");
                registerInfo.LoanOther = Convert.ToDouble(txtOther.Text != "" ? txtOther.Text : "0");
                registerInfo.SumAsset = Convert.ToDouble(txtAssetValue.Text != "" ? txtAssetValue.Text : "0") -
                                        Convert.ToDouble(txtLandAsset.Text != "" ? txtLandAsset.Text : "0");

                registerInfo.IsPassCreditBureau = null;
                registerInfo.CreditBureauLevel = 1;
            }
            catch (Exception ex)
            {
                Utility.writeLog("GetRegisterInfo Error : " + ex, ref log4);
            }

            return registerInfo;
        }

        public CustomerProfileHistoryModel GetUIDMapCustomerProfile(string uid, string type)
        {
            return registerController.GetUIDMapRegiterType(uid, type);
        }

        public ScoreInfo calculateScore(RegisterInfo registerInfo)
        {
            return registerController.calculateScore(registerInfo);
        }

        public RegisterInfo calculateDSCR(RegisterInfo registerInfo)
        {
            return registerController.calculateDSCR(registerInfo);
        }

        public RegisterInfo calculateTCGScoreAndRBP(RegisterInfo registerInfo)
        {
            return registerController.calculateTCGScoreAndRBP(registerInfo);
        }

        public int saveRegisterData(RegisterInfo info, ScoreInfo score)
        {
            return registerController.InsertRegisterInfo(info, score);
        }

        public void showModalResult(bool isSuccess)
        {
            try
            {
                modalResult.Attributes["class"] = "modal open";
                if (isSuccess)
                {
                    lblSaveSuccess.Visible = true;
                    lblSaveFail.Visible = false;
                }
                else
                {
                    lblSaveSuccess.Visible = false;
                    lblSaveFail.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Utility.writeLog("showModalResult Error : " + ex, ref log4);
            }
        }
    }
}