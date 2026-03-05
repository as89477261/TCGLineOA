using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BLL.Controller.NDID;
using CustomerHealthCheck.ServiceInterface;
using DataModel.Models.NDID;
using DataModel.Models.NDID.EForm;
using DataModel.Models.NDID.EFormv2;

namespace CustomerHealthCheck.Api
{
    public class NDIDController : BaseApi
    {
        [HttpPost]
        [Route("api/ndid/register/idp")]
        public IHttpActionResult SubmitUserChooseIDP(List<CustomerChooseIDPModel> obj)
        {
            try
            {
                if (obj != null && obj.Count > 0)
                {
                    ValidateHeader();
                    if (obj == null) return BadRequest("Error");
                    if (ModelState.IsValid)
                    {
                        var data = obj.FirstOrDefault();
                        var masterObj = GenerateMasterObject(data.TransactionID);
                        var masterResult = NDIDStepCon.Instance.UpdateNDIDMasterStatus(masterObj);

                        if (masterResult.RESULT_CODE == "200")
                        {
                            var result = NDIDStepCon.Instance.InsertCustomerChooseIDP(data);
                            if (result.RESULT_STATUS == "OK")
                                return Ok("OK");
                            return BadRequest("Error");
                        }

                        return BadRequest("Error");
                    }

                    return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));
                }

                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/ndid/notification/{transid}/{reqid}")]
        public IHttpActionResult NotificationTransID(string transid, string reqid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(transid)) return BadRequest("Error");

                var masterObj = GenerateMasterObject(transid);
                var masterResult = NDIDStepCon.Instance.UpdateNDIDMasterStatus(masterObj);

                if (masterResult.RESULT_CODE == "200")
                {
                    var a = new SignalHub();
                    a.send("", reqid, transid);
                    return Ok();
                }

                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/ndid/eform/{uid}")]
        public IHttpActionResult CreateLogEFormTransaction(string uid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(uid)) return BadRequest("Error");

                var masterObj = GenerateLogEFormObject(uid);
                var masterResult = NDIDEFormCon.Instance().InsertNDIDEFormLog(masterObj);

                if (masterResult.RESULT_CODE == "200")
                    return Ok(masterObj.TransactionID);
                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }


        [HttpPost]
        [Route("api/ndid/eform")]
        public IHttpActionResult InsertUIDMapTransaction([FromBody] EFormV2PostModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = NDID.PostEformV2Post(obj);
                    return GenJsonResponse<string>(result);
                }

                return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        //-/-/-////////////////   Connext
        [HttpGet]
        [Route("api/ndid/connext/notification/{refid}/{iserror}")]
        public IHttpActionResult NotificationConnextByTransID(string refid, string iserror)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(refid)) return BadRequest("Error");

                var masterObj = GenerateMasterObject(refid);
                var masterResult = NDIDStepCon.Instance.UpdateNDIDMasterStatus(masterObj);

                if (masterResult.RESULT_CODE == "200")
                {
                    var a = new SignalHub();
                    a.send("NDID_01", iserror, refid);
                    return Ok();
                }

                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }


        private NDIDEFormTransactionModel GenerateLogEFormObject(string uid)
        {
            var bufferCountNumber = NDIDEFormCon.Instance().GenerateEFormTransaction();
            if (bufferCountNumber.RESULT_STATUS == "OK")
            {
                var buffer = new NDIDEFormTransactionModel();
                buffer.UID = uid;
                buffer.TransactionID = bufferCountNumber.RESULT_OBJ;
                buffer.CurrentStatusCode = "001";
                buffer.CurrentStatusRemark = "Initial Log NDID";

                return buffer;
            }

            return new NDIDEFormTransactionModel();
        }

        private UIDMapNDIDStatusModel GenerateMasterObject(string transid)
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));

            var buffer = new UIDMapNDIDStatusModel();
            buffer.Step5Status = "001";
            buffer.Step5Remark = "ประชาชนเลือก IDP";
            buffer.CurrentStausCode = "005";
            buffer.CurrentStatusRemark = "NDID ส่งข้อมูลกลับมา บสย.";
            buffer.UpdatedBy = "SYSTEM";
            buffer.TransactionID = transid;

            return buffer;
        }
    }
}