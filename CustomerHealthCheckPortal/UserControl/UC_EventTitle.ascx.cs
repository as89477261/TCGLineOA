using System;

namespace CustomerHealthCheck.UserControl
{
    public partial class UC_EventTitle : System.Web.UI.UserControl
    {
        public string Header { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }


        public bool IsBodyPicture { get; set; }
        public string Body { get; set; }
        public string BodyPicturePath { get; set; }


        public string eventCode { get; set; }
        public string TitleIcon { get; set; }
        public string TitleIconColor { get; set; }
        public bool IsShowRegisterButton { get; set; }
        public DateTime StartShowRegisterButton { get; set; }
        public DateTime EndShowRegisterButton { get; set; }

        public bool IsShowCollaps { get; set; }
        public string RegisterForm { get; set; }
        public bool IsCheckDuplicateRegister { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindingData();
        }

        private void BindingData()
        {
            ltlTitle.Text =
                @"<button class='accordion-button collapsed' type='button' data-bs-toggle='collapse' data-bs-target='#accordion" +
                eventCode + "'><i class='bi " + TitleIcon + "  pe-3 font-30' style='color: " + TitleIconColor +
                ";'></i><span class='font-600 font-18 color-theme'>" + Title +
                @"</span><i class='bi bi-check-circle-fill font-20 color-green-dark'></i></button><div id='accordion" +
                eventCode + "' class='accordion-collapse collapse p-2 " + (IsShowCollaps ? "show" : "") +
                "' data-bs-parent='#accordion-group-7'>";
            //ltlTitle.Text = Title;
            ltlSubTitle.Text = SubTitle;
            ltlBody.Text = Body;

            IsShowButtonRegister();
            IsShowBodyByCondition();
        }

        private void IsShowButtonRegister()
        {
            if (IsShowRegisterButton == false)
            {
                ltlRegisterButton.Text = " <a href='#'  id='btnRegis" + eventCode +
                                         "' class='btn btn-full  gradient-gray shadow-bg shadow-bg-s disableOnLoading'>กิจกรรมยังไม่เปิดลงทะเบียน</a>";
            }
            else
            {
                if (StartShowRegisterButton >= DateTime.Now || EndShowRegisterButton <= DateTime.Now)
                    ltlRegisterButton.Text = " <a href='#'  id='btnRegis" + eventCode +
                                             "' class='btn btn-full  gradient-gray shadow-bg shadow-bg-s disableOnLoading'>กิจกรรมยังไม่เปิดลงทะเบียน</a>";
                else
                    ltlRegisterButton.Text = " <a href='#' onclick='ChooseEvent(\"" + RegisterForm + "\"," + eventCode +
                                             "," + (IsCheckDuplicateRegister ? 1 : 0) + ")' id='btnRegis" + eventCode +
                                             "' class='btn btn-full gradient-blue shadow-bg shadow-bg-s'>ลงทะเบียนกิจกรรม</a>";
            }
        }

        private void IsShowBodyByCondition()
        {
            if (IsBodyPicture)
            {
                imgImageBody.ImageUrl = BodyPicturePath;
                pnlIsBodyIsPicture.Visible = true;
                pnlIsBodyIsText.Visible = false;
            }
            else
            {
                ltlBody.Text = Body;
                pnlIsBodyIsPicture.Visible = false;
                pnlIsBodyIsText.Visible = true;
            }
        }
    }
}