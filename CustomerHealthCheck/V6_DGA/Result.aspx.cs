using System;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Controller;
using CustomerHealthCheck.RegisterControllerService;
using log4net;
using Newtonsoft.Json;
using Task = System.Threading.Tasks.Task;


namespace CustomerHealthCheck.V6_DGA
{
    public partial class Result : BasePage
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly RegisterControllerSoapClient registerController = new RegisterControllerSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

                if (Session["RegisterInfo"] != null && Session["ScoreInfo"] != null)
                {
                    try
                    {
                        LocalLogManager.Logger("Begin Step1", "HealthCheck");
                        var registerInfo = (RegisterInfo)Session["RegisterInfo"];
                        var scoreInfo = (ScoreInfo)Session["ScoreInfo"];
                        var uid = (string)Session["uid"];

                        if (!string.IsNullOrEmpty(uid))
                        {
                            var enrolPersonal = registerController.GetUIDMapEnrolment(uid);
                            if (enrolPersonal.RESULT_STATUS == "OK")
                            {
                                var bufferInfo = enrolPersonal.RESULT_OBJ;
                                BindingInfo(bufferInfo);

                            }
                        }

                        if (registerInfo != null && scoreInfo != null)
                        {
                            bindTitleName(registerInfo.personType);
                            setShowHideDivPersonType(registerInfo.personType);
                            lblResultText.Text = scoreInfo.groupDesc;
                            imageBG.ImageUrl = scoreInfo.ImageBG;
                            imageScore.ImageUrl = scoreInfo.ImageScore;
							//เพิ่มการ Show Score ไปแสดงผล
							int scorehealth = scoreInfo.score;
							if (scorehealth == 0)
							{
								lblScore.Text = "คะแนน ไม่อยู่ในเกณฑ์";
							}
							else
							{
								lblScore.Text = "คะแนน : " + scorehealth.ToString();

							}
							bindChannel();
                        }
                        else
                        {
                            Utility.writeLog("Page_Load >> session != null, registerInfo = null or scoreInfo = null",
                                ref log4);
                           // Response.Redirect("Default.aspx");
                        }
                    }
                    catch (Exception ex)
                    {
                        Utility.writeLog("Page_Load >> session != null Error : " + ex, ref log4);
                    }
                }
                else
                {
                    LocalLogManager.Logger("Begin Step 1 else", "HealthCheck");
                    Utility.writeLog("Page_Load session is null, redirect to DefaultV5.aspx page", ref log4);
                   // Response.Redirect("Default.aspx");
                }
            }
            else
            {
                LocalLogManager.Logger("Begin step1 Save Data", "HealthCheck");
                saveContact();
                if (Session["uid"] != null)
                {
                    Session.RemoveAll();
                  //  Response.Redirect("Default.aspx?modalSuccess=true&line=true");
                }
                else
                {
                    SubmitConsentAndRedirect();
                }
            }
        }
        private void BindingInfo(EnrolmentPersonalModel obj)
        {
            ddTitlePerson.SelectedValue = obj.TitleName;
            txtName.Text = obj.FirstName;
            txtSurname.Text = obj.LastName;
            txtPhone.Text = obj.MobilePhone;
            txtIDCard.Text = obj.IdentityID;

            ddTitlePerson.Enabled = false;
            txtName.Enabled = false;
            txtSurname.Enabled = false;
            txtPhone.Enabled = false;
            txtIDCard.Enabled = false;

            txtName.CssClass += " form-control";
            txtSurname.CssClass += " form-control";
            txtPhone.CssClass += " form-control";
            txtIDCard.CssClass += " form-control";


        }
        public void bindTitleName(PersonType type)
        {
            try
            {
                var dd = new DropDownList();
                if (type == PersonType.Person)
                    dd = ddTitlePerson;
                else if (type == PersonType.Corporate)
                    dd = ddTitleCorporate;
                dd.DataSource = registerController.GetTitleName(type);
                dd.DataTextField = "Name";
                dd.DataValueField = "Code";
                dd.DataBind();
            }
            catch (Exception ex)
            {
                Utility.writeLog("bindTitleName Error : " + ex, ref log4);
            }
        }
        public void bindChannel()
        {
            try
            {
                ddChannel.DataSource = registerController.GetChannel();
                ddChannel.DataTextField = "FieldName";
                ddChannel.DataValueField = "ID";
                ddChannel.DataBind();
                ddChannel.Items.Insert(0, new ListItem("กรุณาเลือกที่มา", "0"));
            }
            catch (Exception ex)
            {
                Utility.writeLog("bindIndustry Error : " + ex, ref log4);
            }
        }
        public void setShowHideDivPersonType(PersonType type)
        {
            try
            {
                if (type == PersonType.Person)
                {
                    divPerson.Style.Add("display", "block");
                    divCorporate.Style.Add("display", "none");
                    lblIDCard.Text = "เลขประจำตัวประชาชน";
                    hdIDCard.Value = "0";
                }
                else if (type == PersonType.Corporate)
                {
                    divPerson.Style.Add("display", "none");
                    divCorporate.Style.Add("display", "block");
                    lblIDCard.Text = "เลขทะเบียนนิติบุคคล";
                    hdIDCard.Value = "1";
                }
            }
            catch (Exception ex)
            {
                Utility.writeLog("setShowHideDivPersonType Error : " + ex, ref log4);
            }
        }

        public RegisterInfo getContactInfo(RegisterInfo info)
        {
            try
            {
                if (info.personType == PersonType.Person)
                {
                    info.title = ddTitlePerson.SelectedValue;
                    info.businessName = txtBusinessNamePerson.Text;
                    info.name = txtName.Text;
                    info.surname = txtSurname.Text;
                    if (string.IsNullOrEmpty(info.name))
                        info.name = info.businessName;
                    if (string.IsNullOrEmpty(info.surname))
                        info.surname = "";
                }
                else if (info.personType == PersonType.Corporate)
                {
                    info.title = ddTitleCorporate.SelectedValue;
                    info.businessName = txtBusinessNameCorporate.Text;
                }

                info.phone = txtPhone.Text;
                info.idCard = txtIDCard.Text;
                info.remark = txtRemark.Text;
                info.email = txtEmail.Text;
                info.eventType = Convert.ToInt32(ddChannel.SelectedValue);


                //if (radioEvent.Checked)
                //{
                //    info.eventType = EventType.Event;
                //}
            }
            catch (Exception ex)
            {
                Utility.writeLog("getContactInfo Error : " + ex, ref log4);
            }

            return info;
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
        public void showModalConsent(bool isShow)
        {
            try
            {
                if (isShow)
                    modalConsent.Attributes["class"] = "modal open";
                else
                    modalConsent.Attributes["class"] = "modal";
            }
            catch (Exception ex)
            {
                Utility.writeLog("showModalConsent Error : " + ex, ref log4);
            }
        }

        public void saveContact()
        {
            var errorStep = "Begin";
            try
            {
                LocalLogManager.Logger("Begin Step down Save Data", "HealthCheck");
                if (Session["RegisterInfo"] != null && Session["ScoreInfo"] != null)
                {
                    var registerInfo = (RegisterInfo)Session["RegisterInfo"];
                    var scoreInfo = (ScoreInfo)Session["ScoreInfo"];

                    if (string.IsNullOrEmpty(registerInfo.requestNo)) /* ยังไม่เคยเซฟ */
                    {
                        registerInfo = getContactInfo(registerInfo);
                        errorStep = "UpdateRegisterInfo";
                        registerController.UpdateRegisterInfo(registerInfo);
                        errorStep = "InsertCustomerProfile";
                        var customerCode = registerController.InsertCustomerProfile(registerInfo);
                        if (Session["uid"] != null)
                        {
                            errorStep = "UpdateUID";
                            registerController.UpdateUID(Session["uid"].ToString(), customerCode);
                        }

                        errorStep = "InsertContactProfile";
                        registerController.InsertContactProfile(registerInfo, customerCode, registerInfo.email);
                        errorStep = "InsertRequest";
                        registerInfo.requestNo = registerController.InsertRequestPGS10(customerCode);
                        Session["RegisterInfo"] = registerInfo;
                        errorStep = "InsertFieldData";
                        registerController.InsertFieldData(registerInfo, scoreInfo);
                        errorStep = "UpdateCodeFromClinic";
                        registerController.UpdateCodeFromClinic(registerInfo.id, customerCode, registerInfo.requestNo);
                        errorStep = "End";
                    }

                    var registerInfoId = registerInfo.id;


                    if (Session["uid"] != null && registerInfoId != 0)
                        try
                        {
                            var uid = Session["uid"].ToString();
                            //Task.Run(() => { SendEmail(uid, scoreInfo.groupDesc); });
                            LocalLogManager.Logger("Step 1 Sent Mail To UID : " + uid + " : RegisterinfoId : " + registerInfoId);
                            Task.Run(() => { SendEmailPhomKhum(uid, registerInfoId); });
                            // SendEmailPhomKhum(uid, registerInfoId);
                        }
                        catch (Exception ex)
                        {
                            LocalLogManager.Logger("SendMail : " + ex.Message);
                        }
                }
                else
                {
                    Utility.writeLog("saveContact session is null, redirect to Default.aspx page", ref log4);
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                Utility.writeLog("saveContact Step " + errorStep + " Error : " + ex, ref log4);
                showModalResult(false);
            }
        }
        private void SendEmail(string uid, string groupDesc)
        {
            // ขออนุญาตเพิ่ม Code ครับ
            LocalLogManager.Logger("SendMail : Begin Process");
            var GetEmailTemplate = DecodeBase64(GetAppsetting("emailTemplateBody")); // เปลี่ยน Temp 
            var customerInfo = CustomerProfileCon.Instance.GetCustomerProfileByUID(uid);
            if (customerInfo != null && customerInfo.RESULT_OBJ.Count > 0)
            {
                LocalLogManager.Logger("SendMail : Get Profile By UID");
                var bufferCustomer = customerInfo.RESULT_OBJ.FirstOrDefault();
                if (!string.IsNullOrEmpty(bufferCustomer.Email))
                {
                    LocalLogManager.Logger("SendMail : Generate Template Email");
                    GetEmailTemplate = GetEmailTemplate.Replace("@level", groupDesc); // แทนค่า ในการ ใส่ข้อมูล 
                    GetEmailTemplate = GetEmailTemplate.Replace("@URL", GetAppsetting("TCGContactURL"));
                    var emailInfo = new EmailInfo
                    {
                        Body = GetEmailTemplate,
                        Sender = "noreply@tcg.or.th",
                        CCEmail = "",
                        Email = bufferCustomer.Email,
                        Subject = GetAppsetting("EmailTemplateHeader")
                    };

                    LocalLogManager.Logger("SendMail : " + JsonConvert.SerializeObject(emailInfo));
                    registerController.SendEmail(emailInfo);

                    LocalLogManager.Logger("SendMail : Send Success");
                    //var bufferToken = APIAuthenCon.Instance.GetAuthenToken();
                    //var Result = EmailCon.Instance.SendMail(emailInfo, bufferToken);
                }
            }
        }
        private void SendEmailPhomKhum(string uid, int registerInfoId)
        {
            // ขออนุญาตเพิ่ม Code ครับ
            LocalLogManager.Logger("SendMail : Begin Process");
            var GetEmailTemplate = DecodeBase64(GetAppsetting("emailTemplateBodyPromKhum")); // เปลี่ยน Temp 
            var customerInfo = CustomerProfileCon.Instance.GetUIDMapRegisterHealthCheck(uid, registerInfoId);

            if (customerInfo != null && customerInfo.RESULT_OBJ.Count > 0)
            {
                LocalLogManager.Logger("SendMail : Get Profile By UID");
                var bufferCustomer = customerInfo.RESULT_OBJ.FirstOrDefault();
                if (!string.IsNullOrEmpty(bufferCustomer.HC_GroupDesc))
                {
                    LocalLogManager.Logger("SendMail : Generate Template Email");
                    GetEmailTemplate = GetEmailTemplate.Replace("@R05Title_Des_Thai", bufferCustomer.R05Title_Des_Thai); // แทนค่า ในการ ใส่ข้อมูล 
                    GetEmailTemplate = GetEmailTemplate.Replace("@CustomerName", bufferCustomer.CustomerName);
                    GetEmailTemplate = GetEmailTemplate.Replace("@CustomerSurname", bufferCustomer.CustomerSurname);
                    GetEmailTemplate = GetEmailTemplate.Replace("@BusinessName", bufferCustomer.BusinessName);
                    GetEmailTemplate = GetEmailTemplate.Replace("@MobilePhone", bufferCustomer.MobilePhone);
                    GetEmailTemplate = GetEmailTemplate.Replace("@IdCard", bufferCustomer.IdCard);
                    GetEmailTemplate = GetEmailTemplate.Replace("@EventContact", bufferCustomer.EventContact);
                    GetEmailTemplate = GetEmailTemplate.Replace("@EmailClinic", bufferCustomer.EmailClinic);
                    GetEmailTemplate = GetEmailTemplate.Replace("@TypeBussiness", bufferCustomer.TypeBussiness);
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_EstablishmentType",bufferCustomer.HC_EstablishmentType);
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_YearIncorporate", $"{bufferCustomer.HC_YearIncorporate}"); 
                    GetEmailTemplate = GetEmailTemplate.Replace("@R25Industry_Group_Name", bufferCustomer.R25Industry_Group_Name);
                    GetEmailTemplate = GetEmailTemplate.Replace("@R04Province_Name", bufferCustomer.R04Province_Name);
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_OwnerAge", $"{bufferCustomer.HC_OwnerAge}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_MaritalStatus", bufferCustomer.HC_MaritalStatus);
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_YearExperience", $"{bufferCustomer.HC_YearExperience}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_DebtStatus", $"{bufferCustomer.HC_DebtStatus}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_AssetValue", $"{bufferCustomer.HC_AssetValue}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_DebtValue", $"{bufferCustomer.HC_DebtValue}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_Income", $"{bufferCustomer.HC_Income}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_Expense", $"{bufferCustomer.HC_Expense}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_InstallmentAmount", $"{bufferCustomer.HC_InstallmentAmount}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_IsGetProfit", $"{bufferCustomer.HC_IsGetProfit}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@ClinicObjectiveTerm", $"{bufferCustomer.ClinicObjectiveTerm}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_LoanAmount", $"{bufferCustomer.HC_LoanAmount}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_YearInstallment", $"{bufferCustomer.HC_YearInstallment}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_GroupShortDesc", $"{bufferCustomer.HC_GroupShortDesc}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_GroupDesc", $"{bufferCustomer.HC_GroupDesc}");
                    GetEmailTemplate = GetEmailTemplate.Replace("@HC_Remark", $"{bufferCustomer.HC_Remark}");

                    var emailInfo = new EmailInfo
                    {
                        Body = GetEmailTemplate,
                        Sender = "noreply@tcg.or.th",
                        CCEmail = "",
                        Email = "",
                        Subject = GetAppsetting("emailSubjectPhomKhum")
                    };

                    LocalLogManager.Logger("SendMail : " + JsonConvert.SerializeObject(emailInfo));
                    registerController.SendEmailPromKhum(emailInfo);

                    //LocalLogManager.Logger("SendMail : Send Success");
                    //var bufferToken = APIAuthenCon.Instance.GetAuthenToken();
                    //var Result = EmailCon.Instance.SendMail(emailInfo, bufferToken);
                }
            }
        }

        private void SubmitConsentAndRedirect()
        {
            try
            {
                LocalLogManager.Logger("Begin step down down Save Data", "HealthCheck");

                if (Session["RegisterInfo"] != null)
                {
                    var registerInfo = (RegisterInfo)Session["RegisterInfo"];
                    registerInfo.consent = radioAccept.Checked ? 1 : 0;
                    registerController.UpdateConsent(registerInfo);

                    Session.RemoveAll();
                    Response.Redirect("Default.aspx?modalSuccess=true");
                }
                else
                {
                    Utility.writeLog("btnSubmit_Click session is null, redirect to Default.aspx page", ref log4);
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                Utility.writeLog("btnSubmit_Click Error : " + ex, ref log4);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                LocalLogManager.Logger("Begin step down down down Save Data", "HealthCheck");
                if (Session["RegisterInfo"] != null)
                {
                    var registerInfo = (RegisterInfo)Session["RegisterInfo"];
                    registerInfo.consent = radioAccept.Checked ? 1 : 0;
                    registerController.UpdateConsent(registerInfo);
                    showModalConsent(false);
                    Session.RemoveAll();
                    Response.Redirect("Default.aspx?modalSuccess=true");
                }
                else
                {
                    Utility.writeLog("btnSubmit_Click session is null, redirect to Default.aspx page", ref log4);
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                Utility.writeLog("btnSubmit_Click Error : " + ex, ref log4);
                showModalResult(false);
            }
        }
    }
}