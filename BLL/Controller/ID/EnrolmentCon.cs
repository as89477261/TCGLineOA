using CoreUtility;
using DAL.Repos.ID;
using DataModel.Models.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Controller.RP
{
    public class EnrolmentCon : BasePage
    {
        private static EnrolmentCon instance;
        private EnrolmentCon() { }
        public static EnrolmentCon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnrolmentCon();
                }
                return instance;
            }
        }


        public BaseModel<List<EnrolmentPersonalModel>> GetAllEnrollmentPersonal()
        {
            BaseModel<List<EnrolmentPersonalModel>> result = new BaseModel<List<EnrolmentPersonalModel>>();
            try
            {
                var buffer = new EnrollmentRepo();
                var bufferResult = buffer.GetAllEnrollmentPersonal().ToListof<EnrolmentPersonalModel>();
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
        public BaseModel<List<EnrolmentPersonalModel>> GetEnrolmentPersonal(string IdentityID, string IdentityType)
        {
            BaseModel<List<EnrolmentPersonalModel>> result = new BaseModel<List<EnrolmentPersonalModel>>();
            try
            {
                var buffer = new EnrollmentRepo();
                var bufferResult = buffer.GetEnrolmentPersonal(IdentityID, IdentityType).ToListof<EnrolmentPersonalModel>();
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
        public BaseModel<EnrolmentPersonalModel> GetEnrolmentPersonal(string dummyID)
        {
            BaseModel<EnrolmentPersonalModel> result = new BaseModel<EnrolmentPersonalModel>();
            try
            {
                var buffer = new EnrollmentRepo();
                var bufferResult = buffer.GetEnrolmentPersonal(dummyID).To<EnrolmentPersonalModel>();
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
        public BaseModel<string> InsertRegisterPersonal(EnrolmentPersonalModel obj)
        {
            BaseModel<string> result = new BaseModel<string>();
            try
            {
                obj.DummyID = Guid.NewGuid().ToString();
                obj.CreatedBy = "";
                obj.IsDummy = true;
                obj.Status = true;
                obj.CreatedDate = DateTime.Now;
                obj.CreatedBy = "SYSTEM";

                var buffer = new EnrollmentRepo();
                var bufferResult = buffer.InsertRegisterPersonal(obj);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = obj.DummyID;
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
