using BLL.Controller.HealthCheck;
using CustomerHealthCheck.ServiceInterface;
using DataModel.Models.CustomerHealthModel.Reward;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;
using TCG_NDID_API.ServiceInterface;

namespace CustomerHealthCheck.API
{
    public class RewardController : BaseApi
    {

        [HttpGet]
        [Route("api/reward/{rewardid}")]
        public IHttpActionResult GetRewardByRewardCode(string rewardid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(rewardid)) return BadRequest("Error");

                var result = RewardCon.Instance.GetRewardByRewardCode(rewardid);

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
        [Route("api/reward/uid/{uid}/{ownercode}/{programcode}/exist")]
        public async Task<IHttpActionResult> CheckUIDMappingReward(string uid, string ownercode, string programcode)
        {
            try
            {
                var GetTopReward = RewardCon.Instance.GetRewardByOwner(ownercode, programcode);
                if (GetTopReward.RESULT_STATUS == "OK" && GetTopReward.RESULT_OBJ != null)
                {
                    var lstUIDMapReward = RewardCon.Instance.GetUIDMapReward(uid, ownercode, programcode);
                    if (lstUIDMapReward.RESULT_STATUS == "OK" && lstUIDMapReward.RESULT_OBJ.Count <= 0)
                    {
                        return Ok("SUCCESS");
                    }
                    return Ok("FAIL");
                }
                else
                {
                    return Ok("FULL");
                }
            }
            catch (Exception ex)
            {

                return Ok("FULL");
            }
        }

