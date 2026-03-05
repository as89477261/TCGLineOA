using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Middleware
{
    public class APITokenModel
    {
        public string accountId { get; set; }
        public string tokenId { get; set; }
        public string tokenAPIID { get; set; }
        public DateTime expireDate { get; set; }
    }

    public class APIResultMessage
    {
        public int code { get; set; }
        public string message { get; set; }
        public APITokenModel data { get; set; }
    }

}
