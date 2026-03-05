using CustomerHealthCheck.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CustomerHealthCheck.API
{
    public class CampaignConfigController : BaseApi
    {

        [HttpGet]
        [Route("campaignConfig/getCampaignConfigActive")]
        public async Task<IHttpActionResult> GetCampaignConfigActive()
        {
            try
            {
                ValidateHeader();

                var result = await CampaignConfig.GetCampaignConfigActive(); 
                if (result != null)
                    return Ok(result);
                return BadRequest("error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }
    }
}