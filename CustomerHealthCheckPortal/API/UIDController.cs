using BLL.Controller;
using DataModel.Models.Line;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerHealthCheck.API
{
    public class UIDController : BaseApi
    {
        [HttpGet]
        [Route("api/uid/{uid}")]
        public IHttpActionResult GetUIDProfile(string uid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(uid)) { return BadRequest("Error"); }

                //var result = CustomerProfileCon.Instance.GetCustomerProfileByUID(uid);
                var result = CustomerProfileCon.Instance.GetCustomerProfileHistoryByUID(uid);

                var query = result.RESULT_OBJ.AsQueryable();

                if (result.RESULT_OBJ.Count > 0)
                {
                    query = query.Where(o => o.IdCardType == 1).OrderByDescending(o => o.CreateDateTime_AD).Take(1);
                    
                    result.RESULT_OBJ = query.ToList();
                }

                if (result.RESULT_STATUS == "OK")
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Error");
                }

            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/uidlineprofile/{uid}")]
        public IHttpActionResult GetUIDLineProfile(string uid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(uid)) { return BadRequest("Error"); }

                var result = CustomerProfileCon.Instance.GetUIDLineProfile(uid);

                if (result.RESULT_STATUS == "OK")
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/uid/{uid}/customerprofile")]
        public IHttpActionResult GetUIDMapCustomerProfile(string uid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(uid)) { return BadRequest("Error"); }

                var result = UIDMapCustomerProfileCon.Instance.GetUIDMapCustomerProfile(uid);
                if (result.RESULT_STATUS == "OK")
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Error");
                }

            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        // POST: api/UID

        [Route("api/uid")]
        public IHttpActionResult Post([FromBody] LineRawTokenModel obj)
        {
            try
            {
               
                ValidateFixHeader();
                if (obj == null) { return BadRequest("Error"); }
                if (ModelState.IsValid)
                {
                    // step 1 check name
                    var uidModel = UIDCon.Instance.GetUIDByUID(obj.sub);
                    if (uidModel != null)
                    {
                        return BadRequest("Error");
                    }

                    

                    var result = UIDCon.Instance.InsertUIDAndDummyConsent(obj);
                    if (result.RESULT_STATUS == "OK")
                    {
                        return Ok("OK");
                    }
                    else
                    {
                        return BadRequest("Error");
                    }
                }
                else
                {
                    //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                    return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));
                }
            }
            catch (Exception ex)
            {

                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        // Get UID
        [Route("api/uid")]
        public IHttpActionResult GEtExistingUID([FromBody] LineRawTokenModel obj)
        {
            try
            {
                ValidateFixHeader();
                if (obj == null) { return BadRequest("Error"); }
                if (ModelState.IsValid)
                {
                    var result = UIDCon.Instance.InsertUIDAndDummyConsent(obj);
                    if (result.RESULT_STATUS == "OK")
                    {
                        return Ok("OK");
                    }
                    else
                    {
                        return BadRequest("Error");
                    }
                }
                else
                {
                    //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                    return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));
                }
            }
            catch (Exception ex)
            {

                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }




    }
}
