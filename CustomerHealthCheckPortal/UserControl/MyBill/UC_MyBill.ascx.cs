using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;
using DataModel.Models.Bill;

namespace CustomerHealthCheck.UserControl.MyBill
{
    public partial class UC_MyBill : System.Web.UI.UserControl
    {
        public int Index { get; set; }

        public int IndexPlus => Index + 1;

        public string LgNo { get; set; }

        public IEnumerable<BillModel> Bills { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                L_LgNo.Text = LgNo;

                RepeaterMyBillGroup.DataSource = Bills;
                RepeaterMyBillGroup.DataBind();
                RepeaterMyBillHistory.DataSource = Bills;
                RepeaterMyBillHistory.DataBind();
            }
        }

        protected void RepeaterMyBillGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                if (e.Item.DataItem is BillModel item &&
                    e.Item.FindControl("L_ReceiptNumberPay") is Literal L_ReceiptNumberPay1 &&
                    e.Item.FindControl("L_PayFor") is Literal L_PayFor &&
                    e.Item.FindControl("L_DatePay") is Literal L_DatePay)
                {
                    L_ReceiptNumberPay1.Text = item.ReceiptNumberPay;
                    L_PayFor.Text = item.ReceiptType;
                    L_DatePay.Text = item.DatePay.ToString("dd/MM/yyyy");
                }
        }

        protected void RepeaterMyBillHistory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                if (e.Item.DataItem is BillModel item &&
                    e.Item.FindControl("L_ReceiptPayDate") is Literal L_ReceiptPayDate &&
                    e.Item.FindControl("L_RecieveFromChannal") is Literal L_RecieveFromChannal &&
                    e.Item.FindControl("L_ReceivePayFor") is Literal L_ReceivePayFor &&
                    e.Item.FindControl("L_ReceiptNumberPay1") is Literal L_ReceiptNumberPay1 &&
                    e.Item.FindControl("L_ReceiptNumberPay2") is Literal L_ReceiptNumberPay2 &&
                    e.Item.FindControl("L_ReceiptType") is Literal L_ReceiptType &&                
                    e.Item.FindControl("L_FeeAmountSME") is Literal L_FeeAmountSME
                    )//&&
                     //e.Item.FindControl("B_Download") is HyperLink B_Download)
                {
                    L_ReceiptPayDate.Text = item.ReceiptPayDate;
                    L_RecieveFromChannal.Text = item.RecieveFromChannal;
                    L_ReceivePayFor.Text = item.ReceiptPayFor;
                    //L_ReceiptNumberPay1.Text = L_ReceiptNumberPay2.Text = item.ReceiptNumberPay;
                    L_ReceiptNumberPay2.Text = item.ReceiptNumberPay;
                    L_ReceiptNumberPay1.Text = item.LgNo;
                    L_ReceiptType.Text = item.ReceiptType;                
                    L_FeeAmountSME.Text = string.Format(new CultureInfo("th-TH"), "{0:C}", item.FeeAmountSME); 

                    //B_Download.NavigateUrl =
                    //    $"/Views/Bill/Receipt.aspx?lgNo={item.LgNo}&receiptTypeId={item.ReceiptTypeId}&numberPay={item.ReceiptNumberPay}";
                }
        }
    }
}