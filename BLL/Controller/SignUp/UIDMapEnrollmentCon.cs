using System;
using System.Linq;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.CustomerHealthModel;

namespace BLL.Controller.NDID
{
    public class UIDMapEnrollmentCon : BasePage
    {
        private static UIDMapEnrollmentCon instance;

        private UIDMapEnrollmentCon()
        {
        }

        public static UIDMapEnrollmentCon Instance()
        {
            if (instance == null) instance = new UIDMapEnrollmentCon();

            return instance;
        }
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

        public BaseModel<string> InsertUIDMapEnrollment(string uid, string dummyID)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new UIDMapEnrollmentRepo();
                var bufferResult = buffer.InsertUIDMapEnrollment(uid, dummyID);
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