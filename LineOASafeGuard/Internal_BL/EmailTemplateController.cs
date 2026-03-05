using BLL.Controller;
using DataModel.Models.Line;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace LineOASafeGuard.Internal_BL
{
    public class EmailTemplateController : BaseClass
    {
        private EmailTemplateController()
        { }
        public static EmailTemplateController Instance { get; } = new EmailTemplateController();

        private DailyReportModel GetDataReport()
        {
            var startDate = ConfigurationManager.AppSettings["StartDate"];
            var yearList = ConfigurationManager.AppSettings["YearList"];
            var YearListForActiveUserHaveLGNotInCurrentlyYear = ConfigurationManager.AppSettings["YearListForActiveUserHaveLGNotInCurrentlyYear"];
            var thresholdUID = ConfigurationManager.AppSettings["ThresholdUID"];
            var fixStartDate = ConfigurationManager.AppSettings["FixStartDate"];
            var LineFallenStartDate = ConfigurationManager.AppSettings["LineFallenStartDate"];
            var LineFallenEndDate = ConfigurationManager.AppSettings["LineFallenEndDate"];

            DailyReportModel obj = new DailyReportModel();
            var dataSet1 = LineDailyReportRepo.Instance.GetSummaryUIDReport("", "");
            Thread.Sleep(500);
            var dataSet2 = LineDailyReportRepo.Instance.GetLastYearSummaryUIDReport(startDate, "");
            Thread.Sleep(500);
            var dataSet3 = LineDailyReportRepo.Instance.GetSummaryUIDHaveLGReport("", "");
            Thread.Sleep(500);
            var dataSet4 = LineDailyReportRepo.Instance.GetLastYearSummaryUIDHaveLGReport(startDate, "");
            Thread.Sleep(500);
            var dataSet5 = LineDailyReportRepo.Instance.GetSummaryUIDHaveDeptReport("", "");
            Thread.Sleep(500);
            var dataSet6 = LineDailyReportRepo.Instance.GetLastYearSummaryUIDHaveDeptReport(startDate, "");
            Thread.Sleep(500);
            var dataSet7 = LineDailyReportRepo.Instance.GetKPICurrentlyUIDHaveLGinPercentage(yearList );
            var dataset7_1 = LineDailyReportRepo.Instance.GetKPICurrentlyUIDHaveLGPlusinPercentage(YearListForActiveUserHaveLGNotInCurrentlyYear);
            Thread.Sleep(500);
            var dataSet8 = LineDailyReportRepo.Instance.GetKPICuurentlyUIDHaveActiveUserinPercentage(startDate, "");
            var dataset8_1 = LineDailyReportRepo.Instance.GetKPICuurentlyUIDHaveActiveUserinPercentageForLinehasFallen(LineFallenStartDate, LineFallenEndDate);
            Thread.Sleep(500);
            var dataSet9 = LineDailyReportRepo.Instance.GetSummaryUIDKYCReport(startDate, "");
            Thread.Sleep(500);
            var dataSet10 = LineDailyReportRepo.Instance.GetLastYearSummaryUIDKYCReport(startDate, "");
            Thread.Sleep(500);
            var dataSet11 = LineDailyReportRepo.Instance.GetLastYearSummaryUIDKYCReport(fixStartDate, "");

           
            obj.UIDSummary = dataSet1.RESULT_OBJ.StringToMoneyFormat(false);
            obj.UIDLastYearSummary = dataSet2.RESULT_OBJ.StringToMoneyFormat(false);
            obj.UIDHaveLGSummary = dataSet3.RESULT_OBJ.StringToMoneyFormat(false);
            obj.UIDHaveLGLastYearSummary = dataSet4.RESULT_OBJ.StringToMoneyFormat(false);
            obj.UIDHaveDeptSummary = dataSet5.RESULT_OBJ.StringToMoneyFormat(false);
            obj.UIDHaveDeptLastYearSummary = dataSet6.RESULT_OBJ.StringToMoneyFormat(false);
            obj.KPICurrentlyUIDHaveLGinPercentage = dataSet7.RESULT_OBJ != null ? Math.Round(((decimal.Parse(dataSet7.RESULT_OBJ) + decimal.Parse(dataset7_1.RESULT_OBJ)) / decimal.Parse(thresholdUID))*100,2).StringToMoneyFormat(false) : "";
            obj.KPICuurentlyUIDHaveActiveUserinPercentage = dataSet8.RESULT_OBJ != null ? Math.Round(((decimal.Parse(dataSet8.RESULT_OBJ) + decimal.Parse(dataset8_1.RESULT_OBJ)) / decimal.Parse(thresholdUID)) * 100,2).StringToMoneyFormat(false) : "";
            obj.UIDKYCSummary = dataSet9.RESULT_OBJ.StringToMoneyFormat(false);
            obj.UIDKYCLastYearSummary = dataSet10.RESULT_OBJ.StringToMoneyFormat(false);
            obj.UIDKYCFixDateSummary = dataSet11.RESULT_OBJ.StringToMoneyFormat(false);
            return obj;
        }
        public string CretaeEmailTemplate()
        {
            var result = GetDataReport();

            var bodyBuilder = new StringBuilder();
            bodyBuilder.AppendLine("<html>");
            bodyBuilder.AppendLine("<body>");
            
            bodyBuilder.AppendLine($"<h2>รายงาน Line OA TCGFirst ประจำวันที่ "+ DateTime.Now.ToString("dd/MM/yyyy", new CultureInfo("th-TH")) + "</h2>");
            
            bodyBuilder.AppendLine($"<p>จำนวนเพื่อนมี UID สะสม <strong> ทั้งหมด " + result.UIDSummary + " ราย </strong> ( ปี 2568 = " + result.UIDLastYearSummary + " ราย )</p>");
            bodyBuilder.AppendLine($"<p>จำนวนเพื่อนมี LG สะสม <strong> ทั้งหมด " + result.UIDHaveLGSummary + " ราย </strong>  ( ปี 2568 = " + result.UIDHaveLGLastYearSummary + " ราย ) </p>");
            bodyBuilder.AppendLine($"<p>จำนวนเพื่อนที่เป็นหนี้ สะสม <strong> ทั้งหมด " + result.UIDHaveDeptSummary + " ราย </strong>  ( ปี 2568 = " + result.UIDHaveDeptLastYearSummary + " ราย ) </p>");
            bodyBuilder.AppendLine($"<p>จำนวนเพื่อนที่ยืนยันตัวตนกับบสย. สะสม <strong> ทั้งหมด " + result.UIDKYCSummary + " ราย </strong>  ( ปี 2568 = " + result.UIDKYCLastYearSummary + " ราย ) ** 15/10/2568 เป็นต้นไป = "+ result.UIDKYCFixDateSummary + " ราย </p>");
            bodyBuilder.AppendLine("-------------------------------------------------------------");
            bodyBuilder.AppendLine($"<p>สัดส่วนลูกค้าที่ได้รับการค้ำประกัน และสินเชื่อทางดิจิทัล <strong>" + result.KPICurrentlyUIDHaveLGinPercentage + " / 5% </strong>  </p>");
            bodyBuilder.AppendLine($"<p>ลูกค้าที่มีการใช้บริการอย่างน้อย 1 บริการผ่านช่องทางดิจิทัล <strong>" + result.KPICuurentlyUIDHaveActiveUserinPercentage + " / 37% </strong>  </p>");

            bodyBuilder.AppendLine("</body>");
            bodyBuilder.AppendLine("</html>");




            return bodyBuilder.ToString();
        }
    }
}
