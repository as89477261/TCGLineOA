using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DataModel.Models.CustomerHealthModel;

namespace CustomerHealthCheck.UserControl.Attention
{
    public partial class UC_AttentionRequest : System.Web.UI.UserControl
    {
        public string FullName { get; set; }
        public string BusinessType { get; set; }
        public string RegisterDate { get; set; }
        public List<RegisterInfoModel> ListRegisterInfoStep { get; set; }
        public string IsExpand { get; set; }
        public int CountTime { get; set; }
        public string CreateDate { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string BranchEmail { get; set; }
        public string BranchPhone { get; set; }
        public string ContactBranch { get; set; }
        public string SubInfoType { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindingInformationForm();
        }

        private void BindingInformationForm()
        {
            var htmlTag = new StringBuilder();
            if (ListRegisterInfoStep != null && ListRegisterInfoStep.Count > 0 &&
                ListRegisterInfoStep[0].StatusName != null)
            {
                var item = ListRegisterInfoStep.OrderBy(x => x.StatusLevelID).ToList();
                for (var i = 0; i < item.Count; i++)
                {
                    htmlTag.Append(
                        $"<li class=\"{(item[i].StatusEndLevel ? "complete" : "active")}\" data-target=\"#step{i}\" style=\"background-color:white !important;\">");
                    htmlTag.Append($"<a href=\"#tab{i}\" data-toggle=\"tab\" class=\"active\" aria-expanded=\"true\">");
                    htmlTag.Append("<span class=\"round-tab\"></span>");
                    htmlTag.Append($"<span class=\"title\">{item[i].StatusName}</span></a></li>");
                }
            }
            else
            {
                htmlTag.Append(
                    "<li class=\"active\" data-target=\"#step1\" style=\"background-color:white !important;\">");
                htmlTag.Append("<a href=\"#tab1\" data-toggle=\"tab\" class=\"active\" aria-expanded=\"true\">");
                htmlTag.Append("<span class=\"round-tab\"></span>");
                htmlTag.Append("<span class=\"title\">บสย. รับเรื่อง</span></a></li>");
                ;
            }


            Header.Text = GenerateHeader(CountTime, IsExpand, CreateDate , SubInfoType);
            SubHeader.Text = GenerateSubHeader(CountTime, IsExpand, FullName, BusinessType, RegisterDate);
            Footer.Text = GenerateFooter(ContactBranch);
            ltlStep.Text = htmlTag.ToString();
        }

        private string GenerateHeader(int countTime, string isExpand, string timestamp , string subInfoType)
        {
            Console.WriteLine(subInfoType);

            var headerProject = string.Empty;

            if (subInfoType == "PROMKHUM")
            {
                headerProject = "โครงการ พร้อมค้ำพร้อมช่วย";
            }
            else if (subInfoType == "SMEsPickUp")
            {
                headerProject = "โครงการ SMEs-Pick Up";
            }
            else if(subInfoType == "SMEsStimulateCampaign")
            {
                headerProject = "โครงการ มาตรการ “กระตุ้นเศรษฐกิจ”";
            }
            
            else
            {
                headerProject = ConfigurationManager.AppSettings["ResultTitleHeader"]; // โครงการ PGS 11
            }

            var strHeader =
                "<a class=\"list-group-item\" runat=\"server\" id=\"divRegisterAttentionRequest\" data-bs-toggle=\"collapse\" " +
                $"href=\"#collapse-list-{countTime}\" aria-controls=\"collapse-list-1\" aria-expanded=\"{isExpand}\" style=\"padding:5px 10px;border-radius: 10px;\"   >" +
                "<i class=\"bi color-green-dark bi-clipboard-check-fill\" style=\"font-size:25px;\"></i> " +
                $"<div style=\"margin-left:12px;\"><strong>" + headerProject + $"</strong><span>(วันที่ {timestamp} น. )</span></div>" +
                "<i class=\"bi bi-chevron-down\"></i></a>";
            return strHeader;
        }

        //private string GenerateHeader(int countTime, string isExpand, string timestamp)
        //{
        //    var strHeader =
        //        "<a class=\"list-group-item\" runat=\"server\" id=\"divRegisterAttentionRequest\" data-bs-toggle=\"collapse\" " +
        //        $"href=\"#collapse-list-{countTime}\" aria-controls=\"collapse-list-1\" aria-expanded=\"{isExpand}\" style=\"padding:5px 10px;border-radius: 10px;\"   >" +
        //        "<i class=\"bi color-green-dark bi-clipboard-check-fill\" style=\"font-size:25px;\"></i> " +
        //        $"<div style=\"margin-left:12px;\"><strong>โครงการ PGS 10</strong><span>(วันที่ {timestamp} น. )</span></div>" +
        //        "<i class=\"bi bi-chevron-down\"></i></a>";
        //    return strHeader;
        //}

        private string GenerateSubHeader(int countTime, string isExpand, string fullName, string businessType,
            string registerDate)
        {
            var strSubHeader =
                $"<div id=\"collapse-list-{countTime}\" runat=\"server\"  class=\" collapse {(isExpand == "true" ? "show" : "")}\" style=\"padding:5px;\">" +
                "<div class=\"row mb-3 mt-4\"><h5 class=\"col-4 text-start font-15\">ชื่อผู้ติดต่อ</h5>" +
                "<h5 class=\"col-8 text-end font-14 opacity-60 font-400\">" +
                $"{fullName}</h5>" +
                "<h5 class=\"col-4 text-start font-15\">ประเภทธุรกิจ</h5>" +
                "<h5 class=\"col-8 text-end font-14 font-400\">" +
                $"{businessType}</h5>" +
                "<h5 class=\"col-4 text-start font-15\">วันที่ลงทะเบียน</h5>" +
                "<h5 class=\"col-8 text-end font-14 opacity-60 font-400\">" +
                $"{registerDate}</h5></Div>";


            return strSubHeader;
        }

        private string GenerateFooter(string ContactBranch)
        {
            var strFooter =
                $"<div class=\"mb-3\"><span class=\"col-12 text-start font-12\">{ContactBranch}</span></div>";
            return strFooter;
        }
    }
}