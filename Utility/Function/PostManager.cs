using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web.UI;

// ASP.NET [C#] REDIRECT WITH POST DATA
public static class WebExtensions
{
    public static void RedirectAndPOST(Page page, string destinationUrl,
        NameValueCollection data)
    {
        //Prepare the Posting form
        //string strForm = PreparePOSTForm(destinationUrl, data);
        //Add a literal control the specified page holding 
        //the Post Form, this is to submit the Posting form with the request.
        //page.Controls.Add(new LiteralControl(strForm));


        using (var wb = new WebClient())
        {
            var response = wb.UploadValues(destinationUrl, "POST", data);
            var responseInString = Encoding.UTF8.GetString(response);
        }
    }

    private static string PreparePOSTForm(string url, NameValueCollection data)
    {
        //Set a name for the form
        var formID = "PostForm";
        //Build the form using the specified data to be posted.
        var strForm = new StringBuilder();
        strForm.Append("<form id=\"" + formID + "\" name=\"" +
                       formID + "\" action=\"" + url +
                       "\" method=\"POST\">");

        foreach (string key in data)
            strForm.Append("<input type=\"hidden\" name=\"" + key +
                           "\" value=\"" + data[key] + "\">");

        strForm.Append("</form>");
        //Build the JavaScript which will do the Posting operation.
        var strScript = new StringBuilder();
        strScript.Append("<script language='javascript'>");
        strScript.Append("var v" + formID + " = document." +
                         formID + ";");
        strScript.Append("v" + formID + ".submit();");
        strScript.Append("</script>");
        //Return the form and the script concatenated.
        //(The order is important, Form then JavaScript)
        return strForm + strScript.ToString();
    }
}