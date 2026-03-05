using System;

namespace DataModel.Models.SMEClinic
{
    public class IdentifiedProfileModel
    {
        public string ID { get; set; }
        public string UID { get; set; }
        public string BinaryImg1 { get; set; }
        public string BinaryImg2 { get; set; }
        public string BinaryImg3 { get; set; }
        public string Status { get; set; }
        public string IsOCR { get; set; }
        public string IsConfirmProfile { get; set; }
        public string IsConfirmOTP { get; set; }
        public string OTPSend { get; set; }
        public string OTPReceive { get; set; }
        public string PIDCard { get; set; }
        public string PFirstNameThai { get; set; }
        public string PFirstNameEng { get; set; }
        public string PLastNameThai { get; set; }
        public string PLastNameEng { get; set; }
        public string PFullNameThai { get; set; }
        public string PFullNameEng { get; set; }
        public string PBirthDate { get; set; }
        public string PRegion { get; set; }
        public string PAddress { get; set; }
        public string PStartDateThai { get; set; }
        public string PEndDateThai { get; set; }
        public string PStartDateEng { get; set; }
        public string PEndDateEng { get; set; }
        public string PRawData { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}