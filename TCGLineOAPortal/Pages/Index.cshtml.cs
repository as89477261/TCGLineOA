using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using OPEN_API_BL.Controller;
//using OPEN_API_MODEL.Model.OIC_Parking;
using OPEN_API_MODELS.Model;
using System.Text;

namespace CC_CustomerPortal.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        //public void OnGet()
        //{
        //    var a = DecodeFrom64("PyXPG4DkksgOa7/0NP2rlg==");
        //}



        //public IActionResult OnPostLogin([FromBody] ORA_ParkingAccountModel obj)
        //{
        //    var buffer = ORA_ParkingAccountBL.Instance.GetAccountByUsernameAndPass(obj.USERNAME, obj.PASSWORD);
        //    if (buffer.RESULT_STATUS == "OK" && buffer.RESULT_OBJ.Count > 0)
        //    {
        //        return Content("OK");
        //    }
        //    return NotFound();
        //}
        //public static string EncodePasswordToBase64(string password)
        //{
        //    try
        //    {
        //        byte[] encData_byte = new byte[password.Length];
        //        encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
        //        string encodedData = Convert.ToBase64String(encData_byte);
        //        return encodedData;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error in base64Encode" + ex.Message);
        //    }
        //}
        ////this function Convert to Decord your Password
        //public string DecodeFrom64(string encodedData)
        //{
        //    string decryptpwd = string.Empty;
        //    UTF8Encoding encodepwd = new UTF8Encoding();
        //    Decoder Decode = encodepwd.GetDecoder();
        //    byte[] todecode_byte = Convert.FromBase64String(encodedData);
        //    int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        //    char[] decoded_char = new char[charCount];
        //    Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        //    decryptpwd = new String(decoded_char);
        //    return decryptpwd;
        //}
       
    }
}