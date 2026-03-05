using System;

namespace DataModel.Models.CustomerHealthModel
{
    public class UIDMapEnrollmentModel
    {
        public Guid ID { get; set; }
        public string UID { get; set; }
        public string RegisterID { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}