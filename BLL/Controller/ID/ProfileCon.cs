using CoreUtility;
using DAL.Repos.ID;
using DataModel.Models.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Controller.ID
{
    public class ProfileCon : BasePage
    {


        private static ProfileCon instance;
        private ProfileCon() { }

        public static ProfileCon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProfileCon();
                }
                return instance;
            }
        }


        public BaseModel<List<ProfileModel>> GetProfile(
            string dummyID = "", string identityID = "", string identityType = "",
            string mobilePhone = "", string firstName = "", string lastName = "")
        {
            BaseModel<List<ProfileModel>> result = new BaseModel<List<ProfileModel>>();
            try
            {
                var buffer = new ProfileRepo();
                var bufferResult = buffer.GetProfile(dummyID, identityID, identityType, mobilePhone, firstName, lastName).DataTableToList<ProfileModel>();
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
