using BLL.Controller.FACenter;
using CustomerHealthCheck.ServiceInterface;
using DataModel.Models.FACenter;
using DataModels.FACenter;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Web.Http;
namespace CustomerHealthCheck.API
{
    public class DIPROMController : BaseApi
    {
        [HttpPost]
        [Route("api/diprom/checkIdentity")]

        public IHttpActionResult InsertUIDDIPROM(UIDMapDIPROMModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = UIDMapDIPROMCon.Instance.InsertUIDMapDIPROM(obj);
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

        [HttpPost]
        [Route("api/diprom/update-transaction-diprom")]
        public IHttpActionResult UpdateUIDDIPROM(Request_UIDMapDIPROMModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = UIDMapDIPROMCon.Instance.UpdateUIDMapDIPROM(obj);
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

        //UpdateReturnDataSetUIDMapDIPROM

        [HttpPost]
        [Route("api/diprom/update-transaction-diprom-dataset")]
        public IHttpActionResult UpdateReturnDataSetUIDMapDIPROM(Request_UIDMapDIPROMModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = UIDMapDIPROMCon.Instance.UpdateReturnDataSetUIDMapDIPROM(obj);
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
        [Route("api/diprom/get-transaction-indentityid/{identityId}")]

        public IHttpActionResult GetCheckUIDMapDIPROM(string identityId)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(identityId)) { return BadRequest("Error"); }

                var result = UIDMapDIPROMCon.Instance.GetCheckUIDMapDIPROM(identityId);

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

        [HttpPost]
        [Route("api/diprom/update-importrequest-registersuccess/{ID}")]
        public IHttpActionResult UpdateImportrequestRegisterSuccess(int ID)
        {
            try
            {
                ValidateHeader();
                if (ID == 0) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = UIDMapDIPROMCon.Instance.UpdateReturnDataSetLineScreeningImportRequest(ID);
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
        [Route("api/diprom/get-transaction-uid/{uid}/eventCode/{eventCode}")]
        public IHttpActionResult GetRegisterUIDMapDIPROM(string uid , string eventCode)
        {
            try
            {
                var identityId = "";
                ValidateHeader();
                if (string.IsNullOrEmpty(uid) && string.IsNullOrEmpty(eventCode)) { return BadRequest("Error"); }

                var result = UIDMapDIPROMCon.Instance.GetUIDMapDIPROMEvent(uid , eventCode, identityId);

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
        [Route("api/diprom/get-transaction-profile-uid/{uid}")]
        public IHttpActionResult GetProfileDiprom(string uid)
        {
            try
            {                
                ValidateHeader();
                if (string.IsNullOrEmpty(uid)) { return BadRequest("Error"); }

                var result = UIDMapDIPROMCon.Instance.GetProfileDiprom(uid);

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

        [HttpPost]
        [Route("api/registerinfo/consult/fa")]
        public IHttpActionResult RegisterConsultFA(FormRegisterFAInfo obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = UIDMapDIPROMCon.Instance.InsertFromRegisterDiprom(obj);
                    if (result.RESULT_STATUS == "OK")
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
        [Route("api/diprom/update-transaction-diprom-consult-dataset")]
        public IHttpActionResult UpdateReturnDataSetUidMapDipromConsultFA(UpdateTransConsultFA obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = UIDMapDIPROMCon.Instance.UpdateTransConsultFA(obj);
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
        [Route("api/diprom/get-importrequest/uid/{uid}/identityId/{identityId}")]

        public IHttpActionResult GetImportRequest(string uid, string identityId)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(uid) && string.IsNullOrEmpty(identityId)) { return BadRequest("Error"); }

                var result = UIDMapDIPROMCon.Instance.GetImport(uid, identityId);

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


    }
}