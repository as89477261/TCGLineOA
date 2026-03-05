using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.NCB
{
    public class NCBConsumerConsentSlipModel
    {
        public int ID { get; set; }
        public Guid TransID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string IDCard { get; set; }
        public string MobilePhone { get; set; }
        public string ProductType { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public bool IsRequestEConsentSlip { get; set; }
        public DateTime RequestEConsentSlipDate { get; set; }
        public string NCBToken { get; set; }
        public bool IsGenerateFile { get; set; }
        public DateTime FileGenerateDate { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public bool IsSendEmail { get; set; }
        public DateTime SendEmailDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public string UIDReferenceID { get; set; }
    }
}
