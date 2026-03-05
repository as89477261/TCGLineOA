using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using CoreUtility;
using DataModel.Models.LG;
using DataModel.Models.SignUp;
using Newtonsoft.Json;
using TCG_CORE_MODEL.Model.NDIDConnext;

namespace CustomerHealthCheck.ServiceInterface
{
    public class Enrolment
    {
        public static List<LGModel> GetLGByCardID(string idCard)
        {
            //var url = ConfigurationManager.AppSettings["NDIDAPIHost"] + "/rp/requests/citizen_id/" + idCard;


            //var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>(), idCard);
            //var result = JsonConvert.DeserializeObject<List<LGModel>>(buffer);

            var result = new List<LGModel>
            {
                new LGModel
                {
                    LGNumber = "65-999999",
                    GuaranteePrice = "1000000",
                    IDCard = "1111111111111",
                    EndDate = DateTime.Parse("02/02/2567", new CultureInfo("th-TH")),
                    StartDate = DateTime.Parse("02/02/2566", new CultureInfo("th-TH")),
                    BankName = "Bank Name 01",
                    Objective = "เพื่อหมุนเวียนในองค์กร",
                    RequestName = "นาย สมมุติ รักงาน",
                    ProjectName = "PGS 9",
                    CreateDate = "02/02/2565"
                },

                new LGModel
                {
                    LGNumber = "65-999998",
                    GuaranteePrice = "1000000",
                    IDCard = "1111111111111",
                    EndDate = DateTime.Parse("02/02/2567", new CultureInfo("th-TH")),
                    StartDate = DateTime.Parse("02/02/2566", new CultureInfo("th-TH")),
                    BankName = "Bank Name 02",
                    Objective = "เพื่อหมุนเวียนในองค์กร",
                    RequestName = "นาย สมมุติ รักงาน",
                    ProjectName = "PGS 9",
                    CreateDate = "02/02/2565"
                }
            };
            return result;
        }


        public static BaseModel<string> InsertRegisterPersonal(string jsonBody)
        {
            var url = ConfigurationManager.AppSettings["APIIDURL"] + "/v1/enrollment/new";

            LocalLogManager.Logger("Backend Begin Call Enrolment API");
            //LocalLogManager.Logger(jsonBody);

            var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>(), jsonBody);
            var result = JsonConvert.DeserializeObject<BaseModel<string>>(buffer);

            LocalLogManager.Logger("Backend Get Result Enrolment API : " + buffer);

            return result;
        }

        public static BaseModel<string> VerifyRegisterPersonalReturnStatus(string dummyID)
        {
            var url = ConfigurationManager.AppSettings["APIIDURL"] + "/v1/verify/personal/" + dummyID + "/obj";

            LocalLogManager.Logger("Backend Begin Call Enrolment API");
            //LocalLogManager.Logger(jsonBody);

            var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>(), new Dictionary<string, string>());
            var result = JsonConvert.DeserializeObject<BaseModel<string>>(buffer);

            LocalLogManager.Logger("Backend Get Result Enrolment API : " + buffer);

