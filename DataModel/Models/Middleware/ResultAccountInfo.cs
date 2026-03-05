using System;

namespace DataModel.Models.Middleware
{
    public class ResultAccountInfo : ResultInfo
    {
        public AccountAPIInfo data { get; set; }
    }

    public class AccountAPIInfo
    {
        public string AccountId { get; set; }
        public string TokenAPIID { get; set; }
        public DateTime ExpireDate { get; set; }
        public string TokenId { get; set; }
    }
}