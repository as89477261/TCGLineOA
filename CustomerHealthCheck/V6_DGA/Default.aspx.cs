using System;
using System.Configuration;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerHealthCheck.RegisterControllerService;
using log4net;
using Newtonsoft.Json;


namespace CustomerHealthCheck.V6_DGA
{
    public partial class Default : Page
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly RegisterControllerSoapClient registerController = new RegisterControllerSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                LocalLogManager.Logger("BeginTEST ", "HealthCheck");
            }
            else
            {
                try
                {
                    LocalLogManager.Logger("Begin Load Page ", "HealthCheck");
                    bindProvince();
                    bindIndustry();
                    bindObjTerm();

                    ddIndustry.SelectedIndex= 1;
                    ddProvince.SelectedIndex= 2;
                    ddObjTerm.SelectedIndex= 1;




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
                    catch (Exception ex)
                    {
                        LocalLogManager.Logger(ex.Message, "HealthCheck");
                    }
                }
                catch (Exception ex)
                {
                    LocalLogManager.Logger("Begin Load Page Error : " + ex.Message, "HealthCheck");
                    Utility.writeLog("Page_Load >> Page.IsPostBack == false Error : " + ex, ref log4);
                }
            }
        }

        public void bindProvince()
        {
            try
            {
                ddProvince.DataSource = registerController.GetProvince();
                ddProvince.DataTextField = "Name";
                ddProvince.DataValueField = "ProvinceCode";
                ddProvince.DataBind();
                ddProvince.Items.Insert(0, new ListItem("กรุณาเลือกจังหวัด", "0"));
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
                ddObjTerm.Items.Insert(0, new ListItem("กรุณาเลือกวัตถุประสงค์", "0"));
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
                registerInfo.installmentAmount = Convert.ToDouble(txtInstallmentAmount.Text);
                registerInfo.isGetProfit = radioGetProfitYes.Checked ? IsGetProfit.Yes : IsGetProfit.No;
                //registerInfo.objectiveTerm = radioObjShortTerm.Checked ? ObjectiveTerm.Short : ObjectiveTerm.Long;
                registerInfo.objectiveTerm = Convert.ToInt32(ddObjTerm.SelectedValue);
                registerInfo.loanAmount = Convert.ToDouble(txtLoanAmount.Text);
                registerInfo.yearInstallment = Convert.ToInt32(txtInstallmentYear.Text);

                /// New Data Extension
                // registerInfo. = Convert.ToInt32(txtInstallmentYear.Text);
            }
            catch (Exception ex)
            {
                Utility.writeLog("GetRegisterInfo Error : " + ex, ref log4);
            }

            return registerInfo;
        }

        public ScoreInfo calculateScore(RegisterInfo registerInfo)
        {
            return registerController.calculateScore(registerInfo);
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

        protected void btnSubmitForm_Click(object sender, EventArgs e)
        {
            try
            {
                LocalLogManager.Logger("Begin Save Data", "HealthCheck");
                var registerInfo = GetRegisterInfo();
                LocalLogManager.Logger("RegisterInfo : " + JsonConvert.SerializeObject(registerInfo), "HealthCheck");

                var scoreInfo = calculateScore(registerInfo);
                LocalLogManager.Logger("ScoreInfo : " + JsonConvert.SerializeObject(scoreInfo), "HealthCheck"); ;

                registerInfo.id = saveRegisterData(registerInfo, scoreInfo);
                if (Session["uid"] != null)
                    registerController.InsertUIDRegisterInfo(
                        Session["uid"].ToString(),
                        registerInfo.id,
                        Session["infoType"].ToString(),
                        Session["subInfoType"].ToString());

                Session["RegisterInfo"] = registerInfo;
                Session["ScoreInfo"] = scoreInfo;

                Response.Redirect("~/V6_DGA/Result.aspx");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Begin Save Error : " + ex.Message, "HealthCheck");
                //Utility.writeLog("Page_Load >> Page.IsPostBack Error : " + ex, ref log4);
            }
        }
    }
}