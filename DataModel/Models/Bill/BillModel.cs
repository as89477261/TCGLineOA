using System;
using Newtonsoft.Json;

namespace DataModel.Models.Bill
{
    public class BillModel
    {
        [JsonProperty("lG_No")] public string LgNo { get; set; }

        [JsonProperty("date_Pay")] public DateTime DatePay { get; set; }

        [JsonProperty("receipt_PayDate")] public string ReceiptPayDate { get; set; }

        [JsonProperty("recieveFromChannal_1")] public string RecieveFromChannal { get; set; }

        [JsonProperty("receipt_Payfor")] public string ReceiptPayFor { get; set; }

        [JsonProperty("receipt_NumberPay")] public string ReceiptNumberPay { get; set; }

        [JsonProperty("receipt_Type")] public string ReceiptType { get; set; }

        [JsonProperty("receiptTypeId")] public int ReceiptTypeId { get; set; }
        [JsonProperty("fee_Amount")] public double FeeAmount { get; set; }
        [JsonProperty("fee_AmountGov")] public double FeeAmountGOV { get; set; }
        [JsonProperty("fee_AmountSME")] public double FeeAmountSME { get; set; }
    }
}