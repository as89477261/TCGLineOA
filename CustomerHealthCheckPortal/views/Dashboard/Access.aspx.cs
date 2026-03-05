using System;
using System.Linq;
using System.Web.UI;
using BLL.Controller;
using BLL.Controller.Dashboard;

namespace CustomerHealthCheck.views.Dashboard
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

                var bufferEvent = DashbordEventCon.Instance.GetDashboardEvent();
                var bufferEventMonthly = DashbordEventCon.Instance.GetDashboardEventMonthly();

                var bufferUIDMapRegister =
                    DashbordUIDMapRegisterCon.Instance.GetDashboardUIDMapRegister("HealthCheck", "PGS10");
                var bufferStatusGroup =
                    DashboardRegisterInfoStatusPGS10Con.Instance.GetDashboardRegisterInfoStatusPGS10();


                if (bufferStatusGroup.RESULT_STATUS == "OK" && bufferStatusGroup.RESULT_OBJ != null)
                {
                    var bufferHtml = "";
                    for (var i = 0; i < bufferStatusGroup.RESULT_OBJ.Count; i++)
                    {
                        var html = " <a href=\"#\" class=\"d-flex pb-3\">" +
                                   "<div class=\"align-self-center\">" +
                                   //"<span class=\"icon rounded-s me-2 gradient-blue shadow-bg shadow-bg-xs\"><i class=\"bi "+ ReturnIcon(bufferStatusGroup.RESULT_OBJ[i].LevelId.ToString()) + " font-18 color-white\"></i></span>" +
                                   "<span class=\"icon rounded-s me-2 gradient" +
                                   ReturnColor(bufferStatusGroup.RESULT_OBJ[i].EndLevel.ToString()) +
                                   " shadow-bg shadow-bg-xs\"><i class=\"bi " +
                                   ReturnIcon(bufferStatusGroup.RESULT_OBJ[i].LevelId.ToString()) +
                                   " font-18 color-white\"></i></span>" +
                                   "</div>" +
                                   "<div class=\"align-self-center ps-1\">" +
                                   "<h5 class=\"pt-1 mb-n1 font-12 opacity-90\">" +
                                   bufferStatusGroup.RESULT_OBJ[i].StatusHistory + "</h5>" +
                                   //"<p class=\"mb-0 font-11 opacity-50\">จำนวนคนลงทะเบียน</p>" +
                                   "</div>" +
                                   "<div class=\"align-self-center ms-auto text-end\">" +
                                   "<h4 class=\"pt-1 mb-n1 color" +
                                   ReturnColor(bufferStatusGroup.RESULT_OBJ[i].EndLevel.ToString()) +
                                   "-dark font-12 opacity-90\">" +
                                   bufferStatusGroup.RESULT_OBJ[i].Qty + "</h4>" +
                                   "</div>" +
                                   "</a>";

                        bufferHtml += html;
                    }

                    ltlGroupStatus.Text = bufferHtml;
                }

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

                if (bufferEventMonthly.RESULT_STATUS == "OK" && bufferEventMonthly.RESULT_OBJ != null)
                {
                    var sumData = 0;
                    var monthData = string.Empty;
                    var monthLabel = string.Empty;

                    sumData = bufferEventMonthly.RESULT_OBJ[0].total;
                    monthData = bufferEventMonthly.RESULT_OBJ[0].total.ToString();
                    monthLabel = bufferEventMonthly.RESULT_OBJ[0].groupMonth.ToString();
                    for (var i = 1; i < bufferEventMonthly.RESULT_OBJ.Count; i++)
                    {
                        sumData += bufferEventMonthly.RESULT_OBJ[i].total;
                        monthData += "," + bufferEventMonthly.RESULT_OBJ[i].total;
                        monthLabel += "," + bufferEventMonthly.RESULT_OBJ[i].groupMonth;
                    }

                    hddEventCount.Value = monthData;
                    hddEventLabel.Value = monthLabel;
                    lblEventRegister.Text = sumData.ToString();
                }

                if (bufferEventMonthly.RESULT_STATUS == "OK" && bufferEventMonthly.RESULT_OBJ != null)
                {
                }

                if (bufferUIDMapRegister.RESULT_STATUS == "OK" && bufferUIDMapRegister.RESULT_OBJ != null)
                {
                    var sumData = 0;
                    var monthData = string.Empty;
                    var monthLabel = string.Empty;

                    sumData = bufferUIDMapRegister.RESULT_OBJ[0].total;
                    monthData = bufferUIDMapRegister.RESULT_OBJ[0].total.ToString();
                    monthLabel = bufferUIDMapRegister.RESULT_OBJ[0].groupMonth.ToString();

                    for (var i = 1; i < bufferUIDMapRegister.RESULT_OBJ.Count; i++)
                    {
                        sumData += bufferUIDMapRegister.RESULT_OBJ[i].total;
                        monthData += "," + bufferUIDMapRegister.RESULT_OBJ[i].total;
                        monthLabel += "," + bufferUIDMapRegister.RESULT_OBJ[i].groupMonth;
                    }

                    hddRegisterPGS10Count.Value = monthData;
                    hddRegisterPGS10Label.Value = monthLabel;
                    lblEventRegisterPGS10.Text = sumData.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string ReturnIcon(string icontype)
        {
            switch (icontype)
            {
                case "0":
                    return "bi-0-circle";
                case "1":
                    return "bi-1-circle";
                case "2":
                    return "bi-2-circle";
                case "3":
                    return "bi-3-circle";
                case "4":
                    return "bi-4-circle";
                case "5":
                    return "bi-5-circle";
                case "6":
                    return "bi-6-circle";
                case "7":
                    return "bi-7-circle";
                case "8":
                    return "bi-8-circle";
                default:
                    return " ";
            }
        }

        private string ReturnColor(string color)
        {
            switch (color)
            {
                case "0":
                    return "-green";
                case "1":
                    return "-red";
                case "3":
                    return "-blue";
                default:
                    return "-gray";
            }
        }
    }
}