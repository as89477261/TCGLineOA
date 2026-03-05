using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using OPEN_API_BL.Controller;
//using OPEN_API_MODEL.Model.OIC_Parking;
using OPEN_API_MODELS.Model;

namespace CC_CustomerPortal.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        //public ORA_ParkingDashboardModel p1 { get; set; } = new ORA_ParkingDashboardModel();
        //public ORA_ParkingDashboardModel p2 { get; set; } = new ORA_ParkingDashboardModel();
        //public ORA_ParkingDashboardModel p3 { get; set; } = new ORA_ParkingDashboardModel();
        //public ORA_ParkingDashboardModel p4 { get; set; } = new ORA_ParkingDashboardModel();
        //public List<ORA_ParkingDashboardModel> p5 { get; set; } = new List<ORA_ParkingDashboardModel>();

        //public void OnGet()
        //{
        //    GetDataP1();
        //    GetDataP2();
        //    GetDataP3();
        //    GetDataP4();
        //    GetDataTop10();
        //}
        //public void OnPostLogin([FromBody] ORA_ParkingUser obj)
        //{

        //}

        //private void GetDataP1()
        //{
        //    var result = new ORA_ParkingDashboardModel();
        //    var bufferP1 = ORA_ParkingDashboardBL.Instance.GetINOUTToDayDashboard();
        //    if (bufferP1.RESULT_STATUS == "OK" && bufferP1.RESULT_OBJ.Count > 0)
        //    {
        //        result = bufferP1.RESULT_OBJ.FirstOrDefault();
        //    }

        //    p1 = result;
        //}
        //private void GetDataP2()
        //{
        //    var result = new ORA_ParkingDashboardModel();
        //    var bufferP2 = ORA_ParkingDashboardBL.Instance.GetIsEmptyToDayDashboard();
        //    if (bufferP2.RESULT_STATUS == "OK" && bufferP2.RESULT_OBJ.Count > 0)
        //    {
        //        result = bufferP2.RESULT_OBJ.FirstOrDefault();
        //    }

        //    p2 = result;
        //}
        //private void GetDataP3()
        //{
        //    var result = new ORA_ParkingDashboardModel();
        //    var bufferP3PA = ORA_ParkingDashboardBL.Instance.GetIsPeakAllToDayDashboard();
        //    var bufferP3PI = ORA_ParkingDashboardBL.Instance.GetIsPeakINToDayDashboard();
        //    var bufferP3PO = ORA_ParkingDashboardBL.Instance.GetIsPeakOUTToDayDashboard();

        //    if (bufferP3PA.RESULT_STATUS == "OK" && bufferP3PA.RESULT_OBJ.Count > 0)
        //    {
        //        result = bufferP3PA.RESULT_OBJ.OrderByDescending(x => x.COUNT_TOTAL).FirstOrDefault();
        //        p3.PEAK_ALL = result.CREATE_HOUR.ToString() + ".00";
        //    }
        //    if (bufferP3PI.RESULT_STATUS == "OK" && bufferP3PI.RESULT_OBJ.Count > 0)
        //    {
        //        result = bufferP3PI.RESULT_OBJ.OrderByDescending(x => x.COUNT_TOTAL).FirstOrDefault();
        //        p3.PEAK_IN = result.CREATE_HOUR.ToString() + ".00";
        //    }
        //    if (bufferP3PO.RESULT_STATUS == "OK" && bufferP3PO.RESULT_OBJ.Count > 0)
        //    {
        //        result = bufferP3PO.RESULT_OBJ.OrderByDescending(x => x.COUNT_TOTAL).FirstOrDefault();
        //        p3.PEAK_OUT = result.CREATE_HOUR.ToString() + ".00";
        //    }

        //}
        //private void GetDataP4()
        //{
        //    var result = new ORA_ParkingDashboardModel();
        //    var bufferP4IN = ORA_ParkingDashboardBL.Instance.GetOICINToDayDashboard();
        //    var bufferP4OUT = ORA_ParkingDashboardBL.Instance.GetOICOUTToDayDashboard();

        //    if (bufferP4IN.RESULT_STATUS == "OK" && bufferP4IN.RESULT_OBJ.Count > 0)
        //    {
        //        result = bufferP4IN.RESULT_OBJ.FirstOrDefault();
        //        p4.COUNT_IN = result.COUNT_IN;
        //    }
        //    if (bufferP4OUT.RESULT_STATUS == "OK" && bufferP4OUT.RESULT_OBJ.Count > 0)
        //    {
        //        result = bufferP4OUT.RESULT_OBJ.FirstOrDefault();
        //        p4.COUNT_OUT = result.COUNT_OUT;
        //    }
        //    p4.COUNT_TOTAL = p4.COUNT_OUT + p4.COUNT_IN;

        //}
        //private void GetDataTop10()
        //{
        //    var result = new List<ORA_ParkingDashboardModel>();
        //    var bufferP5 = ORA_ParkingDashboardBL.Instance.GetTop10Dashboard();
        //    if (bufferP5.RESULT_STATUS == "OK" && bufferP5.RESULT_OBJ.Count > 0)
        //    {
        //        p5 = bufferP5.RESULT_OBJ;
        //    }


        //}
    }
}
