using System;

namespace OPEN_API_MODELS.Model.LOG
{
    public class LogReqRes
    {
        public string c_req_url { get; set; }
        public string c_req_header { get; set; }
        public string c_req_body { get; set; }
        public string c_req_hostname { get; set; }
        public string c_req_ip { get; set; }
        public DateTime c_req_qry_time { get; set; }
        public string c_req_total_time { get; set; }
        public string c_res_code { get; set; }
        public string c_res_header { get; set; }
        public string c_res_body { get; set; }
        public DateTime c_create_date { get; set; }
        public string c_create_by { get; set; }
        public DateTime c_res_qry_time { get; set; }
    }
}