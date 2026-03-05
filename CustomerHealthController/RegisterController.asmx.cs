using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Services;
using BLL.Controller;
using BLL.Controller.ID;
using CustomerHealthController.ServiceInterface;
using CustomerHealthModel;
using DataModel.Models;
using DataModel.Models.ID;
using DataModel.Models.SMEClinic;
using log4net;

namespace CustomerHealthController
{
    /// <summary>
    ///     Summary description for RegisterController
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RegisterController : WebService
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly RegisterDB service = new RegisterDB();

        [WebMethod]
        public RegisterInfo newRegisterInfo()
        {
            return new RegisterInfo();
        }

        #region SendMail

        [WebMethod]
        public Task<ResultAPIInfo> SendEmail(EmailInfo emailInfo)
        {
            var bufferToken = ApiAuthInterface.Instance.GetAuthToken();
            var Result = EmailInterface.Instance.SendMail(emailInfo, bufferToken);

            return Result;
        }

        #endregion


        #region SendMailPromKhum

        [WebMethod]
        public async Task<ResultAPIInfo> SendEmailPromKhum(EmailInfo emailInfo)
        {

            var bufferToken = ApiAuthInterface.Instance.GetAuthToken();
            var Result = await EmailInterface.Instance.SendMailPROMKHUM(emailInfo, bufferToken);

            LogUtility.writeLog("Register SendMailPROMKHUM  : " + Result.message, ref log4);


            /*WAY 3*/
            //var Result = new ResultAPIInfo();

            //var smtpClient = new SmtpClient("smtp.gmail.com")
            //{
            //    Port = 587, // Use 465 for SSL
            //    Credentials = new NetworkCredential("Nutbitosakun@gmail.com", "Nutbito1524"),
            //    EnableSsl = true,
            //};

            //var mailMessage = new MailMessage
            //{
            //    From = new MailAddress("test"),
            //    Subject = "subject",
            //    Body = "<h1>Hello</h1>",
            //    IsBodyHtml = true,
            //};

            //mailMessage.To.Add("nuttaphon@tcg.or.th");


            //smtpClient.Send(mailMessage);

            //Console.WriteLine("Email sent successfully!");

            return await Task.FromResult(Result);
        }

        #endregion

