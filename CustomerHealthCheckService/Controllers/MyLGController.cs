using System;
using System.Collections.Generic;
using System.Web.Http;
using CustomerHealthCheckService.ServiceInterface;
using DataModel.Models.LG;

namespace CustomerHealthCheckService.Controllers
{
    public class MyLGController : BaseApi
    {
        [HttpGet]
        [Route("api/mylg/{idcard}/idcard")]
        public IHttpActionResult GetMyLGByIDCard(string idcard)
        {
            try
            {
                var buffer = MyLG.GetMyLGByCardID(idcard);
                return GenJsonResponseFromTCGAPI<List<LGModel>>(buffer);
            }
            catch (Exception ex)
            {
                //System.IO.File.WriteAllText(@"C:\log\WriteText", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}