            return result;
        }

        public static BaseModel<EnrollmentProfileModel_Min> VerifyRegisterPersonalReturnObj(string dummyID)
        {
            var url = ConfigurationManager.AppSettings["APIIDURL"] + "/v1/verify/personal/" + dummyID + "/obj";

            LocalLogManager.Logger("Backend Begin Call Enrolment API");
            //LocalLogManager.Logger(jsonBody);

            var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>(), new Dictionary<string, string>());
            var result = JsonConvert.DeserializeObject<BaseModel<EnrollmentProfileModel_Min>>(buffer);

            LocalLogManager.Logger("Backend Get Result Enrolment API : " + buffer);

            return result;
        }

        public static ResponseDopaModel VerifyDopaRegisterPersonalReturnObjDirectly([FromBody] RequestDopaModel obj)
        {
            var url = ConfigurationManager.AppSettings["APINDIDConnextURL"] + "/rp_connext";

            LocalLogManager.Logger("Backend Begin Call Enrolment API");

            var param = JsonConvert.SerializeObject(obj);
            var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>(), param);
            var result = JsonConvert.DeserializeObject<ResponseDopaModel>(buffer);

            LocalLogManager.Logger("Backend Get Result Enrolment API : " + buffer);

            return result;


        }

        public static BaseModel<string> VerifyOTPReturnStatus(string dummyID, string phoneNumber)
        {
            try
            {
                var data = new BaseModel<string>();
                data.RESULT_OBJ = "9999";
                data.SetSuccess();

                var url = ConfigurationManager.AppSettings["APIIDURL"] + "/v1/verify/otp/" + dummyID + "/" + phoneNumber;

                Task.Run(() =>
                {
                    var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>(), new Dictionary<string, string>());

                });
               
              
                return data;

                //LocalLogManager.Logger("2");
                //var result = JsonConvert.DeserializeObject<BaseModel<string>>(buffer);
               
                //LocalLogManager.Logger("3");
                //LocalLogManager.Logger("Backend Get Result Enrolment API : " + buffer);
                //LocalLogManager.Logger("Backend Get Result Enrolment API REsult : " + result.RESULT_OBJ);

                //return result;
            }
            catch (Exception ex)
            {

                LocalLogManager.Logger("error DIPROM " + ex.Message);
                throw ex;
            }
        }

        public static BaseModel<VerifyProfileModel> VerifyOTPVerifyStatus(string dummyID, string refNumber, string otp)
        {
            try
            {

                var url = ConfigurationManager.AppSettings["APIIDURL"] + "/v1/verify/otp/" + dummyID + "/confirm/" +
                          refNumber + "/" + otp;

                LocalLogManager.Logger("Backend Begin Call Enrolment API");

                var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>(), new Dictionary<string, string>());

                var result = JsonConvert.DeserializeObject<BaseModel<VerifyProfileModel>>(buffer);

                LocalLogManager.Logger("Backend Get Result Enrolment API : " + buffer);

                return result;

            }
            catch (Exception ex)
            {

                LocalLogManager.Logger("error DIPROM " + ex.Message);
                throw ex;

            }
        }

        public static BaseModel<VerifyProfileModel> GetVerifyOTPLastStatus(string dummyid)
        {
            try
            {

                var url = ConfigurationManager.AppSettings["APIIDURL"] + "/v1/verify/dummy/" + dummyid;

                LocalLogManager.Logger("Backend Begin Call Enrolment GetVerifyOTPLastStatus API");

                var buffer = HTTPManager.HttpGet(url);

                var result = JsonConvert.DeserializeObject<List<VerifyProfileModel>>(buffer);

                var data = new BaseModel<VerifyProfileModel>();

                data.RESULT_OBJ = result[0];

                data.SetSuccess();

                LocalLogManager.Logger("Backend Get Result GetVerifyOTPLastStatus API : " + buffer);

                return data;
            }
            catch (Exception ex)
            {

                LocalLogManager.Logger("error DIPROM " + ex.Message);
                throw ex;

            }
        }

        public static async Task<BaseModel<VerifyProfileModel>> GetVerifyOTPLastStatusAsync(string dummyid)
        {
            try
            {

                var url = ConfigurationManager.AppSettings["APIIDURL"] + "/v1/verify/dummy/" + dummyid;

                LocalLogManager.Logger("Backend Begin Call Enrolment GetVerifyOTPLastStatus API");

                var buffer = await HTTPManager.HttpGetAsync(url);

                var result = JsonConvert.DeserializeObject<List<VerifyProfileModel>>(buffer);

                var data = new BaseModel<VerifyProfileModel>();

                data.RESULT_OBJ = result[0];

                data.SetSuccess();

                LocalLogManager.Logger("Backend Get Result GetVerifyOTPLastStatus API : " + buffer);

                return data;
            }
            catch (Exception ex)
            {

                LocalLogManager.Logger("error DIPROM " + ex.Message);
                throw ex;

            }
        }

        public static async Task<BaseModel<string>> VerifyOTPReturnStatusAsync(string dummyID, string phoneNumber)
        {
            try
            {
                var data = new BaseModel<string>();
                data.RESULT_OBJ = "9999";
                data.SetSuccess();

                var url = ConfigurationManager.AppSettings["APIIDURL"] + "/v1/verify/otp/" + dummyID + "/" + phoneNumber;

                var buffer = await HTTPManager.HttpPostAsync(url, new Dictionary<string, string>(), new Dictionary<string, string>());


                data = JsonConvert.DeserializeObject<BaseModel<string>>(buffer);

                return data;
            }
            catch (Exception ex)
            {

                LocalLogManager.Logger("error DIPROM " + ex.Message);
                throw ex;
            }
        }
    }
}