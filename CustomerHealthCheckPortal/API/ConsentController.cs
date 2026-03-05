using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.Controller;
using CustomerHealthCheck.MasterPage;
using CustomerHealthCheck.ServiceInterface;
using DataModel.Models.SMEClinic;

namespace CustomerHealthCheck.Api
{
    public class ConsentController : BaseApi
    {
        // GET: api/Consent/5

        [Route("api/consent/{uid}")]
        public IHttpActionResult Get(string uid)
        {
            try
            {
                if (!string.IsNullOrEmpty(uid))
                {
                    ValidateHeader();
                    if (string.IsNullOrEmpty(uid)) return BadRequest("Error");

                    var bufferConsent = ConsentCon.Instance.GetConsentByUID(uid);
                    if (bufferConsent.RESULT_STATUS == "OK")
                        return GenJsonResponse<UIDConsentModel>(bufferConsent);
                    return BadRequest("Error");
                }

                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpGet]
        [Route("service/GetActivePurposes/{uid}/identifier")]
        public async Task<IHttpActionResult> GetActivePurposesAsync(string uid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(uid)) return BadRequest("error");

                var result = await PdpaApiInterface.GetActivePurposesAsync(uid);
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

        [HttpGet]
        [Route("service/GetApprovedPurposeByIdentifier/{uid}/identifier")]
        public async Task<IHttpActionResult> GetApprovedPurposeByIdentifier(string uid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(uid)) return BadRequest("error");

                var result = await PdpaApiInterface.GetApprovedPurposeByIdentifier(uid);
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

        [HttpGet]
        [Route("service/PurposesGetAll")]
        public async Task<IHttpActionResult> GetPurposesGetAll()
        {
            try
            {
                ValidateHeader();

                var result = await PdpaApiInterface.GetPorposeAll();
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

        [HttpPost]
        [Route("service/SubmitConsent")] // createProfile and create profile history
        public async Task<IHttpActionResult> SubmitConsent(SumbitConsentData obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = await PdpaApiInterface.SubmitConsentAsync(obj);

                    Console.WriteLine(result);

                    if (result != null)
                    {
                        var consentModel = new UIDConsentModel
                        {
                            Uid = obj.identifier, //uid 
                            IsPdpa = "1" // ปรับค่าตาม result 
                        };

                        var updateResult = UpdateConSentPdpa(consentModel);
                        Console.WriteLine(updateResult);
                        if (updateResult != null) // ปรับค่าตาม Result

                            return Ok(result);
                        else
                            return BadRequest("Error");
                    }
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

        [Route("api/UpdateConSentPdpa")]
        public IHttpActionResult UpdateConSentPdpa(UIDConsentModel obj)
        {
            try
            {
                if (!string.IsNullOrEmpty(obj.Uid))
                {
                    ValidateHeader();
                    if (string.IsNullOrEmpty(obj.Uid)) return BadRequest("Error");

                    var resultUpdatePdpa = ConsentCon.Instance.UpdateConsentPdpaStatus(obj);
                    if (resultUpdatePdpa.RESULT_STATUS == "OK")
                        return Ok(resultUpdatePdpa);
                    return BadRequest("Error");
                }

                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [Route("api/UpdateConsentStatus")]
        public IHttpActionResult UpdateUIDConsentWithConsentStatus(UIDConsentModel obj)
        {
            try
            {
                if (!string.IsNullOrEmpty(obj.Uid))
                {
                    ValidateHeader();
                    if (string.IsNullOrEmpty(obj.Uid)) return BadRequest("Error");

                    var resultUpdateConsentStatus = ConsentCon.Instance.UpdateUIDConsentWiteConsentStatus(obj);
                    if (resultUpdateConsentStatus.RESULT_STATUS == "OK")
                        return Ok(resultUpdateConsentStatus);
                    return BadRequest("Error");
                }

                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        //UpdateUIDConsentWiteConsentStatus




    }
}