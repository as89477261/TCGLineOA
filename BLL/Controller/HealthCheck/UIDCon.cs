using System;
using System.Linq;
using DAL.Repos;
using DataModel.Models.Line;
using DataModel.Models.SMEClinic;

namespace BLL.Controller
{
    public class UIDCon
    {
        private UIDCon()
        {
        }

        public static UIDCon Instance { get; } = new UIDCon();

        public UIDReportModel GetUID()
        {
            try
            {
                var buffer = new UIDRepo();
                var result = buffer.GetUID().DataTableToList<UIDReportModel>().FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UIDModel GetUIDByUID(string uid)
        {
            try
            {
                var buffer = new UIDRepo();
                var result = buffer.GetUIDByUID(uid);

                if (result != null)
                {
                    var uidData = result.DataTableToList<UIDModel>().FirstOrDefault();
                    return uidData;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public BaseModel<string> InsertUIDAndDummyConsent(LineRawTokenModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new UIDRepo();
                var bufferResult = buffer.InsertUIDAndDummyConsent(obj);
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

        public BaseModel<string> DeleteDataByUID(string uid)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new UIDRepo();
                var bufferResult = buffer.DeleteDataByUID(uid);
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