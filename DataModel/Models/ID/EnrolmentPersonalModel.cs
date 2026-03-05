using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.ID
{
    public class EnrolmentPersonalModel
    {
        public string DummyID { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityID { get; set; }
        public string IdentityType { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public bool IsDummy { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
