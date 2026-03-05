using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReportApp.Data;
using System.Threading.Tasks;

namespace ReportApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string reportType)
        {

            var reportData = await _context.GetReportDataAsync(reportType);

            var reportConfig = await _context.GetReportAppConfigAsync();

            ViewBag.ReportConfigList = reportConfig;
            View(ViewBag.ReportConfigList);

            ViewBag.ReportType = reportType;
            var reportName = reportConfig.Where(o => (o.ReportType?.Trim() ?? "") == reportType.Trim()).ToList();
            ViewBag.ReportConfigTitleName = reportName[0].ReportName ?? "";
            View(ViewBag.ReportConfigTitleName);

            var json = JsonConvert.SerializeObject(reportData);

            var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

            return View(data);

        }

    }
}
