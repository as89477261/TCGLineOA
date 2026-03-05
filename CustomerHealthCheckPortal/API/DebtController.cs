using System;
using System.Web.Http;
using BLL.Controller.FACenter;
using DataModel.Models.FACenter;

namespace CustomerHealthCheck.Api
{
    public class DebtController : BaseApi
    {
        [HttpGet]
        [Route("api/debt/event/{eventcode}/uid/{uid}")]
        public IHttpActionResult InsertFormEventRegister(string uid, string eventcode)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(eventcode)) return BadRequest("Error");

                var result = UIDMapFAEventCon.Instance.GetUIDMapFAEvent(uid, eventcode);
                if (result.RESULT_STATUS == "OK")
                    return Ok(result.RESULT_OBJ);
                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }


        [HttpPost]
        [Route("api/debt/event/register")]
        public IHttpActionResult InsertFormEventRegister(UIDMapFAEventModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = UIDMapFAEventCon.Instance.InsertUIDMapFAEvent(obj);
                    if (result.RESULT_STATUS == "OK")
                        return Ok("OK");
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

        [HttpGet]
        [Route("api/debt/transaction/uid/{uid}")]
        public IHttpActionResult GetUIDProfile(string uid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(uid)) { return BadRequest("Error"); }

                //var result = CustomerProfileCon.Instance.GetCustomerProfileByUID(uid);
                var result = UIDMapFATransactionCon.Instance.GetUIDMapTransAndFormByID(uid);

                if (result.RESULT_STATUS == "OK")
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Error");
                }

            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }
    }
}