using System.Collections.Generic;
using System.Configuration;
using CoreUtility;
using DataModel.Models.NDID.Utility;

namespace CustomerHealthCheck.ServiceInterface
{
    public static class Utility
    {
        public static class IDP
        {
            public static List<IDPModel> GetIDPModelByID(string idCard)
            {
                var url = ConfigurationManager.AppSettings["NDIDAPIHost"] + "/utility/idp/citizen_id/" + idCard;
                var buffer = HTTPManager.HttpGet<List<IDPModel>>(url);
                return buffer;
            }

            public static List<IDPModel> GetEnrolledIDPModelByID(string idCard)
            {
                var url = ConfigurationManager.AppSettings["NDIDAPIHost"] + "/utility/idp/citizen_id/" + idCard;
                var buffer = HTTPManager.HttpGet<List<IDPModel>>(url);
                return buffer;
            }

            public static List<IDPModel> GetOnTheFlyIDPModelByID(string idCard)
            {
                var url = ConfigurationManager.AppSettings["NDIDAPIHost"] + "/utility/idp/citizen_id/" + idCard;
                var buffer = HTTPManager.HttpGet<List<IDPModel>>(url);
                return buffer;
            }
        }
    }
}