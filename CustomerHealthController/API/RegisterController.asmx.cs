using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using log4net;

namespace CustomerHealthController
{
    /// <summary>
    /// Summary description for RegisterController
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RegisterController : System.Web.Services.WebService
    {
        RegisterDB service = new RegisterDB();
        private static log4net.ILog log4 = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [WebMethod]
        public DataTable GetProvince()
        {
            DataTable dt = null;
            try
            {
                dt = service.GetProvince();
            }
            catch (Exception ex)
            {
                Utility.writeLog("GetProvince Error : " + ex.ToString(), ref log4);
            }
            return dt;
        }

        [WebMethod]
        public DataTable GetIndustryType()
        {
            DataTable dt = null;
            try
            {
                dt = service.GetIndustry();
            }
            catch (Exception ex)
            {
                Utility.writeLog("GetIndustryType Error : " + ex.ToString(), ref log4);
            }
            return dt;
        }

        [WebMethod]
        public DataTable GetTitleName(PersonType type)
        {
            DataTable dt = null;
            try
            {
                dt = service.GetTitleName(type);
            }
            catch (Exception ex)
            {
                Utility.writeLog("GetTitleName Error : " + ex.ToString(), ref log4);
            }
            return dt;
        }

        [WebMethod]
        public RegisterInfo newRegisterInfo()
        {
            return new RegisterInfo();
        }

        [WebMethod]
        public ScoreInfo calculateScore(RegisterInfo info)
        {
            return new Calculate().calculateScore(info);
        }

        [WebMethod]
        public int InsertRegisterInfo(RegisterInfo info, ScoreInfo score)
        {
            return service.InsertRegisterInfo(info, score);
        }

        [WebMethod]
        public bool UpdateRegisterInfo(RegisterInfo info)
        {
            return service.UpdateRegisterInfo(info);
        }

        [WebMethod]
        public bool UpdateConsent(RegisterInfo info)
        {
            return service.UpdateConsent(info);
        }

        [WebMethod]
        public bool UpdateCodeFromClinic(int id, string clinicCustomerCode, string clinicRequestNo)
        {
            return service.UpdateCodeFromClinic(id, clinicCustomerCode, clinicRequestNo);
        }

        [WebMethod]
        public string InsertCustomerProfile(RegisterInfo info)
        {
            return service.InsertCustomerProfile(info);
        }

        [WebMethod]
        public void InsertContactProfile(RegisterInfo info, string customerCode)
        {
            service.InsertContactProfile(info, customerCode, 1);
            service.InsertContactProfile(info, customerCode, 2);
        }

        [WebMethod]
        public string InsertRequest(string customerCode)
        {
            int ID_Activity = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Activity"]);
            return service.InsertRequest(customerCode, ID_Activity);
        }
        
        [WebMethod]
        public void InsertFieldData(RegisterInfo info, ScoreInfo score)
        {
            int ID_Activity = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Activity"]);
            int ID_YearIncorporate = Convert.ToInt32(ConfigurationManager.AppSettings["ID_YearIncorporate"]);
            int ID_YearExperience = Convert.ToInt32(ConfigurationManager.AppSettings["ID_YearExperience"]);
            int ID_OwnerAge = Convert.ToInt32(ConfigurationManager.AppSettings["ID_OwnerAge"]);
            int ID_AssetValue = Convert.ToInt32(ConfigurationManager.AppSettings["ID_AssetValue"]);
            int ID_DebtValue = Convert.ToInt32(ConfigurationManager.AppSettings["ID_DebtValue"]);
            int ID_Income = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Income"]);
            int ID_Expense = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Expense"]);
            int ID_InstallmentAmount = Convert.ToInt32(ConfigurationManager.AppSettings["ID_InstallmentAmount"]);
            int ID_LoanAmount = Convert.ToInt32(ConfigurationManager.AppSettings["ID_LoanAmount"]);
            int ID_YearInstallment = Convert.ToInt32(ConfigurationManager.AppSettings["ID_YearInstallment"]);
            int ID_EstablishmentType_1 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_EstablishmentType_1"]);
            int ID_EstablishmentType_2 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_EstablishmentType_2"]);
            int ID_MaritalStatus_1 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_MaritalStatus_1"]);
            int ID_MaritalStatus_2 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_MaritalStatus_2"]);
            int ID_MaritalStatus_3 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_MaritalStatus_3"]);
            int ID_MaritalStatus_4 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_MaritalStatus_4"]);
            int ID_DebtStatus_1 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_DebtStatus_1"]);
            int ID_DebtStatus_2 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_DebtStatus_2"]);
            int ID_DebtStatus_3 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_DebtStatus_3"]);
            int ID_DebtStatus_4 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_DebtStatus_4"]);
            int ID_DebtStatus_5 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_DebtStatus_5"]);
            int ID_IsGetProfit_yes = Convert.ToInt32(ConfigurationManager.AppSettings["ID_IsGetProfit_yes"]);
            int ID_IsGetProfit_no = Convert.ToInt32(ConfigurationManager.AppSettings["ID_IsGetProfit_no"]);
            int ID_ObjectiveTerm_1 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_ObjectiveTerm_1"]);
            int ID_ObjectiveTerm_2 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_ObjectiveTerm_2"]);
            int ID_Comment = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Comment"]);
            int ID_Health = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Health"]);
            int ID_Event = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Event"]);
            int ID_EventOther = Convert.ToInt32(ConfigurationManager.AppSettings["ID_EventOther"]);

            service.InsertFieldData(info.requestNo, ID_YearIncorporate, info.yearIncorporate.ToString());
            service.InsertFieldData(info.requestNo, ID_YearExperience, info.yearExperience.ToString());
            service.InsertFieldData(info.requestNo, ID_OwnerAge, info.ownerAge.ToString());
            service.InsertFieldData(info.requestNo, ID_AssetValue, info.assetValue.ToString());
            service.InsertFieldData(info.requestNo, ID_DebtValue, info.debtValue.ToString());
            service.InsertFieldData(info.requestNo, ID_Income, info.income.ToString());
            service.InsertFieldData(info.requestNo, ID_Expense, info.expense.ToString());
            service.InsertFieldData(info.requestNo, ID_InstallmentAmount, info.installmentAmount.ToString());
            service.InsertFieldData(info.requestNo, ID_LoanAmount, info.loanAmount.ToString());
            service.InsertFieldData(info.requestNo, ID_YearInstallment, info.yearInstallment.ToString());
            service.InsertFieldData(info.requestNo, ID_Comment, info.remark.ToString());
            service.InsertFieldData(info.requestNo, ID_Health, score.groupShortDesc);

            switch (info.officeType)
            {
                case EstablishmentType.OfficeOwner:
                    service.InsertFieldData(info.requestNo, ID_EstablishmentType_1, "true");
                    break;
                case EstablishmentType.OfficeRental:
                    service.InsertFieldData(info.requestNo, ID_EstablishmentType_2, "true");
                    break;
            }

            switch (info.maritalStatus)
            {
                case MaritalType.Single:
                    service.InsertFieldData(info.requestNo, ID_MaritalStatus_1, "true");
                    break;
                case MaritalType.Married:
                    service.InsertFieldData(info.requestNo, ID_MaritalStatus_2, "true");
                    break;
                case MaritalType.Divorce:
                    service.InsertFieldData(info.requestNo, ID_MaritalStatus_3, "true");
                    break;
                case MaritalType.Widow:
                    service.InsertFieldData(info.requestNo, ID_MaritalStatus_4, "true");
                    break;
            }

            switch (info.debtStatus)
            {
                case DebtStatusType.Normal:
                    service.InsertFieldData(info.requestNo, ID_DebtStatus_1, "true");
                    break;
                case DebtStatusType.OverdueLessThan90:
                    service.InsertFieldData(info.requestNo, ID_DebtStatus_2, "true");
                    break;
                case DebtStatusType.OverdueMoreThan90:
                    service.InsertFieldData(info.requestNo, ID_DebtStatus_3, "true");
                    break;
                case DebtStatusType.TDR:
                    service.InsertFieldData(info.requestNo, ID_DebtStatus_4, "true");
                    break;
                case DebtStatusType.LegalProcess:
                    service.InsertFieldData(info.requestNo, ID_DebtStatus_5, "true");
                    break;
            }

            switch (info.isGetProfit)
            {
                case IsGetProfit.Yes:
                    service.InsertFieldData(info.requestNo, ID_IsGetProfit_yes, "true");
                    break;
                case IsGetProfit.No:
                    service.InsertFieldData(info.requestNo, ID_IsGetProfit_no, "true");
                    break;
            }

            switch (info.objectiveTerm)
            {
                case ObjectiveTerm.Short:
                    service.InsertFieldData(info.requestNo, ID_ObjectiveTerm_1, "true");
                    break;
                case ObjectiveTerm.Long:
                    service.InsertFieldData(info.requestNo, ID_ObjectiveTerm_2, "true");
                    break;
            }

            switch (info.eventType)
            {
                case EventType.Event:
                    service.InsertFieldData(info.requestNo, ID_Event, "true");
                    break;
                case EventType.Other:
                    service.InsertFieldData(info.requestNo, ID_EventOther, "true");
                    break;
            }
        }
    }
}
