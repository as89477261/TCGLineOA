using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace TCG_CORE_MODEL.Model.NDID
{
    public class CallbackRawCheckLaserDopaResult
    {
        public string request_id { get; set; }
        public string ref1 { get; set; }
        public string ref2 { get; set; }
        public DateTime create_time { get; set; }
        public string requester { get; set; }
        public string service { get; set; }
        public string request_status { get; set; }
        public List<ReceivedDatum> received_data { get; set; }

        public CallbackCheckLaserDopaResult GenerateCallbackObj()
        {
            bool isFalse;
            var data = received_data.FirstOrDefault().data;


            var obj = ParseToObject(data);
            obj.request_id = request_id;
            obj.ref1 = ref1;
            obj.ref2 = ref2;
            obj.create_time = create_time;
            obj.requester = requester;
            obj.service = service;
            obj.request_status = request_status;
            obj.received_data = received_data.FirstOrDefault().data;
            obj.received_service = received_data.FirstOrDefault().service;
            obj.received_time = received_data.FirstOrDefault().receive_time;


            return obj;
        }

        public CallbackCheckLaserDopaResult ParseToObject(string sXml)
        {
            var sr = "";
            try
            {
                var readXmlDoc = new XmlDocument();
                readXmlDoc.LoadXml(sXml);

                var obj = new CallbackCheckLaserDopaResult();
                var c1 = readXmlDoc.LastChild.LastChild.LastChild.LastChild["IsError"]; //.ChildNodes[0];
                var c2 = readXmlDoc.LastChild.LastChild.LastChild.LastChild["ErrorMessage"];
                var c3 = readXmlDoc.LastChild.LastChild.LastChild.LastChild["Code"];
                var c4 = readXmlDoc.LastChild.LastChild.LastChild.LastChild["Desc"];
                obj.DopaIsError = c1.InnerText;
                obj.DopaErrorMessage = c2.InnerText;
                obj.DopaCode = c3.InnerText;
                obj.DopaDesc = c4.InnerText;


                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public class ReceivedDatum
    {
        public string service { get; set; }
        public string data { get; set; }
        public DateTime receive_time { get; set; }
    }
}