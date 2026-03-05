using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerHealthCheck.UserControl.MyLG
{
    public partial class UC_MyLG : System.Web.UI.UserControl
    {
        public string LGGuaranteePrice { get; set; }
        public string LGNumber { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsActive { get; set; }
        public string IDCard { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindingLG();
        }

        private void BindingLG()
        {
            ltlLGGuaranteePrice.Text = LGGuaranteePrice.StringToMoneyFormat(true); ;
            ltlLGNumber.Text = LGNumber;
            ltlLGStartDate.Text = StartDate;
            ltlLGEndDate.Text = EndDate;

        }
    }
}