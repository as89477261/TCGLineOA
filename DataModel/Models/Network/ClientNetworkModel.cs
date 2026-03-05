using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Network
{
    public class ClientNetworkModel
    {
        public string IPAddress { get; set; }
        public string IPAddressBehindReverseProxy { get; set; }
        public string IPAddressBehindCloudflare { get; set; }
        public string MacAddress { get; set; }
        public ClientLocationModel Location { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
    }
}
