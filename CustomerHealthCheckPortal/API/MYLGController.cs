using System.Web.Http;

namespace CustomerHealthCheck.Api
{
    public class MYLGController : BaseApi
    {
        [HttpGet]
        [Route("api/mylg/")]
        public IHttpActionResult InsertFormEventRegister(string lgid)
        {
            //var result = UIDMapEventRegisterCon.Instance.GetFormRegisterWithEventCodeAndUID(eventcode, uid);
            //if (result.RESULT_STATUS == "OK")
            //{
            //    return Ok(result.RESULT_OBJ);
            //}
            //else
            //{
            //    return BadRequest("Error");
            //}
            return BadRequest("Error");
        }
    }
}