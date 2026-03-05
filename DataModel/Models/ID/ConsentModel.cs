using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.ID
{
    public class ConsentModel
    {
        public string DummyID { get; set; }
        public Guid ID { get; set; }
        public bool IsConsent1 { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
