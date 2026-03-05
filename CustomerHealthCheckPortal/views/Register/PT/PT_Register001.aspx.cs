using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Controller;
using BLL.Controller.HealthCheck;

namespace CustomerHealthCheck.views.Register
{
    public partial class PT_Register001 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindingProvince();
                //BindingBank();
             
            }
        }

        //private void BindingProvince()
        //{
        //    var result = ProvinceCon.Instance.GetProvinceAll();
        //    ddlProvince.DataSource = result.RESULT_OBJ;
        //    ddlProvince.DataTextField = "Name";
        //    ddlProvince.DataValueField = "ProvinceCode";
        //    ddlProvince.DataBind();
        //}

        //private void BindingBank()
        //{
        //    var result =
        //        BankCon.Instance.GetAllBankByListID(
        //            "'02','06','25','04','69','22','11','67','71','14','98','34','35','24','73','30','66'");


        //    ddlHaveMainBankSelectBank.DataSource = result.RESULT_OBJ;
        //    ddlHaveMainBankSelectBank.DataTextField = "BankName";
        //    ddlHaveMainBankSelectBank.DataValueField = "Bankcode";
        //    ddlHaveMainBankSelectBank.DataBind();
        //}

       
    }
}