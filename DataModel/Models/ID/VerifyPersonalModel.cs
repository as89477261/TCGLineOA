using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.ID
{
    public class VerifyPersonalModel
    {
        public Guid Id { get; set; }

        public string DummyId { get; set; }

        public string VerifyType { get; set; }

        public string VerifyValue { get; set; }

        public string RefNumber { get; set; }

        public bool IsSuccess { get; set; }

        public DateTime SendRefDate { get; set; }

        public byte[] VerifiedTimeStamp { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime KeyInDate { get; set; }

        public string KeyInValue { get; set; }

        public string CreatedBy { get; set; }

        public bool Status { get; set; }
    }
}
