using DataModel.Models.CustomerHealthModel.ENCBConsent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TCGScoreResponseModel;

namespace DataModel.Models.TCGCenterAPI
{
    public class BaseNCBConsentModel
    {
        public bool success { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
        public ENCBConsentDocumentModel data { get; set; }
    }
}
