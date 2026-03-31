using BLL.Controller;
using DataModel.Models.Line;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealTimeReportApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitialForm();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InitialForm()
        {
            txtQueryDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GetInformation();
        }

        private void GetInformation()
        {

            var startDate = ConfigurationManager.AppSettings["StartDate"];
            var currentDate = DateTime.Parse(txtQueryDate.Text).AddYears(-543).ToString("MM/dd/yyyy");



            DailyReportModel obj = new DailyReportModel();
            var dataSet1 = LineDailyReportRepo.Instance.GetSummaryUIDReport("", "");
            Thread.Sleep(1000);
            var dataSet2 = LineDailyReportRepo.Instance.GetLastYearSummaryUIDReport(startDate, currentDate);

            Thread.Sleep(1000);
            var dataSet3 = LineDailyReportRepo.Instance.GetSummaryUIDHaveLGReport("", "");
            Thread.Sleep(1000);
            var dataSet4 = LineDailyReportRepo.Instance.GetLastYearSummaryUIDHaveLGReport(startDate, currentDate);

            Thread.Sleep(1000);
            var dataSet5 = LineDailyReportRepo.Instance.GetSummaryUIDHaveDeptReport("", "");
            Thread.Sleep(1000);
            var dataSet6 = LineDailyReportRepo.Instance.GetLastYearSummaryUIDHaveDeptReport(startDate, currentDate);

            Thread.Sleep(1000);
            var dataSet9 = LineDailyReportRepo.Instance.GetSummaryUIDKYCReport("", "");
            Thread.Sleep(1000);
            var dataSet10 = LineDailyReportRepo.Instance.GetLastYearSummaryUIDKYCReport(startDate, currentDate);

            Thread.Sleep(1000);
            var dataSet11 = LineDailyReportRepo.Instance.GetSummaryUID5ColorReport("", "");
            Thread.Sleep(1000);
            var dataSet12 = LineDailyReportRepo.Instance.GetLastYearSummaryUID5ColorReport(startDate, currentDate);


            txtAllUID.Text = dataSet1.RESULT_OBJ.StringToMoneyFormat(true);
            txtAnnualyUID.Text = dataSet2.RESULT_OBJ.StringToMoneyFormat(true);

            txtAllUID_LG.Text = dataSet3.RESULT_OBJ.StringToMoneyFormat(true);
            txtAnnualyUID_LG.Text = dataSet4.RESULT_OBJ.StringToMoneyFormat(true);

            txtAllUID_DCS.Text = dataSet5.RESULT_OBJ.StringToMoneyFormat(true);
            txtAnnualyUID_DCS.Text = dataSet6.RESULT_OBJ.StringToMoneyFormat(true);

            txtAllUID_KYC.Text = dataSet9.RESULT_OBJ.StringToMoneyFormat(true);
            txtAnnualyUID_KYC.Text = dataSet10.RESULT_OBJ.StringToMoneyFormat(true);

            txtAllUID_Regis5Color.Text = dataSet11.RESULT_OBJ.StringToMoneyFormat(true);
            txtAnnualyUID_Regis5Color.Text = dataSet12.RESULT_OBJ.StringToMoneyFormat(true);


        }

    }
}
