using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerHealthController
{
    public partial class TestModel : Page
    {
        private readonly RegisterController registerController = new RegisterController();
        private readonly RegisterDB service = new RegisterDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                bindProvince();
                bindIndustry();
            }
        }

        protected void btnCalCorporate_Click(object sender, EventArgs e)
        {
            var corp = new Corporate();

            if (radioLoanAmount.Checked)
                txtResult.Text = corp.scoreLoanAmount(Convert.ToDouble(txtLoanAmount.Text)).ToString();
            if (radioYearIncorporate.Checked)
                txtResult.Text = corp.scoreYearIncorporate(Convert.ToInt32(txtYearIncorporate.Text)).ToString();
            if (radioBizProvince.Checked)
            {
                var bucketProvince = service.GetBucketProvince(ddBizProvince.SelectedValue, PersonType.Corporate);
                txtResult.Text = corp.scoreBizProvince(bucketProvince).ToString();
            }

            if (radioEstablishmentStatus.Checked)
                txtResult.Text =
                    corp.scoreEstablishmentStatus(
                        (EstablishmentType)Convert.ToInt32(ddEstablishmentStatus.SelectedIndex)).ToString();
            if (radioDebtToIncome.Checked)
                txtResult.Text =
                    corp.scoreDebtToIncome(Convert.ToDouble(txtDebt.Text), Convert.ToDouble(txtIncome.Text)).ToString();
            if (radioManagementAge.Checked)
                txtResult.Text = corp.scoreManagementAge(Convert.ToInt32(txtManagementAge.Text)).ToString();
        }

        public void bindProvince()
        {
            try
            {
                ddBizProvince.DataSource = registerController.GetProvince();
                ddBizProvince.DataTextField = "Name";
                ddBizProvince.DataValueField = "ProvinceCode";
                ddBizProvince.DataBind();
                ddBizProvince.Items.Insert(0, new ListItem("กรุณาเลือกจังหวัด", "0"));

                ddProvince.DataSource = registerController.GetProvince();
                ddProvince.DataTextField = "Name";
                ddProvince.DataValueField = "ProvinceCode";
                ddProvince.DataBind();
                ddProvince.Items.Insert(0, new ListItem("กรุณาเลือกจังหวัด", "0"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void bindIndustry()
        {
            try
            {
                ddBizType.DataSource = registerController.GetIndustryType();
                ddBizType.DataTextField = "Name";
                ddBizType.DataValueField = "IndustryGroup";
                ddBizType.DataBind();
                ddBizType.Items.Insert(0, new ListItem("กรุณาเลือกประเภทกิจการ", "0"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void btnCalPersonal_Click(object sender, EventArgs e)
        {
            var per = new Personal();

            if (radioProvince.Checked)
            {
                var bucketProvince = service.GetBucketProvince(ddProvince.SelectedValue, PersonType.Person);
                txtResultPersonal.Text = per.scoreProvince(bucketProvince).ToString();
            }

            if (radioBizType.Checked)
            {
                var bucketIndustry = service.GetBucketIndustry(ddBizType.SelectedValue, PersonType.Person);
                txtResultPersonal.Text = per.scoreBizType(bucketIndustry).ToString();
            }

            if (radioMaritalStatus.Checked)
                txtResultPersonal.Text =
                    per.scoreMaritalStatus((MaritalType)Convert.ToInt32(ddMaritalStatus.SelectedValue)).ToString();
            if (radioLoanAmountPersonal.Checked)
                txtResultPersonal.Text = per.scoreLoanAmount(Convert.ToDouble(txtLoanAmountPersonal.Text)).ToString();
            if (radioYearExperience.Checked)
                txtResultPersonal.Text = per.scoreYearExperience(Convert.ToInt32(txtYearExperience.Text)).ToString();
            if (radioManagementAgePersonal.Checked)
                txtResultPersonal.Text =
                    per.scoreManagementAge(Convert.ToInt32(txtManagementAgePersonal.Text)).ToString();
        }
    }
}