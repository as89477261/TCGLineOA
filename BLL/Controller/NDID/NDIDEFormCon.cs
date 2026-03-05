using System;
using DAL.Repos.NDIDInfo;
using DataModel.Models.NDID.EForm;

namespace BLL.Controller.NDID
{
    public class NDIDEFormCon : BasePage
    {
        private static NDIDEFormCon instance;

        private NDIDEFormCon()
        {
        }

        public static NDIDEFormCon Instance()
        {
            if (instance == null) instance = new NDIDEFormCon();

            return instance;
        }

        public BaseModel<string> GenerateEFormTransaction()
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new NDIDEFormRepo();
                var bufferResult = buffer.GetNDIDEFormCountAll();
                var maxLength = int.Parse(GetAppsetting("MaxLengthTransaction"));

                if (!string.IsNullOrEmpty(bufferResult))
                {
                    var curNumber = bufferResult.Length;
                    var randomCount = maxLength - curNumber - 1;
                    var resultTransaction = randomCount.ToString();
                    for (var i = 0; i < randomCount; i++)
                    {
                        var bufferRandom = RandomManager.Instance.Next(0, 9);
                        resultTransaction += bufferRandom.ToString();
                    }

                    var nextNumber = int.Parse(bufferResult) + 1;
                    resultTransaction += nextNumber.ToString();


                    if (bufferResult != null)
                    {
                        result.RESULT_OBJ = resultTransaction;
                        result.SetSuccess();
                    }
                    else
                    {
                        result.SetNotfound();
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }

        public BaseModel<string> GetNDIDEFormCountAll()
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new NDIDEFormRepo();
                var bufferResult = buffer.GetNDIDEFormCountAll();
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

        public BaseModel<string> InsertNDIDEFormLog(NDIDEFormTransactionModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new NDIDEFormRepo();
                var bufferResult = buffer.InsertNDIDEFormTransaction(obj);
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