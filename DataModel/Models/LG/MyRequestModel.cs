namespace DataModel.Models.LG
{
    public class MyRequestModel
    {
        public string onlineId { get; set; }
        public string customerName { get; set; }
        public string customerJoinName { get; set; }
        public string customerType { get; set; }
        public string projectTypeName { get; set; }
        public string projectTypeCode { get; set; }
        public string bankCode { get; set; }
        public string bankName { get; set; }
        public double requestAmount { get; set; }
        public string requestDate { get; set; }
        public string loanTypeName { get; set; }

        public string idCard { get; set; }

        public int dateLimit { get; set; }
    }
}