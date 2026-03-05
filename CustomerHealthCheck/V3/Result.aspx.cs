using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Controller;
using CustomerHealthCheck.RegisterControllerService;
using log4net;
using Newtonsoft.Json;
using Task = System.Threading.Tasks.Task;

namespace CustomerHealthCheck.V3
{
    public partial class Result : BasePage
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly RegisterControllerSoapClient registerController = new RegisterControllerSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var injectUid = Request.QueryString["uid"];

                if (injectUid == null)
                {

                    string script = $"console.log('you are not access with uid');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyLogScript", script, true);
                }
                else
                {
                    Session["uid"] = injectUid;
                }


                if (Session["RegisterInfo"] != null && Session["ScoreInfo"] != null)
                {

                    try
                    {
                        var registerInfo = (RegisterInfo)Session["RegisterInfo"];
                        var scoreInfo = (ScoreInfo)Session["ScoreInfo"];
                        var uid = Session["uid"] as string;
                        var enrolPersonal = registerController.GetUIDMapEnrolment(uid);

                        if (registerInfo != null && scoreInfo != null)
                        {
                            bindTitleName(registerInfo.personType);
                            setShowHideDivPersonType(registerInfo.personType);
                            lblResultText.Text = scoreInfo.groupDesc;
                            imageBG.ImageUrl = scoreInfo.ImageBG;
                            imageScore.ImageUrl = scoreInfo.ImageScore;
                            //เพิ่มการ Show Score ไปแสดงผล
                            int scoreHealth = scoreInfo.score;
                            string personType = registerInfo.personType.ToString();
                            string scoreGroup = scoreInfo.scoreGroup.ToString();

                            var _scoreDisplay = scoreGroupCase(scoreGroup);

                            if (scoreHealth == 0)
                            {
                                string textScoreHealth = personType == "Person" ? "634" : (personType == "Corporate" ? "596" : "ไม่ทราบ");

                                lblScore.Text = $"กลุ่ม {scoreGroup.ToString()} คะแนน : {textScoreHealth.ToString()} {_scoreDisplay.scoreDesc}";
                            }
                            else
                            {

                                lblScore.Text = $"กลุ่ม {scoreGroup.ToString()} คะแนน : {scoreHealth.ToString()} {_scoreDisplay.scoreDesc}";
                            }

                            lblScore.ForeColor = _scoreDisplay.scoreColor;
                            bindChannel();
                        }
                        else
                        {
                            Utility.writeLog("Page_Load >> session != null, registerInfo = null or scoreInfo = null",
                                ref log4);
                            Response.Redirect("Default.aspx");
                        }
                    }
                    catch (Exception ex)
                    {
                        Utility.writeLog("Page_Load >> session != null Error : " + ex, ref log4);
                    }
                }
                else
                {
                    Utility.writeLog("Page_Load session is null, redirect to Default.aspx page", ref log4);
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                var injectUid = Request.QueryString["uid"];
                saveContact();
                var sessionUid = injectUid as string;
                if (sessionUid != null)
                {
                    Session.RemoveAll();
                    Response.Redirect($"Default.aspx?modalSuccess=true&line=true&uid={sessionUid}");
                }
                else
                {
                    SubmitConsentAndRedirect();
                }
            }
        }

        private DisplayScore scoreGroupCase(string scoreGroup)
        {
            var result = new DisplayScore();

            switch (scoreGroup)
            {
                case "3": //อ่อนแอ่
                    result.scoreColor = Color.Red;
                    result.scoreDesc = "อ่อนแอ";
                    break;
                case "2": //ปานกลาง
                    result.scoreColor = Color.Goldenrod; // ใช้ Goldenrod แทน LightGoldenrodYellow ที่อาจไม่มีใน WinForms
                    result.scoreDesc = "ปานกลาง";
                    break;
                case "1": // แข็งแรง
                    result.scoreColor = Color.Green;
                    result.scoreDesc = "แข็งแรง";
                    break;
                default:
                    result.scoreColor = ColorTranslator.FromHtml("#206bc3"); // ค่าเริ่มต้นถ้าไม่ตรงกับเงื่อนไข
                    result.scoreDesc = "ไม่ทราบ";
                    break;
            }
            return result;
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


                    if (Session["uid"] != null)
                        try
                        {
                            var uid = Session["uid"].ToString();
                            Task.Run(() => { SendEmail(uid, scoreInfo.groupDesc); });
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
            var GetEmailTemplate = DecodeBase64(GetAppsetting("emailTemplateBody"));
            var customerInfo = CustomerProfileCon.Instance.GetCustomerProfileByUID(uid);
            if (customerInfo != null && customerInfo.RESULT_OBJ != null && customerInfo.RESULT_OBJ.Count > 0)
            {
                LocalLogManager.Logger("SendMail : Get Profile By UID");
                var bufferCustomer = customerInfo.RESULT_OBJ.FirstOrDefault();
                if (!string.IsNullOrEmpty(bufferCustomer.Email))
                {
                    LocalLogManager.Logger("SendMail : Generate Template Email");
                    GetEmailTemplate = GetEmailTemplate.Replace("@level", groupDesc);
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

        private void SubmitConsentAndRedirect()
        {
            try
            {
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
    public class DisplayScore
    {
        public Color scoreColor { get; set; }

        public string scoreDesc { get; set; }
    }
}