        #region Select

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
                LogUtility.writeLog("GetProvince Error : " + ex, ref log4);
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
                LogUtility.writeLog("GetIndustryType Error : " + ex, ref log4);
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
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }

        [WebMethod]
        public DataTable GetObjTerm()
        {
            var GroupID_Objective = Convert.ToInt32(ConfigurationManager.AppSettings["GroupID_Objective"]);
            DataTable dt = null;
            try
            {
                dt = service.GetFieldName(GroupID_Objective);
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetObjTerm Error : " + ex, ref log4);
            }

            return dt;
        }

        [WebMethod]
        public DataTable GetChannel()
        {
            var GroupID_Channel = Convert.ToInt32(ConfigurationManager.AppSettings["GroupID_Channel"]);
            DataTable dt = null;
            try
            {
                dt = service.GetFieldName(GroupID_Channel);
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetChannel Error : " + ex, ref log4);
            }

            return dt;
        }

        [WebMethod]
        public CustomerProfileHistoryModel GetUIDMapRegiterType(string uid, string type)
        {
            var result = new CustomerProfileHistoryModel();
            try
            {
                var obj = CustomerProfileCon.Instance.GetCustomerProfileHistoryByUID(uid, type);
                result = obj.RESULT_OBJ;
                return result;
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetChannel Error : " + ex, ref log4);
            }

            return null;
        }

        [WebMethod]
        public  BaseModel<EnrolmentPersonalModel> GetUIDMapEnrolment(string uid)
        {
            BaseModel<EnrolmentPersonalModel> result = new BaseModel<EnrolmentPersonalModel>();
            try
            {
                result = EnrolmentReportCon.Instance.GetEnrollmentPersonalByUID(uid);
                return result;
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetChannel Error : " + ex, ref log4);
            }

            return null;
        }


        #endregion

        #region Calculate

        [WebMethod]
        public ScoreInfo calculateScore(RegisterInfo info)
        {
            return new Calculate().calculateScore(info);
        }

        [WebMethod]
        public RegisterInfo calculateDSCR(RegisterInfo info)
        {
            var bufferResult = DscrInterface.Instance.CalculateDscr(info);
            return bufferResult;
        }

        [WebMethod]
        public RegisterInfo calculateTCGScoreAndRBP(RegisterInfo info)
        {
            var result = new RegisterInfo();
            if (info.personType == PersonType.Corporate)
                result = TcgScoreInterface.Instance.CalculateTcgScoreCorperate(info);
            else
                result = TcgScoreInterface.Instance.CalculateTcgScorePersonal(info);
            return result;
        }

        #endregion

        #region Insert

        [WebMethod]
        public int InsertRegisterInfo(RegisterInfo info, ScoreInfo score)
        {
            return service.InsertRegisterInfo(info, score);
        }

        [WebMethod]
        public string InsertCustomerProfile(RegisterInfo info)
        {
            return service.InsertCustomerProfile(info);
        }

        [WebMethod]
        public void InsertContactProfile(RegisterInfo info, string customerCode, string email = "")
        {
            service.InsertContactProfileWithEmail(info, customerCode, 1, email);
            service.InsertContactProfileWithEmail(info, customerCode, 2, email);
        }

        [WebMethod]
        public string InsertRequest(string customerCode)
        {
            var ID_Activity = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Activity"]);
            return service.InsertRequest(customerCode, ID_Activity);
        }


        [WebMethod]
        public string InsertRequestPGS10(string customerCode)
        {
            var ID_Activity = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Activity"]);
            return service.InsertRequestPGS10(customerCode, ID_Activity);
        }

        [WebMethod]
        public void InsertFieldData(RegisterInfo info, ScoreInfo score)
        {
            var ID_Activity = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Activity"]);
            var ID_YearIncorporate = Convert.ToInt32(ConfigurationManager.AppSettings["ID_YearIncorporate"]);
            var ID_YearExperience = Convert.ToInt32(ConfigurationManager.AppSettings["ID_YearExperience"]);
            var ID_OwnerAge = Convert.ToInt32(ConfigurationManager.AppSettings["ID_OwnerAge"]);
            var ID_AssetValue = Convert.ToInt32(ConfigurationManager.AppSettings["ID_AssetValue"]);
            var ID_DebtValue = Convert.ToInt32(ConfigurationManager.AppSettings["ID_DebtValue"]);
            var ID_Income = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Income"]);
            var ID_Expense = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Expense"]);
            var ID_InstallmentAmount = Convert.ToInt32(ConfigurationManager.AppSettings["ID_InstallmentAmount"]);
            var ID_LoanAmount = Convert.ToInt32(ConfigurationManager.AppSettings["ID_LoanAmount"]);
            var ID_YearInstallment = Convert.ToInt32(ConfigurationManager.AppSettings["ID_YearInstallment"]);
            var ID_EstablishmentType_1 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_EstablishmentType_1"]);
            var ID_EstablishmentType_2 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_EstablishmentType_2"]);
            var ID_EstablishmentType_3 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_EstablishmentType_3"]);
            var ID_MaritalStatus_1 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_MaritalStatus_1"]);
            var ID_MaritalStatus_2 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_MaritalStatus_2"]);
            var ID_MaritalStatus_3 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_MaritalStatus_3"]);
            var ID_MaritalStatus_4 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_MaritalStatus_4"]);
            var ID_DebtStatus_1 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_DebtStatus_1"]);
            var ID_DebtStatus_2 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_DebtStatus_2"]);
            var ID_DebtStatus_3 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_DebtStatus_3"]);
            var ID_DebtStatus_4 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_DebtStatus_4"]);
            var ID_DebtStatus_5 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_DebtStatus_5"]);
            var ID_DebtStatus_6 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_DebtStatus_6"]);
            var ID_IsGetProfit_yes = Convert.ToInt32(ConfigurationManager.AppSettings["ID_IsGetProfit_yes"]);
            var ID_IsGetProfit_no = Convert.ToInt32(ConfigurationManager.AppSettings["ID_IsGetProfit_no"]);
            //int ID_ObjectiveTerm_1 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_ObjectiveTerm_1"]);
            //int ID_ObjectiveTerm_2 = Convert.ToInt32(ConfigurationManager.AppSettings["ID_ObjectiveTerm_2"]);
            var ID_Comment = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Comment"]);
            var ID_Health = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Health"]);
            //int ID_Event = Convert.ToInt32(ConfigurationManager.AppSettings["ID_Event"]);
            //int ID_EventOther = Convert.ToInt32(ConfigurationManager.AppSettings["ID_EventOther"]);

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
            service.InsertFieldData(info.requestNo, ID_Comment, info.remark);
            service.InsertFieldData(info.requestNo, ID_Health, score.groupShortDesc);

            switch (info.officeType)
            {
                case EstablishmentType.OfficeOwner:
                    service.InsertFieldData(info.requestNo, ID_EstablishmentType_1, "true");
                    break;
                case EstablishmentType.OfficeRental:
                    service.InsertFieldData(info.requestNo, ID_EstablishmentType_2, "true");
                    break;
                case EstablishmentType.NoShow:
                    service.InsertFieldData(info.requestNo, ID_EstablishmentType_3, "true");
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
                case DebtStatusType.NoDebt:
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
                case DebtStatusType.InstallmentNormal:
                    service.InsertFieldData(info.requestNo, ID_DebtStatus_6, "true");
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

            service.InsertFieldData(info.requestNo, info.objectiveTerm, "true");

            service.InsertFieldData(info.requestNo, info.eventType, "true");

            //switch (info.eventType)
            //{
            //    case EventType.Event:
            //        service.InsertFieldData(info.requestNo, ID_Event, "true");
            //        break;
            //    case EventType.Other:
            //        service.InsertFieldData(info.requestNo, ID_EventOther, "true");
            //        break;
            //}
        }

        [WebMethod]
        public bool InsertUIDRegisterInfo(string uid, int registerInfoId, string infoType = "", string subInfoType = "")
        {
            return service.InsertUIDRegisterInfo(uid, registerInfoId, infoType, subInfoType);
        }

        #endregion

        #region Update

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
        public bool UpdateUID(string uid, string customerProfileCode)
        {
            return service.UpdateUID(uid, customerProfileCode);
        }

        #endregion
    }
}