using System;
using System.Configuration;

namespace CustomerHealthCheck.UserControl.Debt
{
    public partial class UC_DebtPackage_Ads : System.Web.UI.UserControl
    {
        public string PaddingEventsHeader { get; set; }
        public string EventCode { get; set; }
        public string EventTitle { get; set; }
        public string EventImageBody { get; set; }
        public bool IsShowBodyImage { get; set; }
        public string EventTextBody { get; set; }
        public string EventCondition { get; set; }
        public bool IsShowRegisterButton { get; set; }
        public bool ISRegisteredTopUp { get; set; }
        public bool ISChoosedDebtPackage { get; set; }
        public bool IsRegisterBeforeCondition { get; set; }

        public DateTime StartShowRegisterButton { get; set; }
        public DateTime EndShowRegisterButton { get; set; }
        public string RegisterForm { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            BindingPanel();
        }

        protected string GetAppsetting(string configName)
        {
            return ConfigurationManager.AppSettings[configName];
        }

        private void BindingPanel()
        {
            ltlDivPadding.Text = "<div style='padding:" + PaddingEventsHeader + ";'>";
            ltlEventHeader.Text = EventTitle;
            ltlEventCondition.Text = "<span  style='font-size:12px;color:red;' >" + EventCondition + "</span>";

            CookieManager.SetEncryptCookie("lineoa", "debtEID", EventCode, GetAppsetting("APIPartialCode"));

            IsShowBodyByCondition();
            IsRegisteredEvents();
            IsShowButtonRegister();
        }


        private void IsShowButtonRegister()
        {
            if (IsShowRegisterButton == false)
            {
                ltlEventButton.Text = " <a href='#'  id='btnRegis" + EventCode +
                                      "' class='btn btn-full gradient-gray shadow-bg shadow-bg-s disableOnLoading'>กิจกรรมยังไม่เปิดลงทะเบียน</a>";
            }
            else
            {
                if (StartShowRegisterButton >= DateTime.Now || EndShowRegisterButton <= DateTime.Now)
                    ltlEventButton.Text = " <a href='#'  id='btnRegis" + EventCode +
                                          "' class='btn btn-full gradient-gray shadow-bg shadow-bg-s disableOnLoading'>กิจกรรมยังไม่เปิดลงทะเบียน</a>";
                //else
                //{
                //    ltlEventButton.Text = " <a href='#' onclick='OpenDebtPackage(" + EventCode + ")' id='btnRegis" + EventCode + "' class='btn btn-full gradient-blue shadow-bg shadow-bg-s'>ลงทะเบียนรับของขวัญปีใหม่</a>";

                //}
            }
        }

        private void IsShowBodyByCondition()
        {
            if (IsShowBodyImage)
            {
                imgImageBody.ImageUrl = EventImageBody;
                pnlIsBodyIsPicture.Visible = true;
                pnlIsBodyIsText.Visible = false;
            }
            else
            {
                ltlBody.Text = EventTextBody;
                pnlIsBodyIsPicture.Visible = false;
                pnlIsBodyIsText.Visible = true;
            }
        }

        private void IsRegisteredEvents()
        {
            if (ISRegisteredTopUp)
            {
                ltlEventButton.Text = " <a href='#'  id='btnRegis" + EventCode +
                                      "' class='btn btn-full gradient-gray shadow-bg shadow-bg-s disableOnLoading'>ท่านเข้าร่วมมาตรการเรียบร้อยแล้ว</a>";
            }
            else
            {
                if (ISChoosedDebtPackage)
                {
                    if (IsRegisterBeforeCondition)
                        ltlEventButton.Text = " <a href='#' onclick='OpenDebtPackage(" + EventCode + ")' id='btnRegis" +
                                              EventCode +
                                              "' class='btn btn-full gradient-blue shadow-bg shadow-bg-s'>ลงทะเบียนรับของขวัญปีใหม่</a>";
                    else
                        ltlEventButton.Text = " <a href='#'  id='btnRegis" + EventCode +
                                              "' class='btn btn-full gradient-green shadow-bg shadow-bg-s ' style='pointer-events: none;'>ท่านได้รับสิทธิพิเศษ <br/> เข้าร่วมมาตรการ ผ่อนน้อย เบาแรง</a>";
                }
                else
                {
                    ltlEventButton.Text = " <a href='#'  id='btnRegis" + EventCode +
                                          "' class='btn btn-full gradient-gray shadow-bg shadow-bg-s disableOnLoading'>กรุณาเข้าร่วมมาตรการ 3 สีก่อนเข้าร่วม</a>";
                }
            }
        }
    }
}