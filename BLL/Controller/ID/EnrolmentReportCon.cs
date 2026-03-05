using BLL.Controller.RP;
using DAL.Repos.ID;
using DataModel.Models.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controller.ID
{
    public class EnrolmentReportCon
    {
        private static EnrolmentReportCon instance;
        private EnrolmentReportCon() { }
        public static EnrolmentReportCon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnrolmentReportCon();
                }
                return instance;
            }
        }


        public BaseModel<EnrolmentPersonalModel> GetEnrollmentPersonalByUID(string UID, string IdentityID = null, string ParamOrderbyField = null, string ParamOrderbyType = null)
        {
            BaseModel<EnrolmentPersonalModel> result = new BaseModel<EnrolmentPersonalModel>();
            try
            {
                var buffer = new EnrollmentReportRepo();
                var bufferResult = buffer.GetEnrollmentPersonalByUID(UID, IdentityID, ParamOrderbyField, ParamOrderbyType)
                    .ToListof<EnrolmentPersonalModel>()
                    .FirstOrDefault(x => x.IsDummy == false);

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
        public BaseModel<EnrolmentPersonalModel> GetFinishedEnrollmentPersonal(string UID, string IdentityID = null, string ParamOrderbyField = null, string ParamOrderbyType = null)
        {
            BaseModel<EnrolmentPersonalModel> result = new BaseModel<EnrolmentPersonalModel>();
            try
            {
                var buffer = new EnrollmentReportRepo();
                var bufferResult = buffer.GetFinishedEnrollmentPersonal(UID, IdentityID, ParamOrderbyField, ParamOrderbyType)
                    .ToListof<EnrolmentPersonalModel>()
                    .FirstOrDefault(x => x.IsDummy == false);

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
