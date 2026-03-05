using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.CustomerHealthModel.Reward
{
    public class RewardMapUIDModel
    {
        public int ID { get; set; }
        public string UID { get; set; }
        public bool Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime UseDate { get; set; }
        public bool IsUse { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public Guid RewardGUID { get; set; }
        public DateTime RewardStartDate { get; set; }
        public DateTime RewardEndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string OTP { get; set; }
        public string Token { get; set; }
        public string Mac { get; set; }
        public string IP { get; set; }
        public string OTPRef { get; set; }
        public bool OTPStatus { get; set; }

        public bool RewardStatus { get; set; }
        public string RewardCode { get; set; }
        public string RewardDesc { get; set; }
        public string RewardTitle { get; set; }
        public string RewardCriteria { get; set; }
        public string RewardOwner { get; set; }
        public string RewardOwnerCode { get; set; }
        public string RewardType { get; set; }
        public string RewardBranchOwner { get; set; }
        public bool IsRewardActive { get; set; }
        public string EventCode { get; set; }
        public string RewardProgram { get; set; }
        public string RewardProgramCode { get; set; }
        public string RewardValue { get; set; }
        public string RewardRemark { get; set; }
        public int RewardSeq { get; set; }
        public string RewardQRPath { get; set; }
        public string RewardLogoPath { get; set; }
        public string MatchCondition { get; set; }
    }
}
