using System;
using System.Web.UI;
using CustomerHealthCheck.ServiceInterface;

namespace CustomerHealthCheck.views.Bill
{
    public partial class Receipt : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var lgNo = Request["lgNo"];
            var receiptTypeId = Convert.ToInt32(Request["receiptTypeId"]);
            var numberPay = Request["numberPay"];
            var data = MyBill.GetReceiptFile(lgNo, receiptTypeId, numberPay);

            if (data.Length > 1000)
            {
                Response.ContentType = "application/pdf";
                Response.OutputStream.Write(data, 0, data.Length);
                Response.Flush();
                Response.Close();
            }
        }
    }
}