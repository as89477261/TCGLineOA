using System;

namespace OPEN_API_MODELS.Model.LOG
{
    public class LogAccessData
    {
        public string id { get; set; }
        public string parameters { get; set; }
        public string results { get; set; }
        public string result_status { get; set; }
        public string token { get; set; }
        public string user_id { get; set; }
        public string create_date { get; set; }
        public string create_by { get; set; }
        public string req_type { get; set; }
        public DateTime timestamp { get; set; }
    }
}