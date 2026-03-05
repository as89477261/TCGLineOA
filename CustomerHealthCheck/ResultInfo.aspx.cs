using System;
using System.Configuration;
using System.Reflection;
using CustomerHealthCheck.RegisterControllerService;
using log4net;

namespace CustomerHealthCheck
{
    public partial class ResultInfo : BasePage
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private RegisterControllerSoapClient registerController = new RegisterControllerSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Session["RegisterInfo"] != null && Session["ScoreInfo"] != null)
                {
                    try
                    {
                        var registerInfo = (RegisterInfo)Session["RegisterInfo"];
                        var scoreInfo = (ScoreInfo)Session["ScoreInfo"];

                        if (registerInfo != null && scoreInfo != null)
                        {
                            bindTitleName(registerInfo.personType);
                            setShowHideDivPersonType(registerInfo.personType);
                            lblResultText.Text = scoreInfo.groupDesc;
                            imageBG.ImageUrl = scoreInfo.ImageBG;
                            imageScore.ImageUrl = scoreInfo.ImageScore;
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
                if (Session["uid"] != null)
                {
                    Session.RemoveAll();
                    Response.Redirect("Default.aspx?modalSuccess=true&line=true");
                }
            }
        }

        public void bindTitleName(PersonType type)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                Utility.writeLog("getContactInfo Error : " + ex, ref log4);
            }

            return info;
        }

        protected void btnRedirectMain_Click(object sender, EventArgs e)
        {
            var url = ConfigurationManager.AppSettings["lineMenuURL"];
            Response.Redirect(url);
        }
    }
}