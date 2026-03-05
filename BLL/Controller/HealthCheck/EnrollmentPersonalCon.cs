using System;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.CustomerHealthModel.Enrollment;

namespace BLL.Controller.HealthCheck
{
    public class EnrollmentPersonalCon : BasePage
    {
        private EnrollmentPersonalCon()
        {
        }

        public static EnrollmentPersonalCon Instance { get; } = new EnrollmentPersonalCon();

        public BaseModel<EnrollmentPersonalModel> GetUIDMapEnrollmentPersonal(string uid)
        {
            var result = new BaseModel<EnrollmentPersonalModel>();
            try
            {
                var buffer = new EnrollmentPersonalRepo();
                var bufferResult = buffer.GetUIDMapEnrollmentPersonal(uid).To<EnrollmentPersonalModel>();
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
                result.SetException(ex);
                return result;
            }
        }

        public BaseModel<string> UpdateEnrollmentByRegisterID(string registerID,string email)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new EnrollmentPersonalRepo();
                var bufferResult = buffer.UpdateEnrollmentByRegisterID(registerID, email);
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
                result.SetException(ex);
                return result;
            }
        }
    }
}