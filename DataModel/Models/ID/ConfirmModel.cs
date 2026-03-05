using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.ID
{
    public class ConfirmModel_BK
    {
        public Guid ID { get; set; }
        public string DummyID { get; set; }
        public string VerifyType { get; set; }
        public string VerifyValue { get; set; }
        public string RefNumber { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime SendRefDate { get; set; }
        public string VerifiedTimeStamp { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime KeyInDate { get; set; }
        public string KeyInValue { get; set; }
        public string CreatedBy { get; set; }

        public ConfirmModel_BK InitialPersonalVerification(string dummyID, string refNumber, string createdBy, bool isSuccess, string verifyValue, string tcgDBName)
        {
            return new ConfirmModel_BK
            {
                DummyID = dummyID,
                RefNumber = refNumber,
                CreatedBy = createdBy,
                VerifyType = "PERSONAL",
                VerifyValue = verifyValue,
                KeyInDate = DateTime.Now,
                KeyInValue = tcgDBName,
                IsSuccess = isSuccess,
                CreatedDate = DateTime.Now,
                SendRefDate = DateTime.Now
            };
        }
        public ConfirmModel_BK InitialOTPVerification(string dummyID, string refNumber, string createdBy, bool isSuccess, string verifyValue)
        {
            return new ConfirmModel_BK
            {
                DummyID = dummyID,
                RefNumber = refNumber,
                CreatedBy = createdBy,
                VerifyType = "OTP",
                VerifyValue = verifyValue,
                IsSuccess = isSuccess,
                CreatedDate = DateTime.Now,
                SendRefDate = DateTime.Now

            };
        }
        public ConfirmModel_BK InitialEmailVerification(string dummyID, string refNumber, string createdBy, bool isSuccess, string verifyValue)
        {
            return new ConfirmModel_BK
            {
                DummyID = dummyID,
                RefNumber = refNumber,
                CreatedBy = createdBy,
                VerifyType = "EMAIL",
                VerifyValue = verifyValue,
                IsSuccess = isSuccess,
                CreatedDate = DateTime.Now,
                SendRefDate = DateTime.Now
            };
        }



    }
}
