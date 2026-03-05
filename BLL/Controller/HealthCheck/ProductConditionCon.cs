using System;
using System.Collections.Generic;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.CustomerHealthModel;

namespace BLL.Controller.HealthCheck
{
    public class ProductConditionCon
    {
        private ProductConditionCon()
        {
        }

        public static ProductConditionCon Instance { get; } = new ProductConditionCon();

        public BaseModel<List<ProductConditionModel>> GetProductCondition(string uid)
        {
            var result = new BaseModel<List<ProductConditionModel>>();
            try
            {
                var buffer = new ProductConditionRepo();
                var bufferResult = buffer.GetProductCondition(uid).ToListof<ProductConditionModel>();
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