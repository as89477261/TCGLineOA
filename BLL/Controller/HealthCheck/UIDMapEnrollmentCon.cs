using System;
using System.Linq;
using CustomerHealthModel.Model;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.CustomerHealthModel;

namespace BLL.Controller
{
    public class UIDMapEnrollmentCon1
    {
        private UIDMapEnrollmentCon1()
        {
        }

        public static UIDMapEnrollmentCon1 Instance { get; } = new UIDMapEnrollmentCon1();

        public BaseModel<UIDMapEnrollmentModel> GetUIDMapEnrollment(string id)
        {
            var result = new BaseModel<UIDMapEnrollmentModel>();
            try
            {
                var buffer = new UIDMapEnrollmentRepo();
                var bufferResult = buffer.GetUIDMapEnrollment(id).ToListof<UIDMapEnrollmentModel>().FirstOrDefault();
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

        public BaseModel<UIDMapEnrollmentWithCustomerProfileModel> GetUIDMapEnrollmentWithCustomerProfile(string uid)
        {
            var result = new BaseModel<UIDMapEnrollmentWithCustomerProfileModel>();
            try
            {
                var buffer = new UIDMapEnrollmentRepo();
                var bufferResult = buffer.GetUIDMapEnrollmentWithCustomerProfile (uid).ToListof<UIDMapEnrollmentWithCustomerProfileModel>().FirstOrDefault();
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

    }
}