using CoreUtility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using OPEN_API_BL.Controller;
//using OPEN_API_MODEL.Model.OIC_Parking;

namespace OIC_PAK_INT.Pages.Config
{
    public class ContactModel : PageModel
    {
        //public List<ORA_ParkingContactModel> bufferContact { get; set; }
        //public void OnGet()
        //{
        //    GetData();
        //}
        //private void GetData()
        //{
        //    var buffer = ORA_ParkingContactBL.Instance.GetAllContactWithStatus("1");
        //    if (buffer.RESULT_CODE == "200")
        //    {
        //        bufferContact = buffer.RESULT_OBJ;
        //        SessionManager.Set<List<ORA_ParkingContactModel>>(HttpContext.Session, "lstContext", bufferContact);
        //    }

        //}
        //public IActionResult OnGetContactByID(string id)
        //{
        //    var lstContact = SessionManager.Get<List<ORA_ParkingContactModel>>(HttpContext.Session, "lstContext");
        //    if (lstContact != null)
        //    {
        //        var buffer = lstContact.FirstOrDefault(x => x.ID == decimal.Parse(id));
        //        if (buffer != null)
        //        {
        //            return new JsonResult(buffer);
        //        }
        //    }
        //    return NotFound();
        //}
        //public IActionResult OnPostUpdateByID([FromBody]ORA_ParkingContactModel obj)
        //{
        //    var buffer = ORA_ParkingContactBL.Instance.UpdateContact(obj);
        //    if (buffer.RESULT_OBJ == "SUCCESS")
        //    {
        //        return Content("OK");
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
            
        //}
        //public IActionResult OnPostInsert([FromBody] ORA_ParkingContactModel obj)
        //{
        //    var buffer = ORA_ParkingContactBL.Instance.InsertContact(obj);
        //    if (buffer.RESULT_OBJ == "SUCCESS")
        //    {
        //        return Content("OK");
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }

        //}
        //public IActionResult OnGetDeleteByID( string id)
        //{
        //    var buffer = ORA_ParkingContactBL.Instance.DeleteContact(id);
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
