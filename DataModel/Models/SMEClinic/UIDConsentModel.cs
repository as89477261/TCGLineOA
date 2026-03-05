using System;

namespace DataModel.Models.SMEClinic
{
    public class UIDConsentModel
    {
        public string Uid { get; set; }
        public string Consent1 { get; set; }
        public string Consent2 { get; set; }
        public string Consent3 { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string IsActive { get; set; }
        public int CustomerProfile_Code { get; set; }
        //PDPA
        public string IsPdpa { get; set; }
        public DateTime PdpaCreateDate { get; set; }
    }
}