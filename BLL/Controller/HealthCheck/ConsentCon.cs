using System;
using System.Linq;
using DAL.Repos.SMEClinic;
using DataModel.Models.SMEClinic;

namespace BLL.Controller
{
    public class ConsentCon
    {
        private ConsentCon()
        {
        }

        public static ConsentCon Instance { get; } = new ConsentCon();

        public BaseModel<UIDConsentModel> GetConsentByUID(string obj)
        {
            var result = new BaseModel<UIDConsentModel>();
            try
            {
                var buffer = new ConsentRepo();
                var bufferResult = buffer.GetConsentByUID(obj).ToListof<UIDConsentModel>().FirstOrDefault();
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

        public BaseModel<string> UpdateUIDConsentWiteConsentStatus(UIDConsentModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new ConsentRepo();
                var bufferResult = buffer.UpdateUIDConsentWiteConsentStatus(obj);
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

		public BaseModel<string> UpdateConsentPdpaStatus(UIDConsentModel obj)
		{
			var result = new BaseModel<string>();
			try
			{
				var buffer = new ConsentRepo();
				var bufferResult = buffer.UpdateConsentPdpaStatus(obj);
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

		public BaseModel<string> UpdateUIDConsentWiteCustomerProfile(UIDConsentModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new ConsentRepo();
                var bufferResult = buffer.UpdateUIDConsentWiteCustomerProfile(obj);
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