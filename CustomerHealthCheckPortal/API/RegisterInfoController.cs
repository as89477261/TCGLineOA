using System;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.Controller.FACenter;
using DataModel.Models.FACenter;
using DataModels.FACenter;

namespace CustomerHealthCheck.Api
{
    [EnableCors("*", "*", "*")]
    public class RegisterInfoController : BaseApi
    {
        [HttpPost]
        [Route("api/registerinfo/fa")]
        public IHttpActionResult SaveForm_Register(FormRegisterFAInfo obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = FormRegisterFACon.Instance.InsertFormRegister(obj);
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

        [HttpPost]
        [Route("api/registerinfo/fa/uid")]
        public IHttpActionResult InsertUIDMapTransaction(UIDMapTransactionModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = UIDMapFATransactionCon.Instance.InsertUIDMapTransaction(obj);
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
    }
}