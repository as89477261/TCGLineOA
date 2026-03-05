using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using DataModel.Models.Line;
using Utiltiy;

namespace CustomerHealthCheck
{
    public class BasePage : Page
    {
        private static byte[] keyAndIvBytes;

        public BasePage()
        {
            keyAndIvBytes = Encoding.UTF8.GetBytes("password");
        }

        public LineRawTokenModel BASE_LineProfile
        {
            get
            {
                var obj = new LineRawTokenModel
                {
                    sub = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode")),
                    picture = CookieManager.GetEncryptCookie("lineoa", "pic", GetAppsetting("APIPartialCode"))
                };
                return obj;
            }
        }

        public string BASE_UID
        {
            get
            {
                var uid = "";
                uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (string.IsNullOrEmpty(uid)) uid = SessionHelper.UID;

                return uid;
            }
        }


        public static string ByteArrayToHexString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }

        public static string DecodeAndDecrypt(string cipherText)
        {
            var DecodeAndDecrypt = AesDecrypt(StringToByteArray(cipherText));
            return DecodeAndDecrypt;
        }

        public static string EncryptAndEncode(string plaintext)
        {
            return ByteArrayToHexString(AesEncrypt(plaintext));
        }

        public static string AesDecrypt(byte[] inputBytes)
        {
            var outputBytes = inputBytes;

            var plaintext = string.Empty;

            using (var memoryStream = new MemoryStream(outputBytes))
            {
                using (var cryptoStream = new CryptoStream(memoryStream,
                           GetCryptoAlgorithm().CreateDecryptor(keyAndIvBytes, keyAndIvBytes), CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(cryptoStream))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }

        public static byte[] AesEncrypt(string inputText)
        {
            var inputBytes = Encoding.UTF8.GetBytes(inputText); //AbHLlc5uLone0D1q

            byte[] result = null;
            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream,
                           GetCryptoAlgorithm().CreateEncryptor(keyAndIvBytes, keyAndIvBytes), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    cryptoStream.FlushFinalBlock();

                    result = memoryStream.ToArray();
                }
            }

            return result;
        }

        private static RijndaelManaged GetCryptoAlgorithm()
        {
            var algorithm = new RijndaelManaged();
            //set the mode, padding and block size
            algorithm.Padding = PaddingMode.PKCS7;
            algorithm.Mode = CipherMode.CBC;
            algorithm.KeySize = 128;
            algorithm.BlockSize = 128;
            return algorithm;
        }

        //protected override void OnInit(EventArgs e)
        //{
        //    if (HttpContext.Current.Session != null)
        //    {

        //        if (new SessionManager(SessionEnum.LogOn).DoesKeyExist() == false)
        //        {
        //            //Server.Transfer(Server.MapPath("~/login.aspx"));
        //            Response.Redirect("~/index.aspx", true);
        //        }


        //    }
        //}


        protected string GetAppsetting(string configName)
        {
            return ConfigurationManager.AppSettings[configName];
        }

        protected void Alert(string title, string message)
        {
            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "JSScript" + Guid.NewGuid(),
                JavaScriptManager.GenerateDialog(title, message),
                true);
        }

        protected void AlertWithStatus(string title, string message, string status)
        {
            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "JSScript" + Guid.NewGuid(),
                JavaScriptManager.GenerateDialogWithStatus(title, message, status),
                true);
        }

        protected void AlertSuccess(string title, string message)
        {
            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "JSScript" + Guid.NewGuid(),
                JavaScriptManager.GenerateSuccessDialog(title, message),
                true);
        }

        protected void AlertSuccessNotDownBackdrop(string title, string message)
        {
            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "JSScript" + Guid.NewGuid(),
                JavaScriptManager.GenerateSuccessDialogNotDownBackdrop(title, message),
                true);
        }

        protected void ShowModal(string controlID)
        {
            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "JSScript" + Guid.NewGuid(),
                JavaScriptManager.GenerateShowModal(controlID),
                true);
        }

        protected void HideModal(string controlID)
        {
            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "JSScript" + Guid.NewGuid(),
                JavaScriptManager.GenerateHideModal(controlID),
                true);
        }

        protected void RunJs(string command)
        {
            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "JSScript" + Guid.NewGuid(),
                command,
                true);
        }

        protected void RedirectToOriginLineURL()
        {
            if (GetAppsetting("IsRedirectToLineURLOrigin") == "1")
            {
                var bufferURL = GetOriginLineURL();
                Response.Redirect(bufferURL);
            }
            else
            {
                if (GetAppsetting("IsAllowEmptyCookie") == "1")
                {
                    // allow Using
                }
                else
                {
                    Response.Redirect("~/views/Error/General.aspx");
                }
            }
        }

        protected string GetOriginLineURL()
        {
            var url = GetAppsetting(
                "TokenURLLineLiff"); // + "&" + GetAppSetting("TokenURLP2") + "&" + GetAppSetting("TokenURLP3");
            return url;
        }
    }

    public static class DropDownListManager
    {
        //public static DropDownList BindingDSG(this DropDownList control)
        //{
        //    try
        //    {
        //        var buffer = OrganizeController.Instance.GetDSG();

        //        if (buffer != null)
        //            buffer = buffer.OrderBy(o => o.DESCRIPTION).ToList();

        //        control.DataSource = buffer;
        //        control.DataTextField = "DESCRIPTION";
        //        control.DataValueField = "SECTION_CODE";
        //        control.DataBind();

        //        return control;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public static DropDownList BindingASG(this DropDownList control)
        //{
        //    try
        //    {
        //        var buffer = "";// OrganizeController.Instance.GetASG("");

        //        if (buffer != null)
        //            buffer = buffer.OrderBy(o => o.DESCRIPTION).ToList();

        //        control.DataSource = buffer;
        //        control.DataTextField = "DESCRIPTION";
        //        control.DataValueField = "SECTION_CODE";
        //        control.DataBind();

        //        return control;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public static DropDownList BindingDepartment(this DropDownList control)
        //{
        //    try
        //    {
        //        var buffer = OrganizeController.Instance.GetDepartment("");

        //        if (buffer != null)
        //            buffer = buffer.OrderBy(o => o.DESCRIPTION).ToList();

        //        control.DataSource = buffer;
        //        control.DataTextField = "DESCRIPTION";
        //        control.DataValueField = "SECTION_CODE";
        //        control.DataBind();

        //        return control;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public static DropDownList BindingDivision(this DropDownList control)
        //{
        //    try
        //    {
        //        var buffer = OrganizeController.Instance.GetDivision("");

        //        if (buffer != null)
        //            buffer = buffer.OrderBy(o => o.DESCRIPTION).ToList();

        //        control.DataSource = buffer;
        //        control.DataTextField = "DESCRIPTION";
        //        control.DataValueField = "SECTION_CODE";
        //        control.DataBind();

        //        return control;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public static DropDownList BindingYear(this DropDownList control, int yearRang)
        //{
        //    try
        //    {
        //        var lstYear = new int[yearRang];

        //        for (int i = 0; i < lstYear.Count(); i++)
        //        {
        //            lstYear[i] = (DateTime.Now.Year - i) + 543;
        //        }

        //        control.DataSource = lstYear;
        //        control.DataBind();

        //        return control;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}