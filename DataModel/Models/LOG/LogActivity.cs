using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.LOG
{
    public class LogActivity
    {
        public string id { get; set; }
        public string UID { get; set; }
        public string ApplicationCode { get; set; }
        public string SubApplicationCode { get; set; }
        public string Remark { get; set; }
        public string ActivityCode { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public bool Status { get; set; }
    }
}
