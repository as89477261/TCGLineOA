using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CC_CustomerPortal.Pages.Dashboard
{
    public class IndividualCarMobileModel : PageModel
    {
        //public DashboardObject p1 { get; set; } = new DashboardObject();
        //public List<ORA_ParkingDashboardPeakModel> p2 { get; set; } = new List<ORA_ParkingDashboardPeakModel>();
        //[BindProperty]
        //public string startDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        //[BindProperty]
        //public string endDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        //public void OnGet()
        //{
        //    GetDataP1();
        //}
        //public void OnPostSearch()
        //{
        //    GetDataP1();
        //}
        //private void GetDataP1()
        //{

        //    var bufferP1 = ORA_ParkingDashboardPeakBL.Instance.GetPeakDashboardSummary(startDate, endDate);
        //    var bufferP2 = ORA_ParkingDashboardPeakBL.Instance.GetPeakDashboardDaily(startDate, endDate);

        //    if (bufferP1.RESULT_STATUS == "OK" && bufferP1.RESULT_OBJ.Count > 0)
        //    {
        //        p1.Value1 = bufferP1.RESULT_OBJ[0].COUNT_TOTAL.ToString(); // ค่าValue เอามาต่อกัน
        //        p1.Value2 = bufferP1.RESULT_OBJ[0].HOUR.ToString() + ".00";
        //        for (int i = 1; i < bufferP1.RESULT_OBJ.Count; i++)
        //        {
        //            p1.Value1 += ("," + bufferP1.RESULT_OBJ[i].COUNT_TOTAL.ToString()); // ค่าValue เอามาต่อกัน
        //            p1.Value2 += ("," + bufferP1.RESULT_OBJ[i].HOUR.ToString() + ".00");
        //        }
        //    }

        //    if (bufferP2.RESULT_STATUS == "OK" && bufferP2.RESULT_OBJ.Count > 0)
        //    {
        //        p2 = bufferP2.RESULT_OBJ;
        //    }


        //}

    }
}
