using System;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.Controller.HealthCheck;
using BLL.Controller.NDID;
using CustomerHealthCheck.ServiceInterface;
using DataModel.Models.SignUp;
using Newtonsoft.Json;
using TCG_CORE_MODEL.Model.NDIDConnext;

namespace CustomerHealthCheck.Api
{
    public class SignUpController : BaseApi
    {
        [HttpPost]
        [Route("api/enrollment/personal")]
        public IHttpActionResult EnrolmentPersonalData([FromBody] EnrolmentModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    obj.DummyID = Guid.NewGuid().ToString();
                    var bufferJson = JsonConvert.SerializeObject(obj);
                    var result = Enrolment.InsertRegisterPersonal(bufferJson);
                    if (result.RESULT_STATUS == "OK")
                        return GenResponse(result);
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
        [Route("api/verify/personal/{dummyid}/obj")]
        public IHttpActionResult VerifyPersonalData(string dummyid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(dummyid)) return BadRequest("Error");

                var result = Enrolment.VerifyRegisterPersonalReturnObj(dummyid);
                LocalLogManager.Logger("Check 01 : " + JsonConvert.SerializeObject(result));


                if (result != null && result.RESULT_STATUS == "OK")
                {
                    LocalLogManager.Logger("Check 02 : " + JsonConvert.SerializeObject(result));
                    LocalLogManager.Logger("Check 02 Detail : " + JsonConvert.SerializeObject(result.RESULT_OBJ));
                    var buffer = JsonConvert.SerializeObject(result).Replace("\r", "").Replace("\n", "");

                    return GenResponse(result);

                }

                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/verify/dopa/{dummyid}/obj")]
        public IHttpActionResult VerifyDopaData(string dummyid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(dummyid)) return BadRequest("Error");

                var result = Enrolment.VerifyRegisterPersonalReturnObj(dummyid);
                if (result != null && result.RESULT_STATUS == "OK")
                    return GenResponse(result);
                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }


        [HttpPost]
        [Route("api/verify/dopa/directly")]
        public IHttpActionResult VerifyDopaDataDirectly([FromBody] RequestDopaModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = Enrolment.VerifyDopaRegisterPersonalReturnObjDirectly(obj);
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
        [Route("api/verify/dopa/directly/{dummyid}/{uid}/{result}/callback")]
        public IHttpActionResult VerifyDopaDataDirectlyCallback(string dummyid, string uid, string result)
        {
            try
            {
                if (!string.IsNullOrEmpty(dummyid) && !string.IsNullOrEmpty(uid))
                {
                    var a = new SignalHub();
                    a.send("SIGNUP_01", result.ToLower(), uid);
                    return Ok();
                }

                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }


        [HttpPost]
        [Route("api/verify/otp1/{dummyid}/{phonenumber}")]
        public IHttpActionResult VerifySendOTPData(string dummyid, string phonenumber)
        {
            try
            {
                //ValidateHeader();
                if (string.IsNullOrEmpty(dummyid) || string.IsNullOrEmpty(phonenumber)) return BadRequest("Error");

                var result = Enrolment.VerifyOTPReturnStatus(dummyid, phonenumber);
                LocalLogManager.Logger("Enrolment.VerifyOTPReturnStatus : " + result.RESULT_OBJ);
                if (result == null)
                {
                    LocalLogManager.Logger("result == null: " + result);
                    return BadRequest("API False");
                }
                if (result.RESULT_STATUS == "OK" && result.RESULT_OBJ != null)
                {
                    LocalLogManager.Logger("result.RESULT_STATUS == \"OK\": " + result.RESULT_OBJ);
                    return Ok("ok 123");

                }
                return NotFound();
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/verify/otp/{dummyid}/{phonenumber}")]
        public async Task<IHttpActionResult> VerifySendOTPDataAsync(string dummyid, string phonenumber)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(dummyid) || string.IsNullOrEmpty(phonenumber)) return (BadRequest("Error"));

                var result = await Enrolment.VerifyOTPReturnStatusAsync(dummyid, phonenumber);
                LocalLogManager.Logger("Enrolment.VerifyOTPReturnStatus : " + result.RESULT_OBJ);
                if (result == null)
                {
                    LocalLogManager.Logger("result == null: " + result);
                    return BadRequest("API False");
                }
                if (result.RESULT_STATUS == "OK" && result.RESULT_OBJ != null)
                {
                    LocalLogManager.Logger("result.RESULT_STATUS == \"OK\": " + result);
                    return Ok(result);

                }
                return NotFound();
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/verify/otp/{dummyid}/ref/{refnumber}/{otp}")]
        public IHttpActionResult VerifyReceiveOTPData(string dummyid, string refnumber, string otp)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(dummyid) || string.IsNullOrEmpty(refnumber) || string.IsNullOrEmpty(otp))
                { return BadRequest("Error"); }

                //var bufferJson = JsonConvert.SerializeObject(null);

                var result = Enrolment.VerifyOTPVerifyStatus(dummyid, refnumber, otp);
                if (result == null) return NotFound();

                if (result.RESULT_STATUS == "OK" && result.RESULT_OBJ != null && result != null)
                { 
                    return GenResponse(result);
                }
                else { return NotFound(); }
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/mapping/uid/{uid}/dummyid/{dummyid}")]
        public Task<IHttpActionResult> InsertUIDMapEnrollment(string uid, string dummyid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(dummyid)) throw new Exception("Error");

                var result = UIDMapEnrollmentCon.Instance().InsertUIDMapEnrollment(uid, dummyid);
                if (result.RESULT_STATUS == "OK")
                    return Task.FromResult(GenResponse(result));
                throw new Exception("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                throw new Exception("ErrorMessage : " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/getenrollment/uid/{uid}")]
        public Task<IHttpActionResult> GetUidMapEnrollmnet (string uid)
        {
            try
            {
                ValidateHeader();
                if(string.IsNullOrEmpty(uid)) throw new Exception("Error");

                var result = UIDMapEnrollmentCon.Instance().GetUIDMapEnrollment(uid); 
                if (result.RESULT_STATUS == "OK")
                    return Task.FromResult(GenResponse(result));
                throw new Exception("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                throw new Exception("ErrorMessage : " + ex.Message);
            }        
        }


        [HttpPost]
        [Route("api/verify/otp1/{dummyid}/{phonenumber}")]
        public IHttpActionResult VerifySendOTPData1(string dummyid, string phonenumber)
        {
            try
            {
              
                //if (string.IsNullOrEmpty(dummyid) || string.IsNullOrEmpty(phonenumber)) return BadRequest("Error");

                var result = Enrolment.VerifyOTPReturnStatus(dummyid, phonenumber);
                //LocalLogManager.Logger("Enrolment.VerifyOTPReturnStatus : " + result.RESULT_OBJ);
                
                //if (result == null)
                //{
                //    LocalLogManager.Logger("result == null: " + result);
                //    return BadRequest("API False");
                //}

                if (result.RESULT_STATUS == "OK" && result.RESULT_OBJ != null)
                {
                    LocalLogManager.Logger("result.RESULT_STATUS == \"OK\": " + result.RESULT_OBJ);
                    return Ok(result);

                }
                else
                {
                    return NotFound();
                }
               
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        /// <summary>
        /// New 
        /// </summary>
        /// <param name="dummyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/verify/dummy/{dummyid}")]
        public async Task<IHttpActionResult> VerifyOTPLastStatus(string dummyid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(dummyid) || string.IsNullOrEmpty(dummyid)) return BadRequest("Error");

                var result = await Enrolment.GetVerifyOTPLastStatusAsync(dummyid);

                if (result != null)

                    return Ok(result);

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