        [HttpPost]
        [Route("api/reward/otp/verify/step1")]
        public async Task<IHttpActionResult> MappingRewardStep1([FromBody] RewardMapUIDModel obj)
        {
            try
            {

                ValidateHeader();
                var objNetworkInfo = GetRequestNetworkInfo();

                ValidateMacToken(objNetworkInfo);
                if (obj == null) return (BadRequest("Error"));

                obj.IP = objNetworkInfo.IPAddress;
                obj.Mac = objNetworkInfo.MacAddress;

                // Step 1 ตรวจสอบเบอร์นี้ ที่ เคมเปนนี้ต้องไม่เคยลงทะเบียน
                var resultStep1 = RewardCon.Instance.GetUIDMapRewardDuplicate(
                  null
                    , obj.RewardOwnerCode
                    , obj.RewardProgramCode
                    , obj.PhoneNumber
                    , null
                    , null
                    , null);

                if (resultStep1.RESULT_OBJ == null)
                {
                    LocalLogManager.Logger("Verify step1 is Pass for : " + obj.RewardOwnerCode + ">" + obj.RewardProgramCode + ">" + obj.PhoneNumber);

                    var resultStep2_1 = RewardCon.Instance.GetUIDMapRewardDuplicate(
                      null
                    , obj.RewardOwnerCode
                    , obj.RewardProgramCode
                    , null
                    , obj.Token
                    , null
                    , null);


                    // var resultStep2_2 = RewardCon.Instance.GetUIDMapRewardDuplicate(
                    //  null
                    //, obj.RewardOwnerCode
                    //, obj.RewardProgramCode
                    //, null
                    //, null
                    //, obj.Mac
                    //, null);


                    var resultStep2_3 = RewardCon.Instance.GetUIDMapRewardDuplicate(
                     null
                   , obj.RewardOwnerCode
                   , obj.RewardProgramCode
                   , null
                   , null
                   , null
                   , obj.IP);

                    if (resultStep2_1.RESULT_OBJ == null && resultStep2_3.RESULT_OBJ == null)
                    {

                        LocalLogManager.Logger("Verify step2 is Pass for : " + obj.Token + ">" + obj.Mac + ">" + obj.IP);
                        if (resultStep1.RESULT_OBJ == null)
                        {
                            LocalLogManager.Logger("resultUIDMapReward.RESULT_STATUS == \"OK\": " + resultStep1.RESULT_STATUS);
                            var objNew = SendOTP(obj);

                            objNew.Mac = objNetworkInfo.MacAddress;
                            objNew.IP = objNetworkInfo.IPAddress;

                            var resultCreateUIDMapReward = RewardCon.Instance.InsertUIDMapReward(objNew);
                            if (resultCreateUIDMapReward.RESULT_STATUS == "OK" && resultCreateUIDMapReward.RESULT_OBJ != null)
                            {
                                return Ok(objNew);
                            }
                            else
                            {
                                LocalLogManager.Logger("Error Call API : Fail");
                                return BadRequest("ErrorMessage : Fail");
                            }
                        }
                    }
                    else
                    {
                        LocalLogManager.Logger("Verify step2 is Fail for : " + obj.Token + ">" + obj.Mac + ">" + obj.IP);
                        return BadRequest("Duplicate");
                    }
                }
                else
                {
                    LocalLogManager.Logger("Verify step1 is Fail for : " + obj.RewardOwnerCode + ">" + obj.RewardProgramCode + ">" + obj.PhoneNumber);

                    return BadRequest("Duplicate");
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
        [Route("api/reward/otp/verify/step2")]
        public async Task<IHttpActionResult> MappingRewardStep2([FromBody] RewardMapUIDModel obj)
        {
            try
            {

                ValidateHeader();
                var objNetworkInfo = GetRequestNetworkInfo();

                ValidateMacToken(objNetworkInfo);
                if (obj == null) return (BadRequest("Error"));

                obj.IP = objNetworkInfo.IPAddress;
                obj.Mac = objNetworkInfo.MacAddress;

                var resultUIDMapReward = RewardCon.Instance.GetUIDMapRewardDummy(
                    obj.UID
                    , obj.OTP
                    , obj.RewardOwnerCode
                    , obj.RewardProgramCode
                    , obj.PhoneNumber
                    , obj.Token
                    , objNetworkInfo.MacAddress
                    , objNetworkInfo.IPAddress
                    , obj.OTPRef);

                LocalLogManager.Logger("MappingRewardStep2 GetUIDMapRewardDummy : " + resultUIDMapReward.RESULT_OBJ);
                if (resultUIDMapReward.RESULT_OBJ != null && resultUIDMapReward.RESULT_OBJ.OTPStatus == false)
                {
                    // Get Useable Coupon and Booking Item
                    var GetTopReward = RewardCon.Instance.GetRewardByOwner(obj.RewardOwnerCode, obj.RewardProgramCode);
                    if (GetTopReward.RESULT_STATUS == "OK")
                    {
                        var objRewardMapUID = new RewardMapUIDModel()
                        {
                            UID = obj.UID,
                            PhoneNumber = obj.PhoneNumber,
                            RewardProgramCode = obj.RewardProgramCode,
                            RewardOwnerCode = obj.RewardOwnerCode,
                            RewardGUID = GetTopReward.RESULT_OBJ.RewardGUID,
                            OTP = obj.OTP,
                            OTPRef = obj.OTPRef
                        };
                        var result = RewardCon.Instance.UpdateUIDMapReward(objRewardMapUID);
                        return Ok("SUCCESS");
                    }
                    // Map Coupon With UID
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/reward/condition/{ownercode}/{programcode}/{uid}")]
        public async Task<IHttpActionResult> PassCondition(string ownercode, string programcode, string uid)
        {
            try
            {
                ValidateHeader();
                var objNetworkInfo = GetRequestNetworkInfo();

                ValidateMacToken(objNetworkInfo);
                if (string.IsNullOrEmpty(ownercode) || string.IsNullOrEmpty(programcode) || string.IsNullOrEmpty(uid)) return (BadRequest("Error"));

                // Get object campaign name
                var registerUID = await CampaignConfig.GetRegisterUserByUID(uid);
                var resultConcat = "";
                if (registerUID != null)
                {                   
                    for (int i = 0; i < registerUID.Count; i++)
                    {
                        //resultConcat += registerUID[i].campaign.name + "','";
                        resultConcat += ""+registerUID[i].campaign.name + ",";
                    }
                    resultConcat = resultConcat.Substring(0,resultConcat.Length-1);
                }

                var isHaveActivityWithTCG = false;
                //var bufferCondition = RewardCon.Instance.GetUIDPassRewardConditionConfig(uid, GetAppsetting("CouponPassCondition"));
                var bufferCondition = RewardCon.Instance.GetUIDPassRewardConditionConfig(uid, ownercode, programcode, resultConcat);

                if (bufferCondition.RESULT_STATUS == "OK")
                {
                    if (bufferCondition.RESULT_OBJ.isHC != 0)
                    {
                        isHaveActivityWithTCG = true;
                    }
                    else if (bufferCondition.RESULT_OBJ.isSubTypeInfo != 0)
                    {
                        isHaveActivityWithTCG = true;
                    }
                    else if (string.IsNullOrEmpty(bufferCondition.RESULT_OBJ.isEnroll) == false)
                    {
                        isHaveActivityWithTCG = true;
                    }
                    else if (string.IsNullOrEmpty(bufferCondition.RESULT_OBJ.isFACenter) == false)
                    {
                        isHaveActivityWithTCG = true;
                    }
                    else if (string.IsNullOrEmpty(bufferCondition.RESULT_OBJ.is3Color) == false)
                    {
                        isHaveActivityWithTCG = true;
                    }
                    else if (string.IsNullOrEmpty(bufferCondition.RESULT_OBJ.isCampaign) == false)
                    {
                        isHaveActivityWithTCG = true;
                    }

                    if (isHaveActivityWithTCG)
                    {
                        return Ok("SUCCESS");
                    }
                    else
                    {
                        return BadRequest("FAIL");
                    }

                }
                else
                {
                    LocalLogManager.Logger("Error Call API : GetUIDPassRewardCondition");
                    return BadRequest("ErrorMessage : GetUIDPassRewardCondition");
                }

            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/reward/owner/{ownercode}/{programcode}")]
        public IHttpActionResult GetRewardByHeader(string ownercode, string programcode)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(ownercode) && string.IsNullOrEmpty(ownercode)) return BadRequest("Error");

                var result = RewardHeaderCon.Instance.GetRewardByHeader(ownercode, programcode, "1");

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
        [Route("api/reward/program/{ownercode}/{programcode}")]
        public IHttpActionResult GetRewardProgram(string ownercode, string programcode)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(ownercode) && string.IsNullOrEmpty(ownercode)) return BadRequest("Error");

                var result = RewardHeaderCon.Instance.GetRewardByHeader(ownercode, programcode, "1");

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

        /// --- /
        private RewardMapUIDModel SendOTP(RewardMapUIDModel obj)
        {
            try
            {
                ValidateHeader();
                var refNumber = RandomManager.RandomNumber(1000, 9999).ToString();
                var verificationNumber = RandomManager.RandomNumber(100000, 999999).ToString();


                obj.OTP = verificationNumber;
                obj.OTPRef = refNumber;

                if (GetAppSetting("IsDebug") == "0")
                {

                    Task.Factory.StartNew(() =>
                    {
                        var resultSendOTP = OTPInterface.Instance.SendOTP(
                              GetAppSetting("OTPKeyID"),
                              GetAppSetting("OTPMobileGroup"),
                              obj.PhoneNumber,
                              GetAppSetting("OTPMobileMessage").Replace("@ref", refNumber).Replace("@otp", verificationNumber));

                    });
                }

                return obj;

            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                throw ex;
            }
        }
    }
}
