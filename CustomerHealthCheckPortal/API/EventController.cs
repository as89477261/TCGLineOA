using System;
using System.Web.Http;
using BLL.Controller.HealthCheck;
using DataModel.Models.CustomerHealthModel.EventsModel;

namespace CustomerHealthCheck.Api
{
    public class EventController : BaseApi
    {
        [HttpGet]
        [Route("api/event/{eventcode}/uid/{uid}")]
        public IHttpActionResult InsertFormEventRegister(string eventcode, string uid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(eventcode) || string.IsNullOrEmpty(uid)) return BadRequest("Error");

                var result = UIDMapEventRegisterCon.Instance.GetFormRegisterWithEventCodeAndUID(eventcode, uid);
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
        [Route("api/event/register")]
        public IHttpActionResult InsertFormEventRegister(FormEventRegisterInputModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = EventCon.Instance.InsertFormEventRegister(obj);
                    if (result.RESULT_STATUS == "OK")
                        return Ok("OK");
                    return BadRequest("Error");
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

        [HttpPost]
        [Route("api/event/register/dynamic")]
        public IHttpActionResult InsertFormEventRegisterDynamic(FormEventRegisterDynamicInputModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = EventCon.Instance.InsertFormEventRegisterDynamic(obj);
                    if (result.RESULT_STATUS == "OK")
                        return Ok("OK");
                    return BadRequest("Error");
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


        [HttpPost]
        [Route("api/event/register/dynamic/nosendmail")]
        public IHttpActionResult InsertFormEventRegisterDynamicNotSendEmail(FormEventRegisterDynamicInputModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = EventCon.Instance.InsertFormEventRegisterDynamicNotSendEmail(obj);
                    if (result.RESULT_STATUS == "OK")
                        return Ok("OK");
                    return BadRequest("Error");
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