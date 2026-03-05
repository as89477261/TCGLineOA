using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Line
{

    public class UIDReportModel
    {
        public string Uid { get; set; } // Assuming Uid is a GUID/UNIQUEIDENTIFIER
        public DateTime CreateDateTime { get; set; }
        public string Uid_Channel { get; set; } // Assuming Uid_Channel is a GUID/UNIQUEIDENTIFIER
        public string Amr { get; set; }
        public string Aud { get; set; }
        public string Email { get; set; }
        public string Exp { get; set; } // Assuming Exp is a Unix timestamp (long)
        public string Iat { get; set; } // Assuming Iat is a Unix timestamp (long)
        public string Iss { get; set; }
        public string Name { get; set; }
        public string Nonce { get; set; }
        public string Picture { get; set; }
        public DateTime? UpdateTime { get; set; } // Assuming nullable DateTime
        public DateTime SystemCreateDate { get; set; }
    }
}
