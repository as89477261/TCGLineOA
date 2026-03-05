using System;
using DAL.FACenter;
using DataModels.FACenter;

namespace BLL.Controller.FACenter
{
    public class CustomerProfileFACon
    {
        private CustomerProfileFACon()
        {
        }

        public static CustomerProfileFACon Instance { get; } = new CustomerProfileFACon();

        public BaseModel<string> InsertCustomerProfileFA(CustomerProfileFAInfo obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new CutomerProfileFARepo();
                var bufferResult = buffer.InsertCustomerProfileFA(obj);
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