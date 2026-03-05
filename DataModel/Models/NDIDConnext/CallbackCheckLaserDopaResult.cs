using System;

namespace TCG_CORE_MODEL.Model.NDID
{
    public class CallbackCheckLaserDopaResult
    {
        public string request_id { get; set; }
        public string ref1 { get; set; }
        public string ref2 { get; set; }
        public DateTime create_time { get; set; }
        public string requester { get; set; }
        public string service { get; set; }
        public string request_status { get; set; }
        public string received_data { get; set; }
        public string received_service { get; set; }
        public DateTime received_time { get; set; }

        public string DopaIsError { get; set; }
        public string DopaErrorMessage { get; set; }
        public string DopaCode { get; set; }
        public string DopaDesc { get; set; }
    }
}