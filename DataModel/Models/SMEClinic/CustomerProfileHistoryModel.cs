using System;
using System.ComponentModel.DataAnnotations;
using DataModel.Models.NDID.EForm;
using Newtonsoft.Json;

namespace DataModel.Models.SMEClinic
{
    public class CustomerProfileHistoryModel
    {
        [Required] [AlphaFormatValidateField] public long Code { get; set; }

        [Required] [AlphaFormatValidateField] public int IdCardType { get; set; }

        [Required] [AlphaFormatValidateField] public string IdCard { get; set; }

        [Required] [AlphaFormatValidateField] public string TitleName { get; set; }

        [Required] [AlphaFormatValidateField] public string TitleCode { get; set; }

        [Required] [AlphaFormatValidateField] public string Name { get; set; }

        [Required] [AlphaFormatValidateField] public string SureName { get; set; }

        [AlphaFormatValidateField] public string CompanyName { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime CreateDateTime { get; set; }

        [AlphaFormatValidateField] public bool IsActive { get; set; }

        [AlphaFormatValidateField] public string ID { get; set; }

        [AlphaFormatValidateField] public string CreateBy { get; set; }

        [AlphaFormatValidateField] public string Uid { get; set; }

        [AlphaFormatValidateField] public string lineName { get; set; }

        [AlphaFormatValidateField] public string Picture { get; set; }

        [AlphaFormatValidateField] public string Uid_Channel { get; set; }

        [AlphaFormatValidateField("email")] public string Email { get; set; }

        [AlphaFormatValidateField("email")] public string EmailAddress { get; set; }

        [AlphaFormatValidateField("phone")] public string MobileNumber { get; set; }

        [AlphaFormatValidateField] public string TransactionID { get; set; }

        [AlphaFormatValidateField] public bool IsSuccess { get; set; }

        [AlphaFormatValidateField] public string CurrentStatusCode { get; set; }

        [AlphaFormatValidateField] public string CurrentStatusRemark { get; set; }

        public string RawData { get; set; }
        public EFormCallbackMasterResponseModel RawDataObject { get; set; }

        [AlphaFormatValidateField] public string NDID_IDCard { get; set; }

        [AlphaFormatValidateField] public string EmailHistory { get; set; }

        [AlphaFormatValidateField] public string MobileNumberHistory { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime CreateDateTime_AD { get; set; }

        public void ConvertRawDataToObject()
        {
            if (RawData != "") RawDataObject = JsonConvert.DeserializeObject<EFormCallbackMasterResponseModel>(RawData);
        }
    }
}