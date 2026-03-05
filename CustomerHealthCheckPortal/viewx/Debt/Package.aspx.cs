using System;
using BLL.Controller.FACenter;

namespace CustomerHealthCheck.viewx.Debt
{
    public partial class Package : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindingPackage();
        }

        private void BindingPackage()
        {
            var uid = BASE_UID;
            var result = UIDMapFATransactionCon.Instance.GetUIDMapTransAndFormByID(uid);
            //if (result.RESULT_CODE == "200" && result.RESULT_OBJ.Count > 0)
            //{
            //    pnlChoosedNotShowChoice.Visible = true;
            //    pnlChoosePackage.Visible = false;

            //    var data = result.RESULT_OBJ.OrderByDescending(x => x.CreateDate).FirstOrDefault();
            //    switch (data.Dept_Recon_ObjectId)
            //    {
            //        case 1:
            //            divPackage1.Visible = true;
            //            break;
            //        case 2:
            //            divPackage2.Visible = true;
            //            break;
            //        case 3:
            //            divPackage3.Visible = true;
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //else
            //{
            //    /pnlChoosedNotShowChoice.Visible = false;
            //    pnlChoosePackage.Visible = true;
            //}
        }
    }
}