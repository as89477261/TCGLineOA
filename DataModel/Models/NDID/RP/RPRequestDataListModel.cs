using System.Collections.Generic;

namespace DataModel.Models.NDID.RP
{
    public class RPRequestDataListModel
    {
        public string service_id { get; set; }
        public List<string> as_id_list { get; set; }
        public int min_as { get; set; }
        public string request_params { get; set; }
    }
}