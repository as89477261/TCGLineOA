using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.Controller;
using BLL.Controller.FACenter;
using BLL.Controller.HealthCheck;
using DataModel.Models.CustomerHealthModel;
using DataModel.Models.SMEClinic;
using DataModels.FACenter;

namespace CustomerHealthCheck.Api
{
    [EnableCors("*", "*", "*")]
    public class EnrollmentController : BaseApi
    {
        // POST: api/CustomerProfile    
        [HttpPost]
        [Route("api/enrollment/email/{registerid}")]
        public IHttpActionResult GetCustomerProfileByCID([FromBody] string email, string registerid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(registerid) || string.IsNullOrEmpty(email)) return BadRequest("Error");

                var result = EnrollmentPersonalCon.Instance.UpdateEnrollmentByRegisterID(registerid, email);
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


    }
}