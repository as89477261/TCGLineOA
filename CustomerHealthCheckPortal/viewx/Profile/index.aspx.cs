using System;
using System.Linq;
using BLL.Controller;
using DataModel.Models.SMEClinic;

namespace CustomerHealthCheck.viewx.Profile
{
    public partial class index : BasePage
    {
        private CustomerProfileHistoryModel juristicProfile;
        private CustomerProfileHistoryModel personalProfile;
        private CustomerProfileHistoryModel pictureProfile;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetUserProfile();
                //BindingScreen();
            }
        }

        private void GetUserProfile()
        {
            try
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (uid != null)
                {
                    var bufferProfile = CustomerProfileCon.Instance.GetCustomerProfileHistoryByUID(uid);
                    if (bufferProfile.RESULT_STATUS == "OK" && bufferProfile.RESULT_OBJ.Count > 0)
                    {
                        // not coomplete 
                        pictureProfile = bufferProfile.RESULT_OBJ.FirstOrDefault(x => x.Picture != null);
                        personalProfile = bufferProfile.RESULT_OBJ.FirstOrDefault(x => x.IdCardType == 1);
                        juristicProfile = bufferProfile.RESULT_OBJ.FirstOrDefault(x => x.IdCardType == 2);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void BindingScreen()
        {
            bindingPicture();
            BindingPersonal();
            BindingUpdatePersonal();
            BindingJuristic();
            BindingUpdateJuristic();
        }

        // Region Binding
        private void bindingPicture()
        {
            try
            {
                var pic = CookieManager.GetEncryptCookie("lineoa", "pic", GetAppsetting("APIPartialCode"));
                if (string.IsNullOrEmpty(pic)) pic = pictureProfile.Picture;

                //imgLineImage.ImageUrl = pic;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BindingPersonal()
        {
            try
            {
                if (personalProfile != null) hddPCustomerProfileCode.Value = personalProfile.Code.ToString();
                //txtPIDCard.Value = personalProfile.IdCard.ToStringWithCheck();
                //txtPName.Value = personalProfile.Name.ToStringWithCheck();
                //txtPLastName.Value = personalProfile.SureName.ToStringWithCheck();
                //txtPPhone.Value = personalProfile.MobileNumber.ToStringWithCheck();
                //txtPTitle.Value = personalProfile.TitleName.ToStringWithCheck();
                //txtEmail.Value = personalProfile.Email.ToStringWithCheck();
                //tabHeaderPersonal.Attributes["Class"] = "disabled";
                //tab1.Attributes["Class"] = tab1.Attributes["Class"].Replace("show", "").Trim();
                //tabHeaderPersonal.Attributes["aria-expanded"] = tabHeaderJuristic.Attributes["aria-expanded"].Replace("true", "false").Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BindingUpdatePersonal()
        {
            try
            {
                if (personalProfile != null)
                {
                    txtUpdatePIDCard.Value = personalProfile.IdCard.ToStringWithCheck();
                    txtUpdatePName.Value = personalProfile.Name.ToStringWithCheck();
                    txtUpdatePLastName.Value = personalProfile.SureName.ToStringWithCheck();
                    txtUpdatePMobilePhone.Value = personalProfile.MobileNumber.ToStringWithCheck();
                    ddlTitlePersonal.SelectedValue = personalProfile.TitleCode.ToStringWithCheck();
                    txtUpdatePEmail.Value = personalProfile.Email.ToStringWithCheck();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BindingJuristic()
        {
            try
            {
                if (juristicProfile != null) hddJCustomerProfileCode.Value = juristicProfile.Code.ToString();
                //txtJName.Value = juristicProfile.CompanyName.ToStringWithCheck();
                //txtJPhone.Value = juristicProfile.MobileNumber.ToStringWithCheck();
                //txtJTitle.Value = juristicProfile.TitleName.ToStringWithCheck();
                //txtJVatID.Value = juristicProfile.IdCard.ToStringWithCheck();
                //txtJEmail.Value = juristicProfile.Email.ToStringWithCheck();
                //if (personalProfile == null)
                //{
                //    tabHeaderJuristic.Attributes["aria-expanded"] = tabHeaderJuristic.Attributes["aria-expanded"].Replace("false", "true").Trim();
                //    tab2.Attributes["Class"] = "show";
                //}
                //tabHeaderJuristic.Attributes["Class"] = "disabled";
                //tab2.Attributes["Class"] = tab2.Attributes["Class"].Replace("show", "").Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BindingUpdateJuristic()
        {
            try
            {
                if (juristicProfile != null)
                {
                    txtUpdateJName.Value = juristicProfile.CompanyName.ToStringWithCheck();
                    txtUpdateJMobilePhone.Value = juristicProfile.MobileNumber.ToStringWithCheck();
                    ddlTitleCompany.SelectedValue = juristicProfile.TitleCode.ToStringWithCheck();
                    txtUpdateJID.Value = juristicProfile.IdCard.ToStringWithCheck();
                    txtUpdateJEmail.Value = juristicProfile.Email.ToStringWithCheck();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}