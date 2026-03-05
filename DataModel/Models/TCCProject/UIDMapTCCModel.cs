using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.TCCProject
{
    public class UIDMapTCCModel
    {
        public Guid Id { get; set; }

        public string Uid { get; set; }

        public string IdentityId { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool? IsAcceptConsent { get; set; }

        public string InformationId { get; set; }

        public string OtpDummyId { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool? IsRegisterSuccess { get; set; }

        public bool IsMemberTCC { get; set; }

        public string MemberTCCStatus { get; set; }

        public string TransactionId { get; set; }

    }

}
