using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using ClosedXML.Excel;
using BLL.Controller.HealthCheck;
using DataModel.Models.CustomerHealthModel.Reward;

namespace LineOABackend.views
{
    public partial class CouponManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCurrentData();
                Session["BufferCouponDT"] = null;
            }
        }

        private void GenerateCurrentData()
        {
            var lstCoupon = RewardCon.Instance.GetReward();
            var rewardDashboardBuffer = RewardCon.Instance.GetRewardDashboard();

            txtCountCurrentCoupon.Text = "คูปองทั้งหมด : " + lstCoupon.RESULT_OBJ.Count;

            Session["BufferCurrentCouponDT"] = lstCoupon.RESULT_OBJ;
            grdCurrentDataCoupon.DataSource = lstCoupon.RESULT_OBJ;
            grdCurrentDataCoupon.DataBind();


            grdDashboardReward.DataSource = rewardDashboardBuffer.RESULT_OBJ;
            grdDashboardReward.DataBind();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Open the Excel file using ClosedXML.
            using (XLWorkbook workBook = new XLWorkbook(FileUpload1.PostedFile.InputStream))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Create a new DataTable.
                DataTable dt = new DataTable();

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }
                }
                Session["BufferCouponDT"] = dt;

                grdImportData.DataSource = dt;
                grdImportData.DataBind();
            }
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var bufferCouponDT = (DataTable)Session["BufferCouponDT"];
            if (bufferCouponDT != null)
            {
                var result = RewardCon.Instance.InsertRewardList(bufferCouponDT);

                if (result.RESULT_STATUS == "OK")
                {
                    Session["BufferCouponDT"] = null;

                   
                    GenerateCurrentData();
                }
                else
                {
                    txtImportMessage.Text = result.RESULT_STATUS + "  " + result.RESULT_OBJ;
                }
            }
            else
            {
               
            }

            grdImportData.DataSource = null;
            grdImportData.DataBind();
            GenerateCurrentData();
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
         

            Session["BufferCouponDT"] = null;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var lstData = (List<RewardMapUIDModel>)Session["BufferCurrentCouponDT"];
            switch (rdoIsUse.SelectedValue)
            {
                case "0":
                    grdCurrentDataCoupon.DataSource = (List<RewardMapUIDModel>)Session["BufferCurrentCouponDT"];
                    grdCurrentDataCoupon.DataBind();
                    break;
                case "1":
                    grdCurrentDataCoupon.DataSource = lstData.Where(x => x.IsUse == true);
                    grdCurrentDataCoupon.DataBind();
                    break;
                case "2":
                    grdCurrentDataCoupon.DataSource = lstData.Where(x => x.IsUse == false);
                    grdCurrentDataCoupon.DataBind();
                    break;
                default:
                    break;
            }
        }
        protected void btnDrop_Click(object sender, EventArgs e)
        {

        }
    }
}