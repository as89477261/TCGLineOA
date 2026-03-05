using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.Controller;
using BLL.Controller.FACenter;
using BLL.Controller.HealthCheck;
using BLL.Controller.NDID;
using CustomerHealthCheck.ServiceInterface;
using DataModel.Models.CustomerHealthModel;
using DataModel.Models.SMEClinic;
using DataModels.FACenter;
using Newtonsoft.Json;

namespace CustomerHealthCheck.API
{
    public class NCBController : BaseApi
    {
        [HttpGet]
        [Route("api/ncb/history/{idcard}/score")]
        public IHttpActionResult GETNCBScoreHistroyByIDCard(string idcard)
        {
            try
            {
                if (idcard != null)
                {
                    ValidateHeader();
                    if (idcard == null) return BadRequest("Error");
                    if (ModelState.IsValid)
                    {

                        var result = NCBTransactionLogCon.Instance.GETNCBScoreHistroyByIDCard(idcard, true);
                        if (result.RESULT_STATUS == "OK")
                        {
                            return Ok(result);
                        }
                        else
                        {
                            return BadRequest("Error");
                        }
                    }
                    return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));
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
