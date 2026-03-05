using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.Models.CustomerHealthModel.EventsModel;

namespace CustomerHealthCheck.UserControl
{
    public partial class UC_EventBanner : System.Web.UI.UserControl
    {
        public List<EventBannerModel> ListEventBanner { get; set; }
        public string CreateDate { get; set; }
        public int CountTime { get; set; }
        public string IsExpand { get; set; }

        public string UID { get; set; }

        public string Status { get; set; }

        public string Channel { get; set; }

        public string RefCode { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindingInformationForm();
        }

        private void BindingInformationForm()
        {
            var htmlTag = new StringBuilder();
            if (ListEventBanner != null && ListEventBanner.Count > 0 && ListEventBanner[0].Status != null)
            {
                var item = ListEventBanner.OrderBy(x => x.Status).ToList();
                for (var i = 0; i < item.Count; i++)
                {
                    htmlTag.Append(
                        $"<li class=\"{item[i].Status}\" data-target=\"#step{i}\" style=\"background-color:white !important;\">");
                    htmlTag.Append($"<a href=\"#tab{i}\" data-toggle=\"tab\" class=\"active\" aria-expanded=\"true\">");
                    htmlTag.Append("<span class=\"round-tab\"></span>");
                }
            }
            else
            {
                htmlTag.Append(
                    "<li class=\"active\" data-target=\"#step1\" style=\"background-color:white !important;\">");
                htmlTag.Append("<a href=\"#tab1\" data-toggle=\"tab\" class=\"active\" aria-expanded=\"true\">");
                htmlTag.Append("<span class=\"round-tab\"></span>");
                htmlTag.Append("<span class=\"title\">ลงทะเบียนสำเร็จ รอชำระเงินค่าสมาชิก</span>");
                //htmlTag.Append("<div class=\"content\" style=\"max-width:100%;vertical-align:middle\"> <img src=\"https://blog.loga.app/wp-content/uploads/2022/04/sample-promptpay-qr-code-blurred.jpg\" style=\"max-width:100%\" alt=\"alternatetext\"></div>"); 
                htmlTag.Append("</a></li>");
            }

            Header.Text = GenerateHeader(CountTime, IsExpand, CreateDate, Channel);
            SubHeader.Text = GenerateSubHeader(CountTime, IsExpand, RefCode, CreateDate);
            ltlStepEvent.Text = htmlTag.ToString();
        }

        private string GenerateHeader(int countTime, string isExpand, string CreateDate, string Channel)
        {
            var strHeader =
                "<a class=\"list-group-item\" runat=\"server\" id=\"divRegisterAttentionRequest\" data-bs-toggle=\"collapse\" " +
                $"href=\"#collapse-list-{countTime}\" aria-controls=\"collapse-list-1\" aria-expanded=\"{isExpand}\" style=\"padding:5px 10px;border-radius: 10px;\"   >" +
                "<i class=\"has-bg gradient-green shadow-bg shadow-bg-xs color-white rounded-xs bi bi-receipt-cutoff font-14\" style=\"font-size:25px;\"></i> " +
                $"<div style=\"margin-left:12px;\"><strong>{Channel}</strong><span>(วันที่ {CreateDate} น. )</span></div>" +
                "<i class=\"bi bi-chevron-down\"></i></a>";
            return strHeader;
        }


        private string GenerateSubHeader(int countTime, string isExpand, string RefCode, string CreateDate)
        {
            var strSubHeader =
                $"<div id=\"collapse-list-{countTime}\" runat=\"server\"  class=\" collapse {(isExpand == "true" ? "show" : "")}\" style=\"padding:5px;\">" +
                "<div class=\"row mb-3 mt-4\">" +
                "<h5 class=\"col-4 text-start font-15\">เลขที่ลงทะเบียน</h5>" +
                "<h5 class=\"col-8 text-end font-14 font-400\">" +
                $"{RefCode}</h5>" +
                "<h5 class=\"col-4 text-start font-15\">วันที่ลงทะเบียน</h5>" +
                "<h5 class=\"col-8 text-end font-14 opacity-60 font-400\">" +
                $"{CreateDate}</h5></Div>";

            return strSubHeader;
        }
    }
}