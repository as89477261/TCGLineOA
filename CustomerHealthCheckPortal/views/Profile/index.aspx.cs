using System;
using System.Linq;
using BLL.Controller;
using DataModel.Models.SMEClinic;

namespace CustomerHealthCheck.views.Profile
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
                GetUserProfile();
                BindingScreen();
                LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.Profile_Load);
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
                        var dataListObj = bufferProfile.RESULT_OBJ.OrderByDescending(x => x.CreateDateTime).ToList();
                        pictureProfile = dataListObj.FirstOrDefault(x => x.Picture != null);
                        personalProfile = dataListObj.FirstOrDefault(x => x.IdCardType == 1);
                        juristicProfile = dataListObj.FirstOrDefault(x => x.IdCardType == 2);

                        BindingNDIDStatus(personalProfile, "P");
                        // BindingNDIDStatus(juristicProfile, "J");
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

        private void BindingNDIDStatus(CustomerProfileHistoryModel obj, string type)
        {
            if (obj.IsSuccess)
                switch (type)
                {
                    case "P":
                        pnlIsVerifiedNDIDPersonal.Visible = true;
                        //btnPersonalEditModal.Visible = false;

                        break;
                    case "J":
                        pnlIsVerifiedNDIDJuristic.Visible = true;
                        //btnJuristicEditModal.Visible = false;

                        break;
                }
        }

        // Region Binding
        private void bindingPicture()
        {
            try
            {
                var pic = CookieManager.GetEncryptCookie("lineoa", "pic", GetAppsetting("APIPartialCode"));
                if (string.IsNullOrEmpty(pic)) pic = pictureProfile.Picture;

                imgLineImage.ImageUrl = pic;
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
                if (personalProfile != null)
                {
                    hddPCustomerProfileCode.Value = personalProfile.Code.ToString();
                    txtPIDCard.Value = personalProfile.IdCard.ToStringWithCheck();
                    txtPName.Value = personalProfile.Name.ToStringWithCheck();
                    txtPLastName.Value = personalProfile.SureName.ToStringWithCheck();
                    txtPPhone.Value = string.IsNullOrEmpty(personalProfile.MobileNumberHistory)
                        ? personalProfile.MobileNumber.ToStringWithCheck()
                        : personalProfile.MobileNumberHistory.ToStringWithCheck();
                    txtPTitle.Value = personalProfile.TitleName.ToStringWithCheck();
                    txtEmail.Value = string.IsNullOrEmpty(personalProfile.EmailHistory)
                        ? personalProfile.EmailAddress.ToStringWithCheck()
                        : personalProfile.EmailHistory.ToStringWithCheck();

                    var bufferIDCard = CookieManager.GetEncryptCookie("lineoa", "rIDCard", GetAppsetting("APIPartialCode"));
                    if (!string.IsNullOrEmpty(personalProfile.IdCard) && string.IsNullOrEmpty(bufferIDCard))
                        CookieManager.SetEncryptCookie("lineoa", "rIDCard", personalProfile.IdCard, GetAppsetting("APIPartialCode"));
                }
                else
                {
                    tabHeaderPersonal.Attributes["Class"] = "disabled";
                    tab1.Attributes["Class"] = tab1.Attributes["Class"].Replace("show", "").Trim();
                    tabHeaderPersonal.Attributes["aria-expanded"] = tabHeaderJuristic.Attributes["aria-expanded"]
                        .Replace("true", "false").Trim();
                }
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
                    txtUpdatePMobilePhone.Value = string.IsNullOrEmpty(personalProfile.MobileNumberHistory)
                        ? personalProfile.MobileNumber.ToStringWithCheck()
                        : personalProfile.MobileNumberHistory.ToStringWithCheck();
                    ddlTitlePersonal.SelectedValue = personalProfile.TitleCode.ToStringWithCheck();
                    txtUpdatePEmail.Value = string.IsNullOrEmpty(personalProfile.EmailHistory)
                        ? personalProfile.EmailAddress.ToStringWithCheck()
                        : personalProfile.EmailHistory.ToStringWithCheck();
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
                if (juristicProfile != null)
                {
                    hddJCustomerProfileCode.Value = juristicProfile.Code.ToString();
                    txtJName.Value = juristicProfile.CompanyName.ToStringWithCheck();
                    txtJPhone.Value = juristicProfile.MobileNumber.ToStringWithCheck();
                    txtJTitle.Value = juristicProfile.TitleName.ToStringWithCheck();
                    txtJVatID.Value = juristicProfile.IdCard.ToStringWithCheck();
                    txtJEmail.Value = juristicProfile.EmailAddress.ToStringWithCheck();


                    if (personalProfile == null)
                    {
                        tabHeaderJuristic.Attributes["aria-expanded"] = tabHeaderJuristic.Attributes["aria-expanded"]
                            .Replace("false", "true").Trim();
                        tab2.Attributes["Class"] = "show";
                    }
                }
                else
                {
                    tabHeaderJuristic.Attributes["Class"] = "disabled";
                    tab2.Attributes["Class"] = tab2.Attributes["Class"].Replace("show", "").Trim();
                }
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
                    txtUpdateJEmail.Value = juristicProfile.EmailAddress.ToStringWithCheck();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}