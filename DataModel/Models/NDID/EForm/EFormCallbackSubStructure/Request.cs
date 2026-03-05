using System.Collections.Generic;

namespace DataModel.Models.NDID.EForm
{
    public class Request
    {
        public string node_id { get; set; }
        public string type { get; set; }
        public string request_id { get; set; }
        public int min_idp { get; set; }
        public double min_aal { get; set; }
        public double min_ial { get; set; }
        public int request_timeout { get; set; }
        public List<string> idp_id_list { get; set; }
        public List<DataRequestList> data_request_list { get; set; }
        public string request_message_hash { get; set; }
        public List<ResponseList> response_list { get; set; }
        public bool closed { get; set; }
        public bool timed_out { get; set; }
        public int mode { get; set; }
        public object request_type { get; set; }
        public string requester_node_id { get; set; }
        public string status { get; set; }
        public string block_height { get; set; }
    }
}