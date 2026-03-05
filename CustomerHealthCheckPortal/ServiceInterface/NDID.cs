using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading;
using CoreUtility;
using DataModel.Models.NDID;
using DataModel.Models.NDID.EFormv2;
using DataModel.Models.NDID.RP;
using Newtonsoft.Json;

namespace CustomerHealthCheck.ServiceInterface
{
    public static class NDID
    {
        public static RPResponseModel GetRPRequestByID(string idCard, string jsonBody)
        {
            var url = ConfigurationManager.AppSettings["NDIDAPIHost"] + "/rp/requests/citizen_id/" + idCard;

            //LocalLogManager.Logger(url);
            //LocalLogManager.Logger(jsonBody);

            var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>(), jsonBody);
            var result = JsonConvert.DeserializeObject<RPResponseModel>(buffer);

            Thread.Sleep(2000);

            return result;
        }

        public static BaseModel<string> PostEformV2Post(EFormV2PostModel obj)
        {
            var url = ConfigurationManager.AppSettings["NDIDEFormInternalAPI"];
            var result = new BaseModel<string>();
            //LocalLogManager.Logger(url);
            //LocalLogManager.Logger(jsonBody);
            var jsonObj = JsonConvert.SerializeObject(obj);
            //var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>(), jsonObj);
            var buffer = UrlLengthen(url, jsonObj);

            result.RESULT_OBJ = buffer;
            result.SetSuccess();
            //var result = JsonConvert.DeserializeObject<RPResponseModel>(buffer);

            //Thread.Sleep(2000);

            return result;
        }


        /// \
        /// <summary\>
        ///     Follow any redirects to get back to the original URL
        ///     \
        /// </summary\>
        private static string UrlLengthen(string url, string requestTextJson)
        {
            var newurl = url;
            var redirecting = true;
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;

            while (redirecting)
                try
                {
                    newurl = newurl.Replace("https", "http");

                    var request = (HttpWebRequest)WebRequest.Create(newurl);
                    request.AllowAutoRedirect = false;
                    request.UserAgent =
                        "Mozilla/5.0 (Windows; U;Windows NT 6.1; en - US; rv: 1.9.1.3) Gecko / 20090824 Firefox / 3.5.3(.NET CLR 4.0.20506)";
                    request.ContentType = "application/json";
                    request.Method = "POST";
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(requestTextJson);
                    }

                    var response = (HttpWebResponse)request.GetResponse();
                    if ((int)response.StatusCode == 301 || (int)response.StatusCode == 302)
                    {
                        var uriString = response.Headers["Location"];
                        //Log.Debug("Redirecting " + newurl + " to " + uriString + " because " + response.StatusCode);
                        newurl = uriString;
                        redirecting = false;
                        // and keep going
                    }
                    else
                    {
                        //Log.Debug("Not redirecting " + url + " because " + response.StatusCode);
                        redirecting = false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("url", newurl);
                    //Exceptions.ExceptionRecord.ReportCritical(ex);
                    redirecting = false;
                }

            return newurl;
        }

        public static List<NDIDWrapPersonalModel> GetDataByRequestID(string requestID)
        {
            var url = ConfigurationManager.AppSettings["NDIDAPIHost"] + "/rp/request_data/" + requestID;

            LocalLogManager.Logger(url);
            //LocalLogManager.Logger(jsonBody);

            var buffer = HTTPManager.HttpGet(url);
            var result = JsonConvert.DeserializeObject<List<NDIDWrapPersonalModel>>(buffer);


            return result;
        }
    }
}