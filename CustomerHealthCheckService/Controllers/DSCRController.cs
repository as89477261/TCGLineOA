using System;
using System.Web.Http;
using BLL.Controller;

namespace CustomerHealthCheckService.Controllers
{
    public class DSCRController : BaseApi
    {
        // POST: api/DSCR
        [HttpPost]
        [Route("api/dscr/termloan")]
        public IHttpActionResult TermLoan([FromBody] RegisterInfo obj)
        {
            try
            {
                var buffer = DSCRCon.Instance.CalculateTermLoan(obj);
                return GenJsonResponse<RegisterInfo>(buffer);
            }
            catch (Exception ex)
            {
                //System.IO.File.WriteAllText(@"C:\log\WriteText", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/dscr/revolvingloan")]
        public IHttpActionResult RevolvingLoan([FromBody] RegisterInfo obj)
        {
            try
            {
                var buffer = DSCRCon.Instance.CalculateTermLoan(obj);
                return GenJsonResponse<RegisterInfo>(buffer);
            }
            catch (Exception ex)
            {
                //System.IO.File.WriteAllText(@"C:\log\WriteText", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/dscr/termandrevolvingloan")]
        public IHttpActionResult TermAndRevolvingLoan([FromBody] RegisterInfo obj)
        {
            try
            {
                var buffer = DSCRCon.Instance.CalculateTermLoan(obj);
                return GenJsonResponse<RegisterInfo>(buffer);
            }
            catch (Exception ex)
            {
                //System.IO.File.WriteAllText(@"C:\log\WriteText", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}