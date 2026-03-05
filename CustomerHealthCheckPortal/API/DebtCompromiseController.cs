using BLL.Controller.FACenter;
using CustomerHealthCheck.ServiceInterface;
using DataModel.Models.FACenter;
using DataModels.FACenter;
using Newtonsoft.Json;
using System;
using System.Web.Http;

namespace CustomerHealthCheck.API
{
    public class DebtCompromiseController : BaseApi
    {
        [HttpPost]
        [Route("api/v1/FACenter/send-email-to-consult")]
        public IHttpActionResult SentEmailToConsult([FromBody] SendEmailToConsultModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var bufferJson = JsonConvert.SerializeObject(obj);
                    var result = FACenterAPI.SendEmailToConsult(bufferJson);
                    if (result.code == 1)

                        return Ok(result);

                    return BadRequest("Error"); 
                }
                return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/debt/event/checkIdentity")]

        public IHttpActionResult InsertUIDDebtEvent(UIDMapDeptModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = UIDMapDebtEventCon.Instance.InsertUIDMapDebtEvent(obj);
                    if (result.RESULT_STATUS == "OK")
                        return GenResponse(result);
                    return BadRequest("Error");
                }

                return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/registerinfo/fa/debtcompromise")]
        public IHttpActionResult SaveForm_RegisterDebtCompromise(FormRegisterFAInfo obj , string Id, string DummyID)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = FormRegisterFACon.Instance.InsertFormRegisterCompromise(obj , Id , DummyID);
                    if (result.RESULT_STATUS == "OK")
                        return Ok(result);
                    return BadRequest("Error");
                }

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