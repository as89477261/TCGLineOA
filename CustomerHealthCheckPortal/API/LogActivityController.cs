using System;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.Controller;
using BLL.Controller.FACenter;
using DataModel.Models.FACenter;
using DataModel.Models.LOG;
using DataModels.FACenter;

namespace CustomerHealthCheck.Api
{
    //[EnableCors("*", "*", "*")]
    public class LogActivityController : BaseApi
    {
        [HttpPost]
        [Route("api/logactivity")]
        public IHttpActionResult KeepLogActivity(LogActivity obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(obj);
                    return Ok("OK");
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