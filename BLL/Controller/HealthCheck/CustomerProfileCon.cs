using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Repos;
using DataModel.Models.SMEClinic;

namespace BLL.Controller
{
    public class CustomerProfileCon
    {
        private CustomerProfileCon()
        {
        }

        public static CustomerProfileCon Instance { get; } = new CustomerProfileCon();

        public BaseModel<List<CustomerProfileModel>> GetCustomerProfileByUID(string uid)
        {
            var result = new BaseModel<List<CustomerProfileModel>>();
            try
            {
                var buffer = new CustomerProfileRepo();

                var bufferResult = buffer.GetCustomerProfileByUID(uid).ToListof<CustomerProfileModel>();

                var query = bufferResult.AsQueryable();

                query = query.Where(o => o.IdCardType == 1);

                var list = query.ToList();

                if (list != null)
                {
                    result.RESULT_OBJ = list;
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

        public BaseModel<List<CustomerProfileModel>> GetUIDLineProfile(string uid)
        {
            var result = new BaseModel<List<CustomerProfileModel>>();
            try
            {
                var buffer = new CustomerProfileRepo();

                var bufferResult = buffer.GetUIDLineProfile(uid).ToListof<CustomerProfileModel>();

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

        public BaseModel<List<CustomerProfileModel>> GetCustomerProfileByCID(string cid)
        {
            var result = new BaseModel<List<CustomerProfileModel>>();
            try
            {
                var buffer = new CustomerProfileRepo();
                var bufferResult = buffer.GetCustomerProfileByCID(cid).ToListof<CustomerProfileModel>();
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

        public BaseModel<List<CustomerProfileHistoryModel>> GetCustomerProfileHistoryByUID(string uid)
        {
            var result = new BaseModel<List<CustomerProfileHistoryModel>>();
            try
            {
                var buffer = new CustomerProfileRepo();
                var bufferResult = buffer.GetCustomerProfileHistoryByUID(uid).ToListof<CustomerProfileHistoryModel>();
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

        public BaseModel<CustomerProfileHistoryModel> GetCustomerProfileHistoryByUID(string uid, string type)
        {
            var result = new BaseModel<CustomerProfileHistoryModel>();
            try
            {
                var buffer = new RegisterDB();
                var bufferResult = buffer.GetCustomerProfileHistoryByCIDAndType(uid, type)
                    .ToListof<CustomerProfileHistoryModel>();
                if (bufferResult != null && bufferResult.Count > 0)
                {
                    result.RESULT_OBJ = bufferResult.FirstOrDefault();
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

        public BaseModel<string> UpdateCustomerProfileHistory(CustomerProfileHistoryModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new CustomerProfileRepo();
                var bufferResult = buffer.UpdateCustomerProfileHistory(obj);
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