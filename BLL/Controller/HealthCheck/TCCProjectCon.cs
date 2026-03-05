using DAL.Repos.CustomerHealthCheck;
using DAL.Repos.FACenter;
using DataModel.Models.TCCProject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controller.HealthCheck
{
    public class TCCProjectCon
    {
        public static TCCProjectCon Instance { get; } = new TCCProjectCon();

        public BaseModel<DataSet> InsertUIDMapTCC(UIDMapTCCModel obj)
        {
            var result = new BaseModel<DataSet>();
            try
            {
                var buffer = new TCCProjectRepo();
                var bufferResult = buffer.InsertUIDMapTCC(obj);
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
        public BaseModel<DataSet> InsertInformation(InformationTCCModel obj)
        {
            var result = new BaseModel<DataSet>();
            try
            {
                var buffer = new TCCProjectRepo();
                var bufferResult = buffer.InsertInformationTCC(obj);
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
        public BaseModel<DataSet> UpdateInformationTCCPerson(InformationTCCModel obj)
        {
            var result = new BaseModel<DataSet>();
            try
            {
                var buffer = new TCCProjectRepo();
                var bufferResult = buffer.UpdateInformationTCCPerson(obj);
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
        public BaseModel<DataSet> UpdateInformationTCCJurustic(InformationTCCModel obj)
        {
            var result = new BaseModel<DataSet>();
            try
            {
                var buffer = new TCCProjectRepo();
                var bufferResult = buffer.UpdateInformationTCCJurustic(obj);
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
        public BaseModel<DataSet> UpdateUIDMapTCC(UIDMapTCCModel obj)
        {
            var result = new BaseModel<DataSet>();
            try
            {
                var buffer = new TCCProjectRepo();
                var bufferResult = buffer.UpdateUIDMapTCC(obj);
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

        public BaseModel<List<InformationTCCModel>> GetUidDataTCC(string uid)
        {
            var result = new BaseModel<List<InformationTCCModel>>();
            try
            {
                var buffer = new TCCProjectRepo();
                var bufferResult = buffer.GetUidDataTCC(uid).ToListof<InformationTCCModel>();
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
