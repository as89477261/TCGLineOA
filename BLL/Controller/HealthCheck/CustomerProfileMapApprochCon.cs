using System;
using System.Collections.Generic;
using DAL.Repos;
using DataModel.Models.CustomerHealthModel;
using DataModel.Models.SMEClinic;

namespace BLL.Controller
{
    public class CustomerProfileMapApprochCon
    {
        private CustomerProfileMapApprochCon()
        {
        }

        public static CustomerProfileMapApprochCon Instance { get; } = new CustomerProfileMapApprochCon();

        public BaseModel<List<CustomerProfileMapApprochModel>> GetCustomerProfileMapApproch(string cid)
        {
            var result = new BaseModel<List<CustomerProfileMapApprochModel>>();
            try
            {
                var buffer = new CustomerProfileRepo();
                var bufferResult = buffer.GetCustomerProfileMapApproch(cid).ToListof<CustomerProfileMapApprochModel>();
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

        public BaseModel<int> GetCountCustomerProfileMapApproch(string cid)
        {
            var result = new BaseModel<int>();
            try
            {
                var buffer = new CustomerProfileRepo();
                var bufferResult = buffer.GetCustomerProfileMapApproch(cid).ToListof<CustomerProfileHistoryModel>();
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Count;
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