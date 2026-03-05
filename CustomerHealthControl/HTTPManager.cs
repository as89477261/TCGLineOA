using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class HTTPManager
{
    public static string HttpGet(string URI)
    {
        var req = WebRequest.Create(URI);
        // req.Proxy = new System.Net.WebProxy(ProxyString, true); //true means no proxy
        var result = string.Empty;
        using (var response = (HttpWebResponse)req.GetResponse())
        {
            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            result = reader.ReadToEnd().Trim();
            reader.Close();
            dataStream.Close();
        }

        return result;
    }

    public static T HttpGet<T>(string URI)
    {
        var req = WebRequest.Create(URI);
        // req.Proxy = new System.Net.WebProxy(ProxyString, true); //true means no proxy
        var result = string.Empty;
        using (var response = (HttpWebResponse)req.GetResponse())
        {
            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            result = reader.ReadToEnd().Trim();
            reader.Close();
            dataStream.Close();
        }

        return JsonConvert.DeserializeObject<T>(result);
    }

    public static string HttpPost(string url, Dictionary<string, string> header, string responseTextJson)
    {
        try
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            foreach (var item in header) httpWebRequest.Headers.Add(item.Key, item.Value);
            //httpWebRequest.Headers.Add("Authorization", "Bearer " + lineAccessToken);
            //LocalLogManager.Logger("UTILITY : Add Header Success");
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(responseTextJson);
            }

            //LocalLogManager.Logger("UTILITY : Add Body Success");
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            //LocalLogManager.Logger("UTILITY : http result is " + httpResponse.StatusCode + " - " + httpResponse.ToString());
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                return result;
            }
        }
        catch (Exception ex)
        {
            return ex.GetBaseException().Message;
            //LocalLogManager.Logger("URILIRY : EXception is -" + ex.Message);
            //LocalLogManager.Logger("URILIRY : EXception is -" + ex.InnerException.Message);
            //LocalLogManager.Logger("URILIRY : EXception is -" + ex.InnerException.InnerException.Message); throw;
        }
    }

    public static string HttpPost(string URI, IDictionary<string, string> header, IDictionary<string, string> values)
    {
        using (var wc = new WebClient())
        {
            var data = new NameValueCollection();
            foreach (var item in values) wc.Headers[item.Key] = item.Value;

            foreach (var item in header) data[item.Key] = item.Value;

            var HtmlResult = wc.UploadValues(URI, "POST", data);
            var responseString = Encoding.UTF8.GetString(HtmlResult);
            return responseString;
        }
    }

    public static T HttpPost<T>(string URI, IDictionary<string, string> header, IDictionary<string, string> values)
    {
        using (var wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            var data = new NameValueCollection();
            foreach (var item in header) wc.Headers[item.Key] = item.Value;

            var bufferJson = GenJsonString(values);
            var dataByte = Encoding.Default.GetBytes(bufferJson);

            var HtmlResult = wc.UploadData(URI, "POST", dataByte);
            var responseString = Encoding.UTF8.GetString(HtmlResult);
            var result = JsonConvert.DeserializeObject<T>(responseString);
            return result;
        }
    }

    public static T HttpPostWithForm<T>(string URI, IDictionary<string, string> header, NameValueCollection values)
    {
        using (var wc = new WebClient())
        {
            var HtmlResult = new byte[0];
            try
            {
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var data = new NameValueCollection();
                foreach (var item in header) wc.Headers[item.Key] = item.Value;

                HtmlResult = wc.UploadValues(URI, "POST", values);
                var responseString = Encoding.UTF8.GetString(HtmlResult);
                var result = JsonConvert.DeserializeObject<T>(responseString);
                return result;
            }
            catch (Exception ex)
            {
                var responseString = Encoding.UTF8.GetString(HtmlResult);
                throw;
            }
        }
    }

    public static T HttpPost<T>(string URI, IDictionary<string, string> header, string values)
    {
        using (var wc = new WebClient())
        {
            foreach (var item in header) wc.Headers[item.Key] = item.Value;
            wc.Headers[HttpRequestHeader.ContentType] = "application/json;";
            var HtmlResult = wc.UploadString(URI, "POST", values);
            var result = JsonConvert.DeserializeObject<T>(HtmlResult);
            return result;
        }
    }

    public static string HttpPostWithForm2(string URI, IDictionary<string, string> header, string values)
    {
        var encoding = new ASCIIEncoding();

        var data = encoding.GetBytes(values);

        var myRequest =
            (HttpWebRequest)WebRequest.Create(URI);
        myRequest.ProtocolVersion = HttpVersion.Version11;
        myRequest.Method = "POST";
        myRequest.ContentType = "application/x-www-form-urlencoded";
        myRequest.ContentLength = data.Length;
        var newStream = myRequest.GetRequestStream();
        newStream.Write(data, 0, data.Length);
        newStream.Close();

        var response = myRequest.GetResponse();
        var responseStream = response.GetResponseStream();
        var responseReader = new StreamReader(responseStream);
        responseReader.Close();
        response.Close();

        return responseReader.ReadToEnd();
    }

    public static async Task<T> HttpPostWithForm3<T>(string URI, IDictionary<string, string> header,
        IDictionary<string, string> values)
    {
        var client = new HttpClient();


        var res = client.PostAsync(URI, new FormUrlEncodedContent(values));

        var content = await res.Result.Content.ReadAsStringAsync();

        //string responseString = Encoding.UTF8.GetString(content);
        var result = JsonConvert.DeserializeObject<T>(content);
        return result;
    }

    public static string GenJsonString(IDictionary<string, string> values)
    {
        var result = "{";
        var i = 0;
        foreach (var item in values)
        {
            var buffer = "\"" + item.Key + "\":\"" + item.Value + "\"";
            i += 1;
            if (i < values.Count) buffer += ",";

            result += buffer;
        }

        result += "}";
        return result;
    }
}