using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BLL.Controller;
using BLL.Controller.HealthCheck;
using DataModel.Models.CustomerHealthModel;

namespace CustomerHealthCheck.Api
{
    public class ApprochController : BaseApi
    {
        [HttpGet]
        [Route("api/approch/{pcode}/{uid}")]
        public IHttpActionResult Post(string pcode, string uid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(pcode) || string.IsNullOrEmpty(uid)) return BadRequest("Error");

                var result = ApprochCon.Instance.GetUIDMapApproch(uid, pcode);
                if (result.RESULT_STATUS == "OK")
                    return Ok("OK");
                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/approch/{approchID}")]
        public IHttpActionResult PostApprochWithSendMail(string approchID, [FromBody] List<ApprochMapBankModel> obj)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(approchID)) return BadRequest("Error");

                if (ModelState.IsValid)
                {
                    var bufferApproch = ApprochCon.Instance.GetUIDMapApprochWithApprochID(approchID);
                    if (bufferApproch.RESULT_CODE == "200" && bufferApproch.RESULT_OBJ.Count > 0)
                    {
                        var bufferApprochTemplate = bufferApproch.RESULT_OBJ.FirstOrDefault();
                        // Append Email with bank list
                        bufferApprochTemplate.ApprochBody +=
                            EmailTemplate.Instance.AppendBankChoosedList(bufferApprochTemplate.ApprochBody, obj);
                        // Send Internal Email
                        EmailTemplate.Instance.BindingInternalEmail(bufferApprochTemplate.ApprochBody);
                        // Send External Email
                        var lstEmailObj = EmailTemplate.Instance.BindingEmail(bufferApprochTemplate.ApprochBody, obj);
                        if (lstEmailObj != null && lstEmailObj.Count > 0)
                        {
                            var result = ApprochCon.Instance.InsertApprochMapBank(lstEmailObj);
                            if (result.RESULT_STATUS == "OK")
                                return Ok("OK");
                            return BadRequest("Error");
                        }

                        return BadRequest("Not Found ApprochBody");
                    }

                    return BadRequest("Not Found UID");
                }

                //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }
    }
}