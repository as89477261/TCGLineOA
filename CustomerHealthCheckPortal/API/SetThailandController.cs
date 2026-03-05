using BLL.Controller.HealthCheck;
using CustomerHealthCheck.ServiceInterface;
using DataModel.Models.SetThailand;
using Newtonsoft.Json;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CustomerHealthCheck.API
{
    [EnableCors("*", "*", "*")]
    public class SetThailandController : BaseApi
    {
        [HttpPost]
        [Route("api/setthailand/authenticate")]
        public IHttpActionResult GetURLFromSetThailand(SetThailandAPIAuthUserProfileModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var bufferJson = JsonConvert.SerializeObject(obj);
                    var result = new Authentication().AuthTCGNodeSetThailandAPI();
                    if (result != null)

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
        [Route("api/setthailand/log")]
        public IHttpActionResult InsertLogSetThailand(SetThailandLogModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");

                    var bufferJson = JsonConvert.SerializeObject(obj);
                    var result = SetThailandCon.Instance.InsertSetThailandLog(obj);
                    if (result != null) 
                    { 
                        return Ok(result);
                    }
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