using System;

namespace CustomerHealthCheck.UserControl.MyLg
{
    public partial class UC_MyLgItem : System.Web.UI.UserControl
    {
        public int Index { get; set; }
        public string CustomerName { get; set; }
        public string BankName { get; set; }
        public string IsHaveCustomerJoin { get; set; }
        public string ProjectTypeName { get; set; }
        public string SubProjectTypeName { get; set; }
        public string LgNumber { get; set; }
        public decimal Outstanding { get; set; }
        public DateTime LgEndDate { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Item.Attributes["class"] = Index == 0 ? "carousel-item active" : "carousel-item";
                //TabHeader.Attributes["href"] = $"Tab{Index = + 1}";
                //TabHeader.Attributes["aria-controls"] = $"Tab{Index + 1}";
                L_CustomerName.Text = CustomerName;
                L_BankName.Text = BankName;
                L_ProjectTypeName1.Text = L_ProjectTypeName2.Text = ProjectTypeName;
                L_SubProjectTypeName.Text = SubProjectTypeName == "" ? "-" : SubProjectTypeName;
                L_LgNumber1.Text = L_LgNumber2.Text = LgNumber;
                L_IsHaveCustomerJoin.Text = IsHaveCustomerJoin == "ไม่มี" ? "-" : IsHaveCustomerJoin;
                //L_Outstanding1.Text = L_Outstanding2.Text = Outstanding + " บาท";
                L_Outstanding2.Text = Outstanding + " บาท";
                L_LgEndDate.Text = LgEndDate.ToString("dd/MM/yyyy");
            }
        }
    }
}