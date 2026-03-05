using BLL.Controller;
using BLL.Controller.HealthCheck;
using CustomerHealthCheck.ServiceInterface;
using DataModel.Models.LG;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerHealthCheck.views.RequestInfo
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenConfig();
                GetRequestData();
                GetUserProfile();

                LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.NDIDConfirmRequest_Load);
            }
        }

        private void GetRequestData()
        {
            try
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                var idCard = CookieManager.GetEncryptCookie("lineoa", "rIDCard", GetAppsetting("APIPartialCode"));

                LocalLogManager.Logger("Get Request Parameter UID : " + uid);
                LocalLogManager.Logger("Get Request Parameter IDCARDD : " + idCard);

                var requestObj = new MyRequestModel();
                requestObj.idCard = idCard;
                requestObj.projectTypeCode = ConfigurationManager.AppSettings["ProductTypeNCBFocus"];
                requestObj.dateLimit = int.Parse(ConfigurationManager.AppSettings["LimitRequestSendDate"]);

                var bufferLstRequestItem = PreNDIDCon.Instance.GetUIDMapNDIDPreRequest(uid);

                var confProductNCBFocus = ConfigurationManager.AppSettings["ProductTypeNCBFocus"];
                var lstProductNCBFocus = confProductNCBFocus.Split(',');

                List<MyRequestModel> resultApi = new List<MyRequestModel>();
                foreach (var item in lstProductNCBFocus)
                {
                    //var dataResultBuffer = MyRequest.GetRequestByCardID(idCard, item, ConfigurationManager.AppSettings["LimitRequestSendDate"]);
                    requestObj.projectTypeCode = item;
                    LocalLogManager.Logger("Get Request Parameter : " + JsonConvert.SerializeObject(requestObj));

                    var dataResultBuffer = MyRequest.GetRequestByCardID(requestObj);
                    if (dataResultBuffer.data != null && dataResultBuffer.data.Count > 0)
                    {
                        resultApi.AddRange(dataResultBuffer.data);
                    }
                }

                if (resultApi != null && resultApi.Count > 0)
                {
                    LocalLogManager.Logger("Get Request Result Items : " + resultApi.Count);
                    var waitingItem = "";
                    var waitingCount = 0;
                    var finishItem = "";
                    var finishCount = 0;
                    var ncbTransID = "";

                    for (int i = 0; i < resultApi.Count; i++)
                    {
                        var stepName = "รอยืนยันคำขอ";
                        var stepNumber = "1";

                        if (bufferLstRequestItem.RESULT_STATUS == "OK" && bufferLstRequestItem.RESULT_OBJ != null)
                        {

                            var html = "";
                            var bufferRequestItem = bufferLstRequestItem.RESULT_OBJ.OrderByDescending(x => x.CreatedDate).FirstOrDefault(x => x.T01OnlineID == resultApi[i].onlineId);
                            if (bufferRequestItem != null)
                            {
                                stepName = bufferRequestItem.StepName;
                                stepNumber = bufferRequestItem.StepNumber;
                                ncbTransID = bufferRequestItem.NCBTransactionID;
                            }

                            html = " <a style=\"border:none;\" href=\"#\" data-bs-toggle=\"offcanvas\" data-bs-target=\"#menu-request\" class=\"list-group-item\"  >\r\n" +
                            "<img src=\"../../images/Icons/RequestInfo_Document.png\" width=\"53\" class=\"me-3 rounded-xs\" alt=\"img\" />\r\n" +
                            "<div>\r\n" +
                            "<div style=\"display:inline-block;\">" +
                            "<h5 style=\"float:left;margin-right:10px;\" class=\"font-15 mb-0\">เลขที่คำขอ : " + resultApi[i].onlineId +
                            "</h5> <span style=\"float:left;height:25px;margin:0px;padding-left:10px;padding-right:10px;\" class=\"rounded-xl " + GenerateStatusColor(stepNumber) + "\">" + stepName + "</span>" +
                            "</div>" +
                            //"<h5 class=\"font-15 mb-0\">เลขที่คำขอ : " + resultApi[i].onlineId + "</h5> \r\n" +

                            "<div class=\"mt-2\"></div>\r\n" +
                            "<span>โครงการ : " + resultApi[i].projectTypeName + "</span>\r\n" +
                            "<span>ธนาคารที่ส่งคำขอ : " + resultApi[i].bankName + "</span>\r\n" +
                            "<span>วงเงินคำขอสินเชื่อ : " + resultApi[i].requestAmount + " บาท</span>\r\n" +
                            "<span>วันที่เพิ่มคำขอ : " + resultApi[i].requestDate + "</span>\r\n" +
                            //"<span class=\"badge rounded-xl " + GenerateStatusColor(stepNumber) + "\" >" + stepName + "</span>  " +
                            "</div>\r\n" +
                            "</a>";


                            switch (stepNumber)
                            {
                                case "1":
                                    waitingItem += html;
                                    waitingCount++;
                                    break;
                                case "3":
                                    finishItem += html;
                                    finishCount++;
                                    break;
                                default:
                                    break;
                            }
                        }
                        hddLstOnlineID.Value += resultApi[i].onlineId + "/";
                    }

                    lblCountWaitingItem.Text = waitingCount.ToString();
                    lblCountFinishItem.Text = finishCount.ToString();
                    ltlRequestiWaitingItem.Text = waitingItem;
                    ltlRequestFinishedItem.Text = finishItem;

                    if (waitingCount > 0)
                    {
                        pnlNCBEConsentSlip.Visible = false;
                        pnlRequestWaitingItem.Visible = true;
                        pnlEmptyWaitingItem.Visible = false;
                    }
                    else
                    {
                        pnlNCBEConsentSlip.Visible = false;
                        pnlRequestWaitingItem.Visible = false;
                        pnlEmptyWaitingItem.Visible = true;
                    }

                    if (finishCount > 0)
                    {
                        pnlNCBEConsentSlip.Visible = true;
                        pnlRequestFinishedItem.Visible = true;
                        pnlEmptyFinishedItem.Visible = false;

                        GetENCBConsentSlip(ncbTransID);
                    }
                    else
                    {
                        pnlNCBEConsentSlip.Visible = false;
                        pnlRequestFinishedItem.Visible = false;
                        pnlEmptyFinishedItem.Visible = true;
                    }
                }
                else
                {
                    pnlRequestWaitingItem.Visible = false;
                    pnlRequestFinishedItem.Visible = false;
                    pnlEmptyWaitingItem.Visible = true;
                    pnlEmptyFinishedItem.Visible = true;
                }


            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Request info Error : " + ex.Message);
            }
        }
        private void GenConfig()
        {
            hddENCBConsentAPI.Value = GetAppsetting("ENCBConsentSlipLineOAAPI");
            hddENCBConsentToken.Value = GetAppsetting("ENCBConsentSlipToken");
        }
        private string GenerateStatusColor(string status)
        {
            switch (status)
            {

                case "1":
                    return "bg-yellow-dark";
                case "2":
                    return "bg-orange-dark";
                case "3":
                    return "bg-green-dark";
                default:
                    return "";
            }
        }
        private void GetUserProfile()
        {
            try
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (uid != null)
                {
                    var personal = EnrollmentPersonalCon.Instance.GetUIDMapEnrollmentPersonal(uid);
                    if (personal.RESULT_STATUS == "OK")
                    {
                        hddRegisterDummyID.Value = personal.RESULT_OBJ.registerDummyID;
                        hddIDCard.Value = personal.RESULT_OBJ.IdentityID;
                        hddFirstName.Value = personal.RESULT_OBJ.FirstName;
                        hddLastName.Value = personal.RESULT_OBJ.LastName;
                        hddDob.Value = personal.RESULT_OBJ.BirthDay.ToString("yyyyMMdd", new CultureInfo("en-US"));
                        hddBirthDate.Value = personal.RESULT_OBJ.BirthDay.ToString("MM/dd/yyyy", new CultureInfo("en-US"));
                        hddMobileNo.Value = personal.RESULT_OBJ.MobilePhone;
                        hddEmail.Value = personal.RESULT_OBJ.Email;
                        textboxEmailEConsentSlip.Text = personal.RESULT_OBJ.Email;
                    }
                }
            }
            catch (Exception)
            {


            }
        }
        private void GetENCBConsentSlip(string ncbTransID)
        {
            var result = ENCBConsentSlipCon.Instance.GetNCBConsentSlipInfo(ncbTransID);

            if (result.RESULT_STATUS == "OK" && result.RESULT_OBJ != null)
            {
                var path = result.RESULT_OBJ.filePath;
                hddTransID.Value = result.RESULT_OBJ.transId;
                ltlSlipCreateDate.Text = result.RESULT_OBJ.requestEconsentSlipDate.ToString("dd/MM/yyyy",new CultureInfo("th-TH"));

                //CookieManager.SetEncryptCookie("lineoa", "ENCBConsentSlipPath", path, GetAppsetting("APIPartialCode"));

            }
        }

        protected void btnDownloadSlip_1_Click(object sender, EventArgs e)
        {


            var bufferResult = ENCBConsentSlipCon.Instance.GetNCBConsentSlipInfo("7370467E-D940-4F6C-81CD-2F8A64319F62");
        }
    }
}