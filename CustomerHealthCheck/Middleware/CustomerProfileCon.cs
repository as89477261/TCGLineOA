using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using CustomerHealthCheck.Middleware;
using DAL.Repos;
using DataModel.Models;

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
                var bufferResult = ToListof<CustomerProfileModel>(buffer.GetCustomerProfileByUID(uid));
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

        // GetUIDMapRegisterHealthCheck 
        public BaseModel<List<SendMailHealthCheckModel>> GetUIDMapRegisterHealthCheck(string uid , int registerInfoId)
        {
            var result = new BaseModel<List<SendMailHealthCheckModel>>();
            try
            {
                var buffer = new CustomerProfileRepo();
                var bufferResult = ToListof<SendMailHealthCheckModel>(buffer.GetUIDMapRegisterHealthCheck(uid, registerInfoId));
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

        public List<T> ToListof<T>(DataTable dt)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            if (dt != null)
            {
                var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
                var objectProperties = typeof(T).GetProperties(flags);
                var targetList = dt.AsEnumerable().Select(dataRow =>
                {
                    var instanceOfT = Activator.CreateInstance<T>();

                    foreach (var properties in objectProperties.Where(properties =>
                                 columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                        properties.SetValue(instanceOfT, dataRow[properties.Name], null);
                    return instanceOfT;
                }).ToList();

                return targetList;
            }

            return null;
        }
    }
}