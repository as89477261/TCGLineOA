using CoreUtility;
using DAL.Repos.ID;
using DataModel.Models.ID;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Controller.ID
{
    public class VerifyCon : BasePage
    {


        private static VerifyCon instance;
        private VerifyCon() { }

        public static VerifyCon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VerifyCon();
                }
                return instance;
            }
        }


        public BaseModel<List<VerifyPersonalModel>> GetVerfyPersonal(string dummyID, string refNumber = null, string verifyType = null)
        {
            BaseModel<List<VerifyPersonalModel>> result = new BaseModel<List<VerifyPersonalModel>>();
            try
            {
                var buffer = new VerifyRepo();
                var bufferResult = buffer.GetVerfyPersonal(dummyID, refNumber, verifyType).ToListof<VerifyPersonalModel>();
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
