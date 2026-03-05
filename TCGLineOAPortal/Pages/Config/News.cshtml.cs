using CoreUtility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using OPEN_API_BL.Controller;
//using OPEN_API_MODEL.Model.OIC_Parking;

namespace OIC_PAK_INT.Pages.Config
{
    public class NewsModel : PageModel
    {
     
        //public List<ORA_ParkingNewsModel> bufferNews { get; set; }
        //public void OnGet()
        //{
        //    GetData();
        //}
        //private void GetData()
        //{
        //    var buffer = ORA_ParkingNewsBL.Instance.GetAllNewsWithStatus("1");
        //    if (buffer.RESULT_CODE == "200")
        //    {
        //        bufferNews = buffer.RESULT_OBJ.OrderByDescending(x => x.SEQ).ToList();
        //        SessionManager.Set<List<ORA_ParkingNewsModel>>(HttpContext.Session, "lstNews", bufferNews);
        //    }

        //}
        //public IActionResult OnGetNewsByID(string id)
        //{
        //    var lstContact = SessionManager.Get<List<ORA_ParkingNewsModel>>(HttpContext.Session, "lstNews");
        //    if (lstContact != null)
        //    {
        //        var buffer = lstContact.FirstOrDefault(x => x.ID == decimal.Parse(id));
        //        if (buffer != null)
        //        {
        //            buffer.BODY = buffer.BODY.Replace("\\n",Environment.NewLine);
        //            return new JsonResult(buffer);
        //        }
        //    }
        //    return NotFound();
        //}
        //public IActionResult OnPostUpdateByID([FromBody] ORA_ParkingNewsModel obj)
        //{
        //    var buffer = ORA_ParkingNewsBL.Instance.UpdateNews(obj);
        //    if (buffer.RESULT_OBJ == "SUCCESS")
        //    {
        //        return Content("OK");
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }

        //}
        //public IActionResult OnPostInsert([FromBody] ORA_ParkingNewsModel obj)
        //{
        //    var buffer = ORA_ParkingNewsBL.Instance.InsertNews(obj);
        //    if (buffer.RESULT_OBJ == "SUCCESS")
        //    {
        //        return Content("OK");
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }

        //}
        //public IActionResult OnGetDeleteByID(string id)
        //{
        //    var buffer = ORA_ParkingNewsBL.Instance.DeleteNews(id);
        //    if (buffer.RESULT_OBJ == "SUCCESS")
        //    {
        //        return Content("OK");
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }

        //}
    }
}
