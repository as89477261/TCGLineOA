using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.Controller;
using BLL.Controller.FACenter;
using DataModel.Models.CustomerHealthModel;
using DataModel.Models.SMEClinic;
using DataModels.FACenter;

namespace CustomerHealthCheck.Api
{
    [EnableCors("*", "*", "*")]
    public class CustomerProfileController : BaseApi
    {
        // POST: api/CustomerProfile    
        [HttpGet]
        [Route("api/customerprofile/{cid}")]
        public IHttpActionResult GetCustomerProfileByCID(string cid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(cid)) return BadRequest("Error");

                var result = CustomerProfileCon.Instance.GetCustomerProfileByCID(cid);
                if (result.RESULT_STATUS == "OK")
                    return Ok("OK");
                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/customerprofile/new")] // createProfile and create profile history
        public IHttpActionResult CreateCustomerProfile([FromBody] CustomerProfileHistoryModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = CustomerProfileCon.Instance.UpdateCustomerProfileHistory(obj);
                    if (result.RESULT_STATUS == "OK")
                        return Ok("OK");
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

        [HttpGet]
        [Route("api/customerprofile/mapping/{uid}")]
        public IHttpActionResult GetCustomerProfileMappingByUID(string uid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(uid)) return BadRequest("Error");

                var result = UIDMapCustomerProfileCon.Instance.GetUIDMapCustomerProfile(uid);
                if (result.RESULT_STATUS == "OK")
                    return Ok("OK");
                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/customerprofile/mapping/new")] // createProfile and create profile history
        public IHttpActionResult CreateCustomerProfileMapping([FromBody] CustomerProfileHistoryModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = CustomerProfileCon.Instance.UpdateCustomerProfileHistory(obj);
                    if (result.RESULT_STATUS == "OK")
                        return Ok("OK");
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
        [Route("api/customerprofile")]
        public IHttpActionResult UpdateCustomerProfileHistory([FromBody] CustomerProfileHistoryModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = CustomerProfileCon.Instance.UpdateCustomerProfileHistory(obj);
                    if (result.RESULT_STATUS == "OK")
                        return Ok("OK");
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
        [Route("api/customerprofile/fa")]
        public IHttpActionResult PostCustomerProfileFA(CustomerProfileFAInfo obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = CustomerProfileFACon.Instance.InsertCustomerProfileFA(obj);
                    if (result.RESULT_STATUS == "OK")
                        return Ok(result.RESULT_OBJ);
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

        [HttpGet]
        [Route("api/customerprofile/{cid}/approch/count")]
        public IHttpActionResult GetApprochMapCusProfile(string cid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(cid)) return BadRequest("Error");

                var result = CustomerProfileMapApprochCon.Instance.GetCountCustomerProfileMapApproch(cid);
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

        [HttpGet]
        [Route("api/customerprofile/{cid}/approchs")]
        public IHttpActionResult GetCustomerProfileMapApproch(string cid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(cid)) return BadRequest("Error");

                var result = CustomerProfileMapApprochCon.Instance.GetCustomerProfileMapApproch(cid);
                if (result.RESULT_STATUS == "OK" && result.RESULT_OBJ.Count > 0)
                    return GenJsonResponse<List<CustomerProfileMapApprochModel>>(result);
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