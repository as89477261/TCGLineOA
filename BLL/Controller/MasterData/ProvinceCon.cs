using System;
using System.Collections.Generic;
using DAL.Repos.MasterData;
using DataModel.Models.MasterData;

namespace BLL.Controller.HealthCheck
{
    public class ProvinceCon
    {
        private ProvinceCon()
        {
        }

        public static ProvinceCon Instance { get; } = new ProvinceCon();

        public BaseModel<List<ProvinceModel>> GetProvinceAll()
        {
            var result = new BaseModel<List<ProvinceModel>>();
            try
            {
                var buffer = new ProvinceRepo();
                var bufferResult = buffer.GetProvinceAll().ToListof<ProvinceModel>();
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

        public BaseModel<List<PostCodeModel>> GetProvinceDetail()
        {
            var result = new BaseModel<List<PostCodeModel>>();
            try
            {
                var buffer = new ProvinceRepo();
                var bufferResult = buffer.GetProvinceDetail().ToListof<PostCodeModel>();
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