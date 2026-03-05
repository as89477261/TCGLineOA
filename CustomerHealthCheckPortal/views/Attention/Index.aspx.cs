using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using BLL.Controller;
using CustomerHealthCheck.UserControl.Attention;

namespace CustomerHealthCheck.views.Attention
{
    public partial class Index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckRegistered();
                LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.Events_PGS10_Load);
            }
        }

        //private void CheckRegistered()
        //{
        //    var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
        //    var infoType = Request.QueryString["infoType"];
        //    var subInfoType = Request.QueryString["subInfoType"];

        //    if (!string.IsNullOrEmpty(uid))
        //    {
        //        if (subInfoType == "PGS11")
        //        {
        //            var lstRegisterInfo = RegisterInfoCon.Instance.GetRegisInfoByUIDWithType(uid, infoType, subInfoType);
        //            if (lstRegisterInfo.RESULT_STATUS == "OK" && lstRegisterInfo.RESULT_OBJ.Count > 0)
        //            {
        //                var bufferResult = lstRegisterInfo.RESULT_OBJ.OrderByDescending(x => x.CreateDate).ToList();
        //                for (var i = 0; i < bufferResult.Count; i++)
        //                {
        //                    var item = bufferResult[i];
        //                    var control =
        //                        (UC_AttentionRequest)Page.LoadControl("~/UserControl/Attention/UC_AttentionRequest.ascx");
        //                    control.FullName = item.PersonType == 1 ? item.BusinessName : item.Name + " " + item.Surname;
        //                    control.BusinessType = item.PersonType == 1 ? "นิติบุคคล" : "บุคคลธรรมดา";
        //                    control.RegisterDate = item.CreateDate.ToString("dd/MM/yyyy", new CultureInfo("th-TH"));
        //                    control.IsExpand = i == 0 ? "true" : "false";
        //                    control.CountTime = i + 1;
        //                    control.CreateDate = item.CreateDate.ToString("dd/MM/yyyy HH:mm", new CultureInfo("th-TH"));
        //                    control.ContactBranch = "สอบถามข้อมูลเพิ่มเติมติดต่อ <br />" + item.BranchName +
        //                                            "<br /> เบอร์โทร " + item.BranchPhone + "<br /> Email " +
        //                                            item.BranchEmail;
        //                    if (item.ClinicRequestNo != null && item.ClinicRequestNo != "-")
        //                    {
        //                        var lstStep = RegisterInfoCon.Instance
        //                            .GetRegisInfoStatusByUIDWithType(uid, "", item.ClinicRequestNo, infoType, subInfoType)
        //                            .RESULT_OBJ;
        //                        control.ListRegisterInfoStep = lstStep;

        //                        var bufferIsFinish = lstStep.FirstOrDefault(x => x.StatusEndLevel);
        //                        if (bufferIsFinish == null)
        //                        {
        //                            pnlNewPGS10.Visible = false;
        //                            pnlNewPROMKHUM.Visible = false;
        //                        };
        //                        pnlNewPROMKHUM.Visible = false;
        //                        pnlNewPGS10.Visible = true;
        //                        pnlAttentionItem.Controls.Add(control);
        //                    }
        //                    //var healthCheck = ConfigurationManager.AppSettings["PGS10HealthCheckURL"];
        //                    //Response.Redirect(healthCheck + "?uid=" + uid);
        //                }
        //                var lastRegister = RegisterInfoCon.Instance.GetRegisInfoStatusByUIDWithType(uid, "", "", infoType, subInfoType).RESULT_OBJ.Where(o => o.IdCard != null).OrderByDescending(o => o.CreateDate).ThenByDescending(o => o.StatusLevelID).ToList().Take(1);
        //                var endShowNewRegister = lastRegister.SingleOrDefault();
        //                if (endShowNewRegister == null)
        //                {
        //                    pnlNewPROMKHUM.Visible = false;
        //                    pnlNewPGS10.Visible = false;
        //                    pnlSMEsPickUp.Visible = false;
        //                }
        //                if (endShowNewRegister.StatusEndLevel == true)
        //                {
        //                    pnlNewPROMKHUM.Visible = false;
        //                    pnlNewPGS10.Visible = true;
        //                    pnlSMEsPickUp.Visible = false;
        //                }
        //                if (endShowNewRegister.StatusEndLevel == false)
        //                {
        //                    pnlNewPROMKHUM.Visible = false;
        //                    pnlNewPGS10.Visible = false;
        //                    pnlSMEsPickUp.Visible = false;
        //                }
        //            }
        //            else
        //            {
        //                var healthCheck = ConfigurationManager.AppSettings["PGS10HealthCheckURL"];
        //                Response.Redirect(healthCheck + "?uid=" + uid);
        //            }
        //        }
        //        else if(subInfoType == "SMEsPickUp")
        //        {
        //            var lstRegisterInfo = RegisterInfoCon.Instance.GetRegisInfoByUIDWithType(uid, infoType, subInfoType);
        //            if (lstRegisterInfo.RESULT_STATUS == "OK" && lstRegisterInfo.RESULT_OBJ.Count > 0)
        //            {
        //                var bufferResult = lstRegisterInfo.RESULT_OBJ.OrderByDescending(x => x.CreateDate).ToList();
        //                for (var i = 0; i < bufferResult.Count; i++)
        //                {
        //                    var item = bufferResult[i];
        //                    var control =
        //                        (UC_AttentionRequest)Page.LoadControl("~/UserControl/Attention/UC_AttentionRequest.ascx");
        //                    control.FullName = item.PersonType == 1 ? item.BusinessName : item.Name + " " + item.Surname;
        //                    control.BusinessType = item.PersonType == 1 ? "นิติบุคคล" : "บุคคลธรรมดา";
        //                    control.RegisterDate = item.CreateDate.ToString("dd/MM/yyyy", new CultureInfo("th-TH"));
        //                    control.IsExpand = i == 0 ? "true" : "false";
        //                    control.CountTime = i + 1;
        //                    control.CreateDate = item.CreateDate.ToString("dd/MM/yyyy HH:mm", new CultureInfo("th-TH"));
        //                    control.ContactBranch = "สอบถามข้อมูลเพิ่มเติมติดต่อ <br />" + item.BranchName +
        //                                            "<br /> เบอร์โทร " + item.BranchPhone + "<br /> Email " +
        //                                            item.BranchEmail;
        //                    control.SubInfoType = subInfoType;
        //                    if (item.ClinicRequestNo != null && item.ClinicRequestNo != "-")
        //                    {
        //                        var lstStep = RegisterInfoCon.Instance
        //                            .GetRegisInfoStatusByUIDWithType(uid, "", item.ClinicRequestNo, infoType, subInfoType)
        //                            .RESULT_OBJ;
        //                        control.ListRegisterInfoStep = lstStep;

        //                        var bufferIsFinish = lstStep.FirstOrDefault(x => x.StatusEndLevel);
        //                        if (bufferIsFinish == null)
        //                        {
        //                            pnlNewPGS10.Visible = false;
        //                            pnlNewPROMKHUM.Visible = false;
        //                            pnlSMEsPickUp.Visible = false;
        //                        };
        //                        pnlNewPROMKHUM.Visible = false;
        //                        pnlNewPGS10.Visible = false;
        //                        pnlSMEsPickUp.Visible = true;
        //                        pnlAttentionItem.Controls.Add(control);
        //                    }
        //                    //var healthCheck = ConfigurationManager.AppSettings["PGS10HealthCheckURL"];
        //                    //Response.Redirect(healthCheck + "?uid=" + uid);
        //                }
        //                var lastRegister = RegisterInfoCon.Instance.GetRegisInfoStatusByUIDWithType(uid, "", "", infoType, subInfoType).RESULT_OBJ.Where(o => o.IdCard != null).OrderByDescending(o => o.CreateDate).ThenByDescending(o => o.StatusLevelID).ToList().Take(1);
        //                var endShowNewRegister = lastRegister.SingleOrDefault();
        //                if (endShowNewRegister == null)
        //                {
        //                    pnlNewPROMKHUM.Visible = false;
        //                    pnlNewPGS10.Visible = false;
        //                    pnlSMEsPickUp.Visible = false;
        //                }
        //                if (endShowNewRegister.StatusEndLevel == true)
        //                {
        //                    pnlNewPROMKHUM.Visible = false;
        //                    pnlNewPGS10.Visible = false;
        //                    pnlSMEsPickUp.Visible = true;
        //                }
        //                if (endShowNewRegister.StatusEndLevel == false)
        //                {
        //                    pnlNewPROMKHUM.Visible = false;
        //                    pnlNewPGS10.Visible = false;
        //                    pnlSMEsPickUp.Visible = false;
        //                }
        //            }
        //            else
        //            {
        //                var healthCheck = ConfigurationManager.AppSettings["SMEsPickUpHealthCheckUrl"];
        //                Response.Redirect(healthCheck + "?uid=" + uid);
        //            }
        //        }

        //        else
        //        {
        //            var lstRegisterInfo = RegisterInfoCon.Instance.GetRegisInfoByUIDWithType(uid, infoType, subInfoType);
        //            if (lstRegisterInfo.RESULT_STATUS == "OK" && lstRegisterInfo.RESULT_OBJ.Count > 0)
        //            {
        //                var bufferResult = lstRegisterInfo.RESULT_OBJ.OrderByDescending(x => x.CreateDate).ToList();
        //                for (var i = 0; i < bufferResult.Count; i++)
        //                {
        //                    var item = bufferResult[i];
        //                    var control =
        //                        (UC_AttentionRequest)Page.LoadControl("~/UserControl/Attention/UC_AttentionRequest.ascx");
        //                    control.FullName = item.PersonType == 1 ? item.BusinessName : item.Name + " " + item.Surname;
        //                    control.BusinessType = item.PersonType == 1 ? "นิติบุคคล" : "บุคคลธรรมดา";
        //                    control.RegisterDate = item.CreateDate.ToString("dd/MM/yyyy", new CultureInfo("th-TH"));
        //                    control.IsExpand = i == 0 ? "true" : "false";
        //                    control.CountTime = i + 1;
        //                    control.CreateDate = item.CreateDate.ToString("dd/MM/yyyy HH:mm", new CultureInfo("th-TH"));
        //                    control.ContactBranch = "สอบถามข้อมูลเพิ่มเติมติดต่อ <br />" + item.BranchName +
        //                                            "<br /> เบอร์โทร " + item.BranchPhone + "<br /> Email " +
        //                                            item.BranchEmail;
        //                    control.SubInfoType = subInfoType;
        //                    if (item.ClinicRequestNo != null && item.ClinicRequestNo != "-")
        //                    {
        //                        var lstStep = RegisterInfoCon.Instance
        //                            .GetRegisInfoStatusByUIDWithType(uid, "", item.ClinicRequestNo, infoType, subInfoType)
        //                            .RESULT_OBJ;
        //                        control.ListRegisterInfoStep = lstStep;

        //                        var bufferIsFinish = lstStep.FirstOrDefault(x => x.StatusEndLevel);
        //                        if (bufferIsFinish != null)
        //                        {
        //                            pnlNewPROMKHUM.Visible = true;
        //                            pnlNewPGS10.Visible = false;
        //                            pnlSMEsPickUp.Visible = false;
        //                        }
        //                        pnlNewPGS10.Visible = false;
        //                        pnlSMEsPickUp.Visible = false;
        //                        pnlAttentionItem.Controls.Add(control);
        //                    }
        //                    //var healthCheck = ConfigurationManager.AppSettings["PromKhumHealthCheckURL"];
        //                    //Response.Redirect(healthCheck + "?uid=" + uid); 
        //                }
        //                var lastRegister = RegisterInfoCon.Instance.GetRegisInfoStatusByUIDWithType(uid, "","", infoType, subInfoType).RESULT_OBJ.Where(o => o.IdCard != null).OrderByDescending(o => o.CreateDate).ThenByDescending(o => o.StatusLevelID).ToList().Take(1);
        //                var endShowNewRegister = lastRegister.SingleOrDefault();
        //                if (endShowNewRegister == null)
        //                {
        //                    pnlNewPROMKHUM.Visible = false;
        //                    pnlNewPGS10.Visible = false;
        //                    pnlSMEsPickUp.Visible = false;
        //                }
        //                if (endShowNewRegister.StatusEndLevel == true)
        //                {
        //                    pnlNewPROMKHUM.Visible = true;
        //                    pnlNewPGS10.Visible = false;
        //                    pnlSMEsPickUp.Visible = false;
        //                }
        //                if (endShowNewRegister.StatusEndLevel == false)
        //                {
        //                    pnlNewPROMKHUM.Visible = false;
        //                    pnlNewPGS10.Visible = false;
        //                    pnlSMEsPickUp.Visible = false;
        //                }

        //            }
        //            else
        //            {
        //                var healthCheck = ConfigurationManager.AppSettings["PromKhumHealthCheckURL"];
        //                Response.Redirect(healthCheck + "?uid=" + uid);
        //            }
        //        }
        //    }
        //}


        private void CheckRegistered()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var infoType = Request.QueryString["infoType"];
            var subInfoType = Request.QueryString["subInfoType"];

            if (string.IsNullOrEmpty(uid))
                return;

            var lstRegisterInfo = RegisterInfoCon.Instance.GetRegisInfoByUIDWithType(uid, infoType, subInfoType);

            if (lstRegisterInfo.RESULT_STATUS == "OK" && lstRegisterInfo.RESULT_OBJ.Count > 0)
            {
                var bufferResult = lstRegisterInfo.RESULT_OBJ.OrderByDescending(x => x.CreateDate).ToList();
                for (var i = 0; i < bufferResult.Count; i++)
                {
                    var item = bufferResult[i];
                    var control = CreateAttentionRequestControl(item, subInfoType, i);

                    if (item.ClinicRequestNo != null && item.ClinicRequestNo != "-")
                    {
                        var lstStep = RegisterInfoCon.Instance
                            .GetRegisInfoStatusByUIDWithType(uid, "", item.ClinicRequestNo, infoType, subInfoType)
                            .RESULT_OBJ;
                        control.ListRegisterInfoStep = lstStep;

                        SetPanelVisibilityByStep(subInfoType, lstStep);
                        pnlAttentionItem.Controls.Add(control);
                    }
                }

                var lastRegister = RegisterInfoCon.Instance
                    .GetRegisInfoStatusByUIDWithType(uid, "", "", infoType, subInfoType)
                    .RESULT_OBJ
                    .Where(o => o.IdCard != null)
                    .OrderByDescending(o => o.CreateDate)
                    .ThenByDescending(o => o.StatusLevelID)
                    .Take(1)
                    .SingleOrDefault();

                SetPanelVisibilityByLastRegister(subInfoType, lastRegister);
            }
            else
            {
                RedirectToHealthCheck(subInfoType, uid);
            }
        }

        private UC_AttentionRequest CreateAttentionRequestControl(dynamic item, string subInfoType, int index)
        {
            var control = (UC_AttentionRequest)Page.LoadControl("~/UserControl/Attention/UC_AttentionRequest.ascx");
            control.FullName = item.PersonType == 1 ? item.BusinessName : item.Name + " " + item.Surname;
            control.BusinessType = item.PersonType == 1 ? "นิติบุคคล" : "บุคคลธรรมดา";
            control.RegisterDate = item.CreateDate.ToString("dd/MM/yyyy", new CultureInfo("th-TH"));
            control.IsExpand = index == 0 ? "true" : "false";
            control.CountTime = index + 1;
            control.CreateDate = item.CreateDate.ToString("dd/MM/yyyy HH:mm", new CultureInfo("th-TH"));
            control.ContactBranch = "สอบถามข้อมูลเพิ่มเติมติดต่อ <br />" + item.BranchName +
                                    "<br /> เบอร์โทร " + item.BranchPhone + "<br /> Email " +
                                    item.BranchEmail;
            control.SubInfoType = subInfoType;
            return control;
        }

        private void SetPanelVisibilityByStep(string subInfoType, dynamic lstStep)
        {
            var bufferIsFinish = ((IEnumerable<dynamic>)lstStep).FirstOrDefault((Func<dynamic, bool>)(x => x.StatusEndLevel));

            switch (subInfoType)
            {
                case "PGS11":
                    pnlNewPGS10.Visible = bufferIsFinish == null ? false : true;
                    pnlNewPROMKHUM.Visible = false;
                    break;
                case "SMEsPickUp":
                    pnlNewPGS10.Visible = false;
                    pnlNewPROMKHUM.Visible = false;
                    pnlSMEsPickUp.Visible = bufferIsFinish == null ? false : true;
                    break;
                case "SMEsStimulateCampaign":
                    pnlNewPGS10.Visible = false;
                    pnlNewPROMKHUM.Visible = false;
                    pnlSMEsPickUp.Visible = false;
                    pnlSMEsStimulateCampaign.Visible = bufferIsFinish == null ? false : true;
                    break;
                default:
                    pnlNewPROMKHUM.Visible = bufferIsFinish != null;
                    pnlNewPGS10.Visible = false;
                    pnlSMEsPickUp.Visible = false;
                    break;
            }
        }

        private void SetPanelVisibilityByLastRegister(string subInfoType, dynamic endShowNewRegister)
        {
            bool? isEnd = endShowNewRegister?.StatusEndLevel;

            pnlNewPROMKHUM.Visible = false;
            pnlNewPGS10.Visible = false;
            pnlSMEsPickUp.Visible = false;

            if (isEnd == null)
                return;

            switch (subInfoType)
            {
                case "PGS11":
                    pnlNewPGS10.Visible = isEnd == true;
                    break;
                case "SMEsPickUp":
                    pnlSMEsPickUp.Visible = isEnd == true;
                    break;
                case "SMEsStimulateCampaign":
                    pnlSMEsStimulateCampaign.Visible = isEnd == true;
                    break;
                default:
                    pnlNewPROMKHUM.Visible = isEnd == true;
                    break;
            }
        }

        private void RedirectToHealthCheck(string subInfoType, string uid)
        {
            string healthCheckUrl;
            if (subInfoType == "PGS11")
            {
                healthCheckUrl = ConfigurationManager.AppSettings["PGS10HealthCheckURL"];
            }
            else if (subInfoType == "SMEsPickUp")
            {
                healthCheckUrl = ConfigurationManager.AppSettings["SMEsPickUpHealthCheckUrl"];
            }
            else if (subInfoType == "SMEsStimulateCampaign")
            {
                healthCheckUrl = ConfigurationManager.AppSettings["SMEsStimulateCampaignHealthCheckUrl"];
            }
            else
            {
                healthCheckUrl = ConfigurationManager.AppSettings["PromKhumHealthCheckURL"];
            }

            Response.Redirect(healthCheckUrl + "?uid=" + uid);
        }

        protected void btnNewPGS10_Click(object sender, EventArgs e)
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var healthCheck = ConfigurationManager.AppSettings["PGS10HealthCheckURL"];
            Response.Redirect(healthCheck + "?uid=" + uid);
        }

        protected void btnNewPROMKHUM_Click(object sender, EventArgs e)
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var healthCheck = ConfigurationManager.AppSettings["PromKhumHealthCheckURL"];
            Response.Redirect(healthCheck + "?uid=" + uid);
        }


        protected void btnNewSMEsPickUp_Click(object sender, EventArgs e)
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var healthCheck = ConfigurationManager.AppSettings["SMEsPickUpHealthCheckUrl"];
            Response.Redirect(healthCheck + "?uid=" + uid);
        }

        protected void btnNewSMEsStimulateCampaign_Click(object sender, EventArgs e)
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var healthCheck = ConfigurationManager.AppSettings["SMEsStimulateCampaignHealthCheckUrl"];
            Response.Redirect(healthCheck + "?uid=" + uid);
        }

    }
}