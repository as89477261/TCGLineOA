using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHealthModel.Model
{
    public class TCGScoreResponseModel
    {
        public string message { get; set; }
        public Data data { get; set; }
        public class Data
        {
            public double riskBasePricing { get; set; }
            public int total_Score { get; set; }
            public string score_Band { get; set; }
            public string message { get; set; }
            public string messageType { get; set; }
            public bool isPass { get; set; }
        }

    }
}
