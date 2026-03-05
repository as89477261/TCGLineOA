using System.Collections.Generic;

namespace DataModel.Models.NDID.EForm
{
    public class DataRequestList
    {
        public string service_id { get; set; }
        public List<string> as_id_list { get; set; }
        public int min_as { get; set; }
        public string request_params_hash { get; set; }
        public List<ResponseList> response_list { get; set; }
    }
}