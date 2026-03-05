using BLL.Controller.ID;
using BLL.Controller.RP;
using DAL.Repos.ID;
using DataModel.Models.CustomerHealthModel.Enrollment;
using DataModel.Models.ID;
using OIC_UTILITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LineOABackend.views.Register
{
    public partial class index : System.Web.UI.Page
    {
        public List<EnrolmentPersonalModel> ListEnrolmentPersonal
        {
            get { return (List<EnrolmentPersonalModel>)HttpContext.Current.Application["ListEnrolment"]; }
            set { HttpContext.Current.Application["ListEnrolment"] = value; }
        }
        public string SortingAction { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SortingAction = "ASC";
                BindingRegisterPersonal();
            }
        }
        private void BindingRegisterPersonal(string sortingParam = "")
        {
            try
            {
                var bufferResult = EnrolmentCon.Instance.GetAllEnrollmentPersonal();
                switch (sortingParam)
                {
                    case "CreateDate":
                        if (SortingAction == "ASC")
                        {
                            bufferResult.RESULT_OBJ = bufferResult.RESULT_OBJ.OrderBy(x => x.CreatedDate).ToList();
                        }
                        else
                        {
                            bufferResult.RESULT_OBJ = bufferResult.RESULT_OBJ.OrderByDescending(x => x.CreatedDate).ToList();
                        }
                        break;
                    default:
                        break;
                }

                SortingAction = SortingAction == "ASC" ? "DESC" : "ASC";
                ListEnrolmentPersonal = bufferResult.RESULT_OBJ;
                BindingGrid();
            }
            catch (Exception ex)
            {

                LocalLogManager.Logger("Register Module Backend : PageLoad > " + ex.Message, "LineBackEnd");
            }
        }
        private void BindingGrid()
        {
            grdPersonalRegister.DataSource = ListEnrolmentPersonal;
            grdPersonalRegister.DataBind();
        }

        protected void grdPersonalRegister_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPersonalRegister.PageIndex = e.NewPageIndex;
            BindingGrid();
        }

        protected void grdPersonalRegister_Sorting(object sender, GridViewSortEventArgs e)
        {
            BindingRegisterPersonal(e.SortExpression);
        }

        protected void grdPersonalRegister_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string index = (string)e.CommandArgument;
            if (e.CommandName.Equals("detail"))
            {
                var verifyBuffer = VerifyCon.Instance.GetVerfyPersonal(index);
                if (verifyBuffer.RESULT_STATUS == "OK")
                {
                    grdVerifyPersonal.DataSource = verifyBuffer.RESULT_OBJ;
                    grdVerifyPersonal.DataBind();
                }

                var bufferData = ListEnrolmentPersonal.Where(x => x.DummyID == index).ToList();
                if (bufferData != null && bufferData.Count > 0)
                {
                    DetailsView1.DataSource = bufferData;
                    DetailsView1.DataBind();
                }


                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#detailModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock
                   (this, this.GetType(), "DetailModalScript", sb.ToString(), false);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtIdCardSearch.Text != "")
            {
                var bufferResult = ListEnrolmentPersonal.Where(x => (x.IdentityID ?? "").Contains(txtIdCardSearch.Text)).ToList();
                ListEnrolmentPersonal = bufferResult;
                BindingGrid();

            }
            else
            {
                BindingRegisterPersonal();
            }

        }
    }
}