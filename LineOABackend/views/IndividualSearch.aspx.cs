using BLL.Controller;
using BLL.Controller.RP;
using DataModel.Models.CustomerHealthModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LineOABackend.views
{
    public partial class IndividualSearch : System.Web.UI.Page
    {
        public List<RegisterInfoModel> ListResultData
        {
            get { return (List<RegisterInfoModel>)HttpContext.Current.Application["ListResultStatus"]; }
            set { HttpContext.Current.Application["ListResultStatus"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ListResultData = RegisterInfoCon.Instance.GetRegisInfoStatusByIDCardWithType(txtIDCard.Text, "HealthCheck", "PGS11").RESULT_OBJ;
            BindingGrid();
        }

        private void BindingGrid()
        {
            grdData.DataSource = ListResultData;
            grdData.DataBind();
        }
    }
}