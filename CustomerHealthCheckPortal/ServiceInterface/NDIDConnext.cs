using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading;
using CoreUtility;
using Newtonsoft.Json;
using TCG_CORE_MODEL.Model.NDID;
using TCG_CORE_MODEL.Model.NDIDConnext;

namespace CustomerHealthCheck.ServiceInterface
{
    public class NDIDConnextInterface
    {
        private NDIDConnextInterface()
        {
        }

        public static NDIDConnextInterface Instance { get; } = new NDIDConnextInterface();

        public ResponseDopaModel CheckDopaDipChip(RequestDopaModel obj)
        {
            ServicePointManager
                    .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;


            var url = ConfigurationManager.AppSettings["NDIDConnextDOPAAPI"] + "/rp_connext";
            var param = JsonConvert.SerializeObject(obj);
            var bufferResulq = HTTPManager.HttpPost<ResponseDopaModel>(
                url,
                new Dictionary<string, string>(),
                param
            );

            return bufferResulq;
        }

        public bool CallBackToRequest(CallbackRawCheckLaserDopaResult obj)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["LINEApiNotification"];
                var param = JsonConvert.SerializeObject(obj);
                var bufferResulq = HTTPManager.HttpPost<ResponseDopaModel>(
                    url,
                    new Dictionary<string, string>(),
                    param
                );

                Thread.Sleep(500);


                return true;
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(" Error Callback by NDID Connext " + ex.Message);
                return false;
            }
        }
    }
}