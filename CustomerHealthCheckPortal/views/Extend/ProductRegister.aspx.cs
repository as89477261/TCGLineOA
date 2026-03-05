using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Controller;

namespace CustomerHealthCheck.views.Extend
{
    public partial class ProductRegister : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) InitialPage();
        }

        private void InitialPage()
        {
            var cusID = GetQueryString("cid");
            GetRegisteredProduct(cusID);
            GetCustomerProfile(cusID);
        }

        private string GetQueryString(string param)
        {
            var data = Request.QueryString[param];
            return data;
        }

        private void GetCustomerProfile(string cusID)
        {
            var buffer = CustomerProfileCon.Instance.GetCustomerProfileByCID(cusID);
            if (buffer.RESULT_STATUS == "OK" && buffer.RESULT_OBJ.Count > 0)
            {
                var obj = buffer.RESULT_OBJ.FirstOrDefault();
                ltlFullName.Text = obj.Name + " " + obj.SureName;
            }
        }

        private void GetRegisteredProduct(string cusID)
        {
            var result = CustomerProfileMapApprochCon.Instance.GetCustomerProfileMapApproch(cusID);
            if (result.RESULT_STATUS == "OK")
            {
                grdRegistedProduct.DataSource = result.RESULT_OBJ;
                grdRegistedProduct.DataBind();
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var name = grdRegistedProduct.SelectedRow.Cells[1].Text;
            var description = (grdRegistedProduct.SelectedRow.FindControl("lblDescription") as Label).Text;

            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[1]
            {
                new DataColumn("Description", typeof(string))
            });
            dt.Rows.Add(description);

            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();
        }
    }
}