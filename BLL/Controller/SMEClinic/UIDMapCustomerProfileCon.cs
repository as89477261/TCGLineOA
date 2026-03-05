using System;
using System.Linq;
using DAL.Repos;
using DataModel.Models.SMEClinic;

namespace BLL.Controller
{
    public class UIDMapCustomerProfileCon
    {
        private UIDMapCustomerProfileCon()
        {
        }

        public static UIDMapCustomerProfileCon Instance { get; } = new UIDMapCustomerProfileCon();

        public BaseModel<UIDMapCustomerProfileModel> GetUIDMapCustomerProfile(string UID, string CustomerCode = null)
        {
            var result = new BaseModel<UIDMapCustomerProfileModel>();
            try
            {
                var buffer = new UIDMapCustomerProfileRepo();
                var bufferResult = buffer.GetUIDMapCustomerProfile(UID, CustomerCode)
                    .ToListof<UIDMapCustomerProfileModel>().FirstOrDefault();
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult;
                    result.SetSuccess();
                }
                else
                {
                    result.SetNotfound();
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BaseModel<string> InsertUIDMapCustomerProfile(UIDMapCustomerProfileModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new UIDMapCustomerProfileRepo();
                var bufferResult = buffer.InsertUIDMapCustomerProfile(obj);
                if (bufferResult != "")
                {
                    result.RESULT_OBJ = bufferResult;
                    result.SetSuccess();
                }
                else
                {
                    result.SetNotfound();
                }

                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
    }
}