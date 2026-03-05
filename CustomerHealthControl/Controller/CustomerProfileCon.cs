namespace CustomerHealthControl.Controller
{
    public class CustomerProfileCon
    {
        private CustomerProfileCon()
        {
        }

        public static CustomerProfileCon Instance { get; } = new CustomerProfileCon();

        //public BaseModel<UIDMapCustomerProfileModel> GetCustomerProfileHistoryByUID(string uid, string type)
        //{
        //    BaseModel<UIDMapCustomerProfileModel> result = new BaseModel<UIDMapCustomerProfileModel>();
        //    try
        //    {
        //        var buffer = new RegisterDB();
        //        var bufferResult = buffer.GetCustomerProfileHistoryByCIDAndType(uid, type)
        //            .ToListof<UIDMapCustomerProfileModel>();
        //        if (bufferResult != null && bufferResult.Count > 0)
        //        {
        //            result.RESULT_OBJ = bufferResult.FirstOrDefault();
        //            result.SetSuccess();
        //        }
        //        else
        //        {
        //            result.SetNotfound();
        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.SetException(ex);
        //        return result;
        //    }
        //}
    }
}