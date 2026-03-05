using System;
using System.Collections.Generic;
using DAL.Repos.MasterData;
using DataModel.Models.MasterData;

namespace BLL.Controller.HealthCheck
{
    public class IndustryCon
    {
        private IndustryCon()
        {
        }

        public static IndustryCon Instance { get; } = new IndustryCon();

        public BaseModel<List<IndustryModel>> GetIndustryAll()
        {
            var result = new BaseModel<List<IndustryModel>>();
            try
            {
                var buffer = new IndustryRepo();
                var bufferResult = buffer.GetIndustryAll().ToListof<IndustryModel>();
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