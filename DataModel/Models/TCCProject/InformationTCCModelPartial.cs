using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.TCCProject
{
    public partial class InformationTCCModel
    {
        [NotMapped]
        public Guid IdUId { get; set; }

        public string Uid { get; set; }

        public string IdentityId { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDateUID { get; set; }

        public bool? IsAcceptConsent { get; set; }

        public string InformationId { get; set; }

        public string OtpDummyId { get; set; }

        public DateTime UpdatedDateUID { get; set; }

        public bool? IsRegisterSuccess { get; set; }

        public bool IsMemberTCC { get; set; }

        public string MemberTCCStatus { get; set; }
    }
}
