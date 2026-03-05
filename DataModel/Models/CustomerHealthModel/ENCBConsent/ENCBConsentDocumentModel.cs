using DataModel.Models.TCGCenterAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.CustomerHealthModel.ENCBConsent
{
    public class ENCBConsentDocumentModel : BaseNCBConsentModel
    {
        public ENCBConsentDocumentModel()
        {

        }
        public int id { get; set; }
        public string transId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string idcard { get; set; }
        public string mobilePhone { get; set; }
        public string productType { get; set; }
        public string email { get; set; }
        public bool status { get; set; }
        public bool isRequestEconsentSlip { get; set; }
        public DateTime requestEconsentSlipDate { get; set; }
        public string ncbtoken { get; set; }
        public bool isGenerateFile { get; set; }
        public DateTime fileGenerateDate { get; set; }
        public string filePath { get; set; }
        public string fileName { get; set; }
        public string fileType { get; set; }
        public bool isSendEmail { get; set; }
        public DateTime sendEmailDate { get; set; }
        public DateTime createDate { get; set; }
        public string createBy { get; set; }
        public DateTime updateDate { get; set; }
        public string updateBy { get; set; }
    }
}
