using System.Collections.Generic;
using Newtonsoft.Json;

namespace DataModel.Models.NDID.Utility
{
    public class IDPModel
    {
        public string node_id { get; set; }
        public string node_name { get; set; }
        public NodeModel node_object { get; set; }
        public int max_ial { get; set; }
        public int max_aal { get; set; }
        public bool on_the_fly_support { get; set; }
        public double ial { get; set; }
        public object lial { get; set; }
        public object laal { get; set; }
        public List<int> mode_list { get; set; }
        public List<object> supported_request_message_data_url_type_list { get; set; }
        public bool agent { get; set; }

        public void ConvertRawNodeToObject()
        {
            node_object = JsonConvert.DeserializeObject<NodeModel>(node_name);
        }
    }
}