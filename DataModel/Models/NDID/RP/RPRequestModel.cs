using System.Collections.Generic;

namespace DataModel.Models.NDID.RP
{
    public class RPRequestModel
    {
        public string node_id { get; set; }
        public int mode { get; set; }
        public string reference_id { get; set; }
        public List<string> idp_id_list { get; set; }
        public string callback_url { get; set; }
        public List<RPRequestDataListModel> data_request_list { get; set; }
        public string request_message { get; set; }
        public double min_ial { get; set; }
        public double min_aal { get; set; }
        public int min_idp { get; set; }
        public int request_timeout { get; set; }
        public bool bypass_identity_check { get; set; }
    }
}