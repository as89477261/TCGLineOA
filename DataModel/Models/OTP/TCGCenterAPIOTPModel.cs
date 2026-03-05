using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.NDID
{
    public class TCGCenterAPIOTPModel
    {
        public int status { get; set; }
        public int messagE_ID { get; set; }
        public int tasK_ID { get; set; }
        public string end { get; set; }
        public string resultMessage { get; set; }
    }
}
