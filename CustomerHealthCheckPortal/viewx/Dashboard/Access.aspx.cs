using System;
using System.Linq;
using System.Web.UI;
using BLL.Controller;

namespace CustomerHealthCheck.viewx.Dashboard
{
    public partial class Access : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindingData();
        }

        private void BindingData()
        {
            try
            {
                var bufferFARegisterMonthly = DashboardFARegisterCon.Instance.GetDashboardFARegisterMonthly();
                var bufferFARegisterSummary = DashboardFARegisterCon.Instance.GetDashboardFARegisterSummary();

                var bufferUIDSummary = DashboardUIDCon.Instance.GetDashboardUID();
                var bufferUIDMonthly = DashboardUIDCon.Instance.GetDashboardUIDMonthly();


                var bufferResult = DashboardCon.Instance.GetDashboardPersonalType();
                var bufferResultMonthly = DashboardCon.Instance.GetDashboardPersonalMonthly();

                if (bufferResult.RESULT_STATUS == "OK" && bufferResult.RESULT_OBJ != null)
                {
                    var bufferPersonalData = bufferResult.RESULT_OBJ.personalType + "," +
                                             bufferResult.RESULT_OBJ.juristicType + "," +
                                             bufferResult.RESULT_OBJ.notRegister;
                    hddSummaryPersonalType.Value = bufferPersonalData;
                    ltlPersonalValue.Text = bufferResult.RESULT_OBJ.personalType.ToString();
                    ltlJuristicValue.Text = bufferResult.RESULT_OBJ.juristicType.ToString();
                    ltlSummaryCount.Text = bufferResult.RESULT_OBJ.total.ToString();
                    ltlNotRegister.Text = bufferResult.RESULT_OBJ.notRegister.ToString();

                    //var bufferRegisterData = bufferResult.RESULT_OBJ.personalCount.ToString() + "," + bufferResult.RESULT_OBJ.juristicCount.ToString() + "," + bufferResult.RESULT_OBJ.notRegisterCount.ToString();
                    //hddSummaryRegisterType.Value = bufferRegisterData;
                    //ltlPersonalCount.Text = bufferResult.RESULT_OBJ.personalCount.ToString();
                    //ltlCompanyCount.Text = bufferResult.RESULT_OBJ.juristicCount.ToString();
                    //ltlTotalRegisterCount.Text = bufferResult.RESULT_OBJ.notRegisterCount.ToString();
                    //ltlRegisterCount.Text = (bufferResult.RESULT_OBJ.personalCount + bufferResult.RESULT_OBJ.juristicCount + bufferResult.RESULT_OBJ.notRegisterCount).ToString();
                }

                if (bufferResultMonthly.RESULT_STATUS == "OK" && bufferResultMonthly.RESULT_OBJ != null)
                {
                    var sumData = 0;
                    var monthData = string.Empty;
                    var monthLabel = string.Empty;

                    sumData = bufferResultMonthly.RESULT_OBJ[0].countNumber;
                    monthData = bufferResultMonthly.RESULT_OBJ[0].countNumber.ToString();
                    monthLabel = bufferResultMonthly.RESULT_OBJ[0].month.ToString();
                    for (var i = 1; i < bufferResultMonthly.RESULT_OBJ.Count; i++)
                    {
                        sumData += bufferResultMonthly.RESULT_OBJ[i].countNumber;
                        monthData += "," + bufferResultMonthly.RESULT_OBJ[i].countNumber;
                        monthLabel += "," + bufferResultMonthly.RESULT_OBJ[i].month;
                    }

                    hddMonthlyHCRegisterCount.Value = monthData;
                    hddMonthlyHCRegisterLabel.Value = monthLabel;
                    //lblHCRegister.Text = sumData.ToString();
                }

                if (bufferUIDSummary.RESULT_STATUS == "OK" && bufferUIDSummary.RESULT_OBJ != null)
                {
                    var bufferPersonal = bufferUIDSummary.RESULT_OBJ.FirstOrDefault(x => x.IdCardType == 1);
                    var bufferJuristic = bufferUIDSummary.RESULT_OBJ.FirstOrDefault(x => x.IdCardType == 2);
                    var bufferNotRegister = bufferUIDSummary.RESULT_OBJ.FirstOrDefault(x => x.IdCardType == null);


                    var personalCount = bufferPersonal != null ? bufferPersonal.countNumber : 0;
                    var juristicCount = bufferJuristic != null ? bufferJuristic.countNumber : 0;
                    var notRegisterCount = bufferNotRegister != null ? bufferNotRegister.countNumber : 0;

                    var bufferRegisterData = personalCount + "," + juristicCount + "," + notRegisterCount;
                    hddSummaryRegisterType.Value = bufferRegisterData;
                    ltlPersonalCount.Text = personalCount.ToString();
                    ltlCompanyCount.Text = juristicCount.ToString();
                    ltlTotalNotRegisterCount.Text = notRegisterCount.ToString();
                    ltlRegisterCount.Text = (personalCount + juristicCount + notRegisterCount).ToString();
                }

                if (bufferUIDMonthly.RESULT_STATUS == "OK" && bufferUIDMonthly.RESULT_OBJ != null)
                {
                    var sumData = 0;
                    var monthData = string.Empty;
                    var monthLabel = string.Empty;

                    sumData = bufferUIDMonthly.RESULT_OBJ[0].countNumber;
                    monthData = bufferUIDMonthly.RESULT_OBJ[0].countNumber.ToString();
                    monthLabel = bufferUIDMonthly.RESULT_OBJ[0].month.ToString();
                    for (var i = 1; i < bufferUIDMonthly.RESULT_OBJ.Count; i++)
                    {
                        sumData += bufferUIDMonthly.RESULT_OBJ[i].countNumber;
                        monthData += "," + bufferUIDMonthly.RESULT_OBJ[i].countNumber;
                        monthLabel += "," + bufferUIDMonthly.RESULT_OBJ[i].month;
                    }

                    hddUIDMonthly.Value = monthData;
                    hddUIDLabel.Value = monthLabel;
                    //lblHCRegister.Text = sumData.ToString();
                }

                if (bufferFARegisterMonthly.RESULT_STATUS == "OK" && bufferFARegisterMonthly.RESULT_OBJ != null)
                {
                    var sumData = 0;
                    var monthData = string.Empty;
                    var monthLabel = string.Empty;

                    sumData = bufferFARegisterMonthly.RESULT_OBJ[0].countNumber;
                    monthData = bufferFARegisterMonthly.RESULT_OBJ[0].countNumber.ToString();
                    monthLabel = bufferFARegisterMonthly.RESULT_OBJ[0].CreateMonth.ToString();
                    for (var i = 1; i < bufferFARegisterMonthly.RESULT_OBJ.Count; i++)
                    {
                        sumData += bufferFARegisterMonthly.RESULT_OBJ[i].countNumber;
                        monthData += "," + bufferFARegisterMonthly.RESULT_OBJ[i].countNumber;
                        monthLabel += "," + bufferFARegisterMonthly.RESULT_OBJ[i].CreateMonth;
                    }

                    hddMonthlyFARegisterCount.Value = monthData;
                    hddMonthlyFARegisterLabel.Value = monthLabel;
                    lblFARegister.Text = sumData.ToString();
                }

                if (bufferFARegisterSummary.RESULT_STATUS == "OK" && bufferFARegisterSummary.RESULT_OBJ != null)
                {
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}