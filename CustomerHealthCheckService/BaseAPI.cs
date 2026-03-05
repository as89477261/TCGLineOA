using System.Net;
using System.Web.Http;

public class BaseApi : ApiController
{
    protected IHttpActionResult GenJsonResponseFromTCGAPI<T>(object obj)
    {
        var baseObj = (BaseTCGAPIModel<T>)obj;
        switch (baseObj.code)
        {
            case 1:
                return Ok(baseObj.data);
            case 2:
                return BadRequest(baseObj.message);

            default:
                return StatusCode(HttpStatusCode.BadRequest);
        }
    }

    protected IHttpActionResult GenJsonResponse<T>(object obj)
    {
        var baseObj = (BaseModel<T>)obj;
        switch (baseObj.RESULT_CODE)
        {
            case "200":
                return Ok(baseObj.RESULT_OBJ);
            case "400":
                return Ok(baseObj.RESULT_OBJ);
            case "500":
                return BadRequest(baseObj.RESULT_MESSAGE);
            default:
                return StatusCode(HttpStatusCode.BadRequest);
        }
    